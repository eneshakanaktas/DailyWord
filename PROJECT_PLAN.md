# PROJECT_PLAN.md — DailyWord Geliştirme Planı

## Genel Bakış

DailyWord, Türkçe günlük 5 harfli kelime bulmacası oyunudur (Wordle tarzı).
Hedef platform Android, motor Unity 6.6'dır.

---

## Geliştirme Aşamaları

### Aşama 1 — Temel Altyapı ✅ (Mevcut Aşama)

- Proje kimliği ve ayarları
- Android yapılandırması
- Gereksiz paketlerin temizlenmesi
- Template içeriğin kaldırılması
- Proje klasör yapısının oluşturulması
- Temel sahne yapısının kurulması
- Sürüm kontrolü (.gitignore)
- Proje dokümantasyonu

### Aşama 2 — Veri Katmanı (Planlanıyor)

- Türkçe 5 harfli kelime listesinin oluşturulması
- Kelime veri formatının belirlenmesi (JSON/TextAsset/ScriptableObject)
- Kelime doğrulama mekanizması
- Günlük kelime seçim sistemi

### Aşama 3 — Oyun Mekaniği (Planlanıyor)

- Harf tahmini ve değerlendirme sistemi
- Oyun tahtası (5x6 grid)
- Sanal klavye
- Oyun akışı (tahmin → değerlendirme → sonuç)

### Aşama 4 — UI ve Görsel Tasarım (Planlanıyor)

- Ana menü tasarımı
- Oyun ekranı UI'ı
- Sonuç ekranı
- Animasyonlar ve geçişler
- Türkçe destekli font entegrasyonu

### Aşama 5 — Veri Kalıcılığı (Planlanıyor)

- Oyuncu istatistikleri (kazanma/kaybetme, seri)
- Günlük oyun durumu kaydetme
- PlayerPrefs veya JSON tabanlı yerel kayıt

### Aşama 6 — Polisaj ve Yayın Hazırlığı (Planlanıyor)

- Performans optimizasyonu
- Android build testi
- Hata düzeltmeleri
- Play Store hazırlıkları

---

> **Not:** Her aşama, önceki aşama tamamlandıktan sonra başlayacaktır.
> Gelecek aşamalar için henüz kod veya sistem oluşturulmamıştır.
