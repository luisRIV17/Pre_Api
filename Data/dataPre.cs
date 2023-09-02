using Pre_Api.Models;
using System.Data.SqlClient;
using System.Data;
using Pre_Api.Data;

namespace Pre_Api.Data
{
    public class dataPre
    {
        public List<ModelCarrera> listadocarrera(string sede)
        {
            string consulta = "select c.ID_Carrera, Nom_Carrera from carrera c inner join Pagos_Carrera pg on pg.ID_Carrera = c.ID_Carrera where id_sede='" + sede+"'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ClassGeneral.cadena);
            DataTable aux = new DataTable();
            adaptador.Fill(aux);
            List<ModelCarrera> carrera = new List<ModelCarrera>();
            foreach (DataRow f in aux.Rows)
            {
                carrera.Add(new ModelCarrera
                {
                    id_carrera = f[0].ToString(),
                    nombre = f[1].ToString()
                });
            }
            return carrera;
        }
        public List<ModelJornada> listajornada(string sede, string carrera)
        {
            string consulta = "select j.id_jornada, nombre_jornada from jornada j inner join Pagos_Carrera pg on pg.id_jornada =j.id_jornada where id_sede='"+sede+"' and ID_Carrera='" + carrera + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ClassGeneral.cadena);
            DataTable aux = new DataTable();
            adaptador.Fill(aux);
            List<ModelJornada> jorna = new List<ModelJornada>();
            foreach (DataRow f in aux.Rows)
            {
                jorna.Add(new ModelJornada
                {
                    id =Convert.ToInt32( f[0]),
                    nombre = f[1].ToString()
                });
            }
            return jorna;
        }
        public List<ModelDepartamento> listadepa()
        {
            string consulta = "select * from departamento";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ClassGeneral.cadena);
            DataTable aux = new DataTable();
            adaptador.Fill(aux);
            List<ModelDepartamento> depa = new List<ModelDepartamento>();
            foreach (DataRow f in aux.Rows)
            {
                depa.Add(new ModelDepartamento
                {
                    id_depa = Convert.ToInt32(f[0]),
                    nombre_depa = f[1].ToString()
                });
            }
            return depa;
        }
        public List<ModelMunicipio> listamuni(int idepa)
        {
            string consulta = "select * from municipio where id_departamento= "+idepa.ToString();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ClassGeneral.cadena);
            DataTable aux = new DataTable();
            adaptador.Fill(aux);
            List<ModelMunicipio> muni = new List<ModelMunicipio>();
            foreach (DataRow f in aux.Rows)
            {
                muni.Add(new ModelMunicipio
                {
                    id_municipio = Convert.ToInt32(f[0]),
                    nombre_municipio = f[1].ToString()
                });
            }
            return muni;
        }
        public int insertacliente(ModelPreinscripcion nuevapre)
        {

            string consulta = "insert into Preinscripcion_Alumno values (@ID,@dpi,@Nombre1,@Nombre2,@Apellido1,@Apellido2,@Estado_Civil,@Genero,@Fechanac," +
                "@Fecha_Pre,@Celular,@Correo_personal,@Direccion,@id_jornada,@id_sede,@ID_Pagos_Carrera,@id_municipio)";
            SqlConnection cone = new SqlConnection(ClassGeneral.cadena);
            SqlCommand comando = new SqlCommand(consulta, cone);
            comando.Parameters.AddWithValue("@ID", nuevapre.id);
            comando.Parameters.AddWithValue("@dpi", nuevapre.dpi);
            comando.Parameters.AddWithValue("@Nombre1", nuevapre.nombre1);
            comando.Parameters.AddWithValue("@Nombre2", nuevapre.nombre2);
            comando.Parameters.AddWithValue("@Apellido1", nuevapre.apellido1);
            comando.Parameters.AddWithValue("@Apellido2", nuevapre.apellido2);
            comando.Parameters.AddWithValue("@Estado_Civil", nuevapre.estadocivil);
            comando.Parameters.AddWithValue("@Genero", nuevapre.genero);
            comando.Parameters.AddWithValue("@Fechanac", nuevapre.fechanac);
            comando.Parameters.AddWithValue("@Fecha_Pre", nuevapre.fechapre);
            comando.Parameters.AddWithValue("@Celular", nuevapre.celular);
            comando.Parameters.AddWithValue("@Correo_personal", nuevapre.correo);
            comando.Parameters.AddWithValue("@Direccion", nuevapre.direccion);
            comando.Parameters.AddWithValue("@id_jornada", nuevapre.id_jor);
            comando.Parameters.AddWithValue("@id_sede", nuevapre.id_sede);
            comando.Parameters.AddWithValue("@ID_Pagos_Carrera", nuevapre.idpg);
            comando.Parameters.AddWithValue("@id_municipio", nuevapre.idmuni);
            try
            {
                cone.Close();
                cone.Open();
                comando.ExecuteNonQuery();
                cone.Close();
                return 1;
            }
            catch { return 0; }


        }
    }
}
