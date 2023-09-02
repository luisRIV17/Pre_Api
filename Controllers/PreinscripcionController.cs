using Api_Preinscripcion.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pre_Api.Data;
using Pre_Api.Models;

namespace Pre_Api.Controllers
{
    [Route("pre")]
    [ApiController]
    public class PreinscripcionController : ControllerBase
    {
        dataSede sede = new dataSede();
        [HttpGet]
        [Route("listsede")]

        public List<ModelSede> listasede()
        {

            return sede.listadosedes();
        }
        dataPre pre = new dataPre();
        [HttpGet]
        [Route("liscarre")]

        public List<ModelCarrera> listadocarrera(string sede)
        {

            return pre.listadocarrera(sede);
        }
        [HttpGet]
        [Route("listjor")]
        public List<ModelJornada> listjornada(string sede, string carrera)
        {
            return pre.listajornada(sede, carrera);
        }
        [HttpPost]
        [Route("insert")]
        public int insertapre(ModelPreinscripcion nuevo)
        {
            return pre.insertacliente(nuevo);
        }
        [HttpGet]
        [Route("lisdepa")]
        public List<ModelDepartamento> listadepa()
        {
            return pre.listadepa();
        }
        [HttpGet]
        [Route("listamuni")]
        public List<ModelMunicipio> listamuni(int iddepa)
        {
            return pre.listamuni(iddepa);
        }
    }
}
