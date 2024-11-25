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
    public class MembersController : Controller
    {
        private readonly MembersContext _context;

        public MembersController(MembersContext context)
        {
            _context = context;
        }

        // GET: Members
        [Authorize(Roles = "Administrator,Manager,User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parent.ToListAsync());
        }

        // GET: Members/Details/5
        [Authorize(Roles = "Administrator,Manager,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Parent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Members/Create
        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Address,City,State,Zip,Email,MobilePhone")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: Members/Edit/5
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Parent.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Address,City,State,Zip,Email,MobilePhone")] Members members)
        {
            if (id != members.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.ID))
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
            return View(members);
        }

        // GET: Members/Delete/5
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Parent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Parent.FindAsync(id);
            _context.Parent.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Parent.Any(e => e.ID == id);
        }
    }
}
