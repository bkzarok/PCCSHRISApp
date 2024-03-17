using HRISApplication.Models;
using HRISApplication.Models.ChartModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HRISApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SspdfContext _context;
        

        public HomeController(ILogger<HomeController> logger, SspdfContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var soldierRankCount =
               from s in _context.PersonalDetails
               group s by s.SoldierRank into g
               select new WordCount { Word = g.Key, Count = g.Count() };

            var soldierBloodGroupCount =
               from s in _context.PersonalDetails
               group s by s.BloodGroup into g
               select new WordCount { Word = g.Key, Count = g.Count() };

            var soldierGenderCount =
               from s in _context.PersonalDetails
               group s by s.Gender into g
               select new WordCount { Word = g.Key ? "Male" : "Female", Count = g.Count() };

            var ethnicityCount =
               from s in _context.PersonalDetails
               group s by s.Ethnicity into g
               select new WordCount { Word = g.Key, Count = g.Count() };

            var soldierBirthDayCount =
               from s in _context.PersonalDetails
               group s by s.DateOfBirth.Year-DateTime.Now.Year into g
               select new WordCount { Word = g.Key.ToString(), Count = g.Count() };

            var getbierdat = from s in _context.PersonalDetails
                             select new
                             {
                                 s.DateOfBirth 

                                 
                             }.DateOfBirth ;

           
            var mycharts = new Tuple<IEnumerable<WordCount>, IEnumerable<WordCount>,
                IEnumerable<WordCount>, IEnumerable<WordCount>, IEnumerable<WordCount>>(
                soldierRankCount.ToList(),
                soldierBloodGroupCount.ToList(),
                soldierGenderCount.ToList(),
                ethnicityCount.ToList(),
                soldierBirthDayCount.ToList());

            return View(mycharts);
        }

        private  string CalculateAgeRange(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age--; // Adjust for leap years

            if (age <= 15)
                return "0-15";
            else if (age >= 16 && age <= 18)
                return "15-18";
            else if (age >= 19 && age <= 21)
                return "19-21";
            else if (age >= 22 && age <= 25)
                return "22-25";
            else if (age >= 26 && age <= 35)
                return "26-35";
            else if (age >= 36 && age <= 45)
                return "36-45";
            else if (age >= 46 && age <= 55)
                return "46-55";
            else if (age >= 56 && age <= 69)
                return "56-69";
            else 
                return "70 and Over";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
