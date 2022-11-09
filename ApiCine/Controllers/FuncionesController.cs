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
            List<Funcion> lst;
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
        public IActionResult PostFuncion(Funcion funcion)
        {
            try
            {
                if (funcion == null)
                {
                    return BadRequest("Datos de funcion incorrectos!");
                }

                return Ok(dataApi.SaveFuncion(funcion));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


        [HttpDelete("/deleteFuncion/{id}")]
        public IActionResult DeleteFunciones(int id)
        {
            try
            {
                return Ok(dataApi.DeleteFuncion(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");

            }
        }

        [HttpPut("/editFuncion")]
        public IActionResult EditFuncion(Funcion oFuncion)
        {
            try
            {
                if (oFuncion == null) return BadRequest("Datos de funcion incorrectos!");
                else return Ok(dataApi.EditFuncion(oFuncion));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
