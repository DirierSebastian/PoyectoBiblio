using Microsoft.AspNetCore.Mvc;
using PoyectoBiblio.Datos;
using PoyectoBiblio.Models;
namespace PoyectoBiblio.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDatos _usuariodatos = new UsuarioDatos();    
        public IActionResult Listar()
        {
            var lista = _usuariodatos.Listar();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(UsuarioModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _usuariodatos.GuardarUsuario(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Editar(int IdUsuario)
        {
            UsuarioModel _usuario = _usuariodatos.ObtenerUsuario(IdUsuario);

            return View(_usuario);

            
        }
        [HttpPost]
        public IActionResult Editar(UsuarioModel model)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            var repuesta = _usuariodatos.EditarUsuario(model);
            if(repuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Eliminar(int IdUsuario)
        {
            var _usuario = _usuariodatos.ObtenerUsuario(IdUsuario);
            return View(_usuario);
        }
        [HttpPost]
        public IActionResult Eliminar(UsuarioModel model)
        {
            var respuesta = _usuariodatos.EliminarUsuario(model.IdUsuario);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
