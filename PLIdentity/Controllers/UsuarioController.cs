using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ML;

namespace PLIdentity.Controllers
{
    public class UsuarioController : Controller
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var users = await userManager.Users.ToListAsync();
        //    return View(users);
        //}

        [HttpGet]
        public IActionResult GetAll()
        {

            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.Usuarios = result.Objects;

                return View(usuario);
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Form()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Add(usuario);
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            return View();
        }
    }
}
