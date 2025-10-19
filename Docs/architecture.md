# Arquitetura - DesafioMauricio

Data: 2025-10-17

## Vis�o Geral
API ASP.NET Core 8 estruturada em camadas (Controller -> Service -> Repository -> Data Store) aplicando princ�pios de separa��o de responsabilidades, inje��o de depend�ncias e simplicidade para um dom�nio reduzido (Cliente).

## Camadas
- Controllers: Interface HTTP REST.
- Services: Regras de neg�cio e valida��o.
- Repositories: Abstra��o de acesso a dados.
- Data: Armazenamento em mem�ria centralizado.
- Models: Entidades de dom�nio.

## Diagrama C4
1. System Context (system.c4.puml): posiciona a API dentro do ecossistema, mostrando usu�rios e sistemas externos que interagem ou interagir�o.
2. Container (container.c4.puml): detalha a API como container principal, storage em mem�ria e poss�vel banco futuro.
3. Components (components.c4.puml): mostra componentes internos (Controller, Service, Repository, DataStore, Model) e relacionamentos.

## UML
1. Class (class.puml): classes e interfaces principais, depend�ncias e responsabilidades.
2. Sequence (sequence.puml): fluxo de cria��o de Cliente evidenciando valida��o no service e persist�ncia no repository.
3. Deployment (deployment.puml): topologia de execu��o (container em nuvem / local) e poss�vel evolu��o para banco relacional.

## Decis�es de Projeto
- Repository Pattern: permite trocar InMemory por banco real sem afetar camadas superiores.
- InMemoryDataStore est�tico: simplicidade para challenge, com lock para garantir seguran�a em cen�rios concorrentes.
- Service Layer: centraliza valida��es (nome e email) e evita duplica��o em controllers.
- DI Lifetime: Repository como Singleton para manter estado; Service Scoped para alinhamento com escopo de request; DataStore est�tico para simplificar.
- PlantUML: favorece versionamento de diagramas como c�digo.

## Evolu��o Futura
- Substituir InMemory por EF Core + migra��es.
- Adicionar autentica��o/authorization (JWT / OAuth2).
- Observabilidade: logging estruturado e m�tricas Prometheus.
- Pagina��o e filtros avan�ados nas consultas.

## Mapeamento C�digo x Componentes
| Componente | C�digo |
|-----------|--------|
| Controller | Controllers/ClientesController.cs |
| Service | Services/ClienteService.cs |
| Repository | Repositories/ClienteRepository.cs + IClienteRepository.cs |
| Data Store | Data/InMemoryDataStore.cs |
| Domain Model | Models/Cliente.cs |

## Exporta��o de Diagramas
Utilize extens�o VS Code PlantUML ou CLI:
```
plantuml -tpng Docs/diagrams/c4/*.puml
plantuml -tpng Docs/diagrams/uml/*.puml
```
Os PNGs resultantes devem ficar ao lado dos arquivos .puml.

## Qualidade
- Valida��es expl�citas
- C�digo comentado e organizado
- Pronto para expans�o
