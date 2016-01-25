using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_Banks
{
	class Program
	{
		static string folderPath;
		public static string[] filePaths;
		public static bool endProgram = false;


		static void Main(string[] args)
		{
			Console.SetWindowSize(150, 50);
			folderPath = Directory.GetCurrentDirectory() + @"\CMP1124M_Assigment_Files\";

			while(!Directory.Exists(folderPath)) //Confirm the location of data files
			{
				Console.Clear();
				Console.WriteLine("Directory \"" + folderPath + "\" does not exist. Please enter correct directory.");
				folderPath = Console.ReadLine();
			}
			Console.Clear();


			filePaths = Directory.GetFiles(folderPath, "*.txt"); //put .txt file locations into array
			
			Bank[] banks = new Bank[CountBanks(filePaths)]; //create array of banks according to the number of data files


			for (int i = 0; i < banks.Length; i++ )
			{
				banks[i] = new Bank(i);
			} //end of program set up



			bool firstRun = true;
			bool trueEntry = true;

			while(!endProgram)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\t| Root Menu |\n\n");
				Console.ResetColor();


				if(firstRun)
				{ 
					Console.WriteLine("Data has succesfully been read, there are {0} banks to chose from.\n", banks.Length);
					firstRun = false;
				}
				if(!trueEntry)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Not a recognised entry, please try again \n");
					Console.ResetColor();

					trueEntry = true;
				}

				Console.WriteLine("Please enter the number of the bank you wish to see data for (ie. 1 to {0})", banks.Length);
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("Enter \"end\" to close the program\n");
				Console.ResetColor();

				string input1 = Console.ReadLine().ToLower();
				int bankChoice;
				if(Int32.TryParse(input1, out bankChoice) && bankChoice < banks.Length + 1)
				{
					banks[bankChoice - 1].BankMenu();
				}
				else if(input1 == "end")
				{
					endProgram = true;
					Console.WriteLine();
				}
				else
				{ 
					trueEntry = false;
				} //end if
			} //end main method



			Console.WriteLine("Press any key to close program.");
			Console.ReadKey();
			Console.Clear();
		}


		static int CountBanks(string[] dataFiles)
		{
			int count = 0;

			foreach (string s in dataFiles)
			{
				if(s.Contains("_Diff.txt"))
				{
					count++;
				}
			}

			return count;
		}
	}
}
