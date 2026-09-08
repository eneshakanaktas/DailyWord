# CURRENT_STATE.md — DailyWord Mevcut Proje Durumu

**Son güncelleme:** 2026-09-08

---

## Genel Durum

Proje, **Aşama 1 — Temel Altyapı** kurulumunu tamamlamıştır.
Henüz oyun mekaniği, UI veya veri sistemi uygulanmamıştır.

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

---

## Mevcut Olmayan / Uygulanmamış Öğeler

- ❌ Oyun mekaniği (kelime tahmini, değerlendirme)
- ❌ UI bileşenleri (klavye, tahta, menüler)
- ❌ Kelime listesi veya veri dosyaları
- ❌ Kayıt/yükleme sistemi
- ❌ GameManager veya herhangi bir runtime script
- ❌ Font asset'leri (sadece gereksinimler belgelendi)
- ❌ Animasyonlar
- ❌ Ses efektleri

---

## Korunan Yapılandırmalar

- URP 17.6.0 pipeline ayarları (`Assets/Settings/`)
- Input System ayarları
- UGUI paketi
- Test Framework
- Tüm `com.unity.modules.*` paketleri
