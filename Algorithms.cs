using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CMP1124M_Banks
{
	class Algorithms
	{
		public static int Bubble(ref int[] seq) //bubble sort int array
		{
			//variables
			int passes = 0;
			int tempNum;
			bool fin = false;

			while (!fin)
			{
				fin = true;
				passes++;

				for (int i = 0; i < seq.Length - 1; i++)
				{
					if (seq[i] > seq[i + 1]) //compares 2 elements and swaps them if needed
					{
						fin = false;
						tempNum = seq[i];
						seq[i] = seq[i + 1];
						seq[i + 1] = tempNum;
					}
				}
			}

			return passes;
		}


		public static int Bubble(ref Stock[] stockArray, string sortField) //bubble sort Object array
		{
			//variables
			int passes = 0;
			Stock tempStock;
			bool fin = false;

			switch(sortField) //check which field to sort by
			{
				case "day":
					while (!fin)
					{
						fin = true;
						passes++;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].numericalDay > stockArray[i + 1].numericalDay) //compares 2 objects and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
							}
						}
					}
					break;

				case "date":
					while (!fin)
					{
						fin = true;
						passes++;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].date > stockArray[i + 1].date) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
							}
						}
					}
					break;

				case "close":
					while (!fin)
					{
						fin = true;
						passes++;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].close > stockArray[i + 1].close) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
							}
						}
					}
					break;

				case "open":
					while (!fin)
					{
						fin = true;
						passes++;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].open > stockArray[i + 1].open) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
							}
						}
					}
					break;

				case "volume":
					while (!fin)
					{
						fin = true;
						passes++;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].volume > stockArray[i + 1].volume) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
							}
						}
					}
					break;

				case "diff":
					while (!fin)
					{
						fin = true;
						passes++;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].diff > stockArray[i + 1].diff) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
							}
						}
					}
					break;

				default:
					passes = -1;
					break;
			}

			return passes;
		}


		public static int BubbleReverse(ref Stock[] stockArray, string sortField) //bubble sort Object array
		{
			//variables
			int passes = 0;
			Stock tempStock;
			bool fin = false;

			switch (sortField) //check which field to sort by
			{
				case "day":
					while (!fin)
					{
						fin = true;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].numericalDay < stockArray[i + 1].numericalDay) //compares 2 objects and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
								passes++;
							}
						}
					}
					break;

				case "date":
					while (!fin)
					{
						fin = true;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].date < stockArray[i + 1].date) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
								passes++;
							}
						}
					}
					break;

				case "close":
					while (!fin)
					{
						fin = true;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].close < stockArray[i + 1].close) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
								passes++;
							}
						}
					}
					break;

				case "open":
					while (!fin)
					{
						fin = true;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].open < stockArray[i + 1].open) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
								passes++;
							}
						}
					}
					break;

				case "volume":
					while (!fin)
					{
						fin = true;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].volume < stockArray[i + 1].volume) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
								passes++;
							}
						}
					}
					break;

				case "diff":
					while (!fin)
					{
						fin = true;

						for (int i = 0; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].diff < stockArray[i + 1].diff) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
								stockArray[i] = stockArray[i + 1];
								stockArray[i + 1] = tempStock;
								passes++;
							}
						}
					}
					break;

				default:
					passes = -1;
					break;
			}

			return passes;
		}


		public static Stock[] LinearSearch(Stock[] stockArray, string searchField, string target)
		{
			Stock[] searchResults = new Stock[stockArray.Length];

			switch (searchField) //check which field to sort by
			{
				case "day":
					/*for(int i = 0; i < stockArray.Length; i++)
					{
						if(stockArray[i].day.ToLower() == target.ToLower())
						{
							searchResults[i] = stockArray[i];
						}
					} */

					Parallel.For(0, stockArray.Length, i => {
						if(stockArray[i].day.ToLower() == target.ToLower())
						{
							searchResults[i] = stockArray[i];
						}
					}); 
					break;

				case "date":
					/*for (int i = 0; i < stockArray.Length; i++)
					{
						if (stockArray[i].dateFormatted == target.ToLower())
						{
							searchResults[i] = stockArray[i];
						}
					}*/

					Parallel.For(0, stockArray.Length, i => {
						if (stockArray[i].dateFormatted == target.ToLower())
						{
							searchResults[i] = stockArray[i];
						}
					}); 
					break;

				case "close":
					/*for (int i = 0; i < stockArray.Length; i++)
					{
						if (stockArray[i].close == Convert.ToDouble(target))
						{
							searchResults[i] = stockArray[i];
						}
					}*/

					Parallel.For(0, stockArray.Length, i => {
						if (stockArray[i].close == Convert.ToDouble(target))
						{
							searchResults[i] = stockArray[i];
						}
					}); 
					break;

				case "open":
					/*for (int i = 0; i < stockArray.Length; i++)
					{
						if (stockArray[i].open == Convert.ToDouble(target))
						{
							searchResults[i] = stockArray[i];
						}
					}*/

					Parallel.For(0, stockArray.Length, i => {
						if (stockArray[i].open == Convert.ToDouble(target))
						{
							searchResults[i] = stockArray[i];
						}
					}); 
					break;

				case "volume":
					/*for (int i = 0; i < stockArray.Length; i++)
					{
						if (stockArray[i].volume == Convert.ToInt32(target))
						{
							searchResults[i] = stockArray[i];
						}
					}*/

					Parallel.For(0, stockArray.Length, i => {
						if (stockArray[i].volume == Convert.ToInt32(target))
						{
							searchResults[i] = stockArray[i];
						}
					}); 
					break;

				case "diff":
					/*for (int i = 0; i < stockArray.Length; i++)
					{
						if (stockArray[i].diff == Convert.ToDouble(target))
						{
							searchResults[i] = stockArray[i];
						}
					}*/

					Parallel.For(0, stockArray.Length, i => {
						if (stockArray[i].diff == Convert.ToDouble(target))
						{
							searchResults[i] = stockArray[i];
						}
					}); 
					break;

				default:
					break;
			}

			return searchResults;
		}


		public static Stock FindMax(Stock[] stockArray, string sortField) //Find maximum Object array
		{
			//variables
			Stock tempStock = stockArray[0];
			bool fin = false;

			switch (sortField) //check which field to sort by
			{
				case "date":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].date > tempStock.date) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "close":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].close > tempStock.close) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "open":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].open > tempStock.open) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "volume":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].volume > tempStock.volume) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "diff":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].diff > tempStock.diff) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				default:
					break;
			}

			return tempStock;
		}


		public static Stock FindMin(Stock[] stockArray, string sortField) //Find minimum Object array
		{
			//variables
			Stock tempStock = stockArray[0];
			bool fin = false;

			switch (sortField) //check which field to sort by
			{
				case "date":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].date < tempStock.date) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "close":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].close < tempStock.close) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "open":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].open < tempStock.open) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "volume":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].volume < tempStock.volume) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				case "diff":
					while (!fin)
					{
						fin = true;

						for (int i = 1; i < stockArray.Length - 1; i++)
						{
							if (stockArray[i].diff < tempStock.diff) //compares 2 elements and swaps them if needed
							{
								fin = false;
								tempStock = stockArray[i];
							}
						}
					}
					break;

				default:
					break;
			}

			return tempStock;
		}


		public static Stock[] BinarySearch(Stock[] stockArray, string sortField, string target, char ascendDescend) 
		{
			int low = 0; 
			int high = stockArray.Length;
			int midpoint;
			bool compleate = false;
			if (ascendDescend == 'd')
				Array.Reverse(stockArray);

			Stock[] searchResults = new Stock[stockArray.Length];
			switch(sortField)
			{ 
				case "day":
					int intDay = Convert.ToInt32(target);

					while (low <= high && compleate == false)
					{
						midpoint = (low + high) / 2;

						if (intDay == stockArray[midpoint].numericalDay)
						{
							searchResults[midpoint] = stockArray[midpoint];

							Parallel.Invoke(() =>
								{	
									bool success1 = true;
									int testValue1 = midpoint;
									while (success1) //finds all equal values above first success
									{
										testValue1++;
										if (testValue1 >= 0 && testValue1 < stockArray.Length)
										{
											if (intDay == stockArray[testValue1].numericalDay)
											{
												searchResults[testValue1] = stockArray[testValue1];
											}
											else
											{
												success1 = false;
											}
										}
										else
										{
											success1 = false;
										}
									}
								},
									() =>
									{
										bool success2 = true;
										int testValue2 = midpoint;

										while (success2)//finds all equal values below first success
										{
											testValue2--;
											if (testValue2 >= 0 && testValue2 < stockArray.Length)
											{
												if (intDay == stockArray[testValue2].numericalDay)
												{
													searchResults[testValue2] = stockArray[testValue2];
												}
												else
												{
													success2 = false;
												}
											}
											else
											{
												success2 = false;
											}
										}
									});

							compleate = true;
						}
						else if (intDay > stockArray[midpoint].numericalDay) 
						{
							low = midpoint + 1;
						}
						else 
						{
							high = midpoint - 1;
						}
					}
					break;

				case "close":
					double doubleClose = Convert.ToDouble(target);

					while (low <= high && compleate == false)
					{
						midpoint = (low + high) / 2;

						if (doubleClose == stockArray[midpoint].close)
						{
							searchResults[midpoint] = stockArray[midpoint];

							Parallel.Invoke(()=>
								{
									bool success = true;
									int testValue = midpoint;
									while (success)//finds all equal values above first success
									{
										testValue++;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (doubleClose == stockArray[testValue].close)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								},
								() =>
								{
									bool success = true;
									int testValue = midpoint;

									while (success)//finds all equal values below first success
									{
										testValue--;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (doubleClose == stockArray[testValue].close)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								});
							compleate = true;
						}
						else if (doubleClose > stockArray[midpoint].close)
						{
							low = midpoint + 1;
						}
						else
						{
							high = midpoint - 1;
						}
					}
					break;

				case "open":
					double doubleOpen = Convert.ToDouble(target);

					while (low <= high && compleate == false)
					{
						midpoint = (low + high) / 2;

						if (doubleOpen == stockArray[midpoint].open)
						{
							searchResults[midpoint] = stockArray[midpoint];

							Parallel.Invoke(()=>
								{
									bool success = true;
									int testValue = midpoint;
									while (success)//finds all equal values above first success
									{
										testValue++;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (doubleOpen == stockArray[testValue].open)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								},
								()=>
								{
									bool success = true;
									int testValue = midpoint;

									while (success)//finds all equal values below first success
									{
										testValue--;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (doubleOpen == stockArray[testValue].open)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								});
							compleate = true;
						}
						else if (doubleOpen > stockArray[midpoint].open)
						{
							low = midpoint + 1;
						}
						else
						{
							high = midpoint - 1;
						}
					}
					break;

				case "diff":
					double doubleDiff = Convert.ToDouble(target);

					while (low <= high && compleate == false)
					{
						midpoint = (low + high) / 2;

						if (doubleDiff == stockArray[midpoint].diff)
						{
							searchResults[midpoint] = stockArray[midpoint];

							Parallel.Invoke(()=>
								{
									bool success = true;
									int testValue = midpoint;
									while (success)//finds all equal values above first success
									{
										testValue++;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (doubleDiff == stockArray[testValue].diff)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								},
								()=>
								{
									bool success = true;
									int testValue = midpoint;

									while (success)//finds all equal values below first success
									{
										testValue--;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (doubleDiff == stockArray[testValue].diff)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								});
							compleate = true;
						}
						else if (doubleDiff > stockArray[midpoint].diff)
						{
							low = midpoint + 1;
						}
						else
						{
							high = midpoint - 1;
						}
					}
					break;

				case "volume":
					int intVolume = Convert.ToInt32(target);

					while (low <= high && compleate == false)
					{
						midpoint = (low + high) / 2;

						if (intVolume == stockArray[midpoint].volume)
						{
							searchResults[midpoint] = stockArray[midpoint];

							Parallel.Invoke(()=>
								{
									bool success = true;
									int testValue = midpoint;
									while (success)//finds all equal values above first success
									{
										testValue++;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (intVolume == stockArray[testValue].volume)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								},
								()=>
								{
									bool success = true;
									int testValue = midpoint;

									while (success)//finds all equal values below first success
									{
										testValue--;
										if (testValue >= 0 && testValue < stockArray.Length)
										{
											if (intVolume == stockArray[testValue].volume)
											{
												searchResults[testValue] = stockArray[testValue];
											}
											else
											{
												success = false;
											}
										}
										else
										{
											success = false;
										}
									}
								});
							compleate = true;
						}
						else if (intVolume > stockArray[midpoint].volume)
						{
							low = midpoint + 1;
						}
						else
						{
							high = midpoint - 1;
						}
					}
					break;
			}

			return searchResults;
		}


		public static int HeapSort(ref Stock[] input, char dir)
		{
			//Build Heap
			int heapSize = input.Length;
			int counter = 0;

			for (int p = (heapSize - 1) / 2; p >= 0; p--)
			{
				counter += Heapify(ref input, heapSize, p);
			}

			for (int i = input.Length - 1; i > 0; i--)
			{
				//Swap
				Stock temp = input[i];
				input[i] = input[0];
				input[0] = temp;

				heapSize--;
				counter += Heapify(ref input, heapSize, 0);
				
			}

			if(dir =='d')
			{
				counter += ReverseArray(input);
			}

			return counter;
		}

		private static int Heapify(ref Stock[] input, int heapSize, int index)
		{
			int left = (index + 1) * 2 - 1;
			int right = (index + 1) * 2;
			int largest = 0; 
			int counter = 0;

			if (left < heapSize && input[left].volume > input[index].volume) 
				largest = left;
			else
				largest = index;

			if (right < heapSize && input[right].volume > input[largest].volume) 
				largest = right;

			if (largest != index)
			{
				Stock temp = input[index]; 
				input[index] = input[largest];
				input[largest] = temp;

				counter += Heapify(ref input, heapSize, largest) + 1;
			}
			return counter;
		}


		public static int ReverseArray(Stock[] input)
		{
			int counter = 0;
			Stopwatch time = new Stopwatch();
			time.Start();
			/*for (int i = 0; i < (input.Length - 1) / 2; i++)
			{
				Stock temp = input[i];
				input[i] = input[(input.Length - 1) - i];
				input[(input.Length - 1) - i] = temp;
				counter++;
			} 
			Debug.WriteLine(time.ToString());*/

			Parallel.For(0, (input.Length - 1) / 2, i => {
				Stock temp = input[i];
				input[i] = input[(input.Length - 1) - i];
				input[(input.Length - 1) - i] = temp;
				counter++;
			});
			
			Debug.WriteLine(time.ToString());

			return counter;
		}
	}

}
