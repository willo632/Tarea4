
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea4.Models;
using Tarea4.Data;

public class PropietarioController : Controller
{
    private readonly ApplicationDbContext _context;

    public PropietarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PROPIETARIOMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Propietarios.ToListAsync());
    }

    // GET: PROPIETARIOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var propietariomodel = await _context.Propietarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (propietariomodel == null)
        {
            return NotFound();
        }

        return View(propietariomodel);
    }

    // GET: PROPIETARIOMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROPIETARIOMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Cedula,Telefono")] PropietarioModel propietariomodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(propietariomodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(propietariomodel);
    }

    // GET: PROPIETARIOMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var propietariomodel = await _context.Propietarios.FindAsync(id);
        if (propietariomodel == null)
        {
            return NotFound();
        }
        return View(propietariomodel);
    }

    // POST: PROPIETARIOMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombres,Apellidos,Cedula,Telefono")] PropietarioModel propietariomodel)
    {
        if (id != propietariomodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(propietariomodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropietarioModelExists(propietariomodel.Id))
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
        return View(propietariomodel);
    }

    // GET: PROPIETARIOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var propietariomodel = await _context.Propietarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (propietariomodel == null)
        {
            return NotFound();
        }

        return View(propietariomodel);
    }

    // POST: PROPIETARIOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var propietariomodel = await _context.Propietarios.FindAsync(id);
        if (propietariomodel != null)
        {
            _context.Propietarios.Remove(propietariomodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PropietarioModelExists(int? id)
    {
        return _context.Propietarios.Any(e => e.Id == id);
    }
}
