using appZ.Models;
using appZ.Models.ViewModelBinding;
using appZ.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace appZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppZContext _context;

        public HomeController(ILogger<HomeController> logger, AppZContext context)
        {
            _logger = logger;
            _context = context;
        }
        [NonAction]
        private int GetSavedCity()
        {
            int CityId = Convert.ToInt32(HttpContext.Request.Cookies["CityId"]);
            return CityId;
        }
        [HttpPost]
        public async Task<IActionResult> GetCities(int SubjectId)
        {
            CitiesTableBinding model = new CitiesTableBinding();
            _context.Countries.Load();
            _context.Subjects.Load();
            model.Cities = await _context.Cities.Where(x => x.SubjectId == SubjectId).ToListAsync();
            model.CityId = 0;
            if (HttpContext.Request.Cookies.ContainsKey("CityId"))
            {
                model.CityId = Convert.ToInt32(HttpContext.Request.Cookies["CityId"]);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GetSubjects(int CountryId)
        {
            var context= new CountriesSubjectsCitiesViewModel();
            var model = new SubjectsTableBinding();
            var city = new CitiesTableBinding();
            _context.Countries.Load();
            _context.Subjects.Load();
            _context.Cities.Load();
            context.Subjects = await _context.Subjects.Where(x => x.CountryId == CountryId).ToListAsync();
            model.SubjectId = _context.Subjects.FirstOrDefault(x => x.CountryId == CountryId).Id;
            model.Subjects = context.Subjects;
            //city.Cities = await _context.Cities.Where(x => x.SubjectId == model.SubjectId).ToListAsync();
            //city.CityId = 0;
            //if (HttpContext.Request.Cookies.ContainsKey("CityId"))
            //{
            //    city.CityId = Convert.ToInt32(HttpContext.Request.Cookies["CityId"]);
            //}
            return View(model);
        }
        public async Task<IActionResult> Index(int SubjectId, int CountryId)
        {
            var model = new CountriesSubjectsCitiesViewModel();
            model.Binding = new CitiesTableBinding();
            model.SubjectsBinding = new SubjectsTableBinding();
            if (CountryId == 0)
            {
                if (HttpContext.Request.Cookies.ContainsKey("CountryId"))
                    CountryId = Convert.ToInt32(HttpContext.Request.Cookies["CountryId"]);
                else
                    CountryId = 1;
            }
            model.Countries = _context.Countries.ToList();
            int CityId = 0;
            if (SubjectId == 0)
            {
                if (HttpContext.Request.Cookies.ContainsKey("CityId"))
                {
                    CityId = Convert.ToInt32(HttpContext.Request.Cookies["CityId"]);
                    SubjectId = _context.Cities.Find(CityId).SubjectId;
                    if (!(_context.Subjects.Find(SubjectId).CountryId == CountryId))
                        SubjectId = _context.Subjects.FirstOrDefault(x => x.CountryId == CountryId).Id;
                }
                else
                    SubjectId = _context.Subjects.FirstOrDefault(x => x.CountryId == CountryId).Id;
            }
            model.Cities = await _context.Cities.Where(x => x.SubjectId == SubjectId).ToListAsync();
            model.Subjects = await _context.Subjects.Where(x => x.CountryId == CountryId).ToListAsync();
            model.SubjectsBinding.Subjects = model.Subjects;
            model.SubjectsBinding.SubjectId = SubjectId;
            model.Binding.CityId = CityId;
            model.Binding.Cities = model.Cities;
            return View(model);
        }
        [HttpPost]
        [ActionName("SaveCity")]
        public async Task<IActionResult> Index(int Subject, int Country, int CityId)
        {
            var model = new CountriesSubjectsCitiesViewModel();
            model.Binding = new CitiesTableBinding();
            model.SubjectsBinding = new SubjectsTableBinding();
            model.Countries = _context.Countries.ToList();
            model.Cities = await _context.Cities.Where(x => x.SubjectId == Subject).ToListAsync();
            model.Subjects = await _context.Subjects.Where(x => x.CountryId == Country).ToListAsync();
            model.SubjectsBinding.Subjects = model.Subjects;
            model.SubjectsBinding.SubjectId = Subject;
            model.Binding.CityId = CityId;
            model.Binding.Cities = model.Cities;
            HttpContext.Response.Cookies.Append("CityId", Convert.ToString(CityId));
            HttpContext.Response.Cookies.Append("SubjectId", Convert.ToString(Subject));
            HttpContext.Response.Cookies.Append("CountryId", Convert.ToString(Country));
            ViewBag.CityId = CityId;
            return View("Index", model);
        }
    }
}
