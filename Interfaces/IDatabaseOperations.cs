using System.Collections.Generic;

namespace OkulYonetimSistemi.Interfaces
{
    public interface IDatabaseOperations<T>
    {
        void Ekle(T item);
        List<T> HepsiniGetir();
        void Kaydet();
        void Yukle();
    }
}