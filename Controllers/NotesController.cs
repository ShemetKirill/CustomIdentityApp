using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomIdentityApp.Models;
using CustomIdentityApp.ViewModels;


namespace CustomIdentityApp.Controllers

{   public class NotesController : Controller 
    {

        private ApplicationContext db;
        public NotesController(ApplicationContext context)
        {
            db = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await db.Notes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            db.Notes.Add(note);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
   
}



