using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRISApplication.Models;

namespace HRISApplication.Areas.PersonalFileArea.Controllers
{
    [Area("PersonalFileArea")]
    public class PersonalFilesController : Controller
    {
        private readonly SspdfContext _context;

        private IWebHostEnvironment _env;

        public PersonalFilesController(SspdfContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: PersonalFiles
        public async Task<IActionResult> Index(string id)
        {
            var sspdfContext = _context.PersonalFile.Where(x => x.MilitaryNo == id);
            ViewData["militaryNo"] = id;
            return View(await sspdfContext.ToListAsync());
        }

        // GET: PersonalFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalFile = await _context.PersonalFile
                .Include(p => p.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalFile == null)
            {
                return NotFound();
            }

            return View(personalFile);
        }

        // GET: PersonalFiles/Create
        public IActionResult Create(string id)
        {
            ViewData["MilitaryNo"] = id;
            return View();
        }



        // POST: PersonalFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FormFile, Location,CreateBy,CreatedOn,MilitaryNo")] PersonalFile personalFile)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(_env.ContentRootPath, "Content\\Images");

                var uniqueFileName = $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}" +
                    $"-{Guid.NewGuid()}-{personalFile.FormFile.FileName}";

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await personalFile.FormFile.CopyToAsync(fileStream);
                }

                personalFile.Name = personalFile.FormFile.FileName;
                personalFile.Location = uniqueFileName;
                personalFile.CreatedOn = DateTime.Now;
                personalFile.CreateBy = User.Identity != null ? User.Identity.Name : "NoUser";
                _context.Add(personalFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = personalFile.MilitaryNo });
            }
            ViewData["MilitaryNo"] = personalFile.MilitaryNo;
            return View(personalFile);
        }

        // GET: PersonalFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalFile = await _context.PersonalFile.FindAsync(id);
            if (personalFile == null)
            {
                return NotFound();
            }
            ViewData["MilitaryNo"] = id;
            return View(personalFile);
        }

        // POST: PersonalFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, FormFile, Location,CreateBy,CreatedOn,MilitaryNo")] PersonalFile personalFile)
        {
            if (id != personalFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalFileExists(personalFile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MilitaryNo"] = personalFile.MilitaryNo;
            return View(personalFile);
        }

        // GET: PersonalFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalFile = await _context.PersonalFile
                .Include(p => p.MilitaryNoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalFile == null)
            {
                return NotFound();
            }

            return View(personalFile);
        }

        // POST: PersonalFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalFile = await _context.PersonalFile.FindAsync(id);
            if (personalFile != null)
            {
                _context.PersonalFile.Remove(personalFile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id });
        }


        public async Task<ActionResult> DownloadAsync(int id)
        {
            var personalFile = await _context.PersonalFile.FindAsync(id);
            if (personalFile == null)
            {
                return NotFound();
            }
            string filePath = _env.ContentRootPath + @"\Content\Images\" + personalFile.Location;
            var memoryStream = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            // set the position to return the file from
            memoryStream.Position = 0;

            string contentType = GetContentType(filePath);//"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(memoryStream, contentType, personalFile.Name);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        private bool PersonalFileExists(int id)
        {
            return _context.PersonalFile.Any(e => e.Id == id);
        }
    }
}
