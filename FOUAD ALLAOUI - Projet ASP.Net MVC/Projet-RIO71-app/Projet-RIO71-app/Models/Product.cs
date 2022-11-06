using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_RIO71_app.Models
{
    public class Product
    {
        public int ProduitID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public Nullable<int> Prix { get; set; }
        public int FournisseurID { get; set; }
        public int CategorieID { get; set; }
    }
}