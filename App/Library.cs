using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    internal class Library
    {
        public Book[] Books = new Book[0];

        public void AddBook(Book book)
        {
            Array.Resize(ref Books, Books.Length + 1);
            Books[Books.Length - 1] = book;
        }
        public bool CheckName(string name)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i] != null && Books[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool RemoveBookByName(string name)
        {
            int index = -1;
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i] != null && Books[i].Name == name)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                for (int i = index; i < Books.Length - 1; i++)
                {
                    Books[i] = Books[i + 1];
                }
                Array.Resize(ref Books, Books.Length - 1);
                return true;
            }
            else
            {
                return false; 
            }
        }

        public Book SearchBookByName(string name)
        {

            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name == name)
                {
                    return Books[i];
                }
            }
            return null;
        }

        public Book[] FindAllBooksBySearchvalue(string name)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name.Contains(name))
                {
                    return Books;
                }
            }
            return null;
        }
        public void ShowAllBooks()
        {
            Console.WriteLine("===Kitablar===:");
            for (int i = 0; i < Books.Length; i++)
            {
                Console.WriteLine($"{i + 1}.Kitab:{this.Books[i].Name}/Giymet:{this.Books[i].Price}/Janr:{this.Books[i].Genre}");
            }


        }
        public bool HasNoBooks()
        {
            return Books.Length == 0;
        }
    }
}
