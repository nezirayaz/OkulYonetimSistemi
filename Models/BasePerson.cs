using System;

namespace OkulYonetimSistemi.Models
{
    public abstract class BasePerson
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public virtual void BilgiGoster()
        {
            Console.WriteLine($"ID: {Id}, Ad: {Ad}, Soyad: {Soyad}");
        }
    }
}