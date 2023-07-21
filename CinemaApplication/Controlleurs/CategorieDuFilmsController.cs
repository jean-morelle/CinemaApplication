using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApplication.Data;
using CinemaApplication.Models;

namespace CinemaApplication.Controlleurs
{
    public class CategorieDuFilmsController : Controller
    {
        private readonly CinemaAppDbcontext _context;

        public CategorieDuFilmsController(CinemaAppDbcontext context)
        {
            _context = context;
        }

        // GET: CategorieDuFilms
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategorieDuFilms.ToListAsync());
        }

        // GET: CategorieDuFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieDuFilm = await _context.CategorieDuFilms
                .FirstOrDefaultAsync(m => m.CategorieDuFilmId == id);
            if (categorieDuFilm == null)
            {
                return NotFound();
            }

            return View(categorieDuFilm);
        }

        // GET: CategorieDuFilms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategorieDuFilms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieDuFilmId,GenreDuFilm")] CategorieDuFilm categorieDuFilm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorieDuFilm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorieDuFilm);
        }

        // GET: CategorieDuFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieDuFilm = await _context.CategorieDuFilms.FindAsync(id);
            if (categorieDuFilm == null)
            {
                return NotFound();
            }
            return View(categorieDuFilm);
        }

        // POST: CategorieDuFilms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieDuFilmId,GenreDuFilm")] CategorieDuFilm categorieDuFilm)
        {
            if (id != categorieDuFilm.CategorieDuFilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieDuFilm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieDuFilmExists(categorieDuFilm.CategorieDuFilmId))
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
            return View(categorieDuFilm);
        }

        // GET: CategorieDuFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieDuFilm = await _context.CategorieDuFilms
                .FirstOrDefaultAsync(m => m.CategorieDuFilmId == id);
            if (categorieDuFilm == null)
            {
                return NotFound();
            }

            return View(categorieDuFilm);
        }

        // POST: CategorieDuFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorieDuFilm = await _context.CategorieDuFilms.FindAsync(id);
            _context.CategorieDuFilms.Remove(categorieDuFilm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieDuFilmExists(int id)
        {
            return _context.CategorieDuFilms.Any(e => e.CategorieDuFilmId == id);
        }
    }
}
