using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1124M_Banks
{
	class Bank
	{
		//variables
		string[] date;
		string[] day;
		double[] close;
		double[] diff;
		double[] open;
		int[] volume;
		string lastSort = "date";
		char sortOrder = 'a';
		int bankNum;
		bool goBack;
		bool falseEntry = false;
		int lastCount = -1;

		Stock[] stocks; 


		public Bank(int bankNum) //constructor
		{
			this.bankNum = bankNum + 1;

			SetData(); 

			stocks = new Stock[CountLines(File.ReadAllLines(Program.filePaths[0]))]; //sets size of stocks array

			for(int i = 0; i < stocks.Length; i++) //create Stock object for every non empty line
			{
				stocks[i] = new Stock(date[i], day[i], close[i], diff[i], open[i], volume[i]);
			}
		}


		void SetData()
		{
			string targetNameClose = "SH" + Convert.ToString(bankNum) + "_Close.txt";
			string targetNameDiff = "SH" + Convert.ToString(bankNum) + "_Diff.txt";
			string targetNameOpen = "SH" + Convert.ToString(bankNum) + "_Open.txt";
			string targetNameVolume = "SH" + Convert.ToString(bankNum) + "_Volume.txt";

			foreach(string file in Program.filePaths)
			{
				if(file.Contains("Day.txt"))
				{
					string[] temp = File.ReadAllLines(file);
					day = new string[temp.Length];

					for (int i = 0; i < temp.Length; i++)
					{
						if (temp[i] != "")
						{
							day[i] = temp[i];
						}
					}
				}
				else if(file.Contains("Date.txt"))
				{
					string[] temp = File.ReadAllLines(file);
					date = new string[temp.Length];

					for (int i = 0; i < temp.Length; i++)
					{
						if (temp[i] != "")
						{
							date[i] = temp[i];
						}
					}
				}
				else if (file.Contains(targetNameClose))
				{
					string[] temp = File.ReadAllLines(file);
					close = new double[temp.Length];

					for(int i = 0; i < temp.Length; i++)
					{
						if(temp[i] != "")
						{ 
							close[i] = Convert.ToDouble(temp[i]);
						}
					}
				}
				else if (file.Contains(targetNameDiff))
				{
					string[] temp = File.ReadAllLines(file);
					diff = new double[temp.Length];

					for (int i = 0; i < temp.Length; i++)
					{
						if(temp[i] != "")
						{ 
							diff[i] = Convert.ToDouble(temp[i]);
						}
					}
				}
				else if (file.Contains(targetNameOpen))
				{
					string[] temp = File.ReadAllLines(file);
					open = new double[temp.Length];

					for (int i = 0; i < temp.Length; i++)
					{
						if(temp[i] != "")
						{ 
							open[i] = Convert.ToDouble(temp[i]);
						}
					}
				}
				else if (file.Contains(targetNameVolume))
				{
					string[] temp = File.ReadAllLines(file);
					volume = new int[temp.Length];

					for (int i = 0; i < temp.Length; i++)
					{
						if(temp[i] != "")
						{ 
							volume[i] = Convert.ToInt32(temp[i]);
						}
					}
				}
			}

		}


		static int CountLines(string[] dataFiles) //count non-blank lines in file
		{
			int count = 0;

			foreach (string s in dataFiles)
			{
				if (s != "")
				{
					count++;
				}
			}

			return count;
		} 


		void PrintStocks()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
			Console.ResetColor();

			foreach (Stock s in stocks)
			{
				s.PrintData();
			}
		}


		public void BankMenu()
		{
			goBack = false;
			while(!goBack)
			{ 
				Console.Clear();

				PrintStocks();
				if(lastCount != -1)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("Last algorithm swapped {0} pairs of elements", lastCount);
					Console.ResetColor();
				}
				Console.WriteLine("\n\n\n");

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\t| Bank {0} |\n\n", bankNum);
				Console.ResetColor();

				if(falseEntry)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Not a recognised entry, please try again \n");
					Console.ResetColor();
					falseEntry = false;
				}

				Console.WriteLine("Do you wish to sort, search, find minimum value, or find maximum value? \n(please enter \"search\",  \"sort\", \"min\", or \"max\")");

				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("Enter \"end\" to close the program\nEnter \"back\" to go to the main menu\n");
				Console.ResetColor();

				string input2 = Console.ReadLine().ToLower();


				if (input2 == "search")
				{
					SearchMenu();
				}
				else if(input2 == "sort")
				{
					lastCount = SortMenu();
				}
				else if(input2 == "min")
				{
					MinMenu();
				}
				else if(input2 == "max")
				{
					MaxMenu();
				}
				else if (input2 == "end")
				{
					Program.endProgram = true;
					goBack = true;
				}
				else if(input2 == "back")
				{
					goBack = true;
				}
				else
					falseEntry = true;
			} //end while
		} //end method


		int SearchMenu()
		{
			Console.Clear();

			int passes = -1;

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\t| Sort Bank {0} |\n\n", bankNum);
			Console.ResetColor();

			if (falseEntry)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not a recognised entry, please try again \n");
				Console.ResetColor();
				falseEntry = false;
			}

			Console.WriteLine("Please enter one of the following entries to search by:\nday\ndate\nclose\nopen\ndiff\nVolume");

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("Enter \"end\" to close the program\nEnter \"cancel\" to go to the bank menu\n");
			Console.ResetColor();

			string input2 = Console.ReadLine().ToLower();

			bool complete = false;
			string input3;
			while (!complete)
			{
				switch (input2)
				{
					case "day":
						Console.WriteLine("Please enter the exact day you wish to search for");
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine("Enter \"cancel\" to go to the bank menu\n");
						Console.ResetColor();
						input3 = Console.ReadLine().ToLower();
						Console.Clear();

						if (input3 == "monday" || input3 == "tuesday" || input3 == "wednesday" || input3 == "thursday" || input3 == "friday" || input3 == "saturday" || input3 == "sunday")
						{
							bool noData = true;

							if(lastSort == "day")
							{
								switch(input3)
								{
									case "monday":
										input3 = "1";
										break;
									case "tuesday":
										input3 = "2";
										break;
									case "wednesday":
										input3 = "3";
										break;
									case "thursday":
										input3 = "4";
										break;
									case "friday":
										input3 = "5";
										break;
									case "saturday":
										input3 = "6";
										break;
									case "sunday":
										input3 = "7";
										break;
								}

								foreach (Stock s in Algorithms.BinarySearch(stocks, "day", input3, sortOrder))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									} 
								}
							}
							else
							{
								foreach (Stock s in Algorithms.LinearSearch(stocks, "day", input3))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}
							

							if (noData)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("No data was found\n");
							}

							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Press any key to return to Bank menu");
							Console.ResetColor();
							Console.ReadKey();
							complete = true;
						}
						else if (input3 == "cancel")
						{
							passes = -1;
							complete = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
						break;

					case "date":
						Console.WriteLine("Please enter the date you wish to search for in the format DD/MM/YYYY");
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine("Enter \"cancel\" to go to the bank menu\n");
						Console.ResetColor();
						input3 = Console.ReadLine().ToLower();
						Console.Clear();

						if (input3.Length == 10 && input3.Contains('/'))
						{
							bool noData = true;
							foreach (Stock s in Algorithms.LinearSearch(stocks, "date", input3))
							{
								if (s != null)
								{
									s.PrintData();
									noData = false;
								}
							}

							if (noData)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("No data was found\n");
							}

							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Press any key to return to Bank menu");
							Console.ResetColor();
							Console.ReadKey();
							complete = true;
						}
						else if (input3 == "cancel")
						{
							passes = -1;
							complete = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised format, please try again \n");
							Console.ResetColor();
						}
						break;

					case "close":
						Console.WriteLine("Please enter a number to search for");
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine("Enter \"cancel\" to go to the bank menu\n");
						Console.ResetColor();
						input3 = Console.ReadLine().ToLower();
						Console.Clear();
						double a;

						if(Double.TryParse(input3, out a))
						{
							bool noData = true;

							if(lastSort == "close")
							{
								foreach (Stock s in Algorithms.BinarySearch(stocks, "close", input3, sortOrder))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}
							else
							{
								foreach (Stock s in Algorithms.LinearSearch(stocks, "close", input3))
								{
									if(s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}

							if(noData)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("No data was found\n");
							}

							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Press any key to return to Bank menu");
							Console.ResetColor();
							Console.ReadKey();
							complete = true;
						}
						else if (input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.BubbleReverse(ref stocks, "close");
							complete = true;
						}
						else if (input3 == "cancel")
						{
							passes = -1;
							complete = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
						break;

					case "open":
						Console.WriteLine("Please enter a number to search for");
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine("Enter \"cancel\" to go to the bank menu\n");
						Console.ResetColor();
						input3 = Console.ReadLine().ToLower();
						Console.Clear();
						double b;

						if(Double.TryParse(input3, out b))
						{
							bool noData = true;
							if (lastSort == "open")
							{
								foreach (Stock s in Algorithms.BinarySearch(stocks, "open", input3, sortOrder))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}
							else
							{
								foreach (Stock s in Algorithms.LinearSearch(stocks, "open", input3))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}

							if (noData)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("No data was found\n");
							}

							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Press any key to return to Bank menu");
							Console.ResetColor();
							Console.ReadKey();
							complete = true;
						}
						else if (input3 == "cancel")
						{
							passes = -1;
							complete = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
						break;

					case "volume":
						Console.WriteLine("Please enter an integer number to search for");
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine("Enter \"cancel\" to go to the bank menu\n");
						Console.ResetColor();
						input3 = Console.ReadLine().ToLower();
						Console.Clear();
						int c;

						if(Int32.TryParse(input3, out c))
						{
							bool noData = true;
							if (lastSort == "volume")
							{
								foreach (Stock s in Algorithms.BinarySearch(stocks, "volume", input3, sortOrder))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}
							else
							{
								foreach (Stock s in Algorithms.LinearSearch(stocks, "volume", input3))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}

							if (noData)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("No data was found\n");
							}

							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Press any key to return to Bank menu");
							Console.ResetColor();
							Console.ReadKey();
							complete = true;
						}
						else if (input3 == "cancel")
						{
							passes = -1;
							complete = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
						break;

					case "diff":
						Console.WriteLine("Please enter a number to search for");
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine("Enter \"cancel\" to go to the bank menu\n");
						Console.ResetColor();
						input3 = Console.ReadLine().ToLower();
						Console.Clear();
						double d;

						if(Double.TryParse(input3, out d))
						{
							bool noData = true;
							if (lastSort == "diff")
							{
								foreach (Stock s in Algorithms.BinarySearch(stocks, "diff", input3, sortOrder))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}
							else
							{
								foreach (Stock s in Algorithms.LinearSearch(stocks, "diff", input3))
								{
									if (s != null)
									{
										s.PrintData();
										noData = false;
									}
								}
							}

							if (noData)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("No data was found\n");
							}

							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Press any key to return to Bank menu");
							Console.ResetColor();
							Console.ReadKey();
							complete = true;
						}
						else if (input3 == "cancel")
						{
							passes = -1;
							complete = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
						break;

					case "end":
						Program.endProgram = true;
						goBack = true;
						complete = true;
						passes = -1;
						break;

					case "cancel":
						passes = -1;
						complete = true;
						break;
					default:
						falseEntry = true;
						passes = SearchMenu();
						complete = true;
						break;
				} //end switch
			} //end while

			return passes;
		} //end method


		int SortMenu()
		{
			Console.Clear();

			int passes = -1;

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\t| Sort Bank {0} |\n\n", bankNum);
			Console.ResetColor();

			if (falseEntry)
			{
				Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Not a recognised entry, please try again \n");
				Console.ResetColor();
				falseEntry = false;
			}

			Console.WriteLine("Please enter one of the following entries to sort by:\nday\ndate\nclose\nopen\ndiff\nVolume");

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("Enter \"end\" to close the program\nEnter \"cancel\" to go to the bank menu\n");
			Console.ResetColor();

			string input2 = Console.ReadLine().ToLower();
			
			string input3;
			switch(input2)
			{
				case "day":
					Console.WriteLine("Ascending or descending?");
					input3 = Console.ReadLine().ToLower();
					if(lastSort != "day")
					{ 
						lastSort = "day";

						if(input3 == "a" || input3 == "ascending")
						{
							passes = Algorithms.Bubble(ref stocks, "day");
							sortOrder = 'a';
						}
						else if(input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.BubbleReverse(ref stocks, "day");
							sortOrder = 'd';
						}
						else if (input3 == "cancel")
						{
							passes = -1;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
					}
					else
					{
						if(Char.Parse(input3) != sortOrder)
						{
							passes = Algorithms.ReverseArray(stocks);
							if(sortOrder == 'a')
								sortOrder = 'd';
							else
								sortOrder = 'a';
						}
					}
					break;

				case "date":
					Console.WriteLine("Ascending or descending?");
					input3 = Console.ReadLine().ToLower();
					if(lastSort != "date")
					{
						lastSort = "date";

						if(input3 == "a" || input3 == "ascending")
						{
							passes = Algorithms.Bubble(ref stocks, "date");
							sortOrder = 'a';
						}
						else if(input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.BubbleReverse(ref stocks, "date");
							sortOrder = 'd';
						}
						else if (input3 == "cancel")
						{
							passes = -1;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
					}
					else
					{
						if (Char.Parse(input3) != sortOrder)
						{
							passes = Algorithms.ReverseArray(stocks);
							if (sortOrder == 'a')
								sortOrder = 'd';
							else
								sortOrder = 'a';
						}
					}
					break;

				case "close":
					Console.WriteLine("Ascending or descending?");
					input3 = Console.ReadLine().ToLower();
					if(lastSort != "close")
					{
						lastSort = "close";

						if(input3 == "a" || input3 == "ascending")
						{
							passes = Algorithms.Bubble(ref stocks, "close");
							sortOrder = 'a';
						}
						else if(input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.BubbleReverse(ref stocks, "close");
							sortOrder = 'd';
						}
						else if (input3 == "cancel")
						{
							passes = -1;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
					}
					else
					{
						if(Char.Parse(input3) != sortOrder)
						{
							passes = Algorithms.ReverseArray(stocks);
							if(sortOrder == 'a')
								sortOrder = 'd';
							else
								sortOrder = 'a';
						}
					}
					break;

				case "open":
					Console.WriteLine("Ascending or descending?");
					input3 = Console.ReadLine().ToLower();
					if(lastSort != "open")
					{
						lastSort = "open";

						if(input3 == "a" || input3 == "ascending")
						{
							passes = Algorithms.Bubble(ref stocks, "open");
							sortOrder = 'a';
						}
						else if(input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.BubbleReverse(ref stocks, "open");
							sortOrder = 'd';
						}
						else if (input3 == "cancel")
						{
							passes = -1;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
					}
					else
					{
						if(Char.Parse(input3) != sortOrder)
						{
							passes = Algorithms.ReverseArray(stocks);
							if(sortOrder == 'a')
								sortOrder = 'd';
							else
								sortOrder = 'a';
						}
					}
					break;

				case "volume":
					Console.WriteLine("Ascending or descending?");
					input3 = Console.ReadLine().ToLower();
					if(lastSort != "volume")
					{
						lastSort = "volume";

						if(input3 == "a" || input3 == "ascending")
						{
							passes = Algorithms.HeapSort(ref stocks, 'a');
							sortOrder = 'a';
						}
						else if(input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.HeapSort(ref stocks, 'd');
							sortOrder = 'd';
						}
						else if (input3 == "cancel")
						{
							passes = -1;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
					}
					else
					{
						if(Char.Parse(input3) != sortOrder)
						{
							passes = Algorithms.ReverseArray(stocks);
							if(sortOrder == 'a')
								sortOrder = 'd';
							else
								sortOrder = 'a';
						}
					}
					break;

				case "diff":
					Console.WriteLine("Ascending or descending?");
					input3 = Console.ReadLine().ToLower();
					if(lastSort != "diff")
					{
						lastSort = "diff";

						if(input3 == "a" || input3 == "ascending")
						{
							passes = Algorithms.Bubble(ref stocks, "diff");
							sortOrder = 'a';
						}
						else if(input3 == "d" || input3 == "descending")
						{
							passes = Algorithms.BubbleReverse(ref stocks, "diff");
							sortOrder = 'd';
						}
						else if(input3 == "cancel")
						{
							passes = -1;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Not a recognised entry, please try again \n");
							Console.ResetColor();
						}
					}
					else
					{
						if(Char.Parse(input3) != sortOrder)
						{
							passes = Algorithms.ReverseArray(stocks);
							if(sortOrder == 'a')
								sortOrder = 'd';
							else
								sortOrder = 'a';
						}
					}
					break;

				case "end":
					Program.endProgram = true;
					goBack = true;
					passes = -1;
					break;

				case "cancel":
					passes = -1;
					break;
				default:
					falseEntry = true;
					passes = SortMenu();
					break;
			} //end switch

			return passes;
		} //end method


		void MinMenu()
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\t| Minimum Value Bank {0} |\n\n", bankNum);
			Console.ResetColor();

			if (falseEntry)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not a recognised entry, please try again \n");
				Console.ResetColor();
				falseEntry = false;
			}

			Console.WriteLine("Please enter one of the following entries to search by:\ndate\nclose\nopen\ndiff\nVolume");

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("Enter \"end\" to close the program\nEnter \"cancel\" to go to the bank menu\n");
			Console.ResetColor();

			string input2 = Console.ReadLine().ToLower();

			bool complete = false;
			while (!complete)
			{
				switch (input2)
				{
					case "date":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMin(stocks, "date").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "close":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMin(stocks, "close").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "open":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMin(stocks, "open").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "volume":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMin(stocks, "volume").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "diff":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMin(stocks, "diff").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "end":
						Program.endProgram = true;
						goBack = true;
						complete = true;
						break;

					case "cancel":
						break;
					default:
						falseEntry = true;
						complete = true;
						break;
				} //end switch
			} //end while
		} //end method


		void MaxMenu()
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\t| Minimum Value Bank {0} |\n\n", bankNum);
			Console.ResetColor();

			if (falseEntry)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not a recognised entry, please try again \n");
				Console.ResetColor();
				falseEntry = false;
			}

			Console.WriteLine("Please enter one of the following entries to search by:\ndate\nclose\nopen\ndiff\nVolume");

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("Enter \"end\" to close the program\nEnter \"cancel\" to go to the bank menu\n");
			Console.ResetColor();

			string input2 = Console.ReadLine().ToLower();

			bool complete = false;
			while (!complete)
			{
				switch (input2)
				{
					case "date":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMax(stocks, "date").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "close":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMax(stocks, "close").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "open":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMax(stocks, "open").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "volume":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMax(stocks, "volume").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "diff":
						Console.WriteLine("Date\t\tDay\t\t\tOpen\t\tClose\t\tDiff\t\tVolume");
						Algorithms.FindMax(stocks, "diff").PrintData();

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("Press any key to return to Bank menu");
						Console.ResetColor();
						Console.ReadKey();
						complete = true;
						break;

					case "end":
						Program.endProgram = true;
						goBack = true;
						complete = true;
						break;

					case "cancel":
						break;
					default:
						falseEntry = true;
						complete = true;
						break;
				} //end switch
			} //end while
		} //end method
	}
}
