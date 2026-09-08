# ARCHITECTURE.md — DailyWord Mimari Yapısı

## Genel Bakış

DailyWord, basit ve sürdürülebilir bir mimari üzerine kurulmuştur.
Aşırı soyutlamadan kaçınılır; her katman net bir sorumluluk taşır.

---

## Klasör Yapısı ve Katman Sınırları

```
Assets/_Project/
├── Scripts/
│   ├── Core/       → Uygulama yaşam döngüsü, sahne yönetimi
│   ├── Game/       → Oyun mekaniği (tahmin, değerlendirme, günlük bulmaca)
│   ├── UI/         → UI controller scriptleri
│   ├── Data/       → Veri modelleri, kelime listesi yönetimi
│   ├── Save/       → Kayıt/yükleme, kalıcı oyuncu verileri
│   └── Utils/      → Yardımcı sınıflar, uzantı metotları
├── Prefabs/
│   ├── UI/         → UI prefab'ları
│   └── Game/       → Oyun objesi prefab'ları
├── Data/
│   └── WordLists/  → Kelime listesi dosyaları (TextAsset/JSON)
├── UI/
│   ├── Fonts/      → TMP font asset'leri
│   ├── Sprites/    → UI görselleri
│   └── Animations/ → UI animasyonları
└── Scenes/
    ├── MainMenu.unity
    └── Game.unity
```

---

## Katman Sorumlulukları

### Core
- Uygulama başlatma ve yaşam döngüsü
- Sahne geçişleri
- Genel uygulama durumu

**Henüz uygulanmadı.** Gerçek bir GameManager oluşturulmadan önce oyun akışı tasarlanacaktır.

### Game
- Kelime tahmini ve harf değerlendirmesi
- Günlük bulmaca mantığı
- Oyun kuralları ve durumu

**Henüz uygulanmadı.**

### UI
- Canvas ve UI elemanlarının kontrolü
- Kullanıcı girişi işleme
- Ekran geçişleri

**Henüz uygulanmadı.**

### Data
- Kelime listesi yükleme ve erişim
- Veri modelleri (ScriptableObject veya POCO)
- Kelime doğrulama

**Aşama 2 kapsamında temel yapı uygulandı.**

- Kaynak formatı: `Assets/_Project/Data/WordLists/*.json`
- JSON şeması: `version` ve sıralı `words` alanları
- `WordListLoader`: JSON/TextAsset yükleme sınırı
- `WordList`: sıralı, tekrarsız ve canonical kelime koleksiyonu
- `TurkishWordRules`: Türkçe Unicode, casing ve 5 harf doğrulaması
- `DailyPuzzleSelector`: tarih + liste sürümüne göre deterministik seçim

Kaynak listedeki kelimeler otomatik düzeltilmez; canonical olmayan, hatalı veya tekrarlı girdiler yükleme sırasında reddedilir.

Günlük seçim istemci tarafında çalışır. Aynı tarih ve aynı liste sürümü aynı `PuzzleId` ve kelimeyi üretir. Save katmanı henüz bu sonucu kalıcı olarak saklamaz.

### Save
- Oyuncu istatistiklerinin kaydedilmesi / yüklenmesi
- Günlük oyun ilerlemesinin saklanması
- Kalıcı veri yönetimi (PlayerPrefs veya JSON)

**Henüz uygulanmadı.**

### Utils
- String yardımcıları (Türkçe karakter dönüşümleri dahil)
- Genel yardımcı metotlar

**Henüz uygulanmadı.**

---

## Temel İlkeler

1. **Oyun mantığı ↔ UI mantığı ayrıdır.** Game katmanı, UI'dan bağımsız çalışabilmelidir.
2. **Bulmaca içeriği veri odaklıdır.** Kelime listeleri, oyun kodu içine hard-code edilmez.
3. **Kalıcı veri ↔ geçici durum ayrıdır.** Save katmanı, oyun sırasındaki geçici durumdan bağımsızdır.
4. **Basitlik tercih edilir.** İhtiyaç duymadığımız tasarım kalıplarını uygulamayız.

---

## Sahne Yapısı

| Sahne | İşlev | Durum |
|-------|-------|-------|
| MainMenu | Ana menü ekranı | Boş temel sahne |
| Game | Oyun ekranı | Boş temel sahne |

---

> **Bu belge, proje geliştikçe güncellenecektir.**
> Şu an temel veri katmanı ve sahne iskeleti mevcuttur; gameplay ve UI henüz uygulanmamıştır.
