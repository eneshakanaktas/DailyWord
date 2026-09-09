# DECISIONS.md — DailyWord Mimari Kararlar

## Karar Kayıtları

---

### K-001: GameManager Oluşturulmadı

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Bağlam:** Temel altyapı aşamasında bir GameManager sınıfı oluşturulması düşünüldü.

**Karar:** Bu aşamada GameManager veya herhangi bir runtime bootstrap scripti oluşturulmadı.

**Gerekçe:**
- Oyun akışı henüz tasarlanmadı
- Erken oluşturulan bir GameManager monolitik hale gelebilir
- Önce oyun mekaniğini tasarlayıp, ardından gerçek ihtiyaca göre minimal bir yapı oluşturmak daha sağlıklı

---

### K-002: Klasör Yapısı _Project Altında

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Bağlam:** Proje dosyalarının nerede tutulacağına karar verildi.

**Karar:** Tüm oyun dosyaları `Assets/_Project/` altında tutulacak.

**Gerekçe:**
- Unity'nin kendi klasörlerinden (Settings, Scenes) ayrı tutma
- Üçüncü taraf asset'lerden izolasyon
- Alt çizgi (_) ile başlayan klasörler Unity Project penceresinde üstte görünür

---

### K-003: ARMv7 Korundu

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Bağlam:** Google Play ARM64 gerektiriyor, ARMv7'nin kaldırılması düşünülebilirdi.

**Karar:** ARMv7 korundu, ARM64 ek olarak eklendi (AndroidTargetArchitectures: 3).

**Gerekçe:**
- Eski cihazlarla uyumluluğu koruma
- Kaldırmak için teknik bir zorunluluk yok
- İlerleyen aşamalarda değerlendirilebilir

---

### K-004: Resources Klasörü Oluşturulmadı

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Bağlam:** Unity'nin Resources sistemi asset yükleme için kullanılabilirdi.

**Karar:** Bu aşamada Resources klasörü oluşturulmadı.

**Gerekçe:**
- Resources klasörü Unity'de özel bir anlama sahip ve tüm içerik build'e dahil edilir
- Henüz dinamik yükleme ihtiyacı yok
- Addressables veya direct reference tercih edilebilir

---

### K-005: Android Min SDK 26 Korundu

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Bağlam:** Minimum Android SDK seviyesi gözden geçirildi.

**Karar:** SDK 26 (Android 8.0 Oreo) korundu.

**Gerekçe:**
- Google Play'in mevcut gereksinimleriyle uyumlu
- Yeterli API desteği sağlıyor
- Değiştirmek için teknik bir neden tespit edilmedi

---

### K-006: Sahne Yapısı İki Sahne

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Bağlam:** Tek sahne mi çoklu sahne mi kullanılacağı değerlendirildi.

**Karar:** MainMenu ve Game olmak üzere iki sahne oluşturuldu.

**Gerekçe:**
- Endişelerin ayrılması (menü ↔ oyun)
- Sahne geçişleriyle temiz bellek yönetimi
- İleride splash screen vb. eklemek kolaylaşır

---

### K-007: Kelime Listesi JSON TextAsset Olarak Tutulacak

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Karar:** Türkçe kelime listesi `Assets/_Project/Data/WordLists/` altında JSON dosyası olarak tutulacak ve `WordListLoader` üzerinden yüklenecek.

**Gerekçe:**
- Kaynak veri oyun kodundan ayrı kalır.
- Unity `TextAsset` ile doğrudan referanslanabilir.
- `Resources` tabanlı global yükleme gerektirmez.
- Liste sürümü ve deterministik sıralama dosyanın içinde açıkça tutulabilir.

Kaynak girdiler sessizce normalize edilmez; canonical olmayan veya tekrarlı girdiler reddedilir.

---

### K-008: Günlük Bulmaca Seçimi Deterministik Hash Kullanacak

**Tarih:** 2026-09-08
**Durum:** Kabul Edildi

**Karar:** Günlük kelime indeksi, liste sürümü ile `yyyy-MM-dd` tarihinin SHA-256 özetinden deterministik olarak üretilecek.

**Gerekçe:**
- Aynı tarih ve aynı veri seti tüm oyuncularda aynı sonucu üretir.
- .NET `GetHashCode()` gibi platforma göre değişebilen yöntemlere bağlı kalınmaz.
- Liste sürümü `PuzzleId` içinde yer alır ve veri seti değişiklikleri izlenebilir.
- Sunucu, ağ veya üçüncü taraf servis gerektirmez.

---

### K-009: Safe Area Yaklaşımı — Basit Bileşen

**Tarih:** 2026-09-09
**Durum:** Kabul Edildi

**Bağlam:** Mobil cihazlarda notch, yuvarlak köşeler ve status bar gibi alanlar UI'ın üzerini kapatabilir.

**Karar:** `SafeAreaHandler` adında tek bir MonoBehaviour oluşturuldu. Bağlandığı RectTransform'un anchor'larını `Screen.safeArea` değerlerine göre otomatik ayarlar.

**Gerekçe:**
- Framework düzeyinde bir safe area sistemi gereksiz karmaşıklık ekler
- Tek bileşen yaklaşımı ile istenilen panele kolayca eklenebilir
- Ekran boyutu değişikliklerini (rotation, resize) otomatik algılar
- Unity'nin `Screen.safeArea` API'si yeterli bilgiyi sağlar

---

### K-010: Font Stratejisi — TMP Varsayılanı + Kullanıcı İmport'u

**Tarih:** 2026-09-09
**Durum:** Kabul Edildi

**Bağlam:** TMP Essential Resources Unity Editor'de import edilmeden TMP bileşenleri tam çalışmaz. Font atlas oluşturmak Türkçe karakter seti gerektirir.

**Karar:** Scriptler `TMPro.TMP_Text` referanslarını kullanır. TMP Essential Resources import'u ve Türkçe karakter destekli font atlas oluşturma işlemi Unity Editor'de kullanıcı tarafından yapılacak.

**Gerekçe:**
- TMP Essential Resources import'u Unity Editor GUI'si gerektirir (dosya düzeyinde yapılamaz)
- Proje dışından font dosyası indirilmeyecek (teknik kısıtlama)
- Varsayılan LiberationSans fontu Türkçe karakterleri destekler, atlas oluşturulduğunda çalışır
- Font seçimi ilerleyen aşamalarda değiştirilebilir

---

### K-011: Sahne Oluşturma — Script + Editor Kılavuzu

**Tarih:** 2026-09-09
**Durum:** Kabul Edildi

**Bağlam:** MainMenu sahnesinin Canvas hiyerarşisi oluşturulması gerekiyor. YAML düzeyinde programatik sahne oluşturma, TMP bileşenlerinin karmaşık serialization yapısı nedeniyle riskli.

**Karar:** C# scriptler (MainMenuController, SafeAreaHandler, UIColors) oluşturuldu. Sahne hiyerarşisi için `MAINMENU_SETUP.md` kılavuzu hazırlandı.

**Gerekçe:**
- TMP bileşenleri çok sayıda serialized alan içerir; YAML düzenleme hatalara açık
- Canvas Scaler, RectTransform anchor düzenlemeleri tam doğruluk gerektirir
- Editor kılavuzu, adım adım doğrulanabilir bir süreç sağlar
- Scriptler derlenebilir ve test edilebilir; sahne Editor'de güvenle oluşturulur
