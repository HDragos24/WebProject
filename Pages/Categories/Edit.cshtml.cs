using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.Data;
using WebProject.Model;

namespace WebProject.Pages.Categories;

[BindProperties]
public class EditModel : PageModel
{
     private readonly AppDbContext _db;
     public Category Category { get; set; }

     public EditModel(AppDbContext db)
     {
        _db = db;
     }
     public void OnGet(int id)
     {
        Category = _db.Category.Find(id);
     }

     public async Task<IActionResult> OnPost()
     {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot match the Name");
        }

        if (ModelState.IsValid)
        {
            _db.Category.Update(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category updated successfully.";
            return RedirectToPage("Index");
        }
        return Page();
     }
}

