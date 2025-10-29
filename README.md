Segue um resumo objetivo do que foi feito e por quê.

O que foi implementado

Endpoints de avisos

GET /api/v1/avisos/{id}: busca por id.
POST /api/v1/avisos: cria aviso.
PUT /api/v1/avisos/{id}: edita somente a mensagem.
DELETE /api/v1/avisos/{id}: soft delete.
GET /api/v1/avisos: já existia; agora retorna apenas ativos.


Regras de negócio e validação

FluentValidation nos requests:
Id > 0 para GET por id, PUT e DELETE.
Título e mensagem obrigatórios no POST.
Apenas mensagem no PUT e obrigatória.
Soft delete via campo Ativo=false; consultas filtram Ativo=true.
Auditoria: CreatedAt na criação e UpdatedAt em alterações/remoção.

Camadas alteradas

Domain
AvisoEntity: adicionados CreatedAt e UpdatedAt.

Infra
AvisoMap: mapeamento de created_at e updated_at.
IAvisoRepository: novos métodos (ObterPorIdAtivoAsync, AdicionarAsync, AtualizarMensagemAsync, SoftDeleteAsync).
AvisoRepository: implementação + filtro de ativos em listagens.
Seeding InMemory atualizado com CreatedAt.

Application
Queries: GetAvisoRequest/Handler/Response.
Commands: Create, UpdateMensagem, Delete + Validadores.

API
AvisosController: novos endpoints e integrações via MediatR.

Por que estas decisões
Mantive arquitetura CQRS/MediatR e padrões do projeto para coesão.
FluentValidation evita que requisições inválidas alcancem a aplicação.
Soft delete preserva histórico e simplifica consultas com flag Ativo.
Timestamps dão rastreabilidade mínima de criação/edição.

Como rodar
Subir a API e usar Swagger na raiz da aplicação (https://localhost:PORTA/).
Endpoints disponíveis em /api/v1/avisos.
