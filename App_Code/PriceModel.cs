using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PriceModel
/// </summary>
public class PriceModel
{
    public static DatabaseModel _databaseContext = new DatabaseModel();
    public class Price
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
       
    }

    public class Repository
    {
        public List<Price> ReadPrices()
        {
            return _databaseContext.Prices.ToList();
        }

        public void CreatePrice(Price price)
        {


            _databaseContext.Prices.Add(price);
            _databaseContext.SaveChanges();
        }

        public void DeletePrice(Price price)
        {
            var PriceToDelete = ReadPrices().FirstOrDefault(p => p.Id == price.Id);
            _databaseContext.Prices.Remove(PriceToDelete);
        }

        public void UpdatePrice(Price price)
        {
            var PriceToUpdate = ReadPrices().FirstOrDefault(p => p.Id == price.Id);
            PriceToUpdate.Product = price.Product;
            PriceToUpdate.Amount = price.Amount;
            
            _databaseContext.SaveChanges();
        }
    }
}