using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository.IRepository;
using WebProject.Models;

namespace WebProject.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
