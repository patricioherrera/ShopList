using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ShopListRepository
    {
        private ShopListContext db = new ShopListContext();

        public IEnumerable<ShopList> GetShopLists()
        {
            return db.ShopLists.ToList();
        }

        public ShopList GetShopListById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            ShopList shopList = db.ShopLists.Find(id);
            if (shopList == null)
            {
                return null;
            }
            return shopList;
        }

        public ShopList AddShopList(ShopList shopList)
        {
            try
            {
                db.ShopLists.Add(shopList);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string msg = $"Ups, fallo: {e.Message}";
                throw new Exception(msg);
            }
            return shopList;
        }
        public void DeleteConfirmed(int id)
        {
            ShopList ShopList = db.ShopLists.Find(id);
            db.ShopLists.Remove(ShopList);
            db.SaveChanges();
        }

        public void Edit(ShopList ShopList)
        {
            db.Entry(ShopList).State = EntityState.Modified;
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