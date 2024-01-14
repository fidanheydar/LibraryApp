using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    internal class Book:Product
    {
        public string Genre;
        public Book(string name, double price, string genre) : base(name, price)
        {
            this.Genre = genre;
        }

    }
}
