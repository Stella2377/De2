namespace De2.Models.Entities;

public abstract record Prescription
{
    public required string PrescriptionId { get; init; }
    public required string PatientName { get; init; }
    public DateTime CreatedDate { get; init; } = DateTime.Now;
}