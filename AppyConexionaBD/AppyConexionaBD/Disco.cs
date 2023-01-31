using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppyConexionaBD
{
    internal class Disco
    {
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }

        public int Canciones { get; set; }

        public string Imagen { get; set; }

        public Estilos Estilo { get; set; }

        public Ediciones Edicion { get; set; }
    }
}
