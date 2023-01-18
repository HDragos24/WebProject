using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.Data;
using WebProject.Model;

namespace WebProject.Pages.Categories;

[BindProperties]
public class DeleteModel : PageModel
{
     private readonly AppDbContext _db;
     public Category Category { get; set; }

     public DeleteModel(AppDbContext db)
     {
        _db = db;
     }
     public void OnGet(int id)
     {
        Category = _db.Category.Find(id);
     }

     public async Task<IActionResult> OnPost()
     {
        var categoryFromDb = _db.Category.Find(Category.Id);
        if (categoryFromDb != null)
        {
           _db.Category.Remove(categoryFromDb);
           await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToPage("Index");
        }
        return Page();
     }
}

