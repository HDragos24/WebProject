using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.Pages.Admin.FoodTypes;

[BindProperties]
public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public FoodType FoodType { get; set; }

    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet(int id)
     {
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id==id);
     }

     public async Task<IActionResult> OnPost()
     {
        if (ModelState.IsValid)
        {
            _unitOfWork.FoodType.Update(FoodType);
            _unitOfWork.Save();
            TempData["success"] = "Food type updated successfully.";
            return RedirectToPage("Index");
        }
        return Page();
     }
}

