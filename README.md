#  API de Avisos

API para gestão de avisos com validação, auditoria, soft delete e arquitetura CQRS/MediatR.

##  Funcionalidades
- CRUD de avisos
- Retorno apenas de avisos ativos
- Soft delete (`Ativo = false`)
- Auditoria (`CreatedAt`, `UpdatedAt`)
- Validação com FluentValidation
- CQRS + MediatR
- EF Core InMemory (para fins de exemplo)

##  Endpoints
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/v1/avisos/{id}` | Buscar aviso por ID |
| GET | `/api/v1/avisos` | Listar somente ativos |
| POST | `/api/v1/avisos` | Criar aviso |
| PUT | `/api/v1/avisos/{id}` | Atualizar apenas a mensagem |
| DELETE | `/api/v1/avisos/{id}` | Soft delete |

##  Regras de Negócio e Validação
- `Id > 0` em GET, PUT e DELETE
- POST: `titulo` e `mensagem` obrigatórios
- PUT: apenas `mensagem` (obrigatória)
- Soft delete → `Ativo = false`
- Consultas retornam apenas `Ativo = true`
- Auditoria:
  - `CreatedAt` ao criar
  - `UpdatedAt` ao atualizar ou remover

##  Arquitetura / Alterações

### Domain
- `AvisoEntity` com `CreatedAt` e `UpdatedAt`

### Infra
- Mapping para timestamps
- Repositório com métodos:
  - `ObterPorIdAtivoAsync`
  - `AdicionarAsync`
  - `AtualizarMensagemAsync`
  - `SoftDeleteAsync`
- Seed com `CreatedAt`

### Application
- Queries: `GetAvisoRequest`
- Commands: `Create`, `UpdateMensagem`, `Delete`
- Validações com FluentValidation

### API
- `AvisosController` via MediatR

##  Exemplos de Requisição e Resposta

### POST `/api/v1/avisos`
**Request**
```json
{
  "titulo": "Novo recurso",
  "mensagem": "Relatórios liberados."
}
```

**Response**
```json
{
  "id": 4,
  "titulo": "Novo recurso",
  "mensagem": "Relatórios liberados.",
  "createdAt": "2025-01-20T11:32:00Z"
}
```

### PUT `/api/v1/avisos/4`
**Request**
```json
{
  "mensagem": "Relatórios já disponíveis."
}
```

### DELETE `/api/v1/avisos/4`
**Response**
```json
{
  "message": "Aviso removido (soft delete)."
}
```

### GET `/api/v1/avisos`
**Response**
```json
[
  {
    "id": 1,
    "titulo": "Aviso importante",
    "mensagem": "Sistema em manutenção amanhã"
  }
]
```

##  Como Rodar
Acesse via Swagger:
```
https://localhost:PORTA/
```
Endpoints:
```
/api/v1/avisos
```

##  Stack
- .NET
- MediatR
- FluentValidation
- EF Core (InMemory)
- CQRS

##  Motivações Técnicas
- Seguir padrões de arquitetura (CQRS/MediatR)
- Garantir consistência com FluentValidation
- Soft delete para preservar histórico
- Timestamps para rastreabilidade
