# CURRENT_STATE.md — DailyWord Mevcut Proje Durumu

**Son güncelleme:** 2026-09-08

---

## Genel Durum

Proje, **Aşama 1 — Temel Altyapı** kurulumunu tamamlamış ve
**Aşama 2 — Veri Katmanı** için ilk uygulamayı almıştır.
Oyun mekaniği, UI ve kayıt sistemi henüz uygulanmamıştır.

---

## Tamamlanan İşler

### Proje Ayarları
- `productName`: DailyWord
- `companyName`: DailyWord (geçici geliştirme değeri)
- `applicationIdentifier`: com.dailyword.game (Android + Standalone)
- `defaultScreenOrientation`: Portrait (1)
- `AndroidTargetArchitectures`: ARMv7 + ARM64 (3)
- `AndroidMinSdkVersion`: 26 (Android 8.0)
- `scriptingBackend`: IL2CPP

### Paket Temizliği
Kaldırılan paketler (10 adet):
- com.unity.2d.animation
- com.unity.2d.aseprite
- com.unity.2d.psdimporter
- com.unity.2d.spriteshape
- com.unity.2d.tilemap
- com.unity.2d.tilemap.extras
- com.unity.2d.tooling
- com.unity.visualscripting
- com.unity.timeline
- com.unity.learn.iet-framework

### Template İçerik Temizliği
- `Assets/Welcome/` klasörü silindi (Welcome2DScript.cs, 2d-template.png, asmdef, tutorial asset'leri)
- `Unity.2D.Welcome.csproj` kök dizinden silindi

### Klasör Yapısı
`Assets/_Project/` altında 17 dizin oluşturuldu (detaylar için ARCHITECTURE.md)

### Sahneler
- `Assets/_Project/Scenes/MainMenu.unity` — Boş temel URP 2D sahnesi
- `Assets/_Project/Scenes/Game.unity` — Boş temel URP 2D sahnesi
- Build sırası: 0=MainMenu, 1=Game

### Sürüm Kontrolü
- `.gitignore` oluşturuldu (GitHub Unity şablonu)

### Dokümantasyon
- AGENTS.md, PROJECT_PLAN.md, ARCHITECTURE.md, CURRENT_STATE.md
- DECISIONS.md, TODO.md, CHANGELOG.md
- FONT_REQUIREMENTS.md (Assets/_Project/UI/Fonts/)

### Aşama 2 — Veri Katmanı
- `Assets/_Project/Data/WordLists/turkish_words.json` geliştirme kelime listesi oluşturuldu.
- JSON veri formatı `version` ve sıralı `words` alanlarıyla belirlendi.
- Türkçe karakter ve `I / İ / ı / i` ayrımı için `TurkishWordRules` oluşturuldu.
- Kaynak kelimeleri doğrulayan `WordList` ve `WordListLoader` oluşturuldu.
- Tarih ve liste sürümüne göre deterministik `DailyPuzzleSelector` oluşturuldu.
- Veri katmanı testleri `Assets/_Project/Scripts/Data/Tests/Editor/` altında oluşturuldu.
- Save, UI, GameManager ve Wordle değerlendirme sistemi bu aşamada uygulanmadı.

---

## Mevcut Olmayan / Uygulanmamış Öğeler

- ❌ Oyun mekaniği (kelime tahmini, değerlendirme)
- ❌ UI bileşenleri (klavye, tahta, menüler)
- ❌ Üretim kapsamındaki tam kelime listesi
- ❌ Kayıt/yükleme sistemi
- ❌ GameManager veya herhangi bir runtime script
- ❌ Font asset'leri (sadece gereksinimler belgelendi)
- ❌ Animasyonlar
- ❌ Ses efektleri

---

## Aşama 2 Sınırı

- JSON kelime listesi yükleme ve doğrulama uygulanmıştır.
- Mevcut liste geliştirme amaçlı sınırlı bir listedir; üretim sözlüğü değildir.
- Kelime değerlendirme, günlük oyun akışı ve oyuncu kayıtları sonraki aşamalardadır.

---

## Korunan Yapılandırmalar

- URP 17.6.0 pipeline ayarları (`Assets/Settings/`)
- Input System ayarları
- UGUI paketi
- Test Framework
- Tüm `com.unity.modules.*` paketleri
