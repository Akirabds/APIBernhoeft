using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class GetAvisoHandler : IRequestHandler<GetAvisoRequest, IOperationResult<GetAvisoResponse>>
    {
        private readonly IAvisoRepository _repo;
        public GetAvisoHandler(IAvisoRepository repo) => _repo = repo;

        public async Task<IOperationResult<GetAvisoResponse>> Handle(GetAvisoRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.ObterPorIdAtivoAsync(request.Id, TrackingBehavior.NoTracking, cancellationToken);
            if (entity == null)
                return OperationResult<GetAvisoResponse>.ReturnNotFound();

            return OperationResult<GetAvisoResponse>.ReturnOk(new GetAvisoResponse
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Mensagem = entity.Mensagem
            });
        }
    }
}
