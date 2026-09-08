# Font Gereksinimleri — DailyWord

## Genel Gereksinimler

- TextMeshPro (TMP) ile uyumlu olmalıdır.
- Mobil ekranlarda okunabilirlik yüksek olmalıdır.
- Lisans, mobil oyun kullanımına uygun olmalıdır.

## Türkçe Karakter Desteği (Zorunlu)

Seçilen font aşağıdaki Türkçe karakterlerin **tümünü** desteklemelidir:

### Büyük Harfler
`A B C Ç D E F G Ğ H I İ J K L M N O Ö P R S Ş T U Ü V Y Z`

### Küçük Harfler
`a b c ç d e f g ğ h ı i j k l m n o ö p r s ş t u ü v y z`

### Kritik Türkçe Harf Çiftleri

| Büyük | Küçük | Açıklama |
|-------|-------|----------|
| Ç     | ç     | Cedilla |
| Ğ     | ğ     | Breve |
| İ     | i     | Üstü noktalı I (Türkçe büyük İ) |
| I     | ı     | Noktasız I (Türkçe küçük ı) |
| Ö     | ö     | Umlaut |
| Ş     | ş     | Cedilla |
| Ü     | ü     | Umlaut |

### ⚠️ Özel Dikkat: Türkçe I/İ Sorunu

Türkçe'de `I` ve `İ` farklı harflerdir:
- `İ` (büyük, noktalı) → küçük hali `i`
- `I` (büyük, noktasız) → küçük hali `ı`

Bu, İngilizce'den farklıdır. Font ve kod tarafında bu ayrım doğru şekilde ele alınmalıdır.

**Kod tarafında:** `ToUpper()` / `ToLower()` gibi string dönüşümlerinde `CultureInfo` olarak
`tr-TR` kullanılmalı veya karakter karşılaştırmaları Türkçe kurallarına göre yapılmalıdır.

## TextMeshPro Font Asset Oluşturma Notları

1. Font dosyası (.ttf veya .otf) projeye eklendikten sonra TMP Font Asset olarak dönüştürülmelidir.
2. Font Atlas oluşturulurken **Custom Character Set** kullanılarak tüm Türkçe karakterler dahil edilmelidir.
3. Atlas çözünürlüğü mobil performans ile okunabilirlik arasında dengelenmelidir (512x512 veya 1024x1024 önerilir).
4. SDF (Signed Distance Field) rendering modunun kullanılması tavsiye edilir.

## Durum

> **Henüz kesin bir font seçimi yapılmamıştır.**
> Bu dosya, font seçimi yapılırken referans olarak kullanılmalıdır.
