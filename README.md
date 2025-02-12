Sobre o Projeto:  
API responsável por realizar a gestão das vendas dos Produtos.

Tecnologias Utilizadas:

- C#
- .NET 9
- SQL Server
- Entity Framework Core
- ASP.NET Core
- Swagger (OpenAPI)
- MassTransit
- RabbitMQ

Configuração do Ambiente:

1. Clone o repositório: https://github.com/HelderJr/Ambev.DeveloperEvaluation
2. Instale as dependências: dotnet restore
3. Execute as migrations para criar o banco de dados: dotnet ef database update
4. Executando o Projeto:
     Pelo Visual Studio:
     Abra o projeto no Visual Studio
     Selecione a API (Ambev.DeveloperEvaluation.WebApi) como projeto principal
     Clique em Executar (F5)
     Pelo CLI: dotnet run

A aplicação estará disponível em:
  Backend: http://localhost:7181
  Swagger UI: http://localhost:7181/swagger

Projeto de Mensageria com MassTransit e RabbitMQ
Este projeto implementa um sistema de mensageria utilizando MassTransit para publicar e consumir eventos no RabbitMQ.

Evento: SaleCreatedEvent

O evento SaleCreatedEvent é disparado sempre que uma nova venda é criada no sistema. Ele é publicado na exchange padrão do MassTransit e pode ser consumido por qualquer serviço registrado para escutá-lo.

     
