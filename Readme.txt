Projede 2 tane mikroservis vard�r. Asenkron ileti�im i�in MassTransit RabbitMq kulland�m. Ayr�ca Mimari olarak Onion Arch orm olara entity framworkCore kulland�m.
�ncelikle Hotel servisinde iki tane controller vard�r bir tanesi Hotel di�eri ContactInformation. Hotel Controller i�inde otel ile ilgili crud temel i�lemler vard�r. Di�er ContactInformation controller ise ilgili otele ileti�im ve harita s�n�rs�z ekleme g�ncellme ve listeleme gibi i�lemler vard�r.
Bu 2 tane controller i�inde xUnit test projemde testleri yaz�lm��t�r.
�stenilen db lerde �irket pc kulland���m i�in sadece mssql kullanabildim. Map tablomda �ehir,il�e ve mevki gibi alanlar normalde Id ile tutulaca��ndan dolay� seed db olarak guid t�rlerinde ekledim.
Rapor talep edildi�inde rabbitmq ile procedur olarak �retip kuyru�a atar ilgili kuyru�u dinleyen hotel servis (Consumer) rapor haz�rlamaya ba�lar rapor haz�rlama a�amas�nda procedure olarak kuyru�a haz�rland���na dair bilgi atar ve consume edilen report servise bilgi gelir ve kaydeder.
Consume taraf� olan report servis dinleyip kay�t ettikten sonra kay�t i�lemi ba�ar�l� oldu�unda �retici taraf�na kuyruk ile haber verir sonra rapor haz�rlanma a�amas� bitti�inde rapor consume taraf�na servis edildi�inde ise rapor durumu tamamland� k�sm�na �ekilir.
E�er olursa report taraf�na rapor haz�rlan�or bilgisi geldikten sonra haz�rlan�rken olas� bir hata da ilgili kuyru�a tekrardan dinlenip ilgili statusId g�re raporstatusu Error �eker. Bu �ekilde transaction ve veri b�t�nl�l���n� korumu� olurum.

Rapor listelendi�inde �ehir,iil�e ve mah gibi alanlar default olarak dolu gelir. Map tablosunda Id tuttu�um i�in g�stermelik olrak defaul de�er ekledim.
Ayr�ca Hotelservisin Persistence katman�nda Configuration entityleri olup seed database yapmaktard�r.
Loglama olarak serilog kulland�m ve GlobalExceptionError Middleware etkindir. Serilog ile t�m istek,yan�t ve errorlar hepsini tutar.

Te�ekk�r ederim.
