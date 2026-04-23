using De2.Models.Entities;

namespace De2.Services;

public interface IPrescriptionService
{
    decimal CalculateTotal(Prescription prescription);
    Task SavePrescriptionAsync(Prescription prescription);
}