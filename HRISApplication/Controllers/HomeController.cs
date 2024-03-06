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
               group s by s.DateOfBirth into g
               select new WordCount { Word = g.Key.ToString(), Count = g.Count() };


            List<WordCount> newwordscount = new List<WordCount>();

            DateTime dateTime1996 = DateTime.Parse("01-01-1996");
            DateTime dateTime1990 = DateTime.Parse("01-01-1990");

            var date19961990 = new WordCount
            {
                Word = "1996-1990",
                Count = 0
            };

            DateTime dateTime2001 = DateTime.Parse("01-01-2001");
            DateTime dateTime1997 = DateTime.Parse("01-01-1997");


            var date20011997 = new WordCount
            {
                Word = "2001-1997",
                Count = 0
            };

            DateTime dateTime2002 = DateTime.Parse("01-01-2002");
            DateTime dateTime2005 = DateTime.Parse("01-01-2005");

            var date20022005 = new WordCount
            {
                Word = "2002-2005",
                Count = 0
            };

            foreach (var s in soldierBirthDayCount)
            {
                DateTime dateTime = DateTime.Parse(s.Word);
                if (dateTime < dateTime2005 && dateTime > dateTime2002)
                {
                    date20022005.Count++;
                }

                if (dateTime < dateTime2001 && dateTime > dateTime1997)
                {
                    date20011997.Count++;
                }
                if (dateTime < dateTime1996)
                {
                    date19961990.Count++;
                }
            }

            newwordscount.Add(date20022005);
            newwordscount.Add(date20011997);
            newwordscount.Add(date19961990);



            var mycharts = new Tuple<IEnumerable<WordCount>, IEnumerable<WordCount>,
                IEnumerable<WordCount>, IEnumerable<WordCount>>(
                soldierRankCount.ToList(),
                soldierBloodGroupCount.ToList(),
                soldierGenderCount.ToList(),
                //soldierEthnicityCount.ToList(),
                newwordscount);

            return View(mycharts);
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
