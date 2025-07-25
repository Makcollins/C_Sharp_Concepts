using System;

namespace BankSystem;

public partial class Program
{
public List<Customer> customers = new List<Customer>();
        Customer loggedIn;
        static string cID;
        static string cName;
        static double bal;
        static Gender gender;
        static string phoneNo;
        static string mail;
        static DateTime dob;

        //REGISTER        
        public void Register()
        {
            bool test = true;

            int inputID = 0;
            do
            {
                Console.Write("NEW CUSTOMER ID: ");
                bool isNum = int.TryParse(Console.ReadLine(), out inputID);

                if (isNum)
                {
                    test = true;
                    if (inputID < 10)
                    {
                        cID = "HDFC" + "000" + inputID.ToString();
                    }
                    else if (inputID < 100)
                    {
                        cID = "HDFC" + "00" + inputID.ToString();
                    }
                    else if (inputID < 1000)
                    {
                        cID = "HDFC" + "0" + inputID.ToString();
                    }
                    else if (inputID >= 1000 && inputID < 10000)
                    {
                        cID = "HDFC" + inputID.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, can only take upto 4 digits");
                        test = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number of up to 4 digits");
                    test = false;
                }
            } while (test == false);
            Console.WriteLine($"{cID}");

            //user name
            Console.Write("Enter Name: ");
            cName = Console.ReadLine();
            
            //balance input
            do
            {
                Console.Write("Enter Balance: ");
                double myBal = 0;
                bool isBal = Double.TryParse(Console.ReadLine(), out myBal);
                if (isBal)
                {
                    bal = myBal;
                    test = true;
                }
                else
                {
                    Console.Write("Invalid Entry, Enter correct balance: ");
                    test = false;
                }
            } while (!test);

            do
            {
                try
                {
                    Console.Write("Enter Gender (Male/Female): ");
                    gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
                    test = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Case sensitive, check on your spellings");
                    test = false;
                }
            } while (!test);

            // Input phone number
            do
            {
                Console.Write("Enter Phone Number (07......../01........) : ");
                phoneNo = Console.ReadLine();

                //checking if the phone number contains 10 number characters
                int nums = 0;
                bool isNums = int.TryParse(phoneNo, out nums);

                if (isNums)
                {
                    if (phoneNo.Length == 10 && phoneNo[0] == '0' && (phoneNo[1] == '7' || phoneNo[1] == '1'))
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

            //mail ID
            Console.Write("Enter Mail ID: ");
            mail = Console.ReadLine();

            //Date of Birth
            do
            {
                try
                {
                    Console.Write("Enter Date Of Birth (dd/MM/yyyy): ");
                    dob = Convert.ToDateTime(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date Format, please enter a correct date;");
                    test = false;
                }

            } while (!test);
            Customer cust = new Customer()
            {
                CustomerID = cID,
                CustomerName = cName,
                Balance = bal,
                CustomerGender = gender.ToString(),
                Phone = phoneNo,
                MailID = mail,
                DOB = dob
            };
            customers.Add(cust);

        }

}
