namespace De2.Models.Entities;

public record SpecialPrescription : Prescription
{
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
    public decimal StorageFee { get; init; }
    public string? DoctorLicense { get; init; }
}