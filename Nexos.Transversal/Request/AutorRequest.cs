using System;

namespace Nexos.Transversal.Request
{
    public class AutorRequest
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int CiudadId { get; set; }
        public string Correo { get; set; }
    }
}
