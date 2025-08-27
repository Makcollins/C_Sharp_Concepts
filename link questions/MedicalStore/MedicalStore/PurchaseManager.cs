using System;

namespace MedicalStore;

public class PurchaseManager
{
    public void PurchaseMedicine(UserDetails user, List<MedicineDetails> medicineDetails)
    {
        bool correct;
        int medicineCount;

        Console.Write("Select Medicine ID: ");
        string userInput = Console.ReadLine()!;

        do
        {
            Console.Write("Medicine Count: ");
            correct = int.TryParse(Console.ReadLine(), out medicineCount);
            if (!correct)
                Console.WriteLine("Invalid Format");

        } while (!correct);

        var selectedMedicine = medicineDetails.Find(medicine => medicine.MedicineID == userInput);

        if (selectedMedicine != null)
        {

        }
        else
        {
            Console.WriteLine("Incorrect MedicineID");
        }
    }

    public void CountAvailable(int count, MedicineDetails selectedMedicine,UserDetails user)
    {
        if (count < selectedMedicine.AvailableCount && selectedMedicine.DateOfExpiry > DateTime.Now)
        {
            if (user.WalletBalance > (count * selectedMedicine.Price))
            {
                selectedMedicine.AvailableCount -= count;
                user.DeductBalance(selectedMedicine.Price);
            }
        }
        else if (count < selectedMedicine.AvailableCount || selectedMedicine.DateOfExpiry < DateTime.Now)
        {
            Console.WriteLine("Medicine is not available");
        }
    }
}
