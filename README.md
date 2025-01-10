# Okul Yönetim Sistemi

Bu proje, bir okul yönetim sistemi simülasyonudur. Öğrenciler, öğretim görevlileri ve dersler arasında temel yönetim işlemlerini gerçekleştirmenizi sağlar. Proje, C# dilinde geliştirilmiş bir konsol uygulamasıdır.

## Özellikler

- Öğrenci ekleme ve listeleme
- Öğretim görevlisi ekleme ve listeleme
- Ders tanımlama ve ders bilgilerini görüntüleme
- JSON dosyaları ile veri depolama

## Gereksinimler

- [.NET SDK](https://dotnet.microsoft.com/download) (8.0 veya daha yeni bir sürüm)
- `Newtonsoft.Json` NuGet paketi

## Kurulum

1. **Depoyu Klonlayın**: Projeyi yerel makinenize klonlayın veya indirin.

   ```bash
   git clone https://github.com/kullaniciadi/OkulYonetimSistemi.git
   cd OkulYonetimSistemi
   ```

2. **Gerekli Paketleri Yükleyin**: Proje dizininde `Newtonsoft.Json` paketini yükleyin.

   ```bash
   dotnet add package Newtonsoft.Json
   ```

3. **Proje Dosyasını Güncelleyin**: Proje dosyanızın (`OkulYonetimSistemi.csproj`) `TargetFramework` kısmını sisteminizde yüklü olan .NET sürümüne uygun şekilde ayarlayın. Örneğin:

   ```xml
   <TargetFramework>net8.0</TargetFramework>
   ```

4. **Projeyi Derleyin**: Projeyi derlemek için aşağıdaki komutu çalıştırın:

   ```bash
   dotnet build
   ```

5. **Uygulamayı Çalıştırın**: Uygulamayı başlatmak için:

   ```bash
   dotnet run
   ```

6. **Konsol Arayüzünü Kullananın**: Uygulama çalıştığında, konsol üzerinden öğrenci ve öğretim görevlisi ekleyebilir, ders tanımlayabilir ve ders bilgilerini görüntüleyebilirsiniz.

## Kullanım

- **Öğrenci Ekleme**: Öğrenci bilgilerini girerek yeni bir öğrenci ekleyin.
- **Öğretim Görevlisi Ekleme**: Öğretim görevlisi bilgilerini girerek yeni bir öğretim görevlisi ekleyin.
- **Ders Tanımlama**: Ders adı, kredi ve öğretim görevlisi bilgilerini girerek yeni bir ders tanımlayın.
- **Ders Bilgilerini Görüntüleme**: Tanımlanmış derslerin detaylarını görüntüleyin.

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir issue açın. Her türlü katkı ve geri bildirim memnuniyetle karşılanır.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakın.

## İletişim

Herhangi bir sorunuz veya öneriniz varsa, lütfen `nezir.ayaz@stu.pirireis.edu.tr` adresinden benimle iletişime geçin.
