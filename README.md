# GoodHamburger

![Static Badge](https://img.shields.io/badge/github-repo-blue?style=flat&link=https%3A%2F%2Fgithub.com%2Ffulviocanducci%2FGoodHamburger)
![Static Badge](https://img.shields.io/badge/build-passing-brightgreen?style=flat&link=https%3A%2F%2Fgithub.com%2Ffulviocanducci%2FGoodHamburger)


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

### Projeto de Testes Unitários

No projeto existe um projeto unitário de teste com o nome `TestGoodHamburger`. Ele contém testes unitários para as camadas de domínio e aplicação, utilizando o framework de testes xUnit e Moq para mockar dependências.

### O que eu deixo de fora
- Camada de Apresentação (Frontend) Não sou especialista em frontend, trabalho com ReactJs, KnockoutJs e muito pouco Blazor, meu forte é o backend e Razor Pages, então optei por não incluir uma camada de apresentação para focar no backend e na arquitetura hexagonal.
- Implementação de APIs externas (ex: serviços de pagamento, envio de email, etc.)
- Configurações avançadas de segurança e performance (ex: caching, logging, etc.)
- Documentação detalhada de cada classe e método (embora haja comentários básicos para entendimento geral)

### IA

O projeto foi desenvolvido sem a ajuda de IA, nas seguintes camadas:

- Camada de Compartilhamento (Shared)
- Camada de Domínio (Domain)
- Camada de Aplicação (Application)
- Camada de Infraestrutura (Infrastructure)
- Camada de Apresentação (WebApi)

Com o auxilio de IA, foram gerados os seguintes items:

- Camada de Testes Unitários (TestGoodHamburger)

Eu gerei um padrão de teste e pedi para IA continuar o modelo para todos os controllers, serviços e repositórios, o que me ajudou a acelerar o processo de criação dos testes unitários.

- Readme.md

Fez propostas de estrutura e conteúdo para o arquivo README.md, que foi revisado e editado para se adequar ao projeto.

### Sobre IA

Eu utilizo a IA como apoiador para acelerar o processo de desenvolvimento, especialmente em tarefas repetitivas ou que exigem a criação de muitos arquivos semelhantes, como testes unitários. A IA me ajuda a manter um padrão consistente e a economizar tempo, permitindo que eu me concentre mais na lógica de negócio e na arquitetura do projeto. No entanto, todas as decisões de design e implementação são feitas por mim, garantindo que o projeto atenda às minhas expectativas e requisitos específicos.

### Considerações Finais

Este projeto é uma implementação básica de um sistema de gerenciamento de pedidos para uma hamburgueria, utilizando a arquitetura hexagonal para promover o desacoplamento e a testabilidade. Ele serve como um ponto de partida para quem deseja aprender sobre essa arquitetura e como aplicá-la em projetos reais. Sinta-se à vontade para expandir e melhorar o projeto conforme necessário!

### Imagem do Projeto
![Imagem do Projeto](/Imagens/imagem1.jpg)

### Autor: Fúlvio Cezar Canducci Dias
### Contato: fulviocanducci@hotmail.com
