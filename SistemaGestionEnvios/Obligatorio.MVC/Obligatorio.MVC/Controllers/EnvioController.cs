using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.DTOs.DTOs.DTOSeguimiento;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.MVC.Filtros;
using Obligatorio.MVC.Models;

namespace Obligatorio.MVC.Controllers
{
    public class EnvioController : Controller
    {
        private ICUAltaEnvio _CUAltaEnvio;
        private ICUObtenerEnvios _CUObtenerEnvios;
        private ICUObtenerAgencias _CUObtenerAgencias;
        private ICUObtenerEnvio _CUObtenerEnvio;
        private ICUFinalizarEnvio _CUFinalizarEnvio;
        private ICUAgregarSeguimiento _CUAgregarSeguimiento;
        private ICUObtenerComentarios _CUObtenerComentarios;

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUObtenerEnvios cUObtenerEnvios, ICUObtenerAgencias cUObtenerAgencias, ICUObtenerEnvio cUObtenerEnvio, ICUFinalizarEnvio cUFinalizarEnvio, ICUAgregarSeguimiento cUAgregarSeguimiento, ICUObtenerComentarios cUObtenerComentarios)
        {
            _CUAltaEnvio = cuAltaEnvio;
            _CUObtenerEnvios = cUObtenerEnvios;
            _CUObtenerAgencias = cUObtenerAgencias;
            _CUObtenerEnvio = cUObtenerEnvio;
            _CUFinalizarEnvio = cUFinalizarEnvio;
            _CUAgregarSeguimiento = cUAgregarSeguimiento;
            _CUObtenerComentarios = cUObtenerComentarios;
        }

        [LogueadoAuthorize]
        public IActionResult Index()
        {
            return View(_CUObtenerEnvios.ObtenerEnvios());
        }

        [LogueadoAuthorize]
        public IActionResult Create()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach (var agencia in _CUObtenerAgencias.ObtenerAgencias())
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = agencia.Id.ToString(),
                    Text = agencia.Nombre
                    
                };
                vm.Agencias.Add(selectListItem);
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                int lId = (int)HttpContext.Session.GetInt32("LogueadoId");
                vm.Dto.IdFuncionario = lId;
                _CUAltaEnvio.AltaEnvio(vm.Dto);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }

            return View(vm);
        }

        [LogueadoAuthorize]
        public IActionResult FinalizarEnvio(int id)
        {
            var envio = _CUObtenerEnvio.ObtenerEnvio(id);
            return View(envio);
        }
        [HttpPost, ActionName("FinalizarEnvio")]
        [LogueadoAuthorize]
        public IActionResult FinalizarEnvioConfirmed(int id)
        {
            try
            {
                _CUFinalizarEnvio.FinalizarEnvio(id);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();
        }

        [LogueadoAuthorize]
        public IActionResult AgregarSeguimiento(int id)
        {
            AgregarSeguimientoViewModel vm = new AgregarSeguimientoViewModel();
            EnvioDTO envio = _CUObtenerEnvio.ObtenerEnvio(id);
            vm.EnvioDTO = envio;
            return View(vm);
        }
        [HttpPost]
        public IActionResult AgregarSeguimiento(AgregarSeguimientoViewModel vm)
        {
            try
            {
                int lId = (int)HttpContext.Session.GetInt32("LogueadoId");
                vm.AgregarSeguimientoDTO.LogueadoId = lId;
                _CUAgregarSeguimiento.AgregarSeguimiento(vm.AgregarSeguimientoDTO);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View(vm);
        }
        [LogueadoAuthorize]
        public IActionResult Details(int id)
        {
            MostrarComentariosViewModel vm = new MostrarComentariosViewModel();
            EnvioDTO envio = _CUObtenerEnvio.ObtenerEnvio(id);
            List<SeguimientoDTO> comentarios = _CUObtenerComentarios.ObtenerComentarios(id);
            vm.EnvioDTO = envio;
            vm.Comentarios = comentarios;
            return View(vm);
        }

        

    }
}
