using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerHerramientas
{
    public class NombreInvalidoException : Exception
    {
        public NombreInvalidoException(string mensaje) : base(mensaje) { }
    }
}
