using System;
using System.Collections.Generic;
using System.Linq;
using OkulYonetimSistemi.Data;
using OkulYonetimSistemi.Models;

namespace OkulYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Veri dosyalarının yolları
            string dataPath = "DataFiles";
            Directory.CreateDirectory(dataPath); // DataFiles klasörü yoksa oluşturur

            string ogrenciDosya = System.IO.Path.Combine(dataPath, "ogrenciler.json");
            string ogretimGorevlisiDosya = System.IO.Path.Combine(dataPath, "ogretimgorevlileri.json");
            string dersDosya = System.IO.Path.Combine(dataPath, "dersler.json");

            // Veri operasyonları
            var ogrenciOps = new DatabaseOperations<Ogrenci>(ogrenciDosya);
            var ogretimGorevlisiOps = new DatabaseOperations<OgretimGorevlisi>(ogretimGorevlisiDosya);
            var dersOps = new DatabaseOperations<Ders>(dersDosya);

            // Ders verilerini yükle
            var dersler = dersOps.HepsiniGetir();

            while (true)
            {
                Console.WriteLine("==== Öğrenci ve Ders Yönetim Sistemi ====");
                Console.WriteLine("1. Öğrenci Ekle");
                Console.WriteLine("2. Öğretim Görevlisi Ekle");
                Console.WriteLine("3. Ders Tanımla");
                Console.WriteLine("4. Ders Bilgilerini Göster");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapınız: ");
                var secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        EkleOgrenci(ogrenciOps);
                        break;
                    case "2":
                        EkleOgretimGorevlisi(ogretimGorevlisiOps);
                        break;
                    case "3":
                        DersTanimla(ogretimGorevlisiOps.HepsiniGetir(), ogrenciOps.HepsiniGetir(), dersler);
                        dersOps.Kaydet();
                        break;
                    case "4":
                        DersBilgisiGoster(dersler);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }

                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void EkleOgrenci(DatabaseOperations<Ogrenci> ogrenciOps)
        {
            Console.WriteLine("==== Öğrenci Ekle ====");
            var ogrenci = new Ogrenci();
            ogrenci.Id = ogrenciOps.HepsiniGetir().Count > 0 ? ogrenciOps.HepsiniGetir().Max(o => o.Id) + 1 : 1;
            Console.Write("Ad: ");
            ogrenci.Ad = Console.ReadLine();
            Console.Write("Soyad: ");
            ogrenci.Soyad = Console.ReadLine();
            Console.Write("Numara: ");
            ogrenci.Numara = Console.ReadLine();

            ogrenciOps.Ekle(ogrenci);
            Console.WriteLine("Öğrenci eklendi.");
        }

        static void EkleOgretimGorevlisi(DatabaseOperations<OgretimGorevlisi> ogretimOps)
        {
            Console.WriteLine("==== Öğretim Görevlisi Ekle ====");
            var ogretim = new OgretimGorevlisi();
            ogretim.Id = ogretimOps.HepsiniGetir().Count > 0 ? ogretimOps.HepsiniGetir().Max(o => o.Id) + 1 : 1;
            Console.Write("Ad: ");
            ogretim.Ad = Console.ReadLine();
            Console.Write("Soyad: ");
            ogretim.Soyad = Console.ReadLine();
            Console.Write("Ünvan: ");
            ogretim.Unvan = Console.ReadLine();

            ogretimOps.Ekle(ogretim);
            Console.WriteLine("Öğretim görevlisi eklendi.");
        }

        static void DersTanimla(List<OgretimGorevlisi> ogretimGorevlileri, List<Ogrenci> ogrenciler, List<Ders> dersler)
        {
            Console.WriteLine("==== Ders Tanımlama ====");
            var ders = new Ders();
            ders.DersId = dersler.Count > 0 ? dersler.Max(d => d.DersId) + 1 : 1;
            Console.Write("Ders Adı: ");
            ders.DersAdi = Console.ReadLine();
            Console.Write("Kredi: ");
            if (int.TryParse(Console.ReadLine(), out int kredi))
            {
                ders.Kredi = kredi;
            }
            else
            {
                Console.WriteLine("Geçersiz kredi değeri. Ders eklenmedi.");
                return;
            }

            // Öğretim görevlisi seçimi
            Console.WriteLine("Öğretim Görevlisi Seçiniz:");
            foreach (var ogretim in ogretimGorevlileri)
            {
                Console.WriteLine($"{ogretim.Id}. {ogretim.Ad} {ogretim.Soyad} ({ogretim.Unvan})");
            }
            Console.Write("ID Giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int ogretimId))
            {
                var ogretimGorevlisi = ogretimGorevlileri.FirstOrDefault(o => o.Id == ogretimId);
                if (ogretimGorevlisi != null)
                {
                    ders.OgretimGorevlisi = ogretimGorevlisi;
                }
                else
                {
                    Console.WriteLine("Öğretim görevlisi bulunamadı. Ders eklenmedi.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz ID. Ders eklenmedi.");
                return;
            }

            // Öğrenci kayıt etme
            Console.WriteLine("Öğrencileri derse kayıt etmek ister misiniz? (E/H)");
            var cevap = Console.ReadLine()?.ToUpper();
            if (cevap == "E")
            {
                while (true)
                {
                    Console.WriteLine("Mevcut Öğrenciler:");
                    foreach (var ogr in ogrenciler)
                    {
                        Console.WriteLine($"{ogr.Id}. {ogr.Ad} {ogr.Soyad} - Numara: {ogr.Numara}");
                    }
                    Console.Write("Kayıt etmek istediğiniz öğrenci ID'sini girin (çıkmak için 0): ");
                    if (int.TryParse(Console.ReadLine(), out int ogrenciId))
                    {
                        if (ogrenciId == 0)
                            break;

                        var ogrenci = ogrenciler.FirstOrDefault(o => o.Id == ogrenciId);
                        if (ogrenci != null)
                        {
                            if (!ders.KayitliOgrenciler.Contains(ogrenci))
                            {
                                ders.KayitliOgrenciler.Add(ogrenci);
                                Console.WriteLine("Öğrenci eklendi.");
                            }
                            else
                            {
                                Console.WriteLine("Öğrenci zaten derse kayıtlı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci bulunamadı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ID.");
                    }
                }
            }

            dersler.Add(ders);
            Console.WriteLine("Ders tanımlandı.");
        }

        static void DersBilgisiGoster(List<Ders> dersler)
        {
            Console.WriteLine("==== Ders Bilgilerini Göster ====");
            if (dersler.Count == 0)
            {
                Console.WriteLine("Henüz tanımlanmış ders yok.");
                return;
            }

            foreach (var ders in dersler)
            {
                ders.BilgiGoster();
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}