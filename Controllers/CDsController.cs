using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moment3_2.Data;
using moment3_2.Models;

namespace moment3_2.Controllers
{
    public class CDsController : Controller
    {
        private readonly CDContext _context;

        public CDsController(CDContext context)
        {
            _context = context;
        }

        //Sökfält
        /*public ActionResult Index(string searchString)
        {
            var cds = from m in _context.CD
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                cds = cds.Where(s => s.Title.Contains(searchString));
            }

            return View(cds);
        }*/

        // GET: CDs
        public async Task<IActionResult> Index(string searchString)
        {
            var cds = from m in _context.CD
                      select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                cds = cds.Where(s => s.Title.Contains(searchString));
                return View(cds);
            }

            var cDContext = _context.CD.Include(c => c.Artist);
            return View(await cDContext.ToListAsync());
        }

        // GET: CDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.CDId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // GET: CDs/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName");
            return View();
        }

        // POST: CDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDId,Title,ReleaseDate,Genre,RecordCompany,SongsAmount,ArtistId")] CD cD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName", cD.ArtistId);
            return View(cD);
        }

        // GET: CDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName", cD.ArtistId);
            return View(cD);
        }

        // POST: CDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDId,Title,ReleaseDate,Genre,RecordCompany,SongsAmount,ArtistId")] CD cD)
        {
            if (id != cD.CDId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDExists(cD.CDId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName", cD.ArtistId);
            return View(cD);
        }

        // GET: CDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.CDId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // POST: CDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cD = await _context.CD.FindAsync(id);
            _context.CD.Remove(cD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDExists(int id)
        {
            return _context.CD.Any(e => e.CDId == id);
        }
    }
}
