# MainMenu Sahne Kurulum Kılavuzu

Bu belge, Unity Editor'de MainMenu sahnesinin nasıl oluşturulacağını adım adım açıklar.

---

## Ön Koşullar

1. **TMP Essential Resources** import edin:
   - `Window > TextMeshPro > Import TMP Essential Resources`
   - Import penceresinde tüm dosyaları kabul edin

2. **Türkçe karakter desteği:** Varsayılan LiberationSans SDF font atlası Türkçe karakterleri içermeyebilir. Nihai font atlasında aşağıdaki karakterlerin bulunması **zorunludur**:
   - Büyük: `Ç Ğ İ Ö Ş Ü`
   - Küçük: `ç ğ ı i ö ş ü`
   - Gerekirse `Window > TextMeshPro > Font Asset Creator` ile font atlas yeniden oluşturulabilir
   - Character Set olarak "Custom Characters" seçilip Türkçe alfabe eklenmelidir
   - Detaylı gereksinimler: `Assets/_Project/UI/Fonts/FONT_REQUIREMENTS.md`

3. Projenin hatasız derlendiğini doğrulayın (Console penceresinde kırmızı hata olmamalı)

---

## Adım 1 — MainMenu.unity sahnesini açın

`Assets/_Project/Scenes/MainMenu.unity`

---

## Adım 2 — Canvas Oluşturma

1. Hierarchy'de sağ tık → `UI > Canvas`
2. Adını `MainMenuCanvas` yapın
3. Canvas bileşeninde:
   - **Render Mode:** Screen Space - Overlay
4. **Canvas Scaler** bileşeninde:
   - **UI Scale Mode:** Scale With Screen Size
   - **Reference Resolution:** X=1080, Y=1920
   - **Screen Match Mode:** Match Width Or Height
   - **Match:** 0.5

---

## Adım 3 — Arka Plan

1. `MainMenuCanvas` altına sağ tık → `UI > Image`
2. Adını `Background` yapın
3. RectTransform: Stretch / Stretch (tüm kenarlar 0)
4. Image Color: `#1A1A2E` (koyu lacivert)

---

## Adım 4 — SafeArea Panel

1. `MainMenuCanvas` altına sağ tık → `UI > Panel`
2. Adını `SafeAreaPanel` yapın
3. Image bileşenini devre dışı bırakın veya alpha=0 yapın
4. RectTransform: Stretch / Stretch (tüm kenarlar 0)
5. **SafeAreaHandler** scriptini ekleyin (`Add Component > SafeAreaHandler`)

---

## Adım 5 — Header

1. `SafeAreaPanel` altına sağ tık → `Create Empty`
2. Adını `Header` yapın
3. RectTransform:
   - Anchor: Top-Stretch (sol üst + sağ üst)
   - Height: 280
   - Left/Right Padding: 0
4. **Vertical Layout Group** ekleyin:
   - Child Alignment: Middle Center
   - Spacing: 12
   - Child Force Expand Width: true
   - Child Force Expand Height: false
   - Control Child Size: Width ✓, Height ✓

### Title Text
1. `Header` altına → `UI > Text - TextMeshPro`
2. Adı: `TitleText`
3. İçerik: **DailyWord**
4. Font Size: 64
5. Font Style: Bold
6. Color: `#F5F5F5`
7. Alignment: Center
8. Preferred Height: 80

### Subtitle Text
1. `Header` altına → `UI > Text - TextMeshPro`
2. Adı: `SubtitleText`
3. İçerik: **Günlük Kelime Bulmacası**
4. Font Size: 24
5. Color: `#8B8B9E`
6. Alignment: Center
7. Preferred Height: 36

---

## Adım 6 — MainContent (Primary Button)

1. `SafeAreaPanel` altına sağ tık → `Create Empty`
2. Adını `MainContent` yapın
3. RectTransform:
   - Anchor: Middle-Stretch
   - Height: 200
   - Left: 60, Right: 60
4. **Vertical Layout Group** ekleyin:
   - Child Alignment: Middle Center
   - Control Child Size: Width ✓, Height ✓

### Primary Button
1. `MainContent` altına → `UI > Button - TextMeshPro`
2. Adı: `TodaysPuzzleButton`
3. Button Image Color: `#E2B714` (altın sarısı)
4. RectTransform: Preferred Height: 72
5. Child TMP_Text:
   - İçerik: **Bugünün Bulmacası**
   - Font Size: 28
   - Font Style: Bold
   - Color: `#1A1A2E`
   - Alignment: Center
6. Image bileşeninde köşe yuvarlaması istiyorsanız bir Rounded Sprite kullanabilirsiniz (opsiyonel)

---

## Adım 7 — Navigation (Secondary Buttons)

1. `SafeAreaPanel` altına sağ tık → `Create Empty`
2. Adını `Navigation` yapın
3. RectTransform:
   - Anchor: Bottom-Stretch
   - Height: 320
   - Left: 60, Right: 60
   - Bottom: 80
4. **Vertical Layout Group** ekleyin:
   - Spacing: 16
   - Child Alignment: Middle Center
   - Control Child Size: Width ✓, Height ✓
   - Child Force Expand Height: false

Her buton için (3 adet):

### StatsButton
1. `Navigation` altına → `UI > Button - TextMeshPro`
2. Adı: `StatsButton`
3. Button Image Color: `#2D2D44`
4. Preferred Height: 60
5. Child TMP_Text:
   - İçerik: **İstatistikler**
   - Font Size: 22
   - Color: `#C8C8D8`
   - Alignment: Center

### HistoryButton
1. Aynı adımlar, adı: `HistoryButton`
2. İçerik: **Bulmaca Geçmişi**

### SettingsButton
1. Aynı adımlar, adı: `SettingsButton`
2. İçerik: **Ayarlar**

---

## Adım 8 — MainMenuController Bağlama

1. `MainMenuCanvas` objesini seçin
2. `Add Component > MainMenuController`
3. Inspector'da alanları atayın:
   - **Todays Puzzle Button** → `TodaysPuzzleButton`
   - **Statistics Button** → `StatsButton`
   - **History Button** → `HistoryButton`
   - **Settings Button** → `SettingsButton`

---

## Adım 9 — Doğrulama

1. **Play Mode:** Sahneyi çalıştırın
   - UI ekranda görünmeli
   - "Bugünün Bulmacası" tıklandığında Game sahnesine geçmeli
   - Diğer butonlar Console'da mesaj yazdırmalı
2. **Build Settings:** `File > Build Settings`:
   - 0 = MainMenu
   - 1 = Game
3. **Test Runner:** `Window > General > Test Runner` → EditMode → Run All
   - Tüm DataLayerTests geçmeli

---

## Renk Referansı

| Kullanım | Hex | Örnek |
|----------|-----|-------|
| Arka plan | `#1A1A2E` | Koyu lacivert |
| Yüzey | `#2D2D44` | İkincil buton |
| Birincil vurgu | `#E2B714` | Ana buton |
| Ana metin | `#F5F5F5` | Başlık |
| İkincil metin | `#8B8B9E` | Alt başlık |
| İkincil buton metin | `#C8C8D8` | Buton yazıları |
| Birincil buton metin | `#1A1A2E` | Ana buton yazısı |
