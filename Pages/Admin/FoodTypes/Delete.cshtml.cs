using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.Pages.Admin.FoodTypes;

[BindProperties]
public class DeleteModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public FoodType FoodType { get; set; }

    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet(int id)
     {
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
     }

     public async Task<IActionResult> OnPost()
     {
        var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
        if (foodTypeFromDb != null)
        {
           _unitOfWork.FoodType.Remove(foodTypeFromDb);
           _unitOfWork.Save();
           TempData["success"] = "Food type deleted successfully.";
           return RedirectToPage("Index");
        }
        return Page();
     }
}

