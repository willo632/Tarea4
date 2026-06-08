
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea4.Models;
using Tarea4.Data;

public class MatriculaController : Controller
{
    private readonly ApplicationDbContext _context;

    public MatriculaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MATRICULAMODELS
    public async Task<IActionResult> Index()    
    {
        var matriculas = await _context.Matriculas
            .Include(m => m.Vehiculo)
            .ToListAsync();
        return View(matriculas);
    }

    // GET: MATRICULAMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var matriculamodel = await _context.Matriculas
            .Include(m => m.Vehiculo)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (matriculamodel == null)
        {
            return NotFound();
        }

        return View(matriculamodel);
    }

    // GET: MATRICULAMODELS/Create
    public IActionResult Create()
    {
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa");
        return View();
    }

    // POST: MATRICULAMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FechaEmision,FechaVencimiento,Estado,VehiculoId")] MatriculaModel matriculamodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(matriculamodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa", matriculamodel.VehiculoId);
        return View(matriculamodel);
    }

    // GET: MATRICULAMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var matriculamodel = await _context.Matriculas.FindAsync(id);
        if (matriculamodel == null)
        {
            return NotFound();
        }
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa", matriculamodel.VehiculoId);
        return View(matriculamodel);
    }

    // POST: MATRICULAMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FechaEmision,FechaVencimiento,Estado,VehiculoId")] MatriculaModel matriculamodel)
    {
        if (id != matriculamodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(matriculamodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaModelExists(matriculamodel.Id))
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
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa", matriculamodel.VehiculoId);
        return View(matriculamodel);
    }

    // GET: MATRICULAMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var matriculamodel = await _context.Matriculas
            .Include(m => m.Vehiculo)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (matriculamodel == null)
        {
            return NotFound();
        }

        return View(matriculamodel);
    }

    // POST: MATRICULAMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var matriculamodel = await _context.Matriculas.FindAsync(id);
        if (matriculamodel != null)
        {
            _context.Matriculas.Remove(matriculamodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MatriculaModelExists(int? id)
    {
        return _context.Matriculas.Any(e => e.Id == id);
    }
}
