using System;

namespace AtliKarinca
{
    class Program
    {
        static void Main(string[] args)
        {
            //atlı karıncaya K kadar kişi binebiliyor
            //     bir günde R kere çalışıyor
            //binmek isteyen N kadar grup var

            //her kişi 1TL bilet - gün sonunda gelir ne kadar olur hesapla

            Console.Write("Günde kaç tur, kaç kişilik, grup sayısı: ");    //örnek: 5 7 6
            string inputFrst = Console.ReadLine();
            var data = inputFrst.Split(' ');
            //split fonksiyonu, string class'ında bulunan bir fonksiyon. tek satırda alınan bir stringin içerisindeki ifadeleri belirlenen ifadeye göre bölmeye yarıyor. örneğin burada veriler tek bir space ile ayrılmış. bu yüzden split fonksiyonunun parametresini de tek bir space char'ı olarak belirliyoruz. aynen şu şekilde: ' '
            //şayet değerler virgül ve space ile ayrılsaydı split'in parametresi ", " olacaktı.
            //bunun sonrasında da istediğimiz değeri index numarasına göre alabiliyoruz:
            int lap = int.Parse(data[0]);       //int.Parse metodu, elimizdeki stringden bir int değeri geri almamızı sağlıyor. double okuyacak olsak double.Parse() kullanırdık
            int capacity = int.Parse(data[1]);
            int group = int.Parse(data[2]);

            Console.Write("Gruplardaki kişi sayısı: ");                     //örnek: 4 11 2 3 4 2
            string inputScnd = Console.ReadLine();

            int income = CalculateDailyIncome(inputScnd, lap, capacity, group);
            Console.WriteLine($"Gün sonu kazancı: {income}TL");
        }

        static string MoveGroupToEnd(string input, int group)   //bu fonksiyon, stringdeki ifadeyi split ile ayırıp ilk verinin sona atılmasını sağlıyor.
        {
            var person = input.Split(' ');
            string groupChanged = "";       //verileri input string'den okuyup gereken sırayla bu string'e yazacağız.

            for (int i = 0; i < group; i++) //bu for'un amacı, "0 1 2 3 4 5" olan ifadeyi, yeni bir stringe "1 2 3 4 5 0" olarak kaydetmek.
            {
                if (i + 1 != group)   //son veriye gelene kadar baştan son veriye kadar her veriye i+1 indexini ata. yani: "1 2 3 4 5"
                {
                    groupChanged += $"{person[i + 1]} ";
                }
                else           //son veriye geldiğimizde ise ilk indexteki ifadeyi en sona ekle. yani: "1 2 3 4 5 0"
                {
                    groupChanged += person[0];
                }
            }
            return groupChanged;
        }

        static int CalculateDailyIncome(string input, int lap, int capacity, int group)
        {
            int income = 0;
            for (int i = 0; i < lap; i++)
            {
                int next = 0;
                bool isOverflowing = false;     //kapasite doldu mu dolmadı mı kontrol
                bool isFirstTime = true;        //bir grup indikten sonraki ilk biniş mi kontrol. bu kontrol sayesinde kapasiteyi aşan gruplardan kapasite kadar kişi atlı karıncaya binebiliyor. eğer bu kontrol olmazsa kapasiteyi aşan kalabalık gruplar hiçbir şekilde atlı karıncaya binemez.
                var persPerGrp = input.Split(' ');

                int onRide = 0;                 //binen kişi sayısı her turdan sonra sıfırlanacak. bu yüzden bu satırın for'un içerisinde kalması lazım.
                while (!isOverflowing)
                {
                    int personCheck = int.Parse(persPerGrp[next]);
                    if (isFirstTime && personCheck > capacity)
                    {
                        onRide = capacity;
                        input = MoveGroupToEnd(input, group);
                        isOverflowing = true;
                    }
                    else if ((onRide + personCheck) <= capacity)
                    {
                        onRide += personCheck;
                        input = MoveGroupToEnd(input, group);
                        isFirstTime = false;
                    }
                    else
                    {
                        isOverflowing = true;
                    }
                    next++;
                }
                income += onRide;   //binen herkes 1tl bilet alacağı için her tur sonunda direkt olarak income değişkenini income + onRide'a eşitleyebiliriz.
            }
            return income;
        }
    }
}
