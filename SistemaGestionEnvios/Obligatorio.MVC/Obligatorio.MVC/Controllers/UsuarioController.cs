using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.MVC.Filtros;
using Obligatorio.MVC.Models;

namespace Obligatorio.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private ICULogin _CULogin;
        private ICUAltaUsuario _CUAltaUsuario;
        private ICUObtenerUsuarios _CUObtenerUsuarios;
        private ICUObtenerUsuario _CUObtenerUsuario;
        private ICUEditarUsuario _CUEditUsuario;
        private ICUEliminarUsuario _CUEliminarUsuario;

        public UsuarioController(ICULogin CULogin, ICUAltaUsuario CUAltaUsuario, ICUObtenerUsuarios CUObtenerUsuarios, ICUObtenerUsuario CUObtenerUsuario
            , ICUEditarUsuario CUEditUsuario, ICUEliminarUsuario CUEliminarUsuario)
        {
            _CULogin = CULogin;
            _CUAltaUsuario = CUAltaUsuario;
            _CUObtenerUsuarios = CUObtenerUsuarios;
            _CUObtenerUsuario = CUObtenerUsuario;
            _CUEditUsuario = CUEditUsuario;
            _CUEliminarUsuario = CUEliminarUsuario;
        }

        [LogueadoAuthorize]
        [AdministradorAuthorize]
        public IActionResult Index()
        {
            return View(_CUObtenerUsuarios.ObtenerUsuarios());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDTO dto)
        {
            try
            {
                UsuarioDTO u = _CULogin.VerificarDatosParaLogin(dto);
                HttpContext.Session.SetInt32("LogueadoId", (int)u.Id);
                HttpContext.Session.SetString("LogueadoRol", u.Rol);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LogueadoId");
            HttpContext.Session.Remove("LogueadoRol");
            return RedirectToAction("Index", "Home");
        }

        [LogueadoAuthorize]
        [AdministradorAuthorize]
        public IActionResult Create()
        {
            AltaUsuarioViewModel vm = new AltaUsuarioViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaUsuarioViewModel vm)
        {
            try
            {
                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                vm.Dto.LogueadoId = lid;

                _CUAltaUsuario.AltaEmpleado(vm.Dto);
                ViewBag.msg = "Alta correcta";
            }
            catch (Exception e)
            {

                ViewBag.msg = e.Message;
            }
            return View(vm);
        }

        [LogueadoAuthorize]
        [AdministradorAuthorize]
        public IActionResult Edit(int id)
        {
            UsuarioDTO dto = _CUObtenerUsuario.ObtenerUsuario(id);
            return View(dto);
        }
        [HttpPost]
        public IActionResult Edit(UsuarioDTO dto)
        {
            try
            {
                dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                _CUEditUsuario.EditarUsuario(dto);
                ViewBag.msg = "Editado correctamente";
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return RedirectToAction("Index", "Usuario");
        }

        [LogueadoAuthorize]
        [AdministradorAuthorize]
        public IActionResult Delete(int id)
        {
            var usuario = _CUObtenerUsuario.ObtenerUsuario(id);
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [LogueadoAuthorize]
        [AdministradorAuthorize]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                int? logueadoId = HttpContext.Session.GetInt32("LogueadoId");
                _CUEliminarUsuario.EliminarUsuario(id, logueadoId);
                TempData["msg"] = "Usuario eliminado correctamente";
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
            }
            return RedirectToAction("Index");
        }



    }
}
