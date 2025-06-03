
# FIAP Cloud Games - API

##  Descrição

 API RESTful com finalidade de gerenciar a platarforma de venda de jogo, **FIAP Cloud Games**, a qual foi desenvolvida utilizando **.NET 8**. A partir deste documento você poderá utilizar todas funcionalidades disponíveis no projeto para cadastro e consulta de jogos, realizar Login e criação de usuário.

## Objetivos
- A aplicação tem como função principal o controle de uma biblioteca de jogos (VideoGames). Para que o controle possa ser realizado, implantamos o cadastro de usuário (Users) e o controle de Login, foi implementado token JWT (Json Web Token) para controlar as permissões dos usuários em consultas e alterações de dados.

- **Cadastro de Usuários** :
    - `POST /register`: Cadastro de usuários, realizando validação de e-mail e senha forte.
- **Login**:
    - `POST /Auth/Login`: Autenticação do usuário com retorno do Token JWT gerado
- **Controle dos Jogos**:
    - `GET /GetVideoGames`: Retorna todos os jogos cadastrados.
    - `GET /GetByIdVideoGames/{id}`: Retorna um jogo específico pelo ID.
    - `POST /PostVideoGames`: Cadastra um novo jogo.
    - `POST /PostListVideoGames`: Cadastro em lote de jogos.
    - `PUT /PutVideoGames/{id}`: Atualiza os dados de um jogo existente.
    - `DELETE /DeleteVideoGames/{id}`: Remove um jogo da base.


##  Autenticação e Permissões

- **JWT Token** obrigatório para acessar os endpoints protegidos.
- Dois níveis de acesso:
  - **Usuário:** acesso à plataforma e à biblioteca de jogos.
  - **Administrador:** pode cadastrar, editar e remover jogos.


##  Arquitetura do Projeto

- Projeto monolítico, dividido nas seguintes pastas:
  - `Auth`: Gerenciamento de autenticação e geração de tokens.
  - `Controllers`: Endpoints da API.
  - `Data`: Contexto do banco (Entity Framework).
  - `DTOs`: Transferência de dados.
  - `Entities`: Entidades principais (`Users` e `VideoGames`).
  - `Middlewares`: Tratamento de exceções e logs.
  - `Migrations`: Controle de versão do banco de dados.


##  Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- JWT (Json Web Token)
- Swagger (documentação)
- SQL Server
- GitHub


##  Como Executar o Projeto

###  Pré-requisitos
- .NET 8 SDK
- SQL Server (local ou na nuvem)
- Visual Studio ou VS Code

###  Passos para testar a aplicação

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
```

2. Acesse o diretório do projeto:
```bash
cd FCG
```

3. Configurar o `appsettings.json` com sua string de conexão:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=FCGDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. Aplicar migrations:
```bash
dotnet ef database update
```

5. Executar o projeto:
```bash
dotnet run
```

6. Acesse o Swagger para testar os endpoints:
```
https://localhost:{porta}/swagger
```


