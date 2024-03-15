using asp_practica_con_sql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace asp_practica_con_sql.Controllers
{
    public class GeneroControles : Controller
    {
        private readonly PersonasContext _personasContext;
        public GeneroControles(PersonasContext personasContext)
        {
            _personasContext = personasContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _personasContext.TablaGeneros.ToListAsync());
        }
    }
}
