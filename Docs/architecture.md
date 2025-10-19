# Arquitetura - DesafioMauricio

Data: 2025-10-17

## Visão Geral
API ASP.NET Core 8 estruturada em camadas (Controller -> Service -> Repository -> Data Store) aplicando princípios de separação de responsabilidades, injeção de dependências e simplicidade para um domínio reduzido (Cliente).

## Camadas
- Controllers: Interface HTTP REST.
- Services: Regras de negócio e validação.
- Repositories: Abstração de acesso a dados.
- Data: Armazenamento em memória centralizado.
- Models: Entidades de domínio.

## Diagrama C4
1. System Context (system.c4.puml): posiciona a API dentro do ecossistema, mostrando usuários e sistemas externos que interagem ou interagirão.
2. Container (container.c4.puml): detalha a API como container principal, storage em memória e possível banco futuro.
3. Components (components.c4.puml): mostra componentes internos (Controller, Service, Repository, DataStore, Model) e relacionamentos.

## UML
1. Class (class.puml): classes e interfaces principais, dependências e responsabilidades.
2. Sequence (sequence.puml): fluxo de criação de Cliente evidenciando validação no service e persistência no repository.
3. Deployment (deployment.puml): topologia de execução (container em nuvem / local) e possível evolução para banco relacional.

## Decisões de Projeto
- Repository Pattern: permite trocar InMemory por banco real sem afetar camadas superiores.
- InMemoryDataStore estático: simplicidade para challenge, com lock para garantir segurança em cenários concorrentes.
- Service Layer: centraliza validações (nome e email) e evita duplicação em controllers.
- DI Lifetime: Repository como Singleton para manter estado; Service Scoped para alinhamento com escopo de request; DataStore estático para simplificar.
- PlantUML: favorece versionamento de diagramas como código.

## Evolução Futura
- Substituir InMemory por EF Core + migrações.
- Adicionar autenticação/authorization (JWT / OAuth2).
- Observabilidade: logging estruturado e métricas Prometheus.
- Paginação e filtros avançados nas consultas.

## Mapeamento Código x Componentes
| Componente | Código |
|-----------|--------|
| Controller | Controllers/ClientesController.cs |
| Service | Services/ClienteService.cs |
| Repository | Repositories/ClienteRepository.cs + IClienteRepository.cs |
| Data Store | Data/InMemoryDataStore.cs |
| Domain Model | Models/Cliente.cs |

## Exportação de Diagramas
Utilize extensão VS Code PlantUML ou CLI:
```
plantuml -tpng Docs/diagrams/c4/*.puml
plantuml -tpng Docs/diagrams/uml/*.puml
```
Os PNGs resultantes devem ficar ao lado dos arquivos .puml.

## Qualidade
- Validações explícitas
- Código comentado e organizado
- Pronto para expansão
