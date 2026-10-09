# AppClientes

CRUD de cadastro de clientes via terminal, desenvolvido em C# (.NET 10), com persistência de dados em arquivo JSON.

## Funcionalidades

- Cadastrar cliente (nome, data de nascimento, desconto)
- Listar clientes cadastrados
- Editar cliente existente
- Excluir cliente
- Persistência automática em `clientes.txt`

## Tecnologias

- C#
- .NET 10
- System.Text.Json

## Estrutura do projeto

AppClientes/
├── Program.cs # Menu e fluxo principal
├── Cliente.cs # Modelo de dados do cliente
├── ClienteRepositorio.cs # Regras de CRUD e persistência
└── AppClientes.csproj

## Como executar

Pré-requisito: [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.

```bash
git clone https://github.com/GabrielNaokiUT/AppClientes_CSharp.git
cd AppClientes_CSharp
dotnet run
```

## Uso

Ao iniciar, o menu exibe as opções disponíveis:

Cadastro de Clientes
1 - Cadastrar Cliente
2 - Exibir Clientes
3 - Editar Cliente
4 - Excluir Cliente
5 - Sair


Os dados são salvos automaticamente a cada operação e também ao sair pela opção 5, no arquivo `clientes.txt` na pasta de execução.

## Autor
  
[**Gabriel Naoki Uto Turigoe**](https://github.com/GabrielNaokiUT)

