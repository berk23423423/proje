# Veritabanı Kurulum Rehberi

## Adım 1: SQL Server Express İndirme ve Kurulum

### 1.1 SQL Server Express İndirme
1. Microsoft'un resmi sitesine gidin: https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads
2. **SQL Server Express** seçeneğini seçin (ücretsiz)
3. "İndir" butonuna tıklayın
4. İndirme tamamlandıktan sonra kurulum dosyasını çalıştırın

### 1.2 SQL Server Express Kurulumu
1. Kurulum sihirbazında **"Basic"** seçeneğini seçin (en basit kurulum)
2. Lisans koşullarını kabul edin
3. Kurulum konumunu seçin (varsayılan kalabilir)
4. **"Install"** butonuna tıklayın
5. Kurulum tamamlanana kadar bekleyin (5-10 dakika sürebilir)

**Önemli:** Kurulum sırasında SQL Server instance adını not edin. Genellikle:
- `(local)\SQLEXPRESS` veya
- `BILGISAYAR_ADI\SQLEXPRESS` şeklindedir.

## Adım 2: SQL Server Management Studio (SSMS) Kurulumu

### 2.1 SSMS İndirme
1. Bu linke gidin: https://aka.ms/ssmsfullsetup
2. İndirme başladıktan sonra kurulum dosyasını çalıştırın
3. Kurulum sihirbazını takip edin
4. **"Install"** butonuna tıklayın

### 2.2 SSMS'yi Açma
1. Başlat menüsünden **"SQL Server Management Studio"** arayın
2. Uygulamayı açın
3. İlk açılışta şu bilgileri girin:
   - **Server type:** Database Engine
   - **Server name:** `(local)\SQLEXPRESS` veya kurulum sırasında not ettiğiniz instance adı
   - **Authentication:** Windows Authentication
4. **"Connect"** butonuna tıklayın

## Adım 3: Veritabanı Oluşturma

### 3.1 SQL Script'i Çalıştırma
1. SSMS'de sol tarafta **"Databases"** klasörüne sağ tıklayın
2. **"New Query"** seçeneğini seçin
3. Proje klasörünüzdeki **`database_script.sql`** dosyasını açın
4. Tüm içeriği kopyalayın (Ctrl+A, Ctrl+C)
5. SSMS'deki Query penceresine yapıştırın (Ctrl+V)
6. **"Execute"** butonuna tıklayın (F5 tuşu da çalışır)
7. Alt kısımda "Command(s) completed successfully" mesajını görmelisiniz

### 3.2 Veritabanını Kontrol Etme
1. Sol tarafta **"Databases"** klasörünü genişletin
2. **"yemekhanemenusıstemı"** veritabanını görmelisiniz
3. Veritabanına tıklayıp **"Tables"** klasörünü açın
4. Şu tabloları görmelisiniz:
   - `categories`
   - `orders`
   - `products`
   - `suppliers`
   - `users`
   - `warehouse_entries`
   - `warehouse_exits`
   - `warehouses`

### 3.3 Test Verilerini Ekleme (Opsiyonel)
1. SSMS'de **"yemekhanemenusıstemı"** veritabanını seçin
2. **"New Query"** açın
3. Proje klasörünüzdeki **`test_data.sql`** dosyasını açın
4. Tüm içeriği kopyalayın (Ctrl+A, Ctrl+C)
5. SSMS'deki Query penceresine yapıştırın (Ctrl+V)
6. **"Execute"** butonuna tıklayın (F5 tuşu da çalışır)
7. Alt kısımda "Command(s) completed successfully" mesajını görmelisiniz

## Adım 4: Connection String'i Güncelleme

### 4.1 SQL Server Instance Adını Bulma
1. SSMS'de bağlandığınız server adına bakın (üst kısımda görünür)
2. Genellikle şu formattadır: `BILGISAYAR_ADI\SQLEXPRESS`

### 4.2 App.config Dosyasını Güncelleme
1. Proje klasörünüzde **`yemekhanemenusıstemı/App.config`** dosyasını açın
2. Şu satırı bulun:
   ```xml
   <add name="DefaultConnection" 
        connectionString="Data Source=FURKAN\SQLEXPRESS;..." />
   ```
3. `Data Source=` kısmındaki değeri kendi SQL Server instance adınızla değiştirin
4. Örnekler:
   
   Eğer SQL Server instance adınız `(local)\SQLEXPRESS` ise:
   ```xml
   <add name="DefaultConnection" 
        connectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=yemekhanemenusıstemı;Integrated Security=True;Encrypt=False;TrustServerCertificate=True" 
        providerName="System.Data.SqlClient" />
   ```
   
   Eğer SQL Server instance adınız `BILGISAYAR_ADINIZ\SQLEXPRESS` ise:
   ```xml
   <add name="DefaultConnection" 
        connectionString="Data Source=BILGISAYAR_ADINIZ\SQLEXPRESS;Initial Catalog=yemekhanemenusıstemı;Integrated Security=True;Encrypt=False;TrustServerCertificate=True" 
        providerName="System.Data.SqlClient" />
   ```

**ÖNEMLİ:** 
- Veritabanı adı `yemekhanemenusıstemı` olmalı (Türkçe 'ı' karakteri ile)
- Connection string'i güncelledikten sonra dosyayı kaydedin (Ctrl+S)

## Adım 5: Test Kullanıcısı Ekleme (Opsiyonel)

Uygulamayı test etmek için bir kullanıcı ekleyebilirsiniz:

1. SSMS'de **"yemekhanemenusıstemı"** veritabanını seçin
2. **"New Query"** açın
3. Şu SQL kodunu çalıştırın:
   ```sql
   INSERT INTO users (username, password, status, date_created)
   VALUES ('admin', 'admin123', 'Active', GETDATE());
   ```
4. **"Execute"** butonuna tıklayın

**Not:** Gerçek uygulamada şifreler hash'lenmelidir, ancak test için bu şekilde bırakabilirsiniz.

## Adım 6: Visual Studio Gereksinimleri

### 6.1 Visual Studio Kurulumu
1. Visual Studio 2019 veya üzeri sürümü indirin (Community Edition ücretsiz)
2. İndirme: https://visualstudio.microsoft.com/tr/downloads/
3. Kurulum sırasında **".NET desktop development"** iş yükünü seçin
4. Kurulum tamamlandıktan sonra Visual Studio'yu açın

### 6.2 Projeyi Açma
1. Visual Studio'da **File > Open > Project/Solution**
2. Proje klasöründeki **`yemekhanemenusıstemı.sln`** dosyasını seçin
3. **"Open"** butonuna tıklayın

### 6.3 Projeyi Derleme
1. Visual Studio'da **Build > Build Solution** (veya Ctrl+Shift+B)
2. Alt kısımda **"Build succeeded"** mesajını görmelisiniz
3. Eğer hata varsa, hata mesajlarını kontrol edin

## Adım 7: Uygulamayı Çalıştırma

1. Visual Studio'da **Debug > Start Debugging** (veya F5 tuşu)
2. Uygulama açılacaktır
3. Eğer test verilerini eklediyseniz:
   - Kullanıcı adı: `admin`
   - Şifre: `admin123`
4. Eğer test verilerini eklemediyseniz:
   - **"Sign Up"** butonuna tıklayın
   - Yeni bir kullanıcı oluşturun
   - Oluşturduğunuz kullanıcı ile giriş yapın

## Sorun Giderme

### SQL Server'a Bağlanamıyorum
- SQL Server servisinin çalıştığından emin olun:
  1. Windows tuşu + R
  2. `services.msc` yazın
  3. **"SQL Server (SQLEXPRESS)"** servisini bulun
  4. Sağ tıklayıp **"Start"** seçin

### "Cannot open database" Hatası
- Veritabanının oluşturulduğundan emin olun
- Connection string'deki veritabanı adının doğru olduğunu kontrol edin

### "Login failed" Hatası
- Windows Authentication kullandığınızdan emin olun
- SQL Server'ın Windows Authentication modunda olduğundan emin olun

### "Connection string not found" Hatası
- App.config dosyasının proje klasöründe olduğundan emin olun
- App.config dosyasında connectionStrings bölümünün doğru olduğunu kontrol edin
- Projeyi temizleyip yeniden derleyin:
  - Build > Clean Solution
  - Build > Rebuild Solution

### Ürünler/Kategoriler Görünmüyor
- Veritabanında ürünlerin status değerinin "Available" olduğunu kontrol edin:
  ```sql
  SELECT * FROM products WHERE status = 'Available';
  ```
- Kategorilerin status değerinin "Active" olduğunu kontrol edin:
  ```sql
  SELECT * FROM categories WHERE status = 'Active';
  ```
- Test verilerini ekleyin (Adım 3.3)

### Connection String Formatı
Eğer farklı bir SQL Server kullanıyorsanız:
- **Local SQL Server:** `Data Source=(local);...`
- **Named Instance:** `Data Source=BILGISAYAR_ADI\INSTANCE_ADI;...`
- **Default Instance:** `Data Source=BILGISAYAR_ADI;...`

## Adım 8: Başka Bir Bilgisayara Taşıma

Projeyi başka bir bilgisayara taşımak için:

1. **Tüm proje klasörünü** yeni bilgisayara kopyalayın
2. Yeni bilgisayarda **SQL Server Express** ve **SSMS** kurun (Adım 1-2)
3. **Veritabanını oluşturun** (Adım 3)
4. **Connection string'i güncelleyin** (Adım 4)
5. **Visual Studio'da projeyi açın** (Adım 6)
6. **Projeyi derleyin ve çalıştırın** (Adım 7)

**ÖNEMLİ:** 
- Proje klasörü yolunda Türkçe karakter olmaması önerilir
- Her bilgisayarda connection string'i o bilgisayarın SQL Server instance adına göre güncellemeniz gerekir

## Önemli Notlar

- SQL Server Express ücretsizdir ve ticari kullanım için uygundur
- Integrated Security=True kullanıldığı için Windows kullanıcı adınızla otomatik giriş yapılır
- Veritabanı dosyaları genellikle şu konumda bulunur: `C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\`
- Düzenli yedekleme yapmanız önerilir
- Proje klasörü yolunda Türkçe karakter olmaması önerilir
- Connection string'deki veritabanı adı `yemekhanemenusıstemı` olmalı (Türkçe 'ı' karakteri ile)
- Her bilgisayarda connection string'i o bilgisayarın SQL Server instance adına göre güncellemeniz gerekir

## Detaylı Kurulum Rehberi

Daha detaylı bilgi için proje klasöründeki **`BENİOKU.txt`** dosyasını okuyun.

