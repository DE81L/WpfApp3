using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class DataService
    {
        private const string PharmaciesFile = "pharmacies.json";
        private const string DrugsFile = "drugs.json";
        private const string StockFile = "stock.json";

        public ObservableCollection<Pharmacy> Pharmacies { get; set; }
        public ObservableCollection<Drug> Drugs { get; set; }
        public ObservableCollection<Stock> Stock { get; set; }

        public DataService()
        {
            Pharmacies = new ObservableCollection<Pharmacy>();
            Drugs = new ObservableCollection<Drug>();
            Stock = new ObservableCollection<Stock>();
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(PharmaciesFile))
            {
                var pharmacies = JsonConvert.DeserializeObject<List<Pharmacy>>(File.ReadAllText(PharmaciesFile)) ?? new List<Pharmacy>();
                Pharmacies = new ObservableCollection<Pharmacy>(pharmacies);
            }
            else
            {
                Pharmacies = new ObservableCollection<Pharmacy>();
            }

            if (File.Exists(DrugsFile))
            {
                var drugs = JsonConvert.DeserializeObject<List<Drug>>(File.ReadAllText(DrugsFile)) ?? new List<Drug>();
                Drugs = new ObservableCollection<Drug>(drugs);
            }
            else
            {
                Drugs = new ObservableCollection<Drug>();
            }

            if (File.Exists(StockFile))
            {
                var stock = JsonConvert.DeserializeObject<List<Stock>>(File.ReadAllText(StockFile)) ?? new List<Stock>();
                Stock = new ObservableCollection<Stock>(stock);
            }
            else
            {
                Stock = new ObservableCollection<Stock>();
            }
        }

        public void SaveData()
        {
            File.WriteAllText(PharmaciesFile, JsonConvert.SerializeObject(Pharmacies, Formatting.Indented));
            File.WriteAllText(DrugsFile, JsonConvert.SerializeObject(Drugs, Formatting.Indented));
            File.WriteAllText(StockFile, JsonConvert.SerializeObject(Stock, Formatting.Indented));
        }

        public void AddPharmacy(Pharmacy pharmacy)
        {
            pharmacy.Validate();

            if (pharmacy.PharmacyId == 0)
            {
                pharmacy.PharmacyId = Pharmacies.Any() ? Pharmacies.Max(p => p.PharmacyId) + 1 : 100;
            }

            Pharmacies.Add(pharmacy);
            SaveData();
        }

        public void AddDrug(Drug drug)
        {
            drug.Validate();

            if (drug.DrugId == 0)
            {
                drug.DrugId = Drugs.Any() ? Drugs.Max(d => d.DrugId) + 1 : 1;
            }

            Drugs.Add(drug);
            SaveData();
        }

        public void AddStock(Stock stock)
        {
            stock.Validate();

            if (stock.StockId == 0)
            {
                stock.StockId = Stock.Any() ? Stock.Max(s => s.StockId) + 1 : 1;
            }

            Stock.Add(stock);
            SaveData();
        }

        public List<dynamic> Find24HourAntibiotics()
        {
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

        public List<dynamic> AnalyzeDrugPrices()
        {
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
