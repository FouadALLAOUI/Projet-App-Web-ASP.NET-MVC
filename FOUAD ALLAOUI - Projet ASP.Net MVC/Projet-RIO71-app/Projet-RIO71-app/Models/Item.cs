using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_RIO71_app.Models
{
    public class Item
    {
        private PRODUIT product = new PRODUIT();
        private int quantity;
        public Item()
        {

        }

        public Item(PRODUIT product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public PRODUIT Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}