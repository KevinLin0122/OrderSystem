using HC.Core.DataBase;
using HC.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HC.Web.Controllers
{
    public class OrderController : Controller
    {
        public OrderDbContext DbContext
        {
            get
            {
                return this.db;
            }
        }
        private OrderDbContext db;

        public OrderController()
        {
            db = new OrderDbContext();
        }

        public IActionResult Index()
        {

            List<Product> models = db.Product.ToList();

            return View(models);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            db.Product.Add(model);
            db.SaveChanges();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var result = (from s in db.Product where s.id == id select s).FirstOrDefault();
            if (result != default(Product)) {
                return View(result);
            }
            else
            {
                TempData["ResultMessage"] = "資料有誤，請重新輸入";
                return View(); 
            }
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (this.ModelState.IsValid)
            {
                var upDateModel = db.Product.Find(model.id);
                upDateModel.產品名稱 = model.產品名稱;
                upDateModel.價錢 = model.價錢;
                db.SaveChanges();
                var updated = db.Product.Find(model.id);
                return View(updated);
            }
            else
            {
                return View(model);
            }
         
        }

  
        public IActionResult Delete(int id)
        {
            var result = (from s in db.Product where s.id == id select s).FirstOrDefault();
            if (result != default(Product))
            {
                db.Product.Remove(result);
                db.SaveChanges();

                TempData["ResultMessage"] = string.Format("商品[{0}]成功刪除" , result.產品名稱);
                
            }
            else
            {
                TempData["ResultMessage"] = "資料不存在，無法刪除";
           
            }
            return RedirectToAction("Index");
        }


    }
}
