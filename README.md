# 🎬 Filmes API

API REST desenvolvida em C# com ASP.NET Core e Entity Framework Core para gerenciamento e consulta de filmes, diretores e informações complementares.

O projeto foi desenvolvido como parte dos meus estudos de desenvolvimento backend com .NET, com foco em APIs REST, persistência de dados, relacionamentos entre entidades e organização do código em camadas.

## 📌 Sobre o projeto

A Filmes API permite consultar filmes e diretores, realizar operações de gerenciamento de diretores e acessar informações detalhadas relacionadas aos diretores.

A aplicação utiliza Entity Framework Core para mapear as entidades e realizar operações com o banco de dados SQLite.

## 🛠️ Tecnologias utilizadas

| Tecnologia | Utilização |
|---|---|
| C# | Linguagem de programação |
| .NET 10 | Plataforma de desenvolvimento |
| ASP.NET Core | Construção da API REST |
| Entity Framework Core 10 | ORM e persistência de dados |
| SQLite | Banco de dados relacional |
| Swagger / OpenAPI | Documentação e testes dos endpoints |
| Git e GitHub | Versionamento de código |

## ⚙️ Funcionalidades

- Consulta de filmes cadastrados.
- Consulta de filme por identificador.
- Pesquisa de filmes por título.
- Atualização de informações de filmes.
- Exclusão de filmes.
- Consulta e gerenciamento de diretores.
- Consulta de informações complementares dos diretores.
- Relacionamentos entre filmes e diretores.
- Persistência de dados com Entity Framework Core.

## 🏗️ Arquitetura do projeto

A solução está organizada em três projetos, separando as principais responsabilidades da aplicação:

```text
aspnet-core-filmes-api/
│
├── FilmesApi/
│   ├── EndpointExtensions/
│   ├── EndpointHandlers/
│   ├── Models/
│   ├── Properties/
│   ├── Program.cs
│   └── appsettings.json
│
├── FilmesApi.Domain/
│   └── Entities/
│
├── FilmesApi.Repo/
│   ├── Contexts/
│   ├── Contracts/
│   └── Repositories/
│
├── FilmesApi.slnx
└── README.md
```

**Responsabilidades dos projetos:**

- **FilmesApi:** camada responsável pela aplicação HTTP, configuração e exposição dos endpoints.
- **FilmesApi.Domain:** contém as entidades que representam o domínio da aplicação.
- **FilmesApi.Repo:** concentra o contexto do Entity Framework Core, contratos e implementações de repositórios.

## 🌐 Endpoints

### Filmes

| Método | Endpoint | Descrição |
|---|---|---|
| GET | `/filmes` | Lista os filmes |
| GET | `/filmes/{id}` | Consulta um filme por ID |
| GET | `/filmesEFFunctions/byName/{titulo}` | Pesquisa por título utilizando `EF.Functions.Like` |
| GET | `/filmesContains/byName/{titulo}` | Pesquisa por título utilizando `Contains` |
| PATCH | `/filmesUpdate` | Atualiza informações de um filme |
| PATCH | `/filmesExecuteUpdate` | Atualiza informações utilizando `ExecuteUpdateAsync` |
| DELETE | `/filmes/{filmeId}` | Exclui um filme |

### Diretores

| Método | Endpoint | Descrição |
|---|---|---|
| GET | `/diretores` | Lista os diretores |
| GET | `/diretores/agregacao/{name}` | Consulta diretor por nome |
| GET | `/diretores/where/{id}` | Consulta diretor por ID |
| POST | `/diretores` | Cadastra um diretor |
| PUT | `/diretores` | Atualiza um diretor |
| DELETE | `/diretores/{diretorId}` | Exclui um diretor |
| GET | `/diretorDetalhe/{id}` | Consulta detalhes de um diretor |

## 🔗 Relacionamentos e persistência

O modelo de dados utiliza relacionamentos entre as entidades:

- **Filme e Diretor:** relacionamento muitos-para-muitos.
- **Diretor e DiretorDetalhe:** relacionamento um-para-um.

O mapeamento é configurado no `OnModelCreating`, incluindo configurações de propriedades, chaves estrangeiras e dados iniciais.

O banco SQLite é criado pela aplicação durante a inicialização, utilizando a configuração atual do Entity Framework Core.

## 🚀 Como executar o projeto

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Git](https://git-scm.com/)
- Visual Studio com a carga de trabalho **ASP.NET e desenvolvimento Web**, ou Visual Studio Code com a extensão **C# Dev Kit**.

O SQLite é utilizado como banco de dados local, portanto não é necessário instalar um servidor de banco de dados separado.

### 1. Clonar o repositório

```bash
git clone https://github.com/SamuelLucas1/aspnet-core-filmes-api.git
```

### 2. Acessar a pasta do projeto

```bash
cd aspnet-core-filmes-api
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar a solução

```bash
dotnet build
```

### 5. Executar a API

```bash
dotnet run --project FilmesApi/FilmesApi.API.csproj
```

Aguarde a inicialização e confira no terminal o endereço local informado pela aplicação.

### 6. Acessar a documentação

Com a aplicação em execução, acesse:

```text
https://localhost:<porta>/swagger
```

Substitua `<porta>` pela porta HTTPS exibida no terminal.

## 💻 Executando pelo Visual Studio

1. Clone o repositório ou baixe o projeto.
2. Abra o arquivo `FilmesApi.slnx` no Visual Studio.
3. Aguarde a restauração dos pacotes NuGet.
4. Defina `FilmesApi` como projeto de inicialização, caso necessário.
5. Execute a aplicação com `F5` ou `Ctrl + F5`.
6. Acesse a documentação Swagger pelo endereço apresentado durante a inicialização.

## 🧑‍💻 Executando pelo Visual Studio Code

1. Instale o [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Instale a extensão [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).
3. Clone o repositório e abra a pasta no VS Code.
4. Abra o terminal integrado.
5. Execute:

```bash
dotnet restore
dotnet build
dotnet run --project FilmesApi/FilmesApi.API.csproj
```

6. Acesse o Swagger pelo endereço HTTPS exibido no terminal.

## 📚 Aprendizados

Durante o desenvolvimento deste projeto, pratiquei:

- Desenvolvimento de APIs REST com ASP.NET Core.
- Organização de aplicações em projetos e camadas.
- Programação assíncrona com `async` e `await`.
- Injeção de dependência.
- Padrão Repository e contratos com interfaces.
- Mapeamento de entidades e relacionamentos com Entity Framework Core.
- Consultas LINQ e operações de atualização e exclusão no banco de dados.
- Configuração e utilização do SQLite.
- Documentação e testes de endpoints com Swagger.
- Versionamento de código com Git e GitHub.

## 🔮 Possíveis evoluções

- Implementação de migrations para evolução do banco de dados.
- Padronização das respostas HTTP e tratamento global de exceções.
- Implementação de testes automatizados.
- Validação de dados e melhoria dos contratos de entrada e saída.
- Evolução da arquitetura e documentação da API.

## 👨‍💻 Autor

**Samuel Lucas**

Estudante de Jogos Digitais e desenvolvedor em formação, com foco em C#, .NET e desenvolvimento backend.

- GitHub: [SamuelLucas1](https://github.com/SamuelLucas1)
- LinkedIn: [Samuel Lucas](https://linkedin.com/in/samuel-lucas-916b583b2/)

---

Projeto desenvolvido para fins educacionais e de portfólio, com foco no aprendizado prático de desenvolvimento backend utilizando o ecossistema .NET.
