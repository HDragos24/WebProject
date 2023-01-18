using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.Data;
using WebProject.Model;

namespace WebProject.Pages.Categories;

[BindProperties]
public class CreateModel : PageModel
{
     private readonly AppDbContext _db;
     public Category Category { get; set; }

     public CreateModel(AppDbContext db)
     {
        _db = db;
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
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category created successfully.";
            return RedirectToPage("Index");
        }
        return Page();
     }
}

