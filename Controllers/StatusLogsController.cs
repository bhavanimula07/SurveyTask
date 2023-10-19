using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurveyTask.Models;

namespace SurveyTask.Controllers
{
    public class StatusLogsController : Controller
    {
        private readonly Day1Context _context;

        public StatusLogsController(Day1Context context)
        {
            _context = context;
        }

        // GET: StatusLogs
        public async Task<IActionResult> Index()
        {
              return _context.StatusLogs != null ? 
                          View(await _context.StatusLogs.ToListAsync()) :
                          Problem("Entity set 'Day1Context.StatusLogs'  is null.");
        }

        // GET: StatusLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusLogs == null)
            {
                return NotFound();
            }

            var statusLog = await _context.StatusLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusLog == null)
            {
                return NotFound();
            }

            return View(statusLog);
        }

        // GET: StatusLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Time,StatusId")] StatusLog statusLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusLog);
        }

        // GET: StatusLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusLogs == null)
            {
                return NotFound();
            }

            var statusLog = await _context.StatusLogs.FindAsync(id);
            if (statusLog == null)
            {
                return NotFound();
            }
            return View(statusLog);
        }

        // POST: StatusLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Time,StatusId")] StatusLog statusLog)
        {
            if (id != statusLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusLogExists(statusLog.Id))
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
            return View(statusLog);
        }

        // GET: StatusLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusLogs == null)
            {
                return NotFound();
            }

            var statusLog = await _context.StatusLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusLog == null)
            {
                return NotFound();
            }

            return View(statusLog);
        }

        // POST: StatusLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusLogs == null)
            {
                return Problem("Entity set 'Day1Context.StatusLogs'  is null.");
            }
            var statusLog = await _context.StatusLogs.FindAsync(id);
            if (statusLog != null)
            {
                _context.StatusLogs.Remove(statusLog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusLogExists(int id)
        {
          return (_context.StatusLogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
