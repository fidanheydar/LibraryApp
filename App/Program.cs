using System;
using System.Diagnostics;
using System.Text;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            string opt;

            do
            {
                ShowMenu();
                Console.Write("Emeliyyat sechin: ");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        string name;
                        do
                        {
                            Console.Write("Kitab adi daxil edin: ");
                            name = Console.ReadLine();
                            if (name != null)
                            {
                                name = name.Trim();
                            }

                        } while (!IsValidBookName(ref name));

                        if (name == null)
                        {
                            Console.WriteLine("Yalnish ad!");
                            break;
                        }
                        
                        if (library.CheckName(name))
                        {
                            Console.WriteLine("Bu adli kitab artig movcuddur!");
                        }
                        else
                        {
                            double price;
                            string strPrice;    
                            do
                            {
                                Console.Write("Kitab giymetini daxil edin: ");
                                strPrice = Console.ReadLine();
                            } while (!double.TryParse(strPrice, out price) || price <= 0);

                            string genre;
                                bool flag = true;
                            do
                            {
                                flag = true;
                                Console.Write("Kitab janri daxil edin: ");
                                genre = Console.ReadLine();
                                for (int i = 0; i<genre.Length; i++)
                                {
                                   
                                    if (!char.IsLetter(genre[i]) && !char.IsWhiteSpace(genre[i]))
                                    {
                                        flag= false;
                                    }
                                }
                                if (genre != null)
                                {
                                    genre = genre.Trim();
                                }
                            } while (genre == null || string.IsNullOrWhiteSpace(genre) || !flag);

                            if (genre == null)
                            {
                                Console.WriteLine("Yalnish janr!");
                                break;
                            }

                            Book book = new Book(name, price, genre);
                            library.AddBook(book);
                            Console.WriteLine($"Elave edilen kitab: Ad: {name}, Giymet: {price}, Janr: {genre}");
                        }
                        break;
                    case "2":
                        if (library.HasNoBooks())
                        {
                            Console.WriteLine("Kitabxana boshdur!.");
                        }
                        else
                        {
                            do
                            {
                                string rmvName;
                                Console.Write("Silmek istediyiniz kitabi daxil edin:");
                                rmvName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(rmvName))
                                {
                                    Console.WriteLine("Yalnish ad!!");
                                }
                                else
                                {
                                    if (library.RemoveBookByName(rmvName))
                                    {
                                        Console.WriteLine("Kitab silindi!!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bele bir kitab yoxdur!!.");
                                    }
                                    break;
                                }
                            } while (true);
                        }
                        break;



                    case "3":
                        if (library.HasNoBooks())
                        {
                            Console.WriteLine("Kitabxana boshdur!.");
                        }
                        else
                        {
                            library.ShowAllBooks();
                        }
                        break;


                    case "4":
                        if (library.HasNoBooks())
                        {
                            Console.WriteLine("Kitabxana boshdur!.");
                        }
                        else
                        {
                            string selectedName;
                            do
                            {
                                Console.Write("Sechilmish kitabin adini daxil edin:");
                                selectedName = Console.ReadLine();
                            } while (string.IsNullOrWhiteSpace(selectedName));

                            Book selectedBook = library.SearchBookByName(selectedName);

                            if (selectedBook == null)
                            {
                                Console.WriteLine("Bele bir kitab yoxdur!");
                            }
                            else
                            {
                                Console.WriteLine($"Sechilmish kitab: Adi: {selectedBook.Name}, Giymeti: {selectedBook.Price}, Janri: {selectedBook.Genre}");
                            }
                        }
                        break;

                    case "5":
                        if (library.HasNoBooks())
                        {
                            Console.WriteLine("Kitabxana boshdur!.");
                        }
                        else
                        {
                            string searchValue;
                            do
                            {
                                Console.Write("Axtarish deyeri daxil edin:");
                                searchValue = Console.ReadLine();
                            } while (string.IsNullOrWhiteSpace(searchValue));

                            Book[] foundBooks = library.FindAllBooksBySearchvalue(searchValue);

                            if (foundBooks == null || foundBooks.Length == 0)
                            {
                                Console.WriteLine("Bele bir kitab yoxdur!");
                            }
                            else
                            {
                                Console.WriteLine("Axtarisha uygun kitablar:");
                                for (int i = 0; i < foundBooks.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Kitab adi: {foundBooks[i].Name}, Giymeti: {foundBooks[i].Price}, Janri: {foundBooks[i].Genre}");
                                }
                            }
                        }
                        break;


                }

            } while (opt!="0");


        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Kitab elave et:");
            Console.WriteLine("2. Kitab sil:");
            Console.WriteLine("3. Butun kitablara bax:");
            Console.WriteLine("4. Sechilmish kitaba bax:");
            Console.WriteLine("5. Ada gore axtarish et:");
        }
        static bool IsValidBookName(ref string name)
        {
            if (name.Length < 3 || name.Length > 20)
            {
                Console.WriteLine("Yalnishdir duzgun olchu daxil edin !");
                return false;
            }
            var stringBuilder = new StringBuilder();
            var whiteSpaceCount = 0;
            for (int j = 0; j < name.Length; j++)
            {
                if (char.IsWhiteSpace(name[j]))
                {
                    whiteSpaceCount++;
                }
                else
                {
                    whiteSpaceCount = 0;
                }

                if (whiteSpaceCount > 1)
                {
                    continue;
                }

                stringBuilder.Append(name[j]);
            }

            name = stringBuilder.ToString();
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]) && !char.IsWhiteSpace(name[i]))
                {
                    Console.WriteLine("Kitab adi yalniz herflerden ibaret olmalidir !");
                    return false;
                }

            }
            return true;
        }
       
    }
}
