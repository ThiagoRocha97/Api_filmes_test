using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Query
{
    public class VotoQueryResult
    {
        public long IdVoto { get ; set ; }

        public long IdFilme { get; set; }

        public string Titulo { get; set; }

        public string Diretor { get; set; }

        public long IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
                            
    }
}
