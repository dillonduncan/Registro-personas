using asp_practica_con_sql.Models;
using asp_practica_con_sql.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace asp_practica_con_sql.Controllers
{
    public class PersonasController : Controller
    {
        private readonly PersonasContext _personasContext;
        public PersonasController(PersonasContext personasContext)
        {
            _personasContext = personasContext;
        }

        public async Task<IActionResult> Index()
        {
            var persona = _personasContext.TablaPersonas.Include(p => p.IdGeneroNavigation);
            return View(await persona.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["Genero"] = new SelectList(_personasContext.TablaGeneros, "Id", "NombreGenero");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var persona = new TablaPersona()
                {
                    NombrePersona = model.Name,
                    EdadPersona = model.Age,
                    IdGenero = model.GenderID
                };
                _personasContext.Add(persona);
                await _personasContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["Genero"] = new SelectList(_personasContext.TablaGeneros, "Id", "NombreGenero",model.GenderID);
            return View(model);
        }
    }
}
