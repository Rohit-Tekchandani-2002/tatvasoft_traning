using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "user";
            int password;
            int userId = 0;
            char exit = 'n';
            char cont = 'n';
            int choice = 0;
            bool login = false;
            int bookId = 0;
            int maxLimit = 3;
            string[] names = { "rohit", "mohit" };
            int[] passwords = { 01234, 44444 };
            int[] numberOfBooks = { 2, 3 };
            int[,] bookIds = { { 1, 4, 0 }, 
                               { 3, 2, 5 } 
                             };
            Book[] BookShelf = { 
                                    new Book(1, "book1", "author1"), 
                                    new Book(2, "book2", "author2"), 
                                    new Book(3, "book3", "author3"), 
                                    new Book(4, "book4", "author4"), 
                                    new Book(5, "book5", "author5"), 
                                    new Book(6, "book6", "author6")
                               };
            Console.WriteLine("LMS - Library Managment System");
            Console.WriteLine("");
            Console.WriteLine("LOGIN");
            Console.WriteLine("");
            Console.Write("Enter Your Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Your Password: ");
            password = Convert.ToInt32(Console.ReadLine());


            for (int i=0; i < names.Length; i++)
            {
                if (name == names[i] && password == passwords[i])
                {
                    login = true;
                    name = names[i];
                    userId = i;
                }
            }
            if (login == true)
            {
                Console.WriteLine("We have total " + names.Length + " active usres.\n");
                Console.WriteLine("Welcome\n");
                login = false; // login reset

                ShowStatus(name, userId, numberOfBooks[userId]);

                Console.WriteLine("Press c to continue...");
                cont = Convert.ToChar(Console.ReadLine());
                if (cont == 'c')
                {
                    //process
                    Console.WriteLine("Press 1 to returnbook");
                    Console.WriteLine("Press 2 to borrowbook");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the book ID: ");
                            bookId = Convert.ToInt32(Console.ReadLine());
                            if (CheckId(bookId,bookIds, userId, maxLimit))
                            {
                                int i = 0;
                                while (i < maxLimit)
                                {
                                    if (bookIds[userId, i] == bookId && bookIds[userId, i] != 0)
                                    {
                                        bookIds[userId, i] = 0;
                                        if(numberOfBooks[userId] > 0)
                                        {
                                            numberOfBooks[userId]--;
                                        }
                                    }
                                    i++;
                                }
                                Console.WriteLine("Your book is returned.\n");
                                ShowStatus(name, userId, numberOfBooks[userId]);
                                Console.WriteLine("\nYour Resiter book list: \n");
                                for (i = 0; i < maxLimit; i++)
                                {
                                    if (bookIds[userId, i] != 0)
                                    {
                                        Console.WriteLine(BookShelf[bookIds[userId, i]-1].title);
                                        Console.WriteLine(BookShelf[bookIds[userId, i]-1].authorNname);
                                    }

                                }
                            }
                            break;
                        case 2:
                            Console.Write("Enter the book ID: ");
                            bookId = Convert.ToInt32(Console.ReadLine());
                            if (!CheckId(bookId, bookIds, userId, maxLimit))
                            {
                                if(numberOfBooks[userId] <= maxLimit)
                                {
                                    int i = 0;
                                    while (i < maxLimit)
                                    {
                                        if (bookIds[userId, i] != bookId && bookIds[userId, i] == 0)
                                        {
                                            bookIds[userId, i] = bookId;
                                            numberOfBooks[userId]++;

                                        }
                                        i++;
                                    }
                                    Console.WriteLine("Your book is borrowed\n.");
                                    ShowStatus(name, userId, numberOfBooks[userId]);
                                    Console.WriteLine("\nYour Resiter book list: \n");
                                    for (i = 0; i < maxLimit; i++)
                                    {
                                        if (bookIds[userId, i] != 0)
                                        {
                                            Console.WriteLine(BookShelf[bookIds[userId, i] - 1].title);
                                            Console.WriteLine(BookShelf[bookIds[userId, i] - 1].authorNname);
                                        }

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("MAX LIMIT REACHED: Plese return book before borrow.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your book is already borrowed.");
                            }
                            break;

                        default:
                            Console.Write("INVALID CHOICE");
                            break;
                    }


                }
            }
            else
            {
                Console.WriteLine("Wrong user name or password - Tryagain");

                Console.Write("Press 'e' for EXIT: ");
                try
                {
                    while (exit != 'e')
                    {
                        exit = Convert.ToChar(Console.ReadLine());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.Write("Press 'e' for EXIT: ");
            try
            {
                while (exit != 'e')
                {
                    exit = Convert.ToChar(Console.ReadLine());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            }
        static bool CheckId(int bookId, int[,] bookIds, int userId, int maxLimit)
        {
            int i = 0;
            while(i < maxLimit)
            {
                if (bookIds[userId,i] == bookId && bookIds[userId, i] != 0)
                {
                    return true;
                }
                i++;
            }
            Console.WriteLine("Wrong Book Id");
            return false;
        }
        static void ShowStatus(string name,int userId, int numberOfBooks)
        {
            Console.WriteLine("Status: ");
            Console.WriteLine("User name: " + name);
            Console.WriteLine("User ID: " + (userId + 1));
            Console.WriteLine("Number of books borrowed: " + numberOfBooks);
        }
    }
}
