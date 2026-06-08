
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea4.Models;
using Tarea4.Data;

public class RevisionTecnicaController : Controller
{
    private readonly ApplicationDbContext _context;

    public RevisionTecnicaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: REVISIONTECNICAMODELS
    public async Task<IActionResult> Index()    
    {
        var revisiones = await _context.RevisionesTecnicas
            .Include(r => r.Vehiculo)
            .ToListAsync();
        return View(revisiones);
    }

    // GET: REVISIONTECNICAMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var revisiontecnicamodel = await _context.RevisionesTecnicas
            .Include(r => r.Vehiculo)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (revisiontecnicamodel == null)
        {
            return NotFound();
        }

        return View(revisiontecnicamodel);
    }

    // GET: REVISIONTECNICAMODELS/Create
    public IActionResult Create()
    {
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa");
        return View();
    }

    // POST: REVISIONTECNICAMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FechaRevision,Resultado,Observacion,VehiculoId")] RevisionTecnicaModel revisiontecnicamodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(revisiontecnicamodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa", revisiontecnicamodel.VehiculoId);
        return View(revisiontecnicamodel);
    }

    // GET: REVISIONTECNICAMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var revisiontecnicamodel = await _context.RevisionesTecnicas.FindAsync(id);
        if (revisiontecnicamodel == null)
        {
            return NotFound();
        }
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa", revisiontecnicamodel.VehiculoId);
        return View(revisiontecnicamodel);
    }

    // POST: REVISIONTECNICAMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FechaRevision,Resultado,Observacion,VehiculoId")] RevisionTecnicaModel revisiontecnicamodel)
    {
        if (id != revisiontecnicamodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(revisiontecnicamodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevisionTecnicaModelExists(revisiontecnicamodel.Id))
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
        ViewBag.VehiculoId = new SelectList(_context.Vehiculos, "Id", "Placa", revisiontecnicamodel.VehiculoId);
        return View(revisiontecnicamodel);
    }

    // GET: REVISIONTECNICAMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var revisiontecnicamodel = await _context.RevisionesTecnicas
            .Include(r => r.Vehiculo)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (revisiontecnicamodel == null)
        {
            return NotFound();
        }

        return View(revisiontecnicamodel);
    }

    // POST: REVISIONTECNICAMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var revisiontecnicamodel = await _context.RevisionesTecnicas.FindAsync(id);
        if (revisiontecnicamodel != null)
        {
            _context.RevisionesTecnicas.Remove(revisiontecnicamodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RevisionTecnicaModelExists(int? id)
    {
        return _context.RevisionesTecnicas.Any(e => e.Id == id);
    }
}
