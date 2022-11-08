using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibreriaApi.Fachada;
using LibreriaApi.Dominio;
using LibreriaApi.Data;

namespace ApiCine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private IDataApi dataApi;

        public FuncionesController()
        {
            dataApi = new DataApiIMP();
        }

        [HttpGet("/funciones")]
        public IActionResult GetFunciones()
        {
            List<Funcion> lst = null;
            try
            {
                lst = dataApi.GetFunciones();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/saveFuncion")]
        public IActionResult PostFuncion(List<Parametro> lParametros)
        {
            try
            {
                if (lParametros == null)
                {
                    return BadRequest("Datos de funcion incorrectos!");
                }

                return Ok(dataApi.SaveFuncion(lParametros));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
