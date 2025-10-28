using Bernhoeft.GRT.Core.Interfaces.Results;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class UpdateAvisoMensagemRequest : IRequest<IOperationResult<UpdateAvisoMensagemResponse>>
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
    }

    public class UpdateAvisoMensagemResponse
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
