using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpLift.DataAccess.Data.Repository.IRepository;
using UpLift.Models;

namespace UpLift.DataAccess.Data.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

        public void Update(Service service)
        {
            var objFromDb = _db.Service.FirstOrDefault(s =>
               s.Id == service.Id);

            objFromDb.Name = service.Name;
            objFromDb.LongDesc = service.LongDesc;
            objFromDb.FrequencyId = service.FrequencyId;
            objFromDb.Price = service.Price;
            objFromDb.CategoryId = service.CategoryId;
            objFromDb.ImageUrl = service.ImageUrl;

            _db.SaveChanges();
        }
    }
}
