using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyApp.Data;
using MoneyApp.Models;
using MoneyApp.Models.ViewModels;

namespace MoneyApp.Controllers
{

    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public StaffsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staffs.ToListAsync().ConfigureAwait(true));
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }


        private string UploadedFile(StaffViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Staff staff = new Staff
                {
                    ApplicationUser = model.ApplicationUser,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FirstName + " " + model.LastName,
                    DOB = model.DOB,
                    Address = model.Address,
                    Gender = model.Gender,
                    LocalGovt = model.LocalGovt,
                    Town = model.Town,
                    State = model.State,
                    Position = model.Position,
                    Salary = model.Salary,
                    Loan = model.Loan,
                    Debt = model.Debt,
                    ProfilePicture = uniqueFileName,
                    UpdateDate = DateTime.Now
            };
                _context.Add(staff);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Staffs/Edit/5
        [HttpGet]
        public async Task<ViewResult> EditAsync(int id)
        {
            Staff staff = await _context.Staffs.FindAsync(id);
            StaffEditViewModel staffEditViewModel = new StaffEditViewModel
            {
                Id = staff.Id,
                ApplicationUser = staff.ApplicationUser,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                DOB = staff.DOB,
                Address = staff.Address,
                Gender = staff.Gender,
                LocalGovt = staff.LocalGovt,
                Town = staff.Town,
                State = staff.State,
                Position = staff.Position,
                Salary = staff.Salary,
                Loan = staff.Loan,
                Debt = staff.Debt,
                ExistingProfilePhoto = staff.ProfilePicture,
                UpdateDate = DateTime.Now.ToString()
            };

            return View(staffEditViewModel);
        }


        // POST: Staffs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StaffEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Staff staff = _context.Staffs.Find(model.Id);
                staff.ApplicationUser = model.ApplicationUser;
                staff.FirstName = model.FirstName;
                staff.LastName = model.LastName;
                staff.FullName = model.FirstName + " " + model.LastName;
                staff.DOB = model.DOB;
                staff.Address = model.Address;
                staff.Gender = model.Gender;
                staff.LocalGovt = model.LocalGovt;
                staff.Town = model.Town;
                staff.State = model.State;
                staff.Position = model.Position;
                staff.Salary = model.Salary;
                staff.Loan = model.Loan;
                staff.Debt = model.Debt;        

                if(model.ProfileImage != null)
                {
                    if(model.ExistingProfilePhoto != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", model.ExistingProfilePhoto);
                        System.IO.File.Delete(filePath);
                    }
                    staff.ProfilePicture = UploadedFile(model);
                }
                
                staff.UpdateDate = DateTime.Now;
                _context.Update(staff);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.Id == id);
        }
    }
}
