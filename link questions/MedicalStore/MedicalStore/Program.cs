using System;

namespace MedicalStore
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistrationManager activeRegistration = new();
            ListManager listManager = new ListManager();

            List<UserDetails> usersList = listManager.UsersList();

            List<MedicineDetails> medicinesList = listManager.MedicinesList();

            List<OrderDetails> ordersList = listManager.OrdersList();

            // listManager.DisplayUsers();
            // listManager.DisplayMedicines();
            // listManager.DisplayOrders();


             Console.WriteLine("\n{0}\nONLINE MEDICAL STORE\n{0}\n", new String('*', 60));
            do
            {
                Console.WriteLine("\n{0}\nMAIN MENU\n{0}", new String('.', 60));
                Console.WriteLine("\n1. User Registration\n2. User Login\n3. Exit");

                int.TryParse(Console.ReadLine()!, out int choice);

                switch (choice)
                {
                    case 1:
                        activeRegistration.Registration(usersList);
                        break;
                    case 2:
                        activeRegistration.Login(usersList,medicinesList);
                        break;
                    case 3:
                        return;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }
    }
}