# GoodHamburger

## Descrição do Projeto - GoodHamburger

### Arquitetura de Desenvolvimento - Hexagonal Architecture

A arquitetura hexagonal, também conhecida como Ports and Adapters, é um estilo arquitetural proposto por Alistair Cockburn que organiza o sistema em torno do domínio de negócio, isolando-o de dependências externas como banco de dados, interfaces web e APIs.

Nesse modelo, a aplicação é estruturada em três partes principais: o núcleo (domínio), que contém as regras de negócio; as portas (interfaces), que definem como o sistema se comunica com o mundo externo; e os adaptadores, que implementam essas interfaces para tecnologias específicas, como controllers, repositórios ou serviços externos.

O principal objetivo da arquitetura hexagonal é promover o desacoplamento, permitindo que o domínio permaneça independente de frameworks e ferramentas. Isso facilita testes, manutenção e evolução do sistema, já que mudanças na infraestrutura não impactam diretamente a lógica de negócio.

Em resumo, a arquitetura hexagonal coloca o domínio no centro da aplicação e permite que tudo ao redor seja substituível por meio de contratos bem definidos.

Referências:

* Cockburn, Alistair. Hexagonal Architecture (2005).
* Martin, Robert C. Clean Architecture. Prentice Hall, 2017.
* Fowler, Martin. Patterns of Enterprise Application Architecture. Addison-Wesley, 2002.

### Tecnologias Utilizadas
- C# .NET 10
- Entity Framework Core
- FluentValidation
- Banco de Dados Relacional MySQL Server (versão 8.0 ou superior)

### Configuração do Banco de Dados e Aplicação Web Api

1. Instale o MySQL Server (versão 8.0 ou superior) em sua máquina ou Imagem Docker.
2. Crie um banco de dados para a aplicação, por exemplo, `goodhamburger`.
3. Abre o Projeto em seu Visual Studio 2026 ou IDE de sua preferência (Visual Studio Code com os plugins necessários). 
4. Configure a string de conexão no arquivo `appsettings.json` da aplicação na chave `ConnectionStrings:DefaultConnection`, substituindo os valores de usuário, senha e nome do banco de dados conforme necessário.
5. Dentro do github tem uma pasta SQL, baixe o arquivo SQL `banco.sql` e execute no banco criado no seu banco MySQL. 
6. Execute o seu projeto na IDE.