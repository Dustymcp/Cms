using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductsModel
/// </summary>
public class ProductsModel
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Image { get; set; }
        public int Price { get; set; }
    }

    public class Repository
    {
        DatabaseModel databaseContext = new DatabaseModel();
        public List<Product> Read()
        {
            return databaseContext.Products.ToList();
        }

        public void Create(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Insert(Product product)
        {
            var productToEdit = databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);
            productToEdit.Comment = product.Comment;
            productToEdit.Image = product.Image;
            productToEdit.Title = product.Title;
            databaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var productToDelete = databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);
            databaseContext.Products.Remove(productToDelete);
            databaseContext.SaveChanges();

        }
    }

}