using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    internal class Product
    {
        public string Name;
        public double Price;

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
