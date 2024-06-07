using System.Collections.Generic;
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

        public List<Pharmacy> Pharmacies { get; set; }
        public List<Drug> Drugs { get; set; }
        public List<Stock> Stock { get; set; }

        public DataService()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(PharmaciesFile))
                Pharmacies = JsonConvert.DeserializeObject<List<Pharmacy>>(File.ReadAllText(PharmaciesFile)) ?? new List<Pharmacy>();
            else
                Pharmacies = new List<Pharmacy>();

            if (File.Exists(DrugsFile))
                Drugs = JsonConvert.DeserializeObject<List<Drug>>(File.ReadAllText(DrugsFile)) ?? new List<Drug>();
            else
                Drugs = new List<Drug>();

            if (File.Exists(StockFile))
                Stock = JsonConvert.DeserializeObject<List<Stock>>(File.ReadAllText(StockFile)) ?? new List<Stock>();
            else
                Stock = new List<Stock>();
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
            pharmacy.PharmacyId = Pharmacies.Any() ? Pharmacies.Max(p => p.PharmacyId) + 1 : 100;
            Pharmacies.Add(pharmacy);
            SaveData();
        }

        public void AddDrug(Drug drug)
        {
            drug.Validate();
            drug.DrugId = Drugs.Any() ? Drugs.Max(d => d.DrugId) + 1 : 1;
            Drugs.Add(drug);
            SaveData();
        }

        public void AddStock(Stock stock)
        {
            stock.Validate();
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
