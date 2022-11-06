using Projet_RIO71_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_RIO71_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalogue()
        {
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            var getCategories = db.CATEGORies.ToList();
            SelectList list = new SelectList(getCategories, "CategorieID", "Nom");
            ViewBag.CategoryListName = list;
            return View();
        }

        public ActionResult GetPartialeProducts(int CategID)
        {
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            var list = db.PRODUITs.Where(o => o.CategorieID == CategID).ToList<PRODUIT>();

            ViewBag.listProd = list;

            return PartialView("PartialProductView");
        }

        [HttpGet]
        public ActionResult MultipleSearch()
        {
            return View();
        }

       [HttpPost]
        public ActionResult GetMultipleSearch()
        {
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            var list = db.PRODUITs.Select(o => new { ProduitID = o.ProduitID, Nom = o.Nom, Description = o.Description, Photo = o.Photo, Prix = o.Prix });
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);            
        }

        
        public ActionResult Details(int id)
        {
            M3IDatabaseEntities db = new M3IDatabaseEntities();
            var prod = db.PRODUITs.Where(o => o.ProduitID == id).Select(o => new { ProduitID = o.ProduitID, Nom = o.Nom, Description = o.Description, Photo = o.Photo, Prix = o.Prix, FournisseurID = db.FOURNISSEURs.Where(f => f.FournisseurID == o.FournisseurID).Select(f => f.Nom), CategorieID = db.CATEGORies.Where(c => c.CategorieID == o.CategorieID).Select(c => c.Nom) });
            ViewBag.Prod = prod;
            
            return PartialView("PartialProductDetailsView");
        }



    }
}