using Pre_Api.Models;
using System.Data.SqlClient;
using System.Data;
using Pre_Api.Data;

namespace Api_Preinscripcion.Data
{
    public class dataSede
    {
        public List<ModelSede> listadosedes()
        {
            string consulta = "select * from Sede";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta,ClassGeneral.cadena);
            DataTable aux = new DataTable();
            adaptador.Fill(aux);
            List<ModelSede> sede = new List<ModelSede>();
            foreach(DataRow f in aux.Rows)
            {
                sede.Add(new ModelSede
                {
                    id_sede = f[0].ToString(),
                    nombre_sede = f[1].ToString()
                });
            }
            return sede;
        }
    }
}
