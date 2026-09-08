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
