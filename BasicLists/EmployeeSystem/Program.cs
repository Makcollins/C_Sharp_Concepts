using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace EmployeeSystem
{
    public class Program
    {

        public List<Employee> employees = new List<Employee>();
        Employee loggedIn;
        static string eID;
        static string eName;
        static string eRole;
        static WorkLocation worklocation;
        static string teamName;
        static DateTime doj;
        static int WorkingDays;
        static int leavesTaken;
        static Gender gender;



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
                        eID = "SF" + "000" + inputID.ToString();
                    }
                    else if (inputID < 100)
                    {
                        eID = "SF" + "00" + inputID.ToString();
                    }
                    else if (inputID < 1000)
                    {
                        eID = "SF" + "0" + inputID.ToString();
                    }
                    else if (inputID >= 1000 && inputID < 10000)
                    {
                        eID = "SF" + inputID.ToString();
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
            Console.WriteLine($"{eID}");

            Console.Write("Enter Name: ");
            eName = Console.ReadLine();

            Console.Write("Employee Role: ");
            eRole = Console.ReadLine();

            do
            {
                try
                {
                    Console.Write("WorkLocation (Remote/Hybrid/Onsite): ");
                    worklocation = (WorkLocation)Enum.Parse(typeof(WorkLocation), Console.ReadLine());
                    test = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Case sensitive, check your spellings");
                    test = false;
                }
            } while (!test);

            Console.Write("Team Name: ");
            teamName = Console.ReadLine();

            do
            {
                try
                {
                    Console.Write("Date of Joining: ");
                    doj = Convert.ToDateTime(Console.ReadLine());
                    test = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date Format, please enter a correct date;");
                    test = false;
                }
    
            } while (!test);
            do
            {
                test = true;
                Console.Write("Number of Working days: ");
                WorkingDays = int.Parse(Console.ReadLine());

                if (WorkingDays > 28 || WorkingDays < 0)
                {
                    Console.WriteLine("Incorrect value!");
                    test = false;
                }
            } while (!test);
            do
            {
                Console.Write("Number of Leaves Taken: ");
                leavesTaken = int.Parse(Console.ReadLine());
                test = true;
                if (leavesTaken > WorkingDays)
                {
                    Console.WriteLine("Incorrect value!");
                    test = false;
                }

            } while (!test);

            do
            {
                try
                {
                    Console.Write("Enter Gender (Male/Female): ");
                    gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine().ToLower());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Case sensitive, check on the spellings");
                    test = false;
                }
            } while (!test);

            Employee emp = new Employee()
            {
                EmployeeID = eID,
                EmployeeName = eName,
                EmployeeRole = eRole,
                WorkLocation = worklocation.ToString(),
                TeamName = teamName,
                DateOfJoining = doj,
                WorkingDaysInAMonth = WorkingDays,
                NoOfLeaveTaken = leavesTaken,
                CustomerGender = gender.ToString()
            };
            Console.WriteLine($"New Employee ID: {emp.EmployeeID}");
            employees.Add(emp);

        }



        // LOGIN
        public void Login()
        {
            bool test = true;

            Console.WriteLine("Please Enter your ID: ");
            string inputID = Console.ReadLine();

            Employee result = employees.Find(userID => userID.EmployeeID == inputID);

            if (result == null)
            {
                Console.WriteLine("User Invalid Id");
            }
            else
            {
                loggedIn = result;
                do
                {
                    Console.WriteLine("Choose operation");
                    Console.WriteLine("1. Calculate salary \n2. display details \n3. exit");
                    int submenu = int.Parse(Console.ReadLine());

                    switch (submenu)
                    {
                        case 1:
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine($"Salary = Rs{loggedIn.SalaryCalculation()}");
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine("-----------------------------------------------");
                            break;
                        case 2:
                            loggedIn.EmployeeDetails();
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