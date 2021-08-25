using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpLift.Models;

namespace UpLift.DataAccess.Data.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
       // IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Service service);
    }
}
