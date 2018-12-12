using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class FatherRepository
    {
        private ShopListContext db = new ShopListContext();

        public IEnumerable<Father> GetFathers()
        {
            return db.Fathers.ToList();
        }

        public Father GetFatherById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Father Father = db.Fathers.Find(id);
            if (Father == null)
            {
                return null;
            }
            return Father;
        }

        public Father AddFather(Father Father)
        {
            try
            {
                db.Fathers.Add(Father);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string msg = $"Ups, fallo: {e.Message}";
                throw new Exception(msg);
            }
            return Father;
        }
        public void DeleteConfirmed(int id)
        {
            Father Father = db.Fathers.Find(id);
            db.Fathers.Remove(Father);
            db.SaveChanges();
        }

        public void Edit(Father Father)
        {
            db.Entry(Father).State = EntityState.Modified;
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