using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web_Selling_Laptop.Models;

namespace Web_Selling_Laptop.Controllers
{
    public class UserController : Controller
    {

        LaptopDBContext db = new LaptopDBContext();
        public ActionResult UserList()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s=>s.SDT == _user.SDT);
                if (check == null)
                {
                   /* _user.Password = GetMD5(_user.Password);*/
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string sdt, string password)
        {
            if (ModelState.IsValid)
            {

                var data = db.Users.Where(s=>s.SDT.Equals(sdt) && s.Password.Equals(password)).ToList();
                if(data.Count() > 0)
                {
                    //add session
                    Session["SDT"] = data.FirstOrDefault().SDT;
                    Session["UserID"] = data.FirstOrDefault().UserID;
                    Session["NameCus"]=data.FirstOrDefault().UserName;
                    return RedirectToAction("Home","Laptop");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    //chưa có view index
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Home","Laptop");
        }
        //Tạo chuỗi mã hóa MD5
      /*  public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;

        }*/
    }
}