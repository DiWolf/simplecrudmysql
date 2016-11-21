using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysqltest.Entities;
using mysqltest.Infraestructura;

namespace mysqltest.Controllers
{

    public class PersonasController : Controller
    {
        private readonly MySqlContexto _contexto;
        public PersonasController(MySqlContexto contexto)
        {
            _contexto = contexto;
        }

        //Retorna la información contenida en la base de datos 
        public async Task<IActionResult> Index(){
            return View(await _contexto.Personas.ToListAsync());
        }

        //Detalles de la persona
        public async Task<IActionResult> Detalles(int id){
            if(id==null)
            {
                return NotFound();
            }
            var persona = await _contexto.Personas.SingleAsync(p=>p.Id == id);
            if(persona==null)
            {
                return NotFound(); 
            }
            return View(persona);
        }

      public IActionResult Create()
      {
          return View();
      }

      [HttpPost]
      [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Create (Persona p)
        {
            if(ModelState.IsValid)
            {
                _contexto.Personas.Add(p);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public  async Task<IActionResult> Editar(int Id)
      {
          if(Id == null)
          {
              return NotFound(); 
          }
          var p = await _contexto.Personas.SingleOrDefaultAsync(per => per.Id== Id);
          if(p== null)
          {
              return NotFound(); 
          }
          return View(p);
      }

      [HttpPost]
      [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Editar (Persona p)
        {
          
          if(p.Id == 0)
          {
              return NotFound(); 
          }
          if(ModelState.IsValid){
              try{
                  _contexto.Update(p);
                  await _contexto.SaveChangesAsync();
              }catch(DbUpdateConcurrencyException)
              {
                  return RedirectToAction("Index");
              }
                  return RedirectToAction("Index");
          }

            return View(p);
        }

        public async Task<IActionResult> Borrar(int id)
        {
            if(id==null)
            {
                return NotFound(); 
            }
            var persona = await _contexto.Personas.SingleOrDefaultAsync(per => per.Id == id); 
            if(persona == null)
            {
                return NotFound(); 
            }
            return View(persona);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var p = await _contexto.Personas.SingleOrDefaultAsync(per => per.Id == id);
            _contexto.Personas.Remove(p);
            await _contexto.SaveChangesAsync(); 
            return RedirectToAction("Index");    
        }
    }
}