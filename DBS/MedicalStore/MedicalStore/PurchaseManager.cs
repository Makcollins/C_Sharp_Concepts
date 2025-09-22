using System;

namespace MedicalStore;

public class PurchaseManager
{
    static ListManager listManager = new ListManager();
    List<OrderDetails> ordersList = listManager.OrdersList();
    public void PurchaseMedicine(UserDetails user, List<MedicineDetails> medicineDetails)
    {
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
        if (count <= selectedMedicine.AvailableCount && selectedMedicine.DateOfExpiry > DateTime.Now)
        {
            decimal totalPrice = count * selectedMedicine.Price;
            if (user.WalletBalance >= totalPrice)
            {
                selectedMedicine.AvailableCount -= count;
                user.DeductBalance(totalPrice);
                ordersList.Add(new OrderDetails(user.UserID, selectedMedicine.MedicineID, count, totalPrice, DateTime.Now, OrderStatus.Purchased));

                Console.WriteLine("Medicine was purchased successfully\n");
                listManager.OrdersList();
            }
            else
            {
                Console.WriteLine("Insuffient balance!\n");
            }
        }
        else if (count > 0 || selectedMedicine.DateOfExpiry < DateTime.Now)
        {
            Console.WriteLine("Medicine is not available\n");
        }
        else if (count > selectedMedicine.AvailableCount) { Console.WriteLine($"Sorry, we only have {selectedMedicine.AvailableCount} in Store.\n"); }
    }

    public void ModifyPurchase(UserDetails user, List<MedicineDetails> medicines)
    {
        var purchasedOrders = ordersList.FindAll(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Purchased);

        if (purchasedOrders.Any())
        {
            listManager.DisplayList(purchasedOrders);

            Console.Write("\nEnter OrderID : ");
            string userInput = Console.ReadLine()!.ToUpper().Trim();

            var selectedOrder = purchasedOrders.Find(order => order.OrderID == userInput);

            if (selectedOrder != null)
            {
                var selectedMedicine = medicines.Find(m => m.MedicineID == selectedOrder.MedicineID)!;

                int newQuantity;

                bool correct;

                int totalCount = selectedMedicine.AvailableCount + selectedOrder.MedicineCount;

                do
                {
                    Console.Write("Enter new quantity: ");

                    correct = int.TryParse(Console.ReadLine(), out newQuantity);

                    if (!correct) { Console.WriteLine("Incorrect format, please input a number\n"); }
                    else if (newQuantity > totalCount)
                    {
                        Console.WriteLine($"Sorry, We only have {totalCount} in store!\n");
                    }

                } while (!correct || newQuantity > totalCount);

                if (newQuantity == 0)
                {
                    user.WalletRecharge(selectedOrder.TotalPrice);
                    selectedOrder.OrderStatus = OrderStatus.Cancelled;
                    Console.WriteLine($"Order {selectedOrder.OrderID} was cancelled!\n");
                }
                else if (newQuantity < 0)
                {
                    Console.WriteLine("Invalid Entry!\n");
                }
                else
                {
                    decimal oldPrice = selectedOrder.TotalPrice;
                    int difference = totalCount - newQuantity;
                    selectedMedicine.AvailableCount += difference;
                    selectedOrder.MedicineCount = newQuantity;
                    selectedOrder.TotalPrice = selectedMedicine.Price * newQuantity;

                    if (selectedOrder.TotalPrice > oldPrice) user.DeductBalance(selectedOrder.TotalPrice - oldPrice);
                    else user.WalletRecharge(oldPrice - selectedOrder.TotalPrice);

                    Console.WriteLine("Order Modified Successfully!\n");
                }

            }
            else
            {
                Console.WriteLine("Invalid OrderID\n");
            }
        }
        else
            Console.WriteLine("No orders found\n");
    }

    public void rechargeAfterModify(UserDetails user, decimal oldPrice, decimal newPrice)
    {
        if (newPrice > oldPrice) user.DeductBalance(newPrice - oldPrice);
        else user.WalletRecharge(oldPrice - newPrice);
    }

    public void CancelPurchase(UserDetails user, List<MedicineDetails> medicines)
    {
        var purchasedOrders = ordersList.FindAll(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Purchased);
        if (!purchasedOrders.Any())
        {
            Console.WriteLine("No orders found...\n");
        }

        else
        {
            listManager.DisplayList(purchasedOrders);

            Console.Write("\nEnter OrderID : ");
            string userInput = Console.ReadLine()!.ToUpper().Trim();

            var selectedOrder = purchasedOrders.Find(order => order.OrderID == userInput);

            if (selectedOrder != null)
            {
                var selectedMedicine = medicines.Find(m => m.MedicineID == selectedOrder.MedicineID)!;

                selectedMedicine.AvailableCount += selectedOrder.MedicineCount;
                user.WalletRecharge(selectedOrder.TotalPrice);
                selectedOrder.OrderStatus = OrderStatus.Cancelled;

                Console.WriteLine($"Order {selectedOrder.OrderID} was cancelled Successfully!\n");
            }
        }
    }

    public void RechargeWallet(UserDetails user)
    {
        bool correct;
        decimal rechargeAmount;
        do
        {
            Console.Write("Enter Balance:");
            correct = decimal.TryParse(Console.ReadLine(), out rechargeAmount);
            if (!correct)
                Console.WriteLine("Invalid Entry!\n");
        } while (!correct);
        user.WalletRecharge(rechargeAmount);
    }

    public void PurchaseHistory(UserDetails user)
    {
        listManager.DisplayList(ordersList.FindAll(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Purchased));
    }

}
