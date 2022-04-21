using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Transversal
{
    public class DTResultado<T> where T : class
    {
        public bool Respuesta { get; set; }
        public T Resultado { get; set; }
        public string Mensaje { get; set; }
        public string Codigo { get; set; }
    }
}
