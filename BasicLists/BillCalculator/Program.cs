using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace BillCalculator
{
    public class Program
    {

        public List<Bill> bills = new List<Bill>();
        Bill loggedIn;
        string meterID = "EB1001";
        string userName;
        string phone;
        string mailId;

        int unitUsed = 0;


        //REGISTER        
        public void Register()
        {
            bool test = true;
            Console.Write("User Name: ");
            userName = Console.ReadLine();

             // Input phone number
            do
            {
                Console.Write("Enter Phone Number (07......../01........) : ");
                phone = Console.ReadLine();

                //checking if the phone number contains 10 number characters
                int nums = 0;
                bool isNums = int.TryParse(phone, out nums);

                if (isNums)
                {
                    if (phone.Length == 10 && phone[0] == '0' && (phone[1] == '7' || phone[1] == '1'))
                    {
                        test = true;
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("Invalid Format. start with 07/01 (ensure you input 10 characters) :");
                        test = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid character. Enter a correct phone number: ");
                    test = false;
                }
            } while (!test);

            Console.Write("Enter mail ID: ");
            mailId = Console.ReadLine();

            Bill newBill = new Bill()
            {
                MeterID = meterID,
                UserName = userName,
                PhoneNumber = phone,
                MailID = mailId,
                UnitsUsed = unitUsed
            };
            Console.WriteLine("\n-------------------------------------------------------");
            Console.WriteLine($"METER ID: {newBill.MeterID}");
            Console.WriteLine("-------------------------------------------------------\n");
            bills.Add(newBill);

        }




        // LOGIN
        public void Login()
        {
            bool test = true;

            Console.WriteLine("Please Enter your ID: ");
            string inputID = Console.ReadLine();

            Bill result = bills.Find(myMeterID => myMeterID.MeterID == inputID);

            if (result == null)
            {
                Console.WriteLine("Invalid Meter ID");
            }
            else
            {
                loggedIn = result;
                do
                {
                    Console.WriteLine("Choose operation");
                    Console.WriteLine("1. Calculate Amount \n2. Display user Details \n3. Exit");
                    int submenu = int.Parse(Console.ReadLine());

                    switch (submenu)
                    {
                        case 1:
                            loggedIn.CalculateAmount();
                            break;
                        case 2:
                            loggedIn.DisplayDetails();
                            break;
                        case 3:
                            test = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                } while (test);

            }

        }


        //Main method
        static void Main(string[] args)
        {
            Program pg = new Program();

            bool test = true;

            do
            {
                Console.WriteLine("Choose operation");
                Console.WriteLine("1.Registration \n2.Login \n3.Exit");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        pg.Register();
                        break;
                    case 2:
                        pg.Login();
                        break;
                    case 3:
                        test = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (test);


        }
    }
}