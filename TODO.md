# TODO.md — DailyWord Sonraki Geliştirme Görevleri

## Öncelik: Yüksek (Aşama 2 — Veri Katmanı)

- [x] Geliştirme amaçlı Türkçe 5 harfli kelime listesi oluşturmak
- [x] Kelime listesi veri formatını belirlemek (JSON TextAsset)
- [x] Kelime yükleme ve erişim mekanizmasını yazmak (`Data/` katmanı)
- [x] Kelime doğrulama mantığını yazmak (girilen kelime geçerli mi?)
- [x] Günlük kelime seçim algoritmasını tasarlamak
- [ ] Üretim kapsamındaki Türkçe kelime listesini gözden geçirmek ve genişletmek

## Öncelik: Yüksek (Aşama 3A — Ana Menü & UI Temeli)

- [x] UI renk paleti ve design token'ları oluşturmak
- [x] SafeArea handler yazmak
- [x] SceneNavigator utility'si yazmak
- [x] MainMenuController yazmak
- [x] MAINMENU_SETUP.md kurulum kılavuzu yazmak
- [ ] Unity Editor'de TMP Essential Resources import etmek
- [ ] Unity Editor'de MainMenu Canvas hiyerarşisini oluşturmak (MAINMENU_SETUP.md kılavuzu)
- [ ] Ana menüyü Unity Editor'de test etmek

## Öncelik: Yüksek (Aşama 3B — Oyun Tahtası UI Temeli)

- [ ] 5×6 grid UI yapısını oluşturmak
- [ ] Hücre (tile) görsel durumları için temel yapı
- [ ] Game sahne UI foundation
- [ ] Responsive tahta layout

## Öncelik: Yüksek (Aşama 3C — Türkçe Klavye Girişi)

- [ ] Ekran üstü Türkçe klavye (QWERTY-TR düzeni)
- [ ] Harf girişi, silme, onay mekanizması
- [ ] Giriş durumu yönetimi

## Öncelik: Yüksek (Aşama 3D — Kelime Değerlendirme)

- [ ] Doğru pozisyon / yanlış pozisyon / mevcut değil değerlendirmesi
- [ ] Tekrarlı harf algoritması
- [ ] Değerlendirme testleri

## Öncelik: Yüksek (Aşama 3E — Oyun Entegrasyonu)

- [ ] Tahta + klavye + değerlendirme birleştirmesi
- [ ] Altı tahmin hakkı
- [ ] Kazanma / kaybetme durumu
- [ ] Günlük bulmaca entegrasyonu

## Öncelik: Orta (UI — Oyun Ekranı)

- [ ] Türkçe karakter destekli font bulmak ve TMP font asset oluşturmak
- [ ] Sonuç ekranını tasarlamak

## Öncelik: Düşük (İleri Aşama)

- [ ] Kayıt/yükleme sistemi (istatistikler, günlük ilerleme)
- [ ] İstatistikler ekranı
- [ ] Bulmaca Geçmişi ekranı
- [ ] Ayarlar ekranı
- [ ] Animasyonlar (harf çevirme, satır sallanma vb.)
- [ ] Ses efektleri
- [ ] Android build testi
- [ ] Performans optimizasyonu

## Notlar

- TMP Essential Resources import'u Unity Editor gerektirir.
- İlk Editor açılışında MAINMENU_SETUP.md kılavuzuna göre sahne kurulumu yapılmalıdır.
- Her aşama, önceki aşama tamamlandıktan ve doğrulandıktan sonra başlayacaktır.
