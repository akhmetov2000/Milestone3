using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdditionBonusTask.Data;
using AdditionBonusTask.Models;

namespace AdditionBonusTask.Controllers
{
    public class DialogsController : Controller
    {
        private readonly AuthDbContext _context;

        public DialogsController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: Dialogs
        public async Task<IActionResult> Index()
        {
            var authDbContext = _context.Dialogs.Include(d => d.User);
            return View(await authDbContext.ToListAsync());
        }

        // GET: Dialogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dialog = await _context.Dialogs
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dialog == null)
            {
                return NotFound();
            }

            return View(dialog);
        }

        // GET: Dialogs/Create
        public IActionResult Create()
        {
            ViewData["UserSenderId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Dialogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserSenderId")] Dialog dialog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dialog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserSenderId"] = new SelectList(_context.Users, "Id", "Id", dialog.UserSenderId);
            return View(dialog);
        }

        // GET: Dialogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dialog = await _context.Dialogs.FindAsync(id);
            if (dialog == null)
            {
                return NotFound();
            }
            ViewData["UserSenderId"] = new SelectList(_context.Users, "Id", "Id", dialog.UserSenderId);
            return View(dialog);
        }

        // POST: Dialogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserSenderId")] Dialog dialog)
        {
            if (id != dialog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dialog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DialogExists(dialog.Id))
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
            ViewData["UserSenderId"] = new SelectList(_context.Users, "Id", "Id", dialog.UserSenderId);
            return View(dialog);
        }

        // GET: Dialogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dialog = await _context.Dialogs
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dialog == null)
            {
                return NotFound();
            }

            return View(dialog);
        }

        // POST: Dialogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dialog = await _context.Dialogs.FindAsync(id);
            _context.Dialogs.Remove(dialog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DialogExists(int id)
        {
            return _context.Dialogs.Any(e => e.Id == id);
        }
    }
}
