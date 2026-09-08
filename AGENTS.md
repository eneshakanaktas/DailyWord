# AGENTS.md — DailyWord Proje Kuralları

Bu dosya, DailyWord projesinde çalışan tüm AI kodlama ajanları (Antigravity, Cursor vb.)
için geçerli olan mühendislik kurallarını içerir.

---

## Proje Tanımı

- **Oyun:** Türkçe günlük 5 harfli kelime bulmacası (Wordle tarzı)
- **Motor:** Unity 6.6 (6000.6.0f1)
- **Render Pipeline:** Universal Render Pipeline (URP) 17.6.0, 2D Renderer
- **Hedef Platform:** Android (başlangıç)
- **Dil:** Oyun içi dil Türkçe

---

## Genel Kurallar

1. **Kod tanımlayıcıları (identifier) standart İngilizce** olmalıdır (sınıf adları, metot adları, değişkenler).
2. **Dokümanlar ve ajan iletişimi Türkçe** olmalıdır.
3. **Mevcut dosyaları değiştirmeden önce mutlaka inceleyin.** Dosya yapısını ve içeriğini anlayın.
4. **Gereksiz karmaşıklıktan kaçının.** Basit ve anlaşılır çözümler tercih edin.
5. **Gelecek sistemleri erken oluşturmayın.** Henüz ihtiyaç duyulmayan modülleri, servisleri veya altyapıları eklemeyin.
6. **Test yapılmadıysa yapıldığını iddia etmeyin.** Gerçekte yürütülmeyen testleri "başarılı" olarak raporlamayın.
7. **Bulmaca verileri oyun kodundan ayrı tutulmalıdır.** Kelime listeleri, oyun mantığı içine hard-code edilmemelidir.
8. **Kalıcı oyuncu verileri (save) geçici runtime durumundan (state) ayrı tutulmalıdır.**
9. **Artımlı geliştirme yapın.** Her seferinde küçük, doğrulanabilir adımlar atın.

---

## Ajan İş Birliği Kuralları

- Bu proje üzerinde **hem Antigravity hem Cursor** kullanılabilir.
- Her iki ajan da değişiklik yapmadan önce mevcut dosyaları **incelemeli** ve proje durumunu **anlamalıdır**.
- Mimari bağlam, **konuşma geçmişine değil proje dosyalarına** dayandırılmalıdır.
- Önemli kararlar `DECISIONS.md` dosyasında belgelenmelidir.
- Güncel proje durumu `CURRENT_STATE.md` dosyasında tutulmalıdır.
- Planlanan sonraki adımlar `TODO.md` dosyasında listelenmeli
dir.
- Yapılan değişiklikler `CHANGELOG.md` dosyasına kaydedilmelidir.

---

## Teknik Kısıtlamalar

- Firebase, authentication, multiplayer, analytics, reklam, IAP, online leaderboard veya backend
  sistemleri **bu aşamada eklenmemelidir**.
- İmzalama (signing) yapılandırması veya release keystore oluşturulmamalıdır.
- Gereksiz üçüncü taraf paketler yüklenmemelidir.
- URP yapılandırması korunmalıdır.
- Input System, UGUI, Test Framework korunmalıdır.

---

## Dosya Yapısı

Oyun dosyaları `Assets/_Project/` altında tutulur. Detaylı yapı için `ARCHITECTURE.md` dosyasına bakın.
