// 1. VeriPaketi (Güvenli Nesne)
using System;

public class VeriPaketi : KuantumNesnesi
{
    public VeriPaketi(string id) : base(id, 85, 2) { }

    // Kendi AnalizEt kuralı: Stabilite -5 düşer.
    public override void AnalizEt()
    {
        Console.WriteLine("Veri içeriği okundu.");
        Stabilite -= 5;
    }
}

// 2. KaranlikMadde (Tehlikeli Nesne)
// KuantumNesnesi'nden miras alır VE IKritik arayüzünü uygular (Soğutulabilir!).
public class KaranlikMadde : KuantumNesnesi, IKritik
{
    public KaranlikMadde(string id) : base(id, 60, 7) { }

    // Kendi AnalizEt kuralı: Stabilite -15 düşer.
    public override void AnalizEt()
    {
        Stabilite -= 15;
        Console.WriteLine($"Karanlık Madde analiz ediliyor... Stabilite {Stabilite:F2}%'ye düştü.");
    }

    // Soğutma metodu (IKritik'ten zorunlu gelen metot)
    public void AcilDurumSogutmasi()
    {
        Stabilite += 50; // Stabilite +50 artırılır.
        Console.WriteLine($"*** ACİL SOGUTMA BAŞARILI! Karanlık Madde Stabilite: {Stabilite:F2}% ***");
    }
}

// 3. AntiMadde (Çok Tehlikeli Nesne)
public class AntiMadde : KuantumNesnesi, IKritik
{
    public AntiMadde(string id) : base(id, 40, 10) { }

    // Kendi AnalizEt kuralı: Stabilite -25 düşer (En hızlı).
    public override void AnalizEt()
    {
        Console.WriteLine("!!! UYARI: Evrenin dokusu titriyor... !!!");
        Stabilite -= 25;
        Console.WriteLine($"Anti Madde analiz edildi. Stabilite {Stabilite:F2}%'ye düştü.");
    }

    // Soğutma metodu
    public void AcilDurumSogutmasi()
    {
        Stabilite += 50; // Stabilite +50 artırılır.
        Console.WriteLine($"*** ACİL SOGUTMA BAŞARILI! Anti Madde Stabilite: {Stabilite:F2}% ***");
    }
}