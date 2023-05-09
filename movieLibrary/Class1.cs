using System;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    abstract class Product
    {
        public string name;
        public int quantity;
        public string description;
        public float sellPrice;
        public float purchasePrice;

        public Product(string name, int quantity, string description, float sellPrice, float purchasePrice)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
            this.sellPrice = sellPrice;
            this.purchasePrice = purchasePrice;
        }

        public float PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                if (value > 0)
                {
                    purchasePrice = value;
                }
                else
                {
                    throw new Exception("Purchase price must be greater than zero.");
                }
            }
        }
        public abstract float ReturnTotalCost();
    }
}
