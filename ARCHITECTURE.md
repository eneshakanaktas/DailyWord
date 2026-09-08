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

**Henüz uygulanmadı.**

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
> Şu an yalnızca klasör yapısı ve sahne iskeleti mevcuttur.
