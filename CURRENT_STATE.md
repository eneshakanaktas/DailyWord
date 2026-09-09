# CURRENT_STATE.md — DailyWord Mevcut Proje Durumu

**Son güncelleme:** 2026-09-09

---

## Genel Durum

Proje, **Aşama 1 — Temel Altyapı** ve **Aşama 2 — Veri Katmanı** tamamlanmıştır.
**Aşama 3A — Ana Menü ve UI Temeli** scriptleri oluşturulmuş, sahne kurulumu Unity Editor'de yapılmayı beklemektedir.

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
- `Assets/_Project/Scenes/MainMenu.unity` — Temel URP 2D sahnesi (Canvas henüz Editor'de oluşturulacak)
- `Assets/_Project/Scenes/Game.unity` — Boş temel URP 2D sahnesi
- Build sırası: 0=MainMenu, 1=Game

### Sürüm Kontrolü
- `.gitignore` oluşturuldu (GitHub Unity şablonu)

### Dokümantasyon
- AGENTS.md, PROJECT_PLAN.md, ARCHITECTURE.md, CURRENT_STATE.md
- DECISIONS.md, TODO.md, CHANGELOG.md
- FONT_REQUIREMENTS.md (Assets/_Project/UI/Fonts/)
- MAINMENU_SETUP.md (Assets/_Project/Scenes/)

### Aşama 2 — Veri Katmanı
- `Assets/_Project/Data/WordLists/turkish_words.json` geliştirme kelime listesi oluşturuldu.
- JSON veri formatı `version` ve sıralı `words` alanlarıyla belirlendi.
- Türkçe karakter ve `I / İ / ı / i` ayrımı için `TurkishWordRules` oluşturuldu.
- Kaynak kelimeleri doğrulayan `WordList` ve `WordListLoader` oluşturuldu.
- Tarih ve liste sürümüne göre deterministik `DailyPuzzleSelector` oluşturuldu.
- Veri katmanı testleri `Assets/_Project/Scripts/Data/Tests/Editor/` altında oluşturuldu.
- Save, UI, GameManager ve Wordle değerlendirme sistemi bu aşamada uygulanmadı.

### Aşama 3A — Ana Menü ve UI Temeli (Scriptler Hazır)
- `SceneNavigator` (Core) — statik sahne geçiş utility'si
- `MainMenuController` (UI) — Ana menü buton yönetimi ve navigasyon
- `SafeAreaHandler` (UI) — Mobil safe area adaptasyonu
- `UIColors` (UI) — Premium renk paleti sabitleri
- `MAINMENU_SETUP.md` — Unity Editor'de sahne kurulum kılavuzu
- Canvas hiyerarşisi ve UI bileşenleri henüz Unity Editor'de oluşturulacak

---

## Mevcut Olmayan / Uygulanmamış Öğeler

- ❌ MainMenu sahnesinde Canvas / UI bileşenleri (Editor'de oluşturulacak)
- ❌ TMP Essential Resources import'u (Editor gerektirir)
- ❌ Oyun mekaniği (kelime tahmini, değerlendirme)
- ❌ Üretim kapsamındaki tam kelime listesi
- ❌ Kayıt/yükleme sistemi
- ❌ GameManager veya herhangi bir runtime bootstrap
- ❌ Font asset'leri (sadece gereksinimler belgelendi)
- ❌ Animasyonlar
- ❌ Ses efektleri
- ❌ İstatistikler, Bulmaca Geçmişi, Ayarlar ekranları

---

## Aşama 3A Sınırı

- UI scriptleri oluşturulmuş ve derlemeye hazırdır.
- Sahne kurulumu Unity Editor'de `MAINMENU_SETUP.md` kılavuzuna göre yapılmalıdır.
- İstatistikler, Geçmiş ve Ayarlar butonları placeholder olarak Debug.Log kullanır.
- Wordle tahtası, klavye ve oyun mantığı bu aşamada uygulanmamıştır.

---

## Korunan Yapılandırmalar

- URP 17.6.0 pipeline ayarları (`Assets/Settings/`)
- Input System ayarları
- UGUI paketi (TMP dahil)
- Test Framework
- Tüm `com.unity.modules.*` paketleri
