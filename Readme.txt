Projede 2 tane mikroservis vardýr. Asenkron iletiþim için MassTransit RabbitMq kullandým. Ayrýca Mimari olarak Onion Arch orm olara entity framworkCore kullandým.
Öncelikle Hotel servisinde iki tane controller vardýr bir tanesi Hotel diðeri ContactInformation. Hotel Controller içinde otel ile ilgili crud temel iþlemler vardýr. Diðer ContactInformation controller ise ilgili otele iletiþim ve harita sýnýrsýz ekleme güncellme ve listeleme gibi iþlemler vardýr.
Bu 2 tane controller içinde xUnit test projemde testleri yazýlmýþtýr.
Ýstenilen db lerde þirket pc kullandýðým için sadece mssql kullanabildim. Map tablomda þehir,ilçe ve mevki gibi alanlar normalde Id ile tutulacaðýndan dolayý seed db olarak guid türlerinde ekledim.
Rapor talep edildiðinde rabbitmq ile procedur olarak üretip kuyruða atar ilgili kuyruðu dinleyen hotel servis (Consumer) rapor hazýrlamaya baþlar rapor hazýrlama aþamasýnda procedure olarak kuyruða hazýrlandýðýna dair bilgi atar ve consume edilen report servise bilgi gelir ve kaydeder.
Consume tarafý olan report servis dinleyip kayýt ettikten sonra kayýt iþlemi baþarýlý olduðunda üretici tarafýna kuyruk ile haber verir sonra rapor hazýrlanma aþamasý bittiðinde rapor consume tarafýna servis edildiðinde ise rapor durumu tamamlandý kýsmýna çekilir.
Eðer olursa report tarafýna rapor hazýrlanýor bilgisi geldikten sonra hazýrlanýrken olasý bir hata da ilgili kuyruða tekrardan dinlenip ilgili statusId göre raporstatusu Error çeker. Bu þekilde transaction ve veri bütünlülüðünü korumuþ olurum.

Rapor listelendiðinde þehir,iilçe ve mah gibi alanlar default olarak dolu gelir. Map tablosunda Id tuttuðum için göstermelik olrak defaul deðer ekledim.
Ayrýca Hotelservisin Persistence katmanýnda Configuration entityleri olup seed database yapmaktardýr.
Loglama olarak serilog kullandým ve GlobalExceptionError Middleware etkindir. Serilog ile tüm istek,yanýt ve errorlar hepsini tutar.

Teþekkür ederim.
