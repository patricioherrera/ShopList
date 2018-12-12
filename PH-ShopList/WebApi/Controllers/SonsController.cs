using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class SonsController : Controller
    {
        private ShopListContext db = new ShopListContext();
        SonRepository r = new SonRepository();

        // GET: Sons
        public ActionResult Index()
        {
            return View(r.GetSons());
        }

        // GET: Sons/Details/5
        public ActionResult Details(int? id)
        {
            Son son = r.GetSonById(id);

            if (son == null)
            {
                return HttpNotFound();
            }
            return View(son);
        }

        // GET: Sons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SonId,FatherId,SonName")] Son son)
        {
            if (ModelState.IsValid)
            {
                son = r.AddSon(son);
                return RedirectToAction("Index");
            }

            return View(son);
        }

        // GET: Sons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Son son = r.GetSonById(id);
            if (son == null)
            {
                return HttpNotFound();
            }
            return View(son);
        }

        // POST: Sons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SonId,FatherId,SonName")] Son son)
        {
            if (ModelState.IsValid)
            {
                r.Edit(son);
                return RedirectToAction("Index");
            }
            return View(son);
        }

        // GET: Sons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Son son = r.GetSonById(id);
            if (son == null)
            {
                return HttpNotFound();
            }
            return View(son);
        }

        // POST: Sons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            r.DeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
