using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppManager.Data;
using AppManager.Models;

namespace AppManager.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activity
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityModel.ToListAsync());
        }

        // GET: Activity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel
                .FirstOrDefaultAsync(m => m.ActivityID == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // GET: Activity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityID,ActivityName,ActivityExecuteDate,Status")] ActivityModel activityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityModel);
        }

        // GET: Activity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel.FindAsync(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            return View(activityModel);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityID,ActivityName,ActivityExecuteDate,Status")] ActivityModel activityModel)
        {
            if (id != activityModel.ActivityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityModelExists(activityModel.ActivityID))
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
            return View(activityModel);
        }

        // GET: Activity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel
                .FirstOrDefaultAsync(m => m.ActivityID == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityModel = await _context.ActivityModel.FindAsync(id);
            _context.ActivityModel.Remove(activityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityModelExists(int id)
        {
            return _context.ActivityModel.Any(e => e.ActivityID == id);
        }
    }
}
