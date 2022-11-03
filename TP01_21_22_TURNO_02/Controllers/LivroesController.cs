using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP01_21_22_TURNO_02;
using TP01_21_22_TURNO_02.Data;

namespace TP01_21_22_TURNO_02.Controllers
{
    public class LivroesController : Controller
    {
        private readonly TP01_21_22_TURNO_02Context _context;
        private readonly IHostEnvironment _he;

        public LivroesController(TP01_21_22_TURNO_02Context context, IHostEnvironment e)
        {
            _context = context;
            _he = e;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Livro.ToListAsync());
        }

        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro, IFormCollection files)
        {
            string destination = " ";

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                     destination = Path.Combine(
                        _he.ContentRootPath, "wwwroot/Imagens/", livro.ISBN);
                }

                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }

                foreach (var formFile in files.Files)
                {
                    string path = destination + "\\" + formFile.FileName;

                    FileStream fs = new FileStream(path, FileMode.Create);

                    formFile.CopyTo(fs);

                    if(formFile.Name == "capa")
                    {
                        livro.capa = formFile.FileName;
                    }else if(formFile.Name == "contracapa")
                    {
                        livro.contracapa = formFile.FileName;
                    }

                    fs.Close();
                }

                _context.Add(livro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("titulo,autores,editora,ISBN,capa,contracapa")] Livro livro)
        {
            if (id != livro.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.ISBN))
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
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'TP01_21_22_TURNO_02Context.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
                var path = _he.ContentRootPath + "wwwroot/Imagens/" + livro.ISBN;

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                foreach(var file in dirInfo.GetFiles())
                {
                    System.IO.File.Delete(file.FullName);
                }
                Directory.Delete(path);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(string id)
        {
          return _context.Livro.Any(e => e.ISBN == id);
        }
    }
}
