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
            pharmacy.PharmacyId = Pharmacies.Any() ? Pharmacies.Max(p => p.PharmacyId) + 1 : 1;
            Pharmacies.Add(pharmacy);
            SaveData();
        }

        public void AddDrug(Drug drug)
        {
            drug.DrugId = Drugs.Any() ? Drugs.Max(d => d.DrugId) + 1 : 1;
            Drugs.Add(drug);
            SaveData();
        }

        public void AddStock(Stock stock)
        {
            Stock.Add(stock);
            SaveData();
        }
    }
}
