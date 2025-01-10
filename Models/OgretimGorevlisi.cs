using System;

namespace OkulYonetimSistemi.Models
{
    public class OgretimGorevlisi : BasePerson
    {
        public string Unvan { get; set; }

        public override void BilgiGoster()
        {
            Console.WriteLine($"Öğretim Görevlisi - ID: {Id}, Ad: {Ad}, Soyad: {Soyad}, Ünvan: {Unvan}");
        }
    }
}