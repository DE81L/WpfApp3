using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class DataService
    {
        // Объявление имен файлов для хранения данных о аптеках, лекарствах и запасах
        private const string PharmaciesFile = "pharmacies.json";
        private const string DrugsFile = "drugs.json";
        private const string StockFile = "stock.json";

        // Свойства для хранения списков аптек, лекарств и запасов
        public List<Pharmacy> Pharmacies { get; set; }
        public List<Drug> Drugs { get; set; }
        public List<Stock> Stock { get; set; }

        // Конструктор, вызывающий метод загрузки данных при создании экземпляра класса
        public DataService()
        {
            LoadData();
        }

        // Метод для загрузки данных из файлов JSON
        private void LoadData()
        {
            // Загрузка данных о аптеках, если файл существует, иначе инициализация пустым списком
            if (File.Exists(PharmaciesFile))
                Pharmacies = JsonConvert.DeserializeObject<List<Pharmacy>>(File.ReadAllText(PharmaciesFile)) ?? new List<Pharmacy>();
            else
                Pharmacies = new List<Pharmacy>();

            // Загрузка данных о лекарствах, если файл существует, иначе инициализация пустым списком
            if (File.Exists(DrugsFile))
                Drugs = JsonConvert.DeserializeObject<List<Drug>>(File.ReadAllText(DrugsFile)) ?? new List<Drug>();
            else
                Drugs = new List<Drug>();

            // Загрузка данных о запасах, если файл существует, иначе инициализация пустым списком
            if (File.Exists(StockFile))
                Stock = JsonConvert.DeserializeObject<List<Stock>>(File.ReadAllText(StockFile)) ?? new List<Stock>();
            else
                Stock = new List<Stock>();
        }

        // Метод для сохранения данных в файлы JSON
        public void SaveData()
        {
            // Сохранение данных о аптеках в файл
            File.WriteAllText(PharmaciesFile, JsonConvert.SerializeObject(Pharmacies, Formatting.Indented));
            // Сохранение данных о лекарствах в файл
            File.WriteAllText(DrugsFile, JsonConvert.SerializeObject(Drugs, Formatting.Indented));
            // Сохранение данных о запасах в файл
            File.WriteAllText(StockFile, JsonConvert.SerializeObject(Stock, Formatting.Indented));
        }

        // Метод для добавления новой аптеки в список и сохранения данных
        public void AddPharmacy(Pharmacy pharmacy)
        {
            // Валидация данных аптеки
            pharmacy.Validate();
            // Назначение уникального идентификатора аптеке
            pharmacy.PharmacyId = Pharmacies.Any() ? Pharmacies.Max(p => p.PharmacyId) + 1 : 100;
            // Добавление аптеки в список
            Pharmacies.Add(pharmacy);
            // Сохранение обновленных данных
            SaveData();
        }

        // Метод для добавления нового лекарства в список и сохранения данных
        public void AddDrug(Drug drug)
        {
            // Валидация данных лекарства
            drug.Validate();
            // Назначение уникального идентификатора лекарству
            drug.DrugId = Drugs.Any() ? Drugs.Max(d => d.DrugId) + 1 : 1;
            // Добавление лекарства в список
            Drugs.Add(drug);
            // Сохранение обновленных данных
            SaveData();
        }

        // Метод для добавления новых запасов в список и сохранения данных
        public void AddStock(Stock stock)
        {
            // Валидация данных запасов
            stock.Validate();
            // Добавление запасов в список
            Stock.Add(stock);
            // Сохранение обновленных данных
            SaveData();
        }

        // Метод для поиска антибиотиков в аптеках, работающих круглосуточно
        public List<dynamic> Find24HourAntibiotics()
        {
            // Поиск антибиотиков, доступных в круглосуточных аптеках, и сортировка по цене
            var result = from s in Stock
                         join d in Drugs on s.DrugId equals d.DrugId
                         join p in Pharmacies on s.PharmacyId equals p.PharmacyId
                         where d.Group == "антибиотик" && p.StartHour == 0 && p.EndHour == 24
                         orderby s.Price
                         select new
                         {
                             PharmacyId = p.PharmacyId,
                             PharmacyName = p.Name,
                             PharmacyAddress = p.Address,
                             DrugName = d.Name,
                             d.Dosage,
                             s.Price
                         };
            return result.ToList<dynamic>();
        }

        // Метод для анализа цен на лекарства
        public List<dynamic> AnalyzeDrugPrices()
        {
            // Группировка запасов по названию лекарства и вычисление средней цены
            var result = from s in Stock
                         join d in Drugs on s.DrugId equals d.DrugId
                         group s by d.Name into g
                         select new
                         {
                             DrugName = g.Key,
                             AveragePrice = g.Average(x => x.Price)
                         };
            return result.ToList<dynamic>();
        }
    }
}
