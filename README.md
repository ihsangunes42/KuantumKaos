# ?? Kuantum Ambarý Simülasyonu (Çoklu Dil Mimarisi)

**Kuantum Kaos Yönetimi Projesi**

Bu proje, temel Nesne Yönelimli Programlama (OOP) ilkelerini uygulamak ve sürdürülebilir, geniþletilebilir bir yazýlým mimarisini farklý programlama dillerinde (C#, Java, Python, JavaScript) sergilemek amacýyla geliþtirilmiþtir.

## ?? Proje Mimarisi ve Temel OOP Uygulamalarý

Simülasyon, ambara eklenen kararsýz kuantum nesnelerinin stabilite takibi üzerine kurulmuþtur. Her nesne analiz edildikçe stabilite kaybeder ve stabilite %0'ýn altýna düþtüðünde sistem, bir **Kuantum Çöküþü** hatasý fýrlatarak simülasyonu sonlandýrýr (Game Over).

### 1. Kapsülleme (Encapsulation)

* **Özellik Koruma:** Tüm dillerde (C#'ta `private set`, Java'da `protected setStabilite`, Python'da `@stabilite.setter` ile) nesnenin **Stabilite** deðeri korunmuþtur.
* **Hata Tetikleme:** Stabilite özelliðinin `setter` metodu, her atama iþleminden sonra deðeri kontrol eder. Eðer deðer $\leq 0$ ise, hemen **`KuantumCokusuException`** hatasýný fýrlatýr. Bu, oyunun çöküþ kuralýnýn sistemin temel veri yapýsýna (stabilite özelliðine) entegre edildiði anlamýna gelir.

### 2. Kalýtým ve Polimorfizm (Inheritance & Polymorphism)

* **Soyut Sýnýf:** Tüm nesnelerin atasý olan **`KuantumNesnesi`** (C#'ta `abstract class`, Python'da `ABC`) tanýmlanmýþtýr. Bu sýnýf, tüm nesneler için zorunlu olan `ID`, `Stabilite` ve `DurumBilgisi()` gibi temel yapýlarý tanýmlar.
* **Polimorfik Davranýþ:** **`AnalizEt()`** metodu soyut olarak tanýmlanmýþtýr. Her alt sýnýf (Veri, Karanlýk Madde, Anti Madde) bu metodu kendi kurallarýna göre (stabiliteyi -5, -15 veya -25 düþürerek) uygulamak zorundadýr.

### 3. Arayüz Ayrýmý (Interface Segregation)

* **`IKritik` Arayüzü:** Yalnýzca tehlikeli maddeler (`KaranlikMadde`, `AntiMadde`) için **`IKritik`** arayüzü tanýmlanmýþtýr.
* **Type Checking:** Ana döngüde soðutma iþlemi yapýlmadan önce, nesnenin bu arayüzü uygulayýp uygulamadýðý kontrol edilir (C#'ta `is` veya `as`, Java'da `instanceof`). Arayüzü uygulamayan bir nesne soðutulamaz.

## ?? Proje Yapýsý ve Dil Karþýlaþtýrmasý

Projenin yapýsý ve her dildeki temel araçlar aþaðýdadýr:

| Klasör | Dil | Çekirdek Yapý | Arayüz Uygulamasý | Hata Yönetimi |
| :--- | :--- | :--- | :--- | :--- |
| **C-Sharp** | C# (.NET) | `abstract class` | `interface IKritik` | `class KuantumCokusuException : Exception` |
| **Java** | Java (JDK) | `abstract class` | `interface IKritik` | `class KuantumCokusuException extends Exception` |
| **Python** | Python (3.x) | `abc.ABC` | `abc.ABC` + Çoklu Kalýtým | `class KuantumCokusuException(Exception)` |
| **JavaScript** | Node.js (ES6+) | `class` | Duck Typing (Metot Kontrolü) | `class KuantumCokusuException extends Error` |

## ?? Kurulum ve Çalýþtýrma Talimatlarý

### Genel Gereksinimler

* **C#:** .NET SDK (Tercihen .NET 8+)
* **Java:** JDK 11+
* **Python:** Python 3.x ve `readline-sync` paketi (`pip install readline-sync`)
* **JavaScript:** Node.js ve `readline-sync` paketi (`npm install readline-sync`)

### Örnek Çalýþtýrma (C# ve JavaScript)

| Dil | Konum | Komut |
| :--- | :--- | :--- |
| **C#** | `C-Sharp` klasöründe | `dotnet run` |
| **JavaScript** | `JavaScript` klasöründe | `node kuantumAmbar.js` |

## ????? Katkýda Bulunma

Geri bildirimlere ve projenin diðer dillerle geniþletilmesine her zaman açýðýz. Lütfen bir sorun (Issue) açmaktan çekinmeyin.

---
**Geliþtirici:** [Ýhsan GÜNEÞ / ihsangunes42]
