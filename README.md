# OficinaPitStop
## Descrição
Consiste em uma API capaz de realizar crud em GraphQL de duas entidades. 
Pode ser util como base de diversos projetos de um software para uma farmácia a uma oficina, que foi o objetivo inicial.

## Objetivo
API criada para base de estudos de projetos em GraphQL. 
O objetivo é entender o que é necessário para realizar um crud em GraphQL através de querys e mutations.
A complexidade da API foi reduzida para que seja de fácil entendimento para quem deseja aprender sobre o uso de microsserviços.

Também tem como premissa enfatizar a eficiencia de testes. 
![CodeCoverage](https://github.com/LuizGPG/OficinaPitStop/blob/master/CodeCoverage.PNG)

Esses serviços devem ser testados através de <a href=https://docs.microsoft.com/pt-br/dotnet/core/testing>testes unitarios</a>, cada teste deve ser executado com o minimo de responsabilidade possível, 
caso um mesmo metodo tenha diversas situações, todos os possíveis caminhos devem ser testados separadamente.

A camada de repository geralmente é coberta através de <a href=https://docs.microsoft.com/pt-br/aspnet/core/test/integration-tests>testes de integração</a>. Mas também é possível faze-los isoladamente com testes unitários.

Nessa API os testes de integração foram feitos com acesso a base de dados que é utilizada no projeto.
Dessa forma garantimos que o mapeamento das tabelas e suas entidades estão sempre corretos, caso a estrutura da base seja alterada de alguma forma os testes de integração não vão obter sucesso.

<b>Action ![.NET Core](https://github.com/LuizGPG/OficinaPitStop/workflows/.NET%20Core/badge.svg?branch=master)</b>

Foi criada uma action para validar a cada commit se o codigo esta buildando e os testes estão passando.
Pode ser visto o na aba <a href=https://github.com/LuizGPG/OficinaPitStop/actions>actions</a>.

## Banco de dados - Instalação

O banco de dados utilizado é o <a href=https://www.mysql.com/downloads/>MySQL</a> e deve ser criado conforme scripts do diretorio de <a href=https://github.com/LuizGPG/OficinaPitStop/tree/master/OficinaPitStop.Repositories/Banco%20de%20dados> repositório</a>.

Conforme mencionado anteriormente os testes de integração são executados na base de dados. Estes foram criados para que utilize apenas a estrutura do banco, sendo assim, não é necessário a criação de registros para que os testes passem.
Também fiz de uma maneira que a integração seja feita de ponta a ponta com o crud, criando, atualizando, consultando e por fim removendo o registro, dessa forma não fica lixo na base.

## Utilizando a API 
Após a api rodando seja ela sendo executada através de containers ou no ambiente de desenvolvimento, é possível realizar os cruds de duas entidades criadas. 
Os exemplos sitados a baixo são executados através do playground disponível na biblioteca do <a href=https://https://graphql.org/> graphql</a>.
Nesta aplicação é possível acessar com o caminho: <b>http://localhost:5000/ui/playground</b>

### Criando - Produto
```graphql
mutation{
  create_produto(create:{
    descricao: "Descrição produto teste"
    preco: 17.99
    quantidade: 5
  })
}
```
### Listando - Produto
```graphql
{
  produtos {
    codigo
    descricao
    preco
    quantidade
  }
}
```
### Atualizando - Produto
```graphql
mutation {
  update_produto(
    update: {
      codigo: 1
      descricao: "Atualizando produto"
      quantidade: 10
      preco: 15.00
    }
  )
}
```

### Deletando - Produto
```graphql
mutation {
  delete_produto(delete: { codigo: 1 })
}
```

Essas mesmas ações também se aplicam para a entidade de Marca.

## Docker

Disponibilizei a imagem no docker hub e pode ser feito um pull com o comando:
```bash
docker pull luizidocker/oficinapitstop:latest
```
Ou fazendo clone do projeto e executando o <a href=https://github.com/LuizGPG/OficinaPitStop/blob/master/docker-compose.yml> compose </a>.
```bash
docker-compose up -d
```
Dessa forma o container da aplicação e do banco de dados já é criado corretamente.

Para criar a imagem da api precisei apenas executar o comando a baixo no diretorio onde esta o Dockerfile:
```bash
docker build -t oficinapitstop:1.0 .
```
Desta forma a imagem já foi criada corretamente. Não sendo necessário realizar essa ação se não houver alteração de código.
![imagemDocker](https://github.com/LuizGPG/OficinaPitStop/blob/master/imagemDocker.PNG)
