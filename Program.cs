using System;
using System.Text.RegularExpressions;


public class Program
{
    public static void Main()
    {
        Console.Clear();
        Console.WriteLine("Date in DD/MM/YYYYY");

        //takes input and seperates it into dd, mm and yyyyy
        string fulldate = Console.ReadLine();
        var lengthcheck = "^[0-9/]*$";
        var check = Regex.Match(fulldate, lengthcheck, RegexOptions.IgnoreCase);

        if (!check.Success)
        {
            Console.WriteLine("Please only use the numbers 0-9 and the symbol /");
            Console.ReadLine();
            Main();
        }


        int length = fulldate.Length;
        if (length <11 || length > 11)
        {
            Console.WriteLine("String too long/short");
            Console.ReadLine();
            Main();
        }
        string sday = fulldate.Substring(0, 2);
        string smonth = fulldate.Substring(3, 2);
        string syear = fulldate.Substring(6, 5);
            //converts input to integer
        int day = Int32.Parse(sday);

        if (day >31)
        {
            Console.WriteLine("Day is too large");
            Console.ReadLine();
            Main();
        }

        int month = Int32.Parse(smonth);

        if (month > 12)
        {
            Console.WriteLine("Month is too large");
            Console.ReadLine();
            Main();
        }

        int year = Int32.Parse(syear);
        //works out if year is a leapyear
        var leapyear = 0;
        if (year % 4 == 0 && year % 100 != 0)
        {
            leapyear = 1;
        }
        else if (year % 100 == 0 && year % 400 == 0)
        {
            leapyear = 1;
        }

        if (day >= 29 && month == 2 && leapyear == 0)
        {
            Console.WriteLine("Please enter a valid date");
            Console.ReadLine();
            Main();
        }

        var dayofyear = 0;
        switch (month)
        {
            case 1: //january
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = day;
                break;
            case 2: //february
                if (leapyear == 1)
                {
                    if(day > 29)
                    {
                        Console.WriteLine("Please enter a valid date");
                        Console.ReadLine();
                        Main();
                    }
                }
                else
                {
                    if (day > 28)
                    {
                        Console.WriteLine("Please enter a valid date");
                        Console.ReadLine();
                        Main();
                    }
                }
                dayofyear = 31 + day;
                break;
            case 3: // march
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 59 + day + leapyear;
                break;
            case 4: //april
                if (day > 30)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 90 + day + leapyear;
                break;
            case 5: //may
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 120 + day + leapyear;
                break;
            case 6: //june
                if (day > 30)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 151 + day + leapyear;
                break;
            case 7: //july
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 181 + day + leapyear;
                break;
            case 8: //august
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 212 + day + leapyear;
                break;
            case 9: //september
                if (day > 30)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 243 + day + leapyear;
                break;
            case 10: //october
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 273 + day + leapyear;
                break;
            case 11: //november
                if (day > 30)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 304 + day + leapyear;
                break;
            case 12: //december
                if (day > 31)
                {
                    Console.WriteLine("Please enter a valid date");
                    Console.ReadLine();
                    Main();
                }
                dayofyear = 334 + day + leapyear;
                break;
        }
        //uses input to work out the day of the year

        //Console.WriteLine(dayofyear);

        Console.WriteLine("What time did the event happen, use 24 hour time format to the nearest hour");
        string hour = Console.ReadLine();
        int hourofday = 0;
        var regex = "^[0-9]*$";
        var match = Regex.Match(hour, regex, RegexOptions.IgnoreCase);

        if (!match.Success)
        {
            Console.WriteLine("Please only use the numbers 0-9");
            Console.ReadLine();
            Main();
        }
        else
        {
            hourofday = Int32.Parse(hour);
        }


            if (hourofday > 23)
        {
            Console.WriteLine("Please enter a time between 0 and 23");
        }
            
                //makr constant is used to convert the determined hour into a year fraction (x/1000)
                double makr = 0.11407955;

                //uses the day of year to get the 100th of a year, each 100th is 8 hours and 45 minutes
                int Determinedhour = dayofyear * 24 + hourofday;
                decimal dethour = Convert.ToDecimal(Determinedhour);
                decimal makrconstant = Convert.ToDecimal(makr);

                //multiplies hour and makr constant to 
                decimal impfrac = decimal.Multiply(dethour, makrconstant);

                //rounds the fraction down to the nearest whole number
                decimal help = Math.Floor(impfrac);
                string imperialfraction = Convert.ToString(help);

                //seperates the last 3 digits of the year
                string impyear = syear.Substring(2, 3);

                //gets the first two digits of the year and adds 1 making it the millenium number
                string mill = syear.Substring(0, 2);
                int millenium = Convert.ToInt32(mill);
                millenium += 1;

                //combines the fraction, year and millenium
                Console.WriteLine("That date and time is 0." + imperialfraction + "." + impyear + ".M" + millenium +" in Imperial record-keeping format");
                Console.ReadLine();
            return;

        }

    }