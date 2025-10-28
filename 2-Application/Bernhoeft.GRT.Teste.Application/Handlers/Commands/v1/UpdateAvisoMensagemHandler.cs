using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class UpdateAvisoMensagemHandler : IRequestHandler<UpdateAvisoMensagemRequest, IOperationResult<UpdateAvisoMensagemResponse>>
    {
        private readonly IAvisoRepository _repo;
        public UpdateAvisoMensagemHandler(IAvisoRepository repo) => _repo = repo;

        public async Task<IOperationResult<UpdateAvisoMensagemResponse>> Handle(UpdateAvisoMensagemRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.ObterPorIdAtivoAsync(request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return OperationResult<UpdateAvisoMensagemResponse>.ReturnNotFound();

            await _repo.AtualizarMensagemAsync(request.Id, request.Mensagem, cancellationToken);

            return OperationResult<UpdateAvisoMensagemResponse>.ReturnOk(new UpdateAvisoMensagemResponse
            {
                Id = request.Id,
                Mensagem = request.Mensagem,
                UpdatedAt = DateTime.UtcNow
            });
        }
    }
}
