using System;

namespace MedicalStore;

public class MedicineDetails
{
    public string MedicineID { get; set; }
    public string? MedicineName { get; set; }
    public int AvailableCount { get; set; }
    public decimal Price { get; set; }
    public DateTime DateOfExpiry { get; set; }
    static int counter = 101;
    public MedicineDetails()
    {
        MedicineID = $"MD{counter++}";
    }
}
