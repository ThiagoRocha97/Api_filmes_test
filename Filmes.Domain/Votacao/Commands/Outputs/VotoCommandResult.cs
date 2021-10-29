using Desafio.Infra.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Votacao.Commands.Outputs
{
    public class VotoCommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public VotoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
