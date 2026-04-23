namespace De2.Models.ViewModels;

public class PrescriptionIndexVM
{
    public string Id { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public string TypeDisplayName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public bool IsSpecial { get; set; }
}