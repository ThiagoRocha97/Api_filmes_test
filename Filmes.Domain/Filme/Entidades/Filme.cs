using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entidades
{
    public class Filme
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public Filme(long id, string titulo, string diretor)
        {
            Id = id;
            Titulo = titulo;
            Diretor = diretor;
        }
    }
}
