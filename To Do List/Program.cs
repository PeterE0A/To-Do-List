using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace To_Do_List
{
    public class Program
    {

        static List<string> list = new List<string>();
        static string task="";

        static void Main(string[] args)
        {
            Loading();

            while (true)
            {


                Menu();


                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Add();
                        Console.Clear();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        View();
                        Console.Clear();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Delete();
                        Console.Clear();
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Update();
                        Console.Clear();
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Save();
                        Environment.Exit(0);
                        break;
                    
                }
                
            }

           

        }


        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("To Do List");
            Console.WriteLine("Please Choose From The Options Below: ");
            Console.WriteLine("\n(1) Add");
            Console.WriteLine("(2) View");
            Console.WriteLine("(3) Delete");
            Console.WriteLine("(4) Update");
            Console.WriteLine("(5) Exit/Save");


        }

        static void Loading()
        {

            if (!File.Exists("list.txt"))
            {
                File.Create("list.txt").Dispose();
            }
            else if (File.Exists("list.txt"))
            {
                list = new List<string>(File.ReadAllLines("list.txt"));
            }
    
        }

        static void Add()
        {
  
            Console.Write("\nAdd:");
            task = Console.ReadLine();

            list.Add(task);

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("You Have Successfully Added a New Task to Your List!!");
            Console.ReadLine();


        }

        static void View()
        {
            

            if (list.Count == 0)
            {
                Console.WriteLine("\nNo tasks to display.");
            }
            else
            {
                Console.SetCursorPosition(0,11);
                Console.WriteLine("\n\nYour To Do List: ");

                for (int i = 0; i < list.Count; i++)
                { 
                    Console.WriteLine($"{i + 1}. {list[i]}");
                }
            }
            Console.ReadLine();
        }

        static void Delete()
        {
            View();
            Console.SetCursorPosition(0, 10);
            Console.Write("Enter task number to delete: ");
            int taskNum = Convert.ToInt32(Console.ReadLine()) - 1;
            list.RemoveAt(taskNum);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task deleted!");
            Console.ReadLine();
        }

        static void Update()
        {
            View();
            Console.SetCursorPosition(0, 9);
            Console.Write("Enter task number to Update: ");
            int taskNum = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Enter New Task: ");
            string newTask = Console.ReadLine();
            list[taskNum] = newTask;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task updated!");
            Console.ReadLine();


        }

        static void Save(int timer = 10)
        {
           
                Console.SetCursorPosition(0, 10);
                Console.Write("Saving");

                for (int i = 0; i < timer; i++)
                {

                    Console.Write(".");
                    Thread.Sleep(200);

                }
                File.WriteAllLines("list.txt", list);
        }

        
    }
}
