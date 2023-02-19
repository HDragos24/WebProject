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
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly AppDbContext _db;
        public FoodTypeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FoodType obj)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
        }
    }
}
