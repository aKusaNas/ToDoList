using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Linq;

namespace todolist
{

	public class Metodai
	{
		public static void WriteLineToFile(string filePath, string inputLine, bool append = true)
		{

			using (var file = new StreamWriter(filePath, append))
			{
				{
					file.WriteLine(inputLine);
				}
			}
			Console.Clear();
			Console.WriteLine("---------TO DO LIST ADDED WITH NEW LINE!----------");
			Console.WriteLine();
			Console.WriteLine($"  {inputLine}  ");
			Console.WriteLine();
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("press enter to go to menu");
		}

		public static void ShowList()

		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TODOLIST.txt");
			Console.Clear();
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------TO DO LIST--------------------");
			Console.WriteLine("--------------------------------------------------");
            
            

            if (File.Exists(filePath))
			{
				int counter = 1;
				string line;
				System.IO.StreamReader failas = new System.IO.StreamReader(filePath);
				while ((line = failas.ReadLine()) != null)
				{
					System.Console.WriteLine(counter.ToString() + ": " + line);
					counter++;
				}
				failas.Close();
				Console.WriteLine("--------------------------------------------------");
				Console.WriteLine("--------------------------------------------------");
				Console.WriteLine("press enter to go back to menu");
			}
			else
			{
				Console.Clear();
				Console.WriteLine("--------------------------------------------------");
				Console.WriteLine("--------------------TO DO LIST--------------------");
				Console.WriteLine("-------------------LIST IS EMPTY------------------");
				Console.WriteLine("---------------press enter to go back-------------");
			}
		}

		public static void DeleteLine()
		{
			Console.Clear();
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------TO DO LIST--------------------");
			Console.WriteLine();
			Console.WriteLine("--------------------------------------------------");
			Metodai.ShowList();
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine();
			Console.WriteLine("Write a Number of Line to DELETE:");


			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TODOLIST.txt");
			var file = new List<string>(System.IO.File.ReadAllLines(filePath));
			int l;
			l = Convert.ToInt32(Console.ReadLine());

			if (l >= 0)
			{
				file.RemoveAt(l - 1);
				File.WriteAllLines(filePath, file.ToArray());
				Console.WriteLine("{0}: line was deleted, press enter to go back to menu", l);
			}
		}

		public static void ToDoMenu()
		{
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------TO DO LIST--------------------");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------   MENU   --------------------");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("-------------SHOW LIST Type and Enter 1-----------");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("-----Enter New TO DO to List Type and Enter 2-----");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--Delete From TO DO LIST a Line Type and Enter 3--");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("----------Delete All List Type and Enter 4--------");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("--------------------------------------------------");

		}
        
      

        public static void Approve()
		{
			Console.Clear();
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("---------Type APPROVE to Delete ALL List!!--------");
			Console.WriteLine("--------------------------------------------------");

			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TODOLIST.txt");
			string fine = Console.ReadLine();
			if (fine == "APPROVE")
			{
				Console.Clear();
				Console.WriteLine("--------------------------------------------------");
				Console.WriteLine("------------!!!!ALL LIST WAS DELETED!!!!----------");
				Console.WriteLine("--------------------------------------------------");

				File.WriteAllText(filePath, String.Empty);
			}
			else
			{
				Console.Clear();
				Console.WriteLine("--------------------------------------------------");
				Console.WriteLine("------------Phew..... List is Safe!!!-------------");
				Console.WriteLine("--------------------------------------------------");
			}
		}

		public static int ReadCommandNumber(int commandCount)
		{
			int number;
			var infoForUser = $"Write a Command Number [1 - {commandCount}]:";

			Console.WriteLine(infoForUser);

			string input = Console.ReadLine();

			while (true)
			{
				while (!int.TryParse(input, out number))
				{
					Console.WriteLine("BAD OPTION");
					Console.WriteLine(infoForUser);
					input = Console.ReadLine();
				}
				if (number >= 1 && number <= commandCount)
				{
					return number;
				}
				Console.WriteLine("BAD OPTION");
				Console.WriteLine(infoForUser);
				input = Console.ReadLine();
			}
		}

        public static void CreateTextList()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("-------------------Give Me a Name-----------------");
            string tavotekstas = Console.ReadLine();
            var createText = Path.Combine(Directory.GetCurrentDirectory(), $"{tavotekstas}.txt");
            //string[] array1 = Directory.GetFiles(filePath);

            // Get list of files.
            //string[] filePaths = Directory.GetFiles(filePath, "*.txt");
            //using (var reader = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory()))) ;
            
        }

		public static void Program()
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TODOLIST.txt");
			int option;

			do
			{
				ToDoMenu();
				
				
				option = Metodai.ReadCommandNumber(4);
                var userInput = ReadCommandNumber(Enum.GetNames(typeof(MenuEnnum)).Length - 1);
                Console.Write("Go To: ");
                switch (option)
				{
                    
                    case (int)MenuEnnum.ShowList:
						ShowList();
						break;
                    case (int)MenuEnnum.WriteLineToFile:
                        Console.Clear();
						Console.WriteLine("--------------------------------------------------");
						Console.WriteLine("-----------Write a New Line TO DO List!-----------");
						WriteLineToFile(filePath, Console.ReadLine());
						break;
                    case (int)MenuEnnum.DeleteLine:
						DeleteLine();
						break;
                    case (int)MenuEnnum.Approve:
						Approve();
						break;
                    
                    default:
						return;
				}
				Console.ReadKey();
				Console.Clear();
			}
			while (option != 0);
			Console.ReadKey();
		}
	}
}




