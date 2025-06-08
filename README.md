Um projeto de console simples em C# para gerenciar um inventário de produtos, permitindo operações básicas de cadastro, visualização, atualização e exclusão, com os dados sendo armazenados em um banco de dados MySQL.

Este projeto foi desenvolvido como parte de um estudo prático sobre desenvolvimento back-end, integração com banco de dados e conceitos de CRUD.

Status do Projeto: Concluído

 Funcionalidades Principais
 Cadastrar Produtos: Adiciona novos produtos ao banco de dados, com nome, preço e quantidade inicial.
 Listar Produtos: Exibe todos os produtos cadastrados em uma tabela organizada no console.
 Atualizar Estoque: Permite alterar a quantidade em estoque de um produto existente através de seu ID.
 Remover Produtos: Exclui um produto do banco de dados de forma permanente, utilizando seu ID.

Como Executar o Projeto:
1. Preparando o Banco de Dados
Execute o script SQL abaixo no seu MySQL Workbench para criar o banco de dados e a tabela necessários.
```
CREATE DATABASE IF NOT EXISTS ControleEstoqueDB;
USE ControleEstoqueDB;

CREATE TABLE IF NOT EXISTS Produtos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Preco DECIMAL(10, 2) NOT NULL,
    QuantidadeEmEstoque INT NOT NULL
);
````
2. Configurando e Rodando a Aplicação
Clone este repositório para sua máquina local:

````
Bash
git clone https://github.com/joaogabrielmacedo/sistema-estoque.git
````
Abra o arquivo da solução (SistemaEstoque.sln) com o Visual Studio 2022.

Dentro do arquivo Program.cs, encontre a linha da connectionString e atualize com a sua senha do MySQL:

```
C#

string connectionString = "Server=localhost;Database=ControleEstoqueDB;User=root;Password=SUA_SENHA_AQUI;";
```
Pressione F5 ou clique no botão de "Play" para compilar e executar o projeto.

O console será iniciado com o menu principal da aplicação.
