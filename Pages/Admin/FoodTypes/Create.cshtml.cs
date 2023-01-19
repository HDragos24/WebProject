using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.Pages.Admin.FoodTypes;

[BindProperties]
public class CreateModel : PageModel
{
     private readonly IUnitOfWork _unitOfWork;
     public FoodType FoodType { get; set; }

     public CreateModel(IUnitOfWork unitOfWork)
     {
        _unitOfWork = unitOfWork;
     }
     public void OnGet()
     {
     }

     public async Task<IActionResult> OnPost()
     {
        if (ModelState.IsValid)
        {
            _unitOfWork.FoodType.Add(FoodType);
            _unitOfWork.Save();
            TempData["success"] = "Food type created successfully.";
            return RedirectToPage("Index");
        }
        return Page();
     }
}

