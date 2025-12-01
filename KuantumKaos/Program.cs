using System;
using System.Collections.Generic;
using System.Linq;
// Bu kısım yukarıdaki tüm sınıfları kullanmak için gerekli.

public class KuantumAmbarı
{
    // Bütün nesneler (Veri, Karanlık Madde vb.) bu listede saklanır (List<KuantumNesnesi>)
    private static List<KuantumNesnesi> envanter = new List<KuantumNesnesi>();
    private static Random random = new Random();
    private static int nesneSayaci = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("--- KUANTUM AMBARI KONTROL PANELİ'NE HOŞGELDİNİZ ---");

        while (true) // Oyun Döngüsü: Sonsuza kadar çalışır.
        {
            try
            {
                MenuGoster();
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": YeniNesneEkle(); break;
                    case "2": TumEnvanteriListele(); break; // Polimorfizm burada çalışır!
                    case "3": NesneyiAnalizEt(); break;
                    case "4": AcilDurumSogutmasiYap(); break; // Type Checking (is/as) burada çalışır!
                    case "5": Console.WriteLine("Çıkış yapılıyor."); return;
                    default: Console.WriteLine("Geçersiz seçim."); break;
                }
            }
            // Hata Yakalama: Kuantum CokusuException fırlatılırsa program burada yakalar!
            catch (KuantumCokusuException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n********************************************************");
                Console.WriteLine("!!!! SİSTEM ÇÖKTÜ! TAHLİYE BAŞLATILIYOR... !!!!");
                Console.WriteLine($"Hata Detayı: {ex.Message}");
                Console.WriteLine("********************************************************");
                Console.ResetColor();
                return; // Programı sonlandırır.
            }

            Console.WriteLine("\n--- Sonraki tura geçmek için bir tuşa basın ---");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // --- YARDIMCI METOTLAR ---

    private static void MenuGoster()
    {
        Console.WriteLine("\nKUANTUM AMBARI KONTROL PANELİ");
        Console.WriteLine("1. Yeni Nesne Ekle");
        Console.WriteLine("2. Tüm Envanteri Listele");
        Console.WriteLine("3. Nesneyi Analiz Et");
        Console.WriteLine("4. Acil Durum Soğutması Yap");
        Console.WriteLine("5. Çıkış");
        Console.Write("Seçiminiz: ");
    }

    // 1. Yeni Nesne Ekleme
    private static void YeniNesneEkle()
    {
        nesneSayaci++;
        KuantumNesnesi yeniNesne;
        int tip = random.Next(1, 4); // 1: VeriPaketi, 2: KaranlikMadde, 3: AntiMadde
        string id = $"QN-{nesneSayaci:D3}";

        if (tip == 1) yeniNesne = new VeriPaketi(id);
        else if (tip == 2) yeniNesne = new KaranlikMadde(id);
        else yeniNesne = new AntiMadde(id);

        envanter.Add(yeniNesne);
        Console.WriteLine($"\n*** Yeni Nesne Kabul Edildi: {yeniNesne.DurumBilgisi()} ***");
    }

    // 2. Tüm Envanteri Listeleme
    private static void TumEnvanteriListele()
    {
        if (envanter.Count == 0) { Console.WriteLine("Ambar boş."); return; }

        Console.WriteLine("\n--- ENVANTER RAPORU ---");
        // Polimorfizm: Liste içinde her nesnenin DurumBilgisi() metodu çağrılır.
        foreach (var nesne in envanter)
        {
            Console.WriteLine(nesne.DurumBilgisi());
        }
    }

    // 3. Nesneyi Analiz Etme
    private static void NesneyiAnalizEt()
    {
        Console.Write("Analiz edilecek ID'yi girin: ");
        string id = Console.ReadLine();
        var nesne = envanter.FirstOrDefault(n => n.ID.Equals(id, StringComparison.OrdinalIgnoreCase));

        if (nesne == null) { Console.WriteLine($"ID '{id}' bulunamadı."); return; }

        Console.WriteLine($"\nID {id} Analiz Ediliyor...");
        nesne.AnalizEt(); // Her nesne kendi AnalizEt kuralını çalıştırır.
        Console.WriteLine($"Analiz Sonrası Durum: {nesne.DurumBilgisi()}");
    }

    // 4. Acil Durum Soğutması Yapma
    private static void AcilDurumSogutmasiYap()
    {
        Console.Write("Soğutulacak ID'yi girin: ");
        string id = Console.ReadLine();
        var nesne = envanter.FirstOrDefault(n => n.ID.Equals(id, StringComparison.OrdinalIgnoreCase));

        if (nesne == null) { Console.WriteLine($"ID '{id}' bulunamadı."); return; }

        // Type Checking (Tip Kontrolü): Nesneyi IKritik tipine çevirmeye çalış.
        IKritik kritikNesne = nesne as IKritik;

        if (kritikNesne != null) // Çevirme başarılı olduysa (Karanlık Madde veya AntiMadde ise)
        {
            Console.WriteLine($"\nID {id} İçin Soğutma Başlatıldı...");
            kritikNesne.AcilDurumSogutmasi();
            Console.WriteLine($"Soğutma Sonrası Durum: {nesne.DurumBilgisi()}");
        }
        else // Çevirme başarısız olduysa (VeriPaketi ise)
        {
            Console.WriteLine($"!!! HATA: '{nesne.GetType().Name}' tipindeki nesne soğutulamaz!");
        }
    }
}