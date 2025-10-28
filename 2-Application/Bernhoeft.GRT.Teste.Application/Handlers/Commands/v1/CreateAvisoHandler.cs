using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class CreateAvisoHandler : IRequestHandler<CreateAvisoRequest, IOperationResult<CreateAvisoResponse>>
    {
        private readonly IAvisoRepository _repo;
        public CreateAvisoHandler(IAvisoRepository repo) => _repo = repo;

        public async Task<IOperationResult<CreateAvisoResponse>> Handle(CreateAvisoRequest request, CancellationToken cancellationToken)
        {
            var entity = new AvisoEntity
            {
                Titulo = request.Titulo,
                Mensagem = request.Mensagem,
                Ativo = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AdicionarAsync(entity, cancellationToken);

            return OperationResult<CreateAvisoResponse>.ReturnOk(new CreateAvisoResponse
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Mensagem = entity.Mensagem,
                CreatedAt = entity.CreatedAt
            });
        }
    }
}
