using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Entidades
{
    public class Voto
    {
        public long Id { get; set; }
        public long Id_Usuario { get; set; }
        public long Id_Filme { get; set; }


        public Voto(long id, long id_usuario, long id_filme)
        {
            Id = id;
            Id_Usuario = id_usuario;
            Id_Filme = id_filme;            
        }
    }
}
