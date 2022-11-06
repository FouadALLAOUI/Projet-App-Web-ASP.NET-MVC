using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_RIO71_app.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //------------------------------------- Manage of clients ---------------------------------------

        [HttpGet]
        public ActionResult GestionClients()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetClients()
        {
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                List<CLIENT> clientList = db.CLIENTs.ToList<CLIENT>();
                return Json(new { data = clientList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddClient([Bind(Exclude = "IsEmailVerified,ActivationCode")] CLIENT cli, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/ClientBase"), pic);
                file.SaveAs(path);
            }
            cli.Photo = pic;
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                db.CLIENTs.Add(cli);
            }
            return RedirectToAction("GestionClients", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteClient(int id)
        {
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                CLIENT emp = db.CLIENTs.Where(x => x.ClientID == id).FirstOrDefault<CLIENT>();
                db.CLIENTs.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        //--------------------------------------  Manage Admins---------------------------------------------

        [HttpGet]
        public ActionResult GestionAdmins()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAdmins()
        {
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                var adminList = db.Admins.ToList<Admin>();
                return Json(new { data = adminList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddAdmin(string email, string password, string cpassword)
        {
            M3IDatabaseEntities model;
            model = new M3IDatabaseEntities();
            var v = model.Admins.Where(a => a.EmailID == email).FirstOrDefault();
            if (v != null)
            {
                return RedirectToAction("GestionAdmins", "Admin");
                //return Json(new { success = true, message = "This admin is already exist" }, JsonRequestBehavior.AllowGet);
            }

            if (email != null && password != null && password == cpassword)
            {
                Admin adm = new Admin();
                adm.EmailID = email;
                adm.Password = password;
                model.Admins.Add(adm);
                model.SaveChanges();
                return RedirectToAction("GestionAdmins", "Admin");
                //return Json(new { success = true, message = "Add Successfully" }, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("GestionAdmins", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteAdmin(int id)
        {
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                Admin adm = db.Admins.Where(x => x.AdminID == id).FirstOrDefault<Admin>();
                db.Admins.Remove(adm);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        //----------------------------------------Manage Products--------------------------------------------------

        [HttpGet]
        public ActionResult GestionProducts()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            M3IDatabaseEntities db;
            db = new M3IDatabaseEntities();
            var getCategories = db.CATEGORies.ToList();
            SelectList list = new SelectList(getCategories, "CategorieID", "Nom");
            ViewBag.CategoryList = list;
            var getFournisseurs = db.FOURNISSEURs.ToList();
            SelectList list1 = new SelectList(getFournisseurs, "FournisseurID", "Nom");
            ViewBag.FournisseurList = list1;
            var prodList = db.PRODUITs.Select(o => new { ProduitID = o.ProduitID, Nom = o.Nom, Description = o.Description, Photo = o.Photo, Prix = o.Prix, FournisseurID = db.FOURNISSEURs.Where(f => f.FournisseurID == o.FournisseurID ).Select(f => f.Nom), CategorieID = db.CATEGORies.Where(c => c.CategorieID == o.CategorieID).Select(c => c.Nom) });
            return Json(new { data = prodList }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                PRODUIT emp = db.PRODUITs.Where(x => x.ProduitID == id).FirstOrDefault<PRODUIT>();
                db.PRODUITs.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            var getCategories = db.CATEGORies.ToList();
            SelectList list = new SelectList(getCategories, "CategorieID", "Nom");
            ViewBag.CategoryList = list;
            var getFournisseurs = db.FOURNISSEURs.ToList();
            SelectList list1 = new SelectList(getFournisseurs, "FournisseurID", "Nom");
            ViewBag.FournisseurList = list1;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(PRODUIT prod, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/ProductBase"), pic);
                file.SaveAs(path);
            }

            prod.Photo = pic;
           // prod.FournisseurID = nbrforn;
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            db.PRODUITs.Add(prod);
            db.SaveChanges();
            return RedirectToAction("AddProduct", "Admin");
        }

//----------------------- Manage FOURNISSEURS------------------------------------------------->

        [HttpGet]
        public ActionResult GestionFournisseurs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFournisseurs()
        {
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            var fournList = db.FOURNISSEURs.Select(o => new { FournisseurID = o.FournisseurID, Nom = o.Nom, Adresse = o.Adresse });
            return Json(new { data = fournList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteFourniseur(int id)
        {
            using (M3IDatabaseEntities db = new M3IDatabaseEntities())
            {
                FOURNISSEUR emp = db.FOURNISSEURs.Where(x => x.FournisseurID == id).FirstOrDefault<FOURNISSEUR>();
                db.FOURNISSEURs.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddFournisseur(string nom, string adresse)
        {
            M3IDatabaseEntities model;
            model = new M3IDatabaseEntities();
            var v = model.FOURNISSEURs.Where(a => a.Nom == nom).FirstOrDefault();
            if (v != null)
            {
                return RedirectToAction("GestionFournisseurs", "Admin");
                //return Json(new { success = true, message = "This admin is already exist" }, JsonRequestBehavior.AllowGet);
            }

            if (nom != null && adresse != null )
            {
                FOURNISSEUR frn = new FOURNISSEUR();
                frn.Nom = nom;
                frn.Adresse = adresse;
                model.FOURNISSEURs.Add(frn);
                model.SaveChanges();
                return RedirectToAction("GestionFournisseurs", "Admin");
                //return Json(new { success = true, message = "Add Successfully" }, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("GestionFournisseurs", "Admin");
        }




















    }
}