# CHANGELOG.md — DailyWord Değişiklik Günlüğü

## [0.3.0] — 2026-09-09 — Aşama 3A Ana Menü & UI Temeli

### Eklenenler
- `Assets/_Project/Scripts/Core/SceneNavigator.cs` — statik sahne geçiş utility'si
- `Assets/_Project/Scripts/UI/MainMenuController.cs` — Ana menü buton yönetimi
- `Assets/_Project/Scripts/UI/SafeAreaHandler.cs` — Mobil safe area adaptasyonu
- `Assets/_Project/Scripts/UI/UIColors.cs` — Premium renk paleti sabitleri
- `Assets/_Project/Scenes/MAINMENU_SETUP.md` — Unity Editor sahne kurulum kılavuzu

### Kapsam Sınırı
- Canvas / UI hiyerarşisi Unity Editor'de oluşturulacak (MAINMENU_SETUP.md kılavuzu)
- TMP Essential Resources import'u Unity Editor gerektiriyor
- İstatistikler, Geçmiş, Ayarlar butonları Debug.Log placeholder kullanıyor
- Wordle tahtası, klavye, oyun mantığı, save sistemi uygulanmadı
- Stage 2 Data Layer testleri değiştirilmedi
- Foundation cleanup kalıntıları değiştirilmedi

## [0.2.0] — 2026-09-08 — Aşama 2 Veri Katmanı Başlangıcı

### Eklenenler
- `Assets/_Project/Data/WordLists/turkish_words.json` geliştirme kelime listesi
- `TurkishWordRules` ile Türkçe casing, Unicode ve 5 harf doğrulaması
- `WordList` ve `WordListLoader` ile JSON/TextAsset veri yükleme
- Liste sürümünü ve tarih bilgisini kullanan deterministik `DailyPuzzleSelector`
- Data Layer için NUnit testleri

### Kapsam Sınırı
- Kelime değerlendirme/Wordle skorlaması uygulanmadı.
- UI, save, istatistik, history ve GameManager uygulanmadı.
- Foundation cleanup kalıntıları değiştirilmedi.

## [0.1.0] — 2026-09-08 — Temel Altyapı Kurulumu

### Eklenenler
- `Assets/_Project/` altında proje klasör yapısı oluşturuldu (17 dizin)
- `Assets/_Project/Scenes/MainMenu.unity` — temel URP 2D sahnesi
- `Assets/_Project/Scenes/Game.unity` — temel URP 2D sahnesi
- `Assets/_Project/UI/Fonts/FONT_REQUIREMENTS.md` — font gereksinimleri
- `.gitignore` — Unity standart git-ignore dosyası
- `AGENTS.md` — AI ajan mühendislik kuralları
- `PROJECT_PLAN.md` — geliştirme aşamaları planı
- `ARCHITECTURE.md` — mimari yapı ve katman tanımları
- `CURRENT_STATE.md` — mevcut proje durumu
- `DECISIONS.md` — mimari karar kayıtları
- `TODO.md` — sonraki görevler listesi
- `CHANGELOG.md` — değişiklik günlüğü

### Değiştirilenler
- `ProjectSettings/ProjectSettings.asset`:
  - `companyName`: DefaultCompany → DailyWord
  - `applicationIdentifier`: com.DefaultCompany.2D-URP → com.dailyword.game
  - `defaultScreenOrientation`: AutoRotation (4) → Portrait (1)
  - `AndroidTargetArchitectures`: ARMv7 (2) → ARMv7 + ARM64 (3)
- `ProjectSettings/EditorBuildSettings.asset`:
  - Build sahneleri güncellendi: MainMenu (0), Game (1)
  - SampleScene kaldırıldı
- `Packages/manifest.json`:
  - 10 gereksiz paket kaldırıldı

### Kaldırılanlar
- `Assets/Welcome/` klasörü (template karşılama içeriği)
- `Unity.2D.Welcome.csproj` (template proje dosyası)
- 10 gereksiz paket (2d.animation, 2d.aseprite, 2d.psdimporter, 2d.spriteshape, 2d.tilemap, 2d.tilemap.extras, 2d.tooling, visualscripting, timeline, learn.iet-framework)
