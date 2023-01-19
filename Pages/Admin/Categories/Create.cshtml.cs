using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.Pages.Admin.Categories;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public Category Category { get; set; }

    public CreateModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet()
     {
     }

     public async Task<IActionResult> OnPost()
     {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot match the Name");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(Category);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully.";
            return RedirectToPage("Index");
        }
        return Page();
     }
}
