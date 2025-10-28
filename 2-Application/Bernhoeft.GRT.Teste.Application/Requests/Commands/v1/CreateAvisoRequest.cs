using Bernhoeft.GRT.Core.Interfaces.Results;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class CreateAvisoRequest : IRequest<IOperationResult<CreateAvisoResponse>>
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }

    public class CreateAvisoResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
