using Microsoft.AspNetCore.Mvc;
using De2.Models.Entities;
using De2.Models.ViewModels;
using De2.Services;
using Microsoft.EntityFrameworkCore;
using De2.Data;

namespace De2.Controllers;

public class HomeController(IPrescriptionService service, ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var prescriptions = await context.Prescriptions.ToListAsync();
        var result = prescriptions.Select(p => new PrescriptionIndexVM
        {
            Id = p.PrescriptionId,
            PatientName = p.PatientName,
            IsSpecial = p is SpecialPrescription,
            TypeDisplayName = p is SpecialPrescription ? "Đặc biệt" : "Thường",
            TotalAmount = service.CalculateTotal(p)
        });
        return View(result);
    }

    public async Task<IActionResult> Details(string id)
    {
        // EF Core sẽ tự động Join các bảng Standard/Special nhờ vào TPT
        var prescription = await context.Prescriptions.FirstOrDefaultAsync(p => p.PrescriptionId == id);

        if (prescription == null) return NotFound();

        return View(prescription);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PrescriptionCreateVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            Prescription entity = vm.Type == "Special"
                ? new SpecialPrescription
                {
                    PrescriptionId = vm.PrescriptionId,
                    PatientName = vm.PatientName,
                    UnitPrice = vm.UnitPrice,
                    Quantity = vm.Quantity,
                    StorageFee = vm.StorageFee,
                    DoctorLicense = vm.DoctorLicense
                }
                : new StandardPrescription
                {
                    PrescriptionId = vm.PrescriptionId,
                    PatientName = vm.PatientName,
                    UnitPrice = vm.UnitPrice,
                    Quantity = vm.Quantity
                };

            await service.SavePrescriptionAsync(entity);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(vm);
        }
    }
}