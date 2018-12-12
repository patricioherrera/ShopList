using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class SonRepository
    {
        private ShopListContext db = new ShopListContext();

        public IEnumerable<Son> GetSons()
        {
            return db.Sons.ToList();
        }

        public Son GetSonById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Son son = db.Sons.Find(id);
            if (son == null)
            {
                return null;
            }
            return son;
        }

        public Son AddSon(Son son)
        {
            try
            {
                db.Sons.Add(son);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string msg = $"Ups, fallo: {e.Message}";
                throw new Exception(msg);
            }
            return son;
        }
        public void DeleteConfirmed(int id)
        {
            Son son = db.Sons.Find(id);
            db.Sons.Remove(son);
            db.SaveChanges();
        }

        public void Edit(Son son)
        {
            db.Entry(son).State = EntityState.Modified;
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