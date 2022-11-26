using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Web_Selling_Laptop.Models;


namespace Web_Selling_Laptop.Controllers
{
    public class LaptopController : Controller
    {
        LaptopDBContext db = new LaptopDBContext();
        // GET: Laptop
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Home(int? page, string SearchString)
        {
            var laptops = from l in db.Laptops // lấy toàn bộ liên kết
                        select l;
            int pageSize = 6;

            int pageNumber = (page ?? 1);

            if (page == null) page = 1;

            if (!string.IsNullOrEmpty(SearchString))
            {
               laptops = laptops.Where(s => s.LaptopName.Contains(SearchString));
            }

            return View(laptops.OrderBy(i=>i.LaptopId).ToPagedList(pageNumber, pageSize));


        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }
        //Method lấy ảnh từ folder
        /* private void GetImgPath()
         {
             string path = Server.MapPath("~/img/"); //lấy đường dẫn img
             string[] imgFiles = Directory.GetFiles(path); // lấy tất cả file từ path
             ViewBag.img = imgFiles; //assign các file vào ViewBag

         }*/
    }
}