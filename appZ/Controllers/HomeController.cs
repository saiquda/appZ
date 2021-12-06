using appZ.Models;
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
        public async Task<IActionResult> Index(int SubjectId, int CountryId)
        {
            var model = new CountriesSubjectsCitiesViewModel();
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
            ViewBag.CityId = CityId;
            return View(model);
        }
        [ActionName("SaveCity")]
        public async Task<IActionResult> Index(int SubjectId, int CountryId, int CityId)
        {
            var model = new CountriesSubjectsCitiesViewModel();
            model.Countries = _context.Countries.ToList();
            model.Cities = await _context.Cities.Where(x => x.SubjectId == SubjectId).ToListAsync();
            model.Subjects = await _context.Subjects.Where(x => x.CountryId == CountryId).ToListAsync();
            HttpContext.Response.Cookies.Append("CityId", Convert.ToString(CityId));
            HttpContext.Response.Cookies.Append("SubjectId", Convert.ToString(SubjectId));
            HttpContext.Response.Cookies.Append("CountryId", Convert.ToString(CountryId));
            ViewBag.CityId = CityId;
            return View("Index", model);
        }

        //public async Task<IActionResult> Index()
        //{
        //    var model = new SubjectsCitiesViewModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Index(Subject Subject)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(Subject);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();

        //}
    }
}
