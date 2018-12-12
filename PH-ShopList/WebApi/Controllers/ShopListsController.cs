using System.Net;

using System.Web.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class ShopListsController : Controller
    {
        private ShopListContext db = new ShopListContext();
        ShopListRepository r = new ShopListRepository();

        // GET: ShopLists
        public ActionResult Index()
        {
            return View(r.GetShopLists());
        }

        // GET: ShopLists/Details/5
        public ActionResult Details(int? id)
        {
            ShopList shopList = r.GetShopListById(id);

            if (shopList == null)
            {
                return HttpNotFound();
            }
            return View(shopList);
        }

        // GET: ShopLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopListId,Description,Status,Initial")] ShopList shopList)
        {
            if (ModelState.IsValid)
            {
                shopList = r.AddShopList(shopList);
                return RedirectToAction("Index");
            }

            return View(shopList);
        }

        // GET: ShopLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopList shopList = r.GetShopListById(id);
            if (shopList == null)
            {
                return HttpNotFound();
            }
            return View(shopList);
        }

        // POST: ShopLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopListId,Description,Status,Initial")] ShopList shopList)
        {
            if (ModelState.IsValid)
            {
                r.Edit(shopList);
                return RedirectToAction("Index");
            }
            return View(shopList);
        }
    

        // GET: ShopLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopList shopList = r.GetShopListById(id);
            if (shopList == null)
                {
                return HttpNotFound();
                }
            return View(shopList);
        }
        
    

        // POST: ShopLists/Delete/5
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
