using System;

// 1. Kuantum Çöküşü Hatası (Game Over Uyarısı)
public class KuantumCokusuException : Exception
{
    // Hata oluştuğunda bu mesajı fırlatır.
    public KuantumCokusuException(string nesneID)
        : base($"Kuantum Çöküşü gerçekleşti! Patlayan Nesne ID: {nesneID}")
    {
    }
}

// 2. IKritik Arayüzü (Soğutma Yeteneği)
// Bu, sadece tehlikeli nesnelere verilecek ekstra bir yetenektir.
public interface IKritik
{
    // Çağrıldığında stabiliteyi +50 artırır (max 100).
    void AcilDurumSogutmasi();
}