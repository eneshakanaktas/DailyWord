# TODO.md — DailyWord Sonraki Geliştirme Görevleri

## Öncelik: Yüksek (Aşama 2 — Veri Katmanı)

- [ ] Türkçe 5 harfli kelime listesi oluşturmak veya temin etmek
- [ ] Kelime listesi veri formatını belirlemek (TextAsset / JSON / ScriptableObject)
- [ ] Kelime yükleme ve erişim mekanizmasını yazmak (`Data/` katmanı)
- [ ] Kelime doğrulama mantığını yazmak (girilen kelime geçerli mi?)
- [ ] Günlük kelime seçim algoritmasını tasarlamak

## Öncelik: Yüksek (Aşama 3 — Oyun Mekaniği)

- [ ] Harf değerlendirme sistemi (doğru yer, yanlış yer, yok)
- [ ] Oyun durumu yönetimi (tahmin sayısı, oyun bitti mi?)
- [ ] Oyun akışını tasarlamak ve uygun bir yapı oluşturmak

## Öncelik: Orta (UI)

- [ ] Türkçe karakter destekli font bulmak ve TMP font asset oluşturmak
- [ ] Oyun tahtası UI'ını oluşturmak (5x6 grid)
- [ ] Sanal Türkçe klavye oluşturmak (QWERTY-TR düzeni)
- [ ] Ana menü ekranını tasarlamak
- [ ] Sonuç ekranını tasarlamak

## Öncelik: Düşük (İleri Aşama)

- [ ] Kayıt/yükleme sistemi (istatistikler, günlük ilerleme)
- [ ] Animasyonlar (harf çevirme, satır sallanma vb.)
- [ ] Ses efektleri
- [ ] Android build testi
- [ ] Performans optimizasyonu

## Notlar

- Projeyi Unity'de açıp sahne doğrulaması yapmak önerilir.
- İlk adım olarak kelime listesinin hazırlanması gerekiyor, çünkü oyun mekaniği buna bağlı.
