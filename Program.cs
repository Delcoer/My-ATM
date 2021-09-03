using System;
using System.Text;

namespace MyATM
{
    class Program
    {
        static string c_Pin = "6789";
        static privat double balance = 1000;
        static int counter = 2;
        static void Main(string[] args)
        {

            //Titel from console
            Console.Title = "ATM Machine";

            //Text colour
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Hello customer! Please enter your PIN! With x/X reject card!\n"); 

            //Checking PIN
            while (true)
            {
                try
                {
                    string pin = AskPIN();

                    if(pin == "x" || pin == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\nThank you for your visit and goodbye!\n");
                        Environment.Exit(0);
                    }

                    else if (pin == c_Pin)
                    {
                        break;
                    }

                    else if (counter == 0)
                    {
                        Console.WriteLine("\nThis is your last try!!\n");

                    }

                    else if (counter == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour card has been blocked, please report to the staff!");
                        Environment.Exit(0);
                    }

                    else
                    {

                        Console.WriteLine("\nWrong PIN!!! You have " + counter + " more attempts \n");

                    }

                    counter--;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //User interaction
            while (true)
            {
                try
                {
                    Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\nWelcome, what would you like to do? \n1.Check account balance \n2.Withdraw \n3.Pay in \n4.Exit \n");
                    string input2 = Console.ReadLine();

                    if (input2 == "1" || input2 == "2" || input2 == "3" || input2 == "4")
                    {
                        switch (input2)
                        {
                            case "1":
                                Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("\nYour current account balance is: " + balance + "Fr.\n");
                                break;

                            case "2":
                                while (true)
                                {
                                    Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("\nHow much do you want to withdraw? With x/X back\n");
                                    string input3 = (Console.ReadLine());
                                    if (input3 == "x" || input3 == "X")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        balance = balance - Convert.ToDouble(input3);
                                    }
                                    Console.WriteLine("\nYour current account balance is: " + balance + "Fr.\n");
                                    break;
                                }
                                break;
                                
                                
                            case "3":
                                while (true)
                                {
                                    Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("\nPlease indicate how much you would like to pay in? With x/X back\n");
                                    string input4 = Console.ReadLine();
                                    if (input4 == "x" || input4 == "X")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        balance = balance + Convert.ToDouble(input4);
                                    }
                                    Console.WriteLine("\nYour current account balance is: " + balance + "Fr.\n");
                                    break;
                                }
                                break;

                            case "4":
                                Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n\nThank you for your visit and goodbye!\n");
                                Environment.Exit(0);
                                break;


                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a number from 1 to 4 !");
                        continue;
                    }
                    while (true)
                    {
                        Console.WriteLine("Would you like to use other functions? y/Y für YES oder n/N for NO\n");
                        string input4 = Console.ReadLine();

                        if (input4 == "y" || input4 == "Y")
                        {
                            break;
                        }

                        else if (input4 == "n" || input4 == "N")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Thank you for your visit and goodbye!");
                            Environment.Exit(0);
                            
                        }

                        else
                        {
                            Console.WriteLine("\nWrong entry! Use y/Y or n/N !\n");
                            continue;
                        }
                    }
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
                                     
        }

        //Method for request PIN and hide with *
        private static string AskPIN()
        {
            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (!char.IsControl(keyInfo.KeyChar))
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write("*");

                }

            }

            while (keyInfo.Key != ConsoleKey.Enter);
            {

                return sb.ToString();

            }

        }

    }
}
