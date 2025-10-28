using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Attributes;
using Bernhoeft.GRT.Core.EntityFramework.Infra;
using Bernhoeft.GRT.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bernhoeft.GRT.ContractWeb.Infra.Persistence.SqlServer.ContractStore.Repositories
{
    [InjectService(Interface: typeof(IAvisoRepository))]
    public class AvisoRepository : Repository<AvisoEntity>, IAvisoRepository
    {
        public AvisoRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var baseQuery = Set.Where(x => x.Ativo);
            var query = tracking is TrackingBehavior.NoTracking ? baseQuery.AsNoTrackingWithIdentityResolution() : baseQuery;
            return query.ToListAsync(cancellationToken);
        }

        public Task<AvisoEntity> ObterPorIdAtivoAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var baseQuery = Set.Where(x => x.Ativo && x.Id == id);
            var query = tracking is TrackingBehavior.NoTracking ? baseQuery.AsNoTrackingWithIdentityResolution() : baseQuery;
            return query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AdicionarAsync(AvisoEntity entity, CancellationToken cancellationToken = default)
        {
            entity.Ativo = true;
            entity.CreatedAt = DateTime.UtcNow;
            await Set.AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarMensagemAsync(int id, string mensagem, CancellationToken cancellationToken = default)
        {
            var entity = await Set.FirstOrDefaultAsync(x => x.Id == id && x.Ativo, cancellationToken);
            if (entity is null) return;
            entity.Mensagem = mensagem;
            entity.UpdatedAt = DateTime.UtcNow;
            Set.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> SoftDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Set.FirstOrDefaultAsync(x => x.Id == id && x.Ativo, cancellationToken);
            if (entity is null) return false;
            entity.Ativo = false;
            entity.UpdatedAt = DateTime.UtcNow;
            Set.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}