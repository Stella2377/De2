using System.ComponentModel.DataAnnotations;

namespace De2.Models.ViewModels;

public class PrescriptionCreateVM
{
    [Required] public string PrescriptionId { get; set; } = string.Empty;
    [Required] public string PatientName { get; set; } = string.Empty;
    public string Type { get; set; } = "Standard"; // Standard hoặc Special
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal StorageFee { get; set; }
    public string? DoctorLicense { get; set; }
}