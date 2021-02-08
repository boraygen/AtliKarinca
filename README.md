# AtliKarinca
Bir lunaparktaki atlı karıncanın çalışması ve elde ettiği gelir ile alakalı bir console app. İki input alınıyor: ilk satırda "günde kaç tur çalışacak, kapasite, kaç grup binecek" değerleri, ikinci satırda ise "binecek gruplar kaç kişi olacak".


Her turda, sıradaki ilk gruptan başlayarak atlı karıncaya biniliyor. Eğer bir grubun tamamı için yer kalmadıysa, daha fazla kişi binmeden tur başlıyor. Yani atlı karınca, tam dolmadan da çalışabiliyor. Tur bittikten sonra atlı karıncaya binen gruplar, bindikleri sırada, kuyruğun en arkasına gidiyor.

Atlı karıncaya binen her kişi, 1 TL'lik bilet alıyor.

Örneğin atlı karınca 4 tur çalışsın ve kapasitesi 6 kişi olsun. Atlı karıncaya binecek 4 grup olsun ve bunların kişi sayıları sırasıyla 1, 4, 2 ve 1 olsun. İlk turda iki grup da sığabilir(1, 4) fakat üçüncü grup sığmaz, dolasıyla iki grupla ilk tur yapılır. Ardından bu gruplar arka sıraya geçer ve sıra 2, 1, 1, 4 haline gelir. İkinci turda 2, 1 ve 1 sığar. Sıra artık 4, 2, 1, 1 hâline geldi. Üçüncü turda atlı karıncaya sıradaki iki grup sığabilir. Onlar sıranın sonuna geçtikten sonra da sıra 1, 1, 4, 2 olur. Dördüncü, yani son turda 6 kişi binebilir (1, 1, 4). Sonuç olarak da atlı karınca 4 tur sonunda 21 TL kazanır.
