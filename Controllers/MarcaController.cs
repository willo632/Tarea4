
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea4.Models;
using Tarea4.Data;

public class MarcaController : Controller
{
    private readonly ApplicationDbContext _context;

    public MarcaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MARCAMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Marcas.ToListAsync());
    }

    // GET: MARCAMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marcamodel = await _context.Marcas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (marcamodel == null)
        {
            return NotFound();
        }

        return View(marcamodel);
    }

    // GET: MARCAMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MARCAMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NombreMarca,PaisOrigen,Estado,FechaRegistro")] MarcaModel marcamodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(marcamodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(marcamodel);
    }

    // GET: MARCAMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marcamodel = await _context.Marcas.FindAsync(id);
        if (marcamodel == null)
        {
            return NotFound();
        }
        return View(marcamodel);
    }

    // POST: MARCAMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,NombreMarca,PaisOrigen,Estado,FechaRegistro")] MarcaModel marcamodel)
    {
        if (id != marcamodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(marcamodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaModelExists(marcamodel.Id))
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
        return View(marcamodel);
    }

    // GET: MARCAMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marcamodel = await _context.Marcas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (marcamodel == null)
        {
            return NotFound();
        }

        return View(marcamodel);
    }

    // POST: MARCAMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var marcamodel = await _context.Marcas.FindAsync(id);
        if (marcamodel != null)
        {
            _context.Marcas.Remove(marcamodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MarcaModelExists(int? id)
    {
        return _context.Marcas.Any(e => e.Id == id);
    }
}
