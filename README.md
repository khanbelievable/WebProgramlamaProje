# Fitness Merkezi Yönetim ve Randevu Sistemi

Bu proje, ASP.NET Core MVC framework'ü kullanılarak geliştirilmiş bir "Fitness Merkezi Yönetim ve Randevu Sistemi"dir.

## Özellikler

- **Salon Yönetimi:** Birden fazla spor salonu kaydı, adres ve iletişim bilgilerinin takibi.
- **Eğitmen Yönetimi:** Eğitmenlerin uzmanlık alanları ve çalıştıkları salonlara göre yönetimi.
- **Hizmetler:** Fitness, Yoga, Pilates gibi farklı hizmetlerin süre ve fiyatlandırılması.
- **Randevu Sistemi:** Üyelerin istedikleri eğitmen ve hizmet için randevu alabilmesi, eğitmen uygunluk kontrolü.
- **Admin Paneli:** Salon, eğitmen ve hizmetlerin CRUD işlemleri, randevu onaylama mekanizması.
- **Kimlik Doğrulama:** Identity framework'ü ile Admin ve Member rolleri.
- **AI Entegrasyonu:** Kullanıcı hedeflerine göre kişiselleştirilmiş egzersiz önerileri sunan REST API destekli servis.

## Teknik Detaylar

- **Framework:** ASP.NET Core 8.0 MVC
- **ORM:** Entity Framework Core (Code First)
- **Veritabanı:** SQL Server (LocalDB)
- **Güvenlik:** ASP.NET Core Identity (Role-based Authorization)
- **Frontend:** Bootstrap 5, Razor Views, bi-icons
- **API:** RESTful API for AI Suggestions

## Kurulum ve Çalıştırma

1. Projeyi bilgisayarınıza indirin.
2. `appsettings.json` dosyasındaki bağlantı dizesini (`DefaultConnection`) kontrol edin.
3. Proje klasöründe terminali açın:
   ```bash
   dotnet build
   dotnet run
   ```
4. Veritabanı otomatik olarak oluşturulacak ve başlangıç verileri (“Seeding”) yüklenecektir.

## Varsayılan Admin Bilgileri
- **E-posta:** `g221210000@sakarya.edu.tr`
- **Şifre:** `sau`

## Proje Gereksinim Karşılaştırması (Checklist)
- [x] ASP.NET Core MVC Framework Kullanımı
- [x] REST API Entegrasyonu (AI Önerileri)
- [x] LINQ Sorguları (Filtreleme ve Listeleme)
- [x] Veritabanı CRUD Operasyonları
- [x] İstemci ve Sunucu Taraflı Doğrulamalar
- [x] AI Entegrasyonu (Workout Generator)
- [x] GitHub üzerinde en az 10 commit
- [x] Kimlik Doğrulama ve Rol Yönetimi (Admin/Member)
