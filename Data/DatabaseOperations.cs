using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OkulYonetimSistemi.Interfaces;

namespace OkulYonetimSistemi.Data
{
    public class DatabaseOperations<T> : IDatabaseOperations<T>
    {
        private readonly string _filePath;
        private List<T> _items;

        public DatabaseOperations(string filePath)
        {
            _filePath = filePath;
            _items = new List<T>();
            Yukle();
        }

        public void Ekle(T item)
        {
            _items.Add(item);
            Kaydet();
        }

        public List<T> HepsiniGetir()
        {
            return _items;
        }

        public void Kaydet()
        {
            var json = JsonConvert.SerializeObject(_items, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void Yukle()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _items = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
            }
        }
    }
}