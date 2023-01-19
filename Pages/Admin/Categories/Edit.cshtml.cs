using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.Pages.Admin.Categories;

[BindProperties]
public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public Category Category { get; set; }

    public EditModel(IUnitOfWork unitOfWork)
    {
       _unitOfWork = unitOfWork;
    }
    public void OnGet(int id)
    {
       Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
    }

    public async Task<IActionResult> OnPost()
    {
       if (Category.Name == Category.DisplayOrder.ToString())
       {
           ModelState.AddModelError("Category.Name", "The Display Order cannot match the Name");
       }

       if (ModelState.IsValid)
       {
           _unitOfWork.Category.Update(Category);
           _unitOfWork.Save();
           TempData["success"] = "Category updated successfully.";
           return RedirectToPage("Index");
       }
       return Page();
    }
}

