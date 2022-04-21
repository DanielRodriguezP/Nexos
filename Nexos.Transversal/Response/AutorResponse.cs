using System;

namespace Nexos.Transversal.Response
{
    public class AutorResponse
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
    }
}
