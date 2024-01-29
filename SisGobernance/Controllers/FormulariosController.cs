using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisGobernance.Contexto;
using SisGobernance.Models;

namespace SisGobernance.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly MiContext _context;

        public FormulariosController(MiContext context)
        {
            _context = context;
        }

        // GET: Formularios
        public async Task<IActionResult> Index()
        {
            var miContext = _context.Formiularios.Include(f => f.Empresa).Include(f => f.Usuario);
            return View(await miContext.ToListAsync());
        }

        // GET: Formularios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formiularios
                .Include(f => f.Empresa)
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // GET: Formularios/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Email");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.FechaRegistro = DateTime.Now;
                formulario.UsuarioId = 1;
                _context.Add(formulario);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                TempData["FormularioRegistrado"] = "Formulario Registrado";
                return RedirectToAction("Details", "Formularios", new {id = formulario.EmpresaId} );
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Email", formulario.EmpresaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", formulario.UsuarioId);
            return View(formulario);
        }

        // GET: Formularios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formiularios.FindAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Email", formulario.EmpresaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", formulario.UsuarioId);
            return View(formulario);
        }

        // POST: Formularios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreProducto,Marca,Modelo,Pais,Cantidad,Observaciones,FechaRegistro,FechaModificacion,Rol,ElimLog,UsuarioId,EmpresaId")] Formulario formulario)
        {
            if (id != formulario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formulario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormularioExists(formulario.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Email", formulario.EmpresaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", formulario.UsuarioId);
            return View(formulario);
        }

        // GET: Formularios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formiularios
                .Include(f => f.Empresa)
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.Formiularios.FindAsync(id);
            if (formulario != null)
            {
                _context.Formiularios.Remove(formulario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioExists(int id)
        {
            return _context.Formiularios.Any(e => e.Id == id);
        }
    }
}
