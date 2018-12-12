using System.Net;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class Fathers1Controller : Controller
    {
        private ShopListContext db = new ShopListContext();

        FatherRepository r = new FatherRepository();

        // GET: Products
        public ActionResult Index()
        {
            return View(r.GetFathers());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            Father father = r.GetFatherById(id);

            if (father == null)
            {
                return HttpNotFound();
            }
            return View(father);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FatherId, FatherName")] Father father)
        {
            if (ModelState.IsValid)
            {
                father = r.AddFather(father);
                return RedirectToAction("Index");
            }

            return View(father);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Father father = r.GetFatherById(id);
            if (father == null)
            {
                return HttpNotFound();
            }
            return View(father);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FatherId, FatherName")] Father father)
        {
            if (ModelState.IsValid)
            {
                r.Edit(father);
                return RedirectToAction("Index");
            }
            return View(father);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Father father = r.GetFatherById(id);
            if (father == null)
            {
                return HttpNotFound();
            }
            return View(father);
        }

        // POST: Products/Delete/5
        [System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
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
