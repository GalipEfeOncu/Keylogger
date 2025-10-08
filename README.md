# 🎓 Global KeyLogger (Eğitim Amaçlı Proje)

Tanıtım videosu: https://youtu.be/JayhfKXEAA0

> **Not:** Bu proje yalnızca eğitim ve ders kapsamında hazırlanmıştır.  
> Amaç, **Windows ortamında düşük seviye klavye olaylarını (Low-Level Keyboard Hook)** öğrenmektir.  
> **Hiçbir şekilde kötüye kullanım veya yetkisiz veri toplama amacı taşımamaktadır.**

---

## 📘 Proje Hakkında

Bu proje, Windows işletim sisteminde çalışan uygulamaların klavye girdilerini nasıl dinleyebildiğini göstermek için hazırlanmıştır.  
Form tabanlı bir C# uygulamasıdır ve temel olarak:

- `SetWindowsHookEx` API’si ile klavye olaylarını yakalar,  
- `LowLevelKeyboardProc` delegate’i ile olayları işler,  
- `StringBuilder` aracılığıyla geçici olarak bellekte tutar.  

Proje tamamen **öğrenme ve gösterim amacıyla** yazılmıştır. Gerçek ortamda kullanılmamalıdır.

---

## ⚙️ Teknik Detaylar

- **Dil:** C# (.NET Framework)  
- **Arayüz:** Windows Forms  
- **Ana Dosya:** `Form1.cs`  
- **Kullanılan API’ler:**  
  - `SetWindowsHookEx` → Klavye olaylarını yakalar  
  - `CallNextHookEx` → Olayları diğer uygulamalara iletir  
  - `GetModuleHandle` → Uygulama modülünü alır  

Ek olarak:
- Asenkron yapılar (`async/await`)
- `Marshal` sınıfı ile unmanaged bellekten veri okuma
- `lock` ile thread-safe işlem

---

## 🚀 Çalışma Mantığı

1. Uygulama başlatıldığında hook sistemi devreye girer.  
2. Kullanıcı bir tuşa bastığında olay `HookCallback` metoduna düşer.  
3. Girilen karakter geçici bir `buffer` değişkenine eklenir.  
4. İstenirse bu veriler üzerinde test/demonstrasyon yapılabilir.  
5. Program kapatıldığında hook kaldırılır.

---

## 🧠 Öğrenilen Konular

- Düşük seviye hook mantığı  
- Windows API ile etkileşim  
- Asenkron programlama  
- Thread güvenliği (lock)  
- Bellek yönetimi (Marshal)

---

## ⚠️ Sorumluluk Reddi

Bu proje yalnızca **ders kapsamında yapılan bir eğitim projesidir.**  
Gerçek kullanıcı verilerini toplamak veya paylaşmak **kesinlikle yasaktır**.  
Projeyi kullanan kişi, **yürürlükteki yasaları ihlal ederse sorumluluk kendisine aittir.**  
Geliştirici (Galip Efe), projenin kötüye kullanımından sorumlu değildir.

---

## 👨‍💻 Geliştirici

**Ad:** Galip Efe  
**Üniversite:** Fırat Üniversitesi  
**Bölüm:** Yazılım Mühendisliği  
**Amaç:** Sistem seviyesinde programlama ve Windows API’lerini öğrenmek

---

## 📄 Lisans

MIT License  
Bu kod, yalnızca eğitim amaçlı kullanılmak üzere serbestçe incelenebilir veya değiştirilebilir.
