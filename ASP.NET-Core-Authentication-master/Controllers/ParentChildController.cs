using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;

namespace Authentication.Controllers
{
    public class ParentChildController : Controller
    {
        private readonly MembersContext _context;

        public ParentChildController(MembersContext context)
        {
            _context = context;
        }

        // GET: ParentChild
        [Authorize(Roles = "Administrator,Manager,User")]
        public async Task<IActionResult> Index()
        {
            var membersContext = _context.Family.Include(p => p.Child).Include(p => p.Members);
            return View(await membersContext.ToListAsync());
        }

        // GET: ParentChild/Details/5
        [Authorize(Roles = "Administrator,Manager,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentChild = await _context.Family
                .Include(p => p.Child)
                .Include(p => p.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parentChild == null)
            {
                return NotFound();
            }

            return View(parentChild);
        }

        // GET: ParentChild/Create
        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult Create()
        {
            ViewData["ChildID"] = new SelectList(_context.Child, "ID", "FirstName");
            ViewData["MembersID"] = new SelectList(_context.Parent, "ID", "FirstName");
            return View();
        }

        // POST: ParentChild/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Create([Bind("ID,MembersID,ChildID")] ParentChild parentChild)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentChild);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChildID"] = new SelectList(_context.Child, "ID", "FirstName", parentChild.ChildID);
            ViewData["MembersID"] = new SelectList(_context.Parent, "ID", "FirstName", parentChild.MembersID);
            return View(parentChild);
        }

        // GET: ParentChild/Edit/5
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentChild = await _context.Family.FindAsync(id);
            if (parentChild == null)
            {
                return NotFound();
            }
            ViewData["ChildID"] = new SelectList(_context.Child, "ID", "FirstName", parentChild.ChildID);
            ViewData["MembersID"] = new SelectList(_context.Parent, "ID", "FirstName", parentChild.MembersID);
            return View(parentChild);
        }

        // POST: ParentChild/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MembersID,ChildID")] ParentChild parentChild)
        {
            if (id != parentChild.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentChild);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentChildExists(parentChild.ID))
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
            ViewData["ChildID"] = new SelectList(_context.Child, "ID", "FirstName", parentChild.ChildID);
            ViewData["MembersID"] = new SelectList(_context.Parent, "ID", "FirstName", parentChild.MembersID);
            return View(parentChild);
        }

        // GET: ParentChild/Delete/5
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentChild = await _context.Family
                .Include(p => p.Child)
                .Include(p => p.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parentChild == null)
            {
                return NotFound();
            }

            return View(parentChild);
        }

        // POST: ParentChild/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentChild = await _context.Family.FindAsync(id);
            _context.Family.Remove(parentChild);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentChildExists(int id)
        {
            return _context.Family.Any(e => e.ID == id);
        }
    }
}
