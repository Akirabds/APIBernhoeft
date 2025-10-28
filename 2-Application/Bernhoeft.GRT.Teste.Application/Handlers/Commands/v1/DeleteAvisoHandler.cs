using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class DeleteAvisoHandler : IRequestHandler<DeleteAvisoRequest, IOperationResult<object>>
    {
        private readonly IAvisoRepository _repo;
        public DeleteAvisoHandler(IAvisoRepository repo) => _repo = repo;

        public async Task<IOperationResult<object>> Handle(DeleteAvisoRequest request, CancellationToken cancellationToken)
        {
            var ok = await _repo.SoftDeleteAsync(request.Id, cancellationToken);
            return ok ? OperationResult<object>.ReturnNoContent() : OperationResult<object>.ReturnNotFound();
        }
    }
}
