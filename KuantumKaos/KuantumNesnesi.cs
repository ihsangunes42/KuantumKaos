using System;

// 'abstract' demek: Bu sınıftan doğrudan nesne yapılamaz, sadece miras verir.
public abstract class KuantumNesnesi
{
    // ID özelliği (Herkesin kimliği)
    public string ID { get; protected set; }

    // Stabilite Kapsüllemesi (En önemli kısım!)
    private double _stabilite;
    public double Stabilite
    {
        get { return _stabilite; }
        protected set
        {
            if (value > 100)
            {
                _stabilite = 100;
            }
            else if (value <= 0) // Eğer stabilite biterse...
            {
                _stabilite = 0;
                // Game Over hatasını fırlat!
                throw new KuantumCokusuException(this.ID);
            }
            else
            {
                _stabilite = value;
            }
        }
    }

    // Tehlike Seviyesi özelliği
    public int TehlikeSeviyesi { get; protected set; }

    // Yapıcı Metot (Nesne oluşturulurken ilk ayarları yapar)
    public KuantumNesnesi(string id, double baslangicStabilite, int tehlikeSeviyesi)
    {
        ID = id;
        this.Stabilite = baslangicStabilite;
        this.TehlikeSeviyesi = tehlikeSeviyesi;
    }

    // AnalizEt: Soyut metot. Her alt sınıf bunu kendi kuralına göre yapmak ZORUNDA.
    public abstract void AnalizEt();

    // DurumBilgisi: Herkesin ID ve stabilitesini gösteren raporu döndürür.
    public string DurumBilgisi()
    {
        return $"[ID: {ID}, Tip: {this.GetType().Name}, Stabilite: {Stabilite:F2}% (Tehlike: {TehlikeSeviyesi}/10)]";
    }
}