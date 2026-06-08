
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea4.Models;
using Tarea4.Data;

public class VehiculoController : Controller
{
    private readonly ApplicationDbContext _context;

    public VehiculoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: VEHICULOMODELS
    public async Task<IActionResult> Index()    
    {
        var vehiculos = await _context.Vehiculos
            .Include(v => v.Marca)
            .Include(v => v.Propietario)
            .ToListAsync();
        return View(vehiculos);
    }

    // GET: VEHICULOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculomodel = await _context.Vehiculos
            .Include(v => v.Marca)
            .Include(v => v.Propietario)
            .Include(v => v.Matriculas)
            .Include(v => v.RevisionesTecnicas)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehiculomodel == null)
        {
            return NotFound();
        }

        return View(vehiculomodel);
    }

    // GET: VEHICULOMODELS/Create
    public IActionResult Create()
    {
        ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "NombreMarca");
        ViewBag.PropietarioId = new SelectList(_context.Propietarios, "Id", "Nombres");
        return View();
    }

    // POST: VEHICULOMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Placa,Modelo,Anio,MarcaId,PropietarioId")] VehiculoModel vehiculomodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vehiculomodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "NombreMarca", vehiculomodel.MarcaId);
        ViewBag.PropietarioId = new SelectList(_context.Propietarios, "Id", "Nombres", vehiculomodel.PropietarioId);
        return View(vehiculomodel);
    }

    // GET: VEHICULOMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculomodel = await _context.Vehiculos.FindAsync(id);
        if (vehiculomodel == null)
        {
            return NotFound();
        }
        ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "NombreMarca", vehiculomodel.MarcaId);
        ViewBag.PropietarioId = new SelectList(_context.Propietarios, "Id", "Nombres", vehiculomodel.PropietarioId);
        return View(vehiculomodel);
    }

    // POST: VEHICULOMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Placa,Modelo,Anio,MarcaId,PropietarioId")] VehiculoModel vehiculomodel)
    {
        if (id != vehiculomodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vehiculomodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoModelExists(vehiculomodel.Id))
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
        ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "NombreMarca", vehiculomodel.MarcaId);
        ViewBag.PropietarioId = new SelectList(_context.Propietarios, "Id", "Nombres", vehiculomodel.PropietarioId);
        return View(vehiculomodel);
    }

    // GET: VEHICULOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehiculomodel = await _context.Vehiculos
            .Include(v => v.Marca)
            .Include(v => v.Propietario)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehiculomodel == null)
        {
            return NotFound();
        }

        return View(vehiculomodel);
    }

    // POST: VEHICULOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var vehiculomodel = await _context.Vehiculos.FindAsync(id);
        if (vehiculomodel != null)
        {
            _context.Vehiculos.Remove(vehiculomodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VehiculoModelExists(int? id)
    {
        return _context.Vehiculos.Any(e => e.Id == id);
    }
}
