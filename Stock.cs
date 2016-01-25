using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_Banks
{
	class Stock
	{
		//variables
		public int date;
		public string dateFormatted;
		public string day;
		public double close;
		public double diff;
		public double open;
		public int volume;
		public int numericalDay;

		public Stock(string dateFormatted, string day, double close, double diff, double open, int volume) //constructor
		{
			this.dateFormatted = dateFormatted;
			date = ConvertDate(dateFormatted);

			this.day = day;
			this.close = close;
			this.diff = diff;
			this.open = open;
			this.volume = volume;

			numericalDay = NumberDay(day);
		}


		int ConvertDate(string date)
		{
			string day = "";
			string month = "";
			string year = "";
			int count = 0;

			foreach(char c in date)
			{
				if(count < 2)
					day = day + c;
				else if(count > 5)
					year = year + c;
				else if(c != '/')
					month = month + c;

				count++;
			}

			string tempDate = year + month + day;

			return Convert.ToInt32(tempDate);
		}


		int NumberDay(string day)
		{
			switch(day)
			{
				case "Monday":
					return 1;
					break;
				case "Tuesday":
					return 2;
					break;
				case "Wednesday":
					return 3;
					break;
				case "Thursday":
					return 4;
					break;
				case "Friday":
					return 5;
					break;
				case "Saturday":
					return 6;
					break;
				case "Sunday":
					return 7;
					break;
				default:
					return 0;
					break;
			}
		}


		public void PrintData()
		{
			if(numericalDay == 3 || numericalDay == 4) 
				Console.WriteLine(dateFormatted + "\t" + day + "\t\t" + open + "\t\t" + close + "\t\t" + diff + "\t\t" + volume);
			else
				Console.WriteLine(dateFormatted + "\t" + day + "\t\t\t" + open + "\t\t" + close + "\t\t" + diff + "\t\t" + volume);
		}
	}
}
