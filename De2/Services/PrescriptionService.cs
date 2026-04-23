using De2.Data;
using De2.Models.Entities;

namespace De2.Services;

public class PrescriptionService(ApplicationDbContext context) : IPrescriptionService
{
    public decimal CalculateTotal(Prescription prescription) => prescription switch
    {
        StandardPrescription s => s.UnitPrice * s.Quantity,

        // Property Pattern kết hợp Validation
        SpecialPrescription sp when sp.Quantity > 10 && string.IsNullOrWhiteSpace(sp.DoctorLicense)
            => throw new InvalidOperationException("Số lượng lớn yêu cầu mã bác sĩ!"),

        SpecialPrescription sp => (sp.UnitPrice * sp.Quantity) + sp.StorageFee,

        _ => 0
    };

    public async Task SavePrescriptionAsync(Prescription prescription)
    {
        context.Prescriptions.Add(prescription);
        await context.SaveChangesAsync();
    }
}