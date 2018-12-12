using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ProductRepository
    {
        private ShopListContext db = new ShopListContext();

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string msg = $"Ups, fallo: {e.Message}";
                throw new Exception(msg);
            }
            return product;
        }
        public void DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }
        
        public void Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}