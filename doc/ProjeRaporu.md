# WEB PROGRAMLAMA DERSİ PROJE ÖDEVİ
## FİTZONE: SPOR SALONU YÖNETİM VE RANDEVU SİSTEMİ

---

### ÖĞRENCİ BİLGİLERİ
- **Ad Soyad:** Kaan Yılmaz
- **Öğrenci No:** B221210077
- **Ders Grubu:** 1C
- **Proje Tarihi:** Aralık 2024
- **GitHub:** [https://github.com/kaanyilmaz/WebProgramlamaProje](https://github.com/kaanyilmaz/WebProgramlamaProje)

---

### 1. PROJE ÖZETİ VE AMACI
Bu çalışma, modern bir fitness merkezinin dijital dönüşümünü temsil eden kapsamlı bir web uygulamasıdır. Projenin ana amacı, **ASP.NET Core MVC** mimarisi üzerinde; kullanıcıların antrenörlerden kolayca randevu alabildiği, kişiselleştirilmiş AI destekli antrenman planları oluşturabildiği ve salon yönetiminin tek bir merkezden sağlandığı bir platform oluşturmaktır.

### 2. TEKNİK MİMARİ VE KULLANILAN TEKNOLOJİLER
Proje, katmanlı bir yapıda ve modern web standartlarına uygun olarak geliştirilmiştir:
- **Backend:** C#, .NET 8.0 (LTS), Entity Framework Core
- **Veritabanı:** SQL Server (Production) / SQLite (Development Fallback)
- **Frontend:** HTML5, CSS3, JavaScript (Asenkron API çağrıları için Fetch API)
- **Tasarım:** Özgün "Cyberpunk/Neon" teması, Bootstrap 5 ve Asimetrik Layout.
- **Güvenlik:** ASP.NET Core Identity (Role-based Authorization: Admin/User).

### 3. ÖNE ÇIKAN MODÜLLER VE KABİLİYETLER

#### 3.1. Yapay Zeka (AI) Entegrasyonu
OpenRouter API (Google Gemini/Meta Llama) kullanılarak kullanıcıların; yaş, boy, kilo ve vücut tipi (Ektomorf, Mezomorf, Endomorf) bilgilerine göre tamamen kişiye özel haftalık egzersiz ve beslenme programı oluşturulmaktadır. Bu modül, ödevdeki "Yapay Zeka Entegrasyonu" şartını %100 karşılamaktadır.

#### 3.2. RESTful API ve LINQ Raporlama
`TrainersApiController` katmanı aracılığıyla dış servislerin eğitmen verilerine erişimi sağlanmıştır. API üzerinde **LINQ** sorguları kullanılarak; uzmanlık alanına göre filtreleme ve salon bazlı listeleme gibi gelişmiş sorgulama yetenekleri sunulmaktadır.

#### 3.3. Akıllı Randevu Sistemi
Randevu alma sırasında sistem, antrenörün müsaitlik saatlerini ve daha önce alınmış randevuları kontrol ederek çakışmaları (Validation) otomatik olarak önler.

### 4. VERİTABANI MODELİ (ER DİYAGRAMI ÖZETİ)
- **ApplicationUser:** Kimlik doğrulama ve kullanıcı profili.
- **Gym (Spor Salonu):** Salon bilgileri, harita/resim ve çalışma saatleri.
- **Trainer (Eğitmen):** Uzmanlık, deneyim yılı ve müsaitlik verileri.
- **Appointment (Randevu):** Üye-Eğitmen eşleşmesi ve hizmet detayları.

### 5. SONUÇ
FitZone projesi, bir spor salonunun ihtiyaç duyabileceği tüm temel (CRUD) ve ileri seviye (AI, API) fonksiyonları tek bir potada eritmektedir. Kullanıcı dostu ve estetik arayüzü ile yüksek bir kullanıcı deneyimi hedeflenmiştir.

---
*Bu rapor, Markdown formatından PDF'e dönüştürülmek üzere optimize edilmiştir.*
