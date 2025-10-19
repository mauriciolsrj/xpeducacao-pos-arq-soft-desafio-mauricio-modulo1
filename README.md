# DesafioMauricio

API ASP.NET Core 8 (C# 12) para gestão de Clientes. Estruturada com camadas Controller -> Service -> Repository -> Data Store (InMemory) e diagramas arquiteturais (C4 + UML) em PlantUML.

## Requisitos
- .NET 8 SDK
- (Opcional) PlantUML + Java para exportar diagramas

## Executar
```bash
dotnet run --project DesafioMauricio/DesafioMauricio.csproj
```
Acesse Swagger: https://localhost:5001/swagger ou http://localhost:5000/swagger

## Endpoints Principais
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/clientes | Lista todos |
| GET | /api/clientes/{id} | Obtém por Id |
| GET | /api/clientes/nome/{nome} | Busca por nome (contains, case-insensitive) |
| GET | /api/clientes/contar | Quantidade total |
| POST | /api/clientes | Cria novo (201 + Location) |
| PUT | /api/clientes/{id} | Atualiza existente |
| DELETE | /api/clientes/{id} | Remove |

### Exemplo POST
```bash
curl -X POST https://localhost:5001/api/clientes \
 -H "Content-Type: application/json" \
 -d '{"nome":"João Silva","email":"joao@exemplo.com"}'
```

## Estrutura de Pastas
```
DesafioMauricio/
 ├── Controllers/
 ├── Data/
 ├── Docs/
 │   ├── diagrams/
 │   │   ├── c4/
 │   │   └── uml/
 │   └── architecture.md
 ├── Models/
 ├── Repositories/
 ├── Services/
 ├── Program.cs
 └── DesafioMauricio.csproj
```

## Diagramas
Arquivos PlantUML em `Docs/diagrams`. Exportar PNGs:
```bash
plantuml -tpng Docs/diagrams/c4/*.puml
plantuml -tpng Docs/diagrams/uml/*.puml
```

## Arquitetura
Para detalhes completos sobre a arquitetura do projeto, decisões de design e diagramas visuais, consulte:

📋 **[Documentação de Arquitetura](Docs/architecture.md)**

Este documento inclui:
- Visão geral da arquitetura em camadas
- Diagramas C4 (System Context, Container, Components)
- Diagramas UML (Class, Sequence, Deployment)
- Decisões de projeto e justificativas técnicas
- Mapeamento código x componentes

## Evolução Futura
- Persistência real (EF Core)
- Autenticação/Autorização
- Paginação e filtros
- Observabilidade (Serilog, OpenTelemetry)

## Licença
Uso educacional.
