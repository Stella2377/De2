namespace De2.Models.Entities;

public record StandardPrescription : Prescription
{
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}