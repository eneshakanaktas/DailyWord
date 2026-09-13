# CHANGELOG.md — DailyWord Değişiklik Günlüğü

## [0.3.3] — 2026-09-13 — Aşama 3C Doğrulama ve Test Tamamlama

### Eklenenler
- `GameInputStateTests.Backspace_OnEmptyRow_DoesNothing` — boş satırda backspace testi (toplam 6 test)

### Doğrulananlar
- `Game.unity` sahnesinde `GameInputController` bileşeni `boardView` ve `keyboardController` serialized referanslarıyla kalıcı olarak kayıtlı.
- `GameBoardView` (fileID: 1907188788) ve `TurkishKeyboardController` (fileID: 796293983) sahne YAML'ında doğrulandı.
- `GameInputBootstrap` sahne wiring mevcutsa bootstrap'ı atlayarak doğru çalışır.
- 30 tile (`Tile_01`..`Tile_30`), Row1/Row2/Row3, tüm Türkçe tuşlar, Key_Backspace ve Key_Enter sahne hiyerarşisinde doğrulandı.

### Kapsam Sınırı
- Assembly definition (asmdef) dosyaları eklenmedi — ana kod asmdef'siz olduğundan test asmdef'leri `Assembly-CSharp` referansını çözemez; Unity'nin `Editor` klasör convention'ı testleri otomatik bulur.

## [0.3.2] — 2026-09-13 — Aşama 3C Türkçe Klavye ve Input Controller

### Eklenenler
- `Assets/_Project/Scripts/Game/GameInputState.cs` — aktif satır/kolon, 5 harf sınırı, backspace ve satır ilerletme state'i
- `Assets/_Project/Scripts/Game/GameBoardView.cs` — `Tile_XX/Letter` TMP metinlerini otomatik bulan board view
- `Assets/_Project/Scripts/Game/TurkishKeyboardController.cs` — QWERTY-TR harfleri, `⌫` ve `ENTER` için merkezi button binding
- `Assets/_Project/Scripts/Game/GameInputController.cs` — klavye event'lerini board'a uygulayan ve `RowSubmitted` üreten input controller
- `Assets/_Project/Scripts/Game/GameInputBootstrap.cs` — `Game` sahnesinde Play sırasında input bileşenlerini otomatik kuran bootstrap
- `Assets/_Project/Scripts/Game/Editor/GameScene3CSetup.cs` — Unity Editor'de kalıcı 3C sahne wiring'i ve eksik tuş tamamlama komutu
- `Assets/_Project/Scripts/Game/Tests/Editor/GameInputStateTests.cs` — input state sınırları ve Türkçe I ayrımı testleri

### Doğrulananlar
- `Assets/_Project/Scenes/Game.unity` içinde `GameCanvas > SafeAreaPanel > Board` altında `Tile_01` ... `Tile_30` yapısı bulundu.
- `GameCanvas > SafeAreaPanel > Keyboard` altında `Row1`, `Row2`, `Row3` ve Türkçe harf tuşları bulundu.
- Sahne dosyasında kalıcı `Key_Backspace` / `Key_Enter` kaydı bulunmadı; runtime controller Play sırasında eksikse oluşturacak şekilde bırakıldı.

### Kapsam Sınırı
- Kelime doğrulama ve Wordle değerlendirme uygulanmadı.
- Save, result, stats, history ve settings sistemleri eklenmedi.
- Yeni paket veya üçüncü taraf özellik eklenmedi.
- Stage 2 Data Layer dosyaları ve testleri davranış olarak değiştirilmedi.
- Unity batchmode sahne setup komutu denendi; proje Unity Editor'de açık olduğu için `return code 1` ile tamamlanamadı.

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
