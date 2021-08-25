using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpLift.DataAccess.Data.Repository.IRepository;
using UpLift.Models.ViewModels;

namespace UpLift.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ServiceVM ServVM = new ServiceVM()
            {
                Service = new Models.Service(),
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                FrequencyList = _unitOfWork.Frequency.GetFrequencyListForDropDown(),

            };
            if (id != null)
            {
                ServVM.Service = _unitOfWork.Service.Get(id.GetValueOrDefault());
            }
            return View(ServVM);
        }
         
        #region API CALLS
        public IActionResult GetALL()
        {
            return Json(new { data = _unitOfWork.Service.GetAll(includeProperties:"Category, Frequency")});
        }
        #endregion
    }
}
 