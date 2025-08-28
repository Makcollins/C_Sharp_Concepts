using System;

namespace MedicalStore;

public class PurchaseManager
{
    static ListManager listManager = new ListManager();
    List<OrderDetails> ordersList = listManager.OrdersList();
    // List<OrderDetails> ordersList = new ListManager().OrdersList();
    public void PurchaseMedicine(UserDetails user, List<MedicineDetails> medicineDetails)
    {
        listManager.DisplayList(ordersList);
        bool correct;
        int medicineCount;

        do
        {
            correct = true;
            Console.Write("Select Medicine ID: ");
            string userInput = Console.ReadLine()!.ToUpper();

            do
            {
                Console.Write("Medicine Count: ");
                correct = int.TryParse(Console.ReadLine(), out medicineCount);
                if (!correct)
                    Console.WriteLine("Invalid Format\n");
            } while (!correct);

            var selectedMedicine = medicineDetails.Find(medicine => medicine.MedicineID == userInput);

            if (selectedMedicine != null)
            {
                correct = true;
                CountAvailable(medicineCount, selectedMedicine, user);
            }
            else
            {
                Console.WriteLine("Incorrect MedicineID\n");
                correct = false;
            }
        } while (!correct);
    }

    public void CountAvailable(int count, MedicineDetails selectedMedicine, UserDetails user)
    {
        if (count < selectedMedicine.AvailableCount && selectedMedicine.DateOfExpiry > DateTime.Now)
        {
            decimal totalPrice = count * selectedMedicine.Price;
            if (user.WalletBalance > (totalPrice))
            {
                selectedMedicine.AvailableCount -= count;
                user.DeductBalance(totalPrice);
                ordersList.Add(new OrderDetails(user.UserID, selectedMedicine.MedicineID, count, totalPrice, DateTime.Now, OrderStatus.Purchased));

                Console.WriteLine("Medicine was purchased successfully");
                listManager.OrdersList();
            }
        }
        else if (count < selectedMedicine.AvailableCount || selectedMedicine.DateOfExpiry < DateTime.Now)
        {
            Console.WriteLine("Medicine is not available");
        }
    }

}
