# PROJECT_PLAN.md — DailyWord Geliştirme Planı

## Genel Bakış

DailyWord, Türkçe günlük 5 harfli kelime bulmacası oyunudur (Wordle tarzı).
Hedef platform Android, motor Unity 6.6'dır.

---

## Geliştirme Aşamaları

### Aşama 1 — Temel Altyapı ✅

- Proje kimliği ve ayarları
- Android yapılandırması
- Gereksiz paketlerin temizlenmesi
- Template içeriğin kaldırılması
- Proje klasör yapısının oluşturulması
- Temel sahne yapısının kurulması
- Sürüm kontrolü (.gitignore)
- Proje dokümantasyonu

### Aşama 2 — Veri Katmanı ✅

- [x] Geliştirme amaçlı Türkçe 5 harfli kelime listesinin oluşturulması
- [x] Kelime veri formatının belirlenmesi (JSON/TextAsset)
- [x] Kelime listesi yükleme ve doğrulama mekanizması
- [x] Deterministik günlük kelime seçim sistemi
- [ ] Üretim kapsamındaki kelime listesinin gözden geçirilmesi ve genişletilmesi

Bu aşamada Wordle değerlendirmesi, UI, save ve oyuncu istatistikleri uygulanmamıştır.

### Aşama 3A — Ana Menü & UI Temeli (Scriptler Hazır — Editor Doğrulaması Bekliyor)

- [x] UI renk paleti ve design token'ları
- [x] Safe area handler
- [x] Sahne navigasyon utility'si
- [x] Ana menü controller scripti
- [x] Editor sahne kurulum kılavuzu
- [ ] Unity Editor'de TMP import ve Canvas kurulumu
- [ ] Runtime doğrulaması

### Aşama 3B — Oyun Tahtası UI Temeli (Planlanıyor)

- 5×6 grid UI yapısı
- Hücre (tile) görsel durumları için temel yapı
- Game sahne UI foundation
- Responsive tahta layout

### Aşama 3C — Türkçe Klavye Girişi (Planlanıyor)

- Ekran üstü Türkçe klavye (QWERTY-TR düzeni)
- Harf girişi
- Silme ve onay işlemleri
- Giriş durumu yönetimi

### Aşama 3D — Kelime Değerlendirme (Planlanıyor)

- Doğru pozisyon (yeşil)
- Yanlış pozisyon (sarı)
- Mevcut değil (gri)
- Tekrarlı harf algoritması
- Değerlendirme testleri

### Aşama 3E — Oyun Entegrasyonu (Planlanıyor)

- Tahta + klavye + değerlendirme birleştirmesi
- Altı tahmin hakkı
- Kazanma / kaybetme durumu
- Günlük bulmaca entegrasyonu

### Aşama 4 — Veri Kalıcılığı (Planlanıyor)

- Oyuncu istatistikleri (kazanma/kaybetme, seri)
- Günlük oyun durumu kaydetme
- PlayerPrefs veya JSON tabanlı yerel kayıt

### Aşama 5 — İkincil Ekranlar (Planlanıyor)

- İstatistikler ekranı
- Bulmaca Geçmişi ekranı
- Ayarlar ekranı
- Sonuç ekranı

### Aşama 6 — Polisaj ve Yayın Hazırlığı (Planlanıyor)

- Animasyonlar ve geçişler
- Türkçe destekli font entegrasyonu (üretim fontu)
- Performans optimizasyonu
- Android build testi
- Hata düzeltmeleri
- Play Store hazırlıkları

---

> **Not:** Her aşama, önceki aşama tamamlandıktan sonra başlayacaktır.
> Gelecek aşamalar için henüz kod veya sistem oluşturulmamıştır.
