namespace Pre_Api.Data
{
    public class ModelPreinscripcion
    {
        public string id {  get; set; } 
        public string dpi { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string estadocivil { get; set; }
        public string genero { get;set; }
        public DateTime fechanac { get; set; }
        public DateTime fechapre { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public int id_jor { get; set; } 
        public string id_sede { get; set;}
        public int idpg { get; set;}
        public int idmuni { get; set; }
    }
}
