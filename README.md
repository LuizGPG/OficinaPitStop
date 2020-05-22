# OficinaPitStop
<b>Objetivo</b>
API criada para base de estudos de projetos em GraphQL. 
O objetivo é entender o que é necessário para realizar um crud em GraphQL através de querys e mutations.
A complexidade da API foi reduzida para que seja de fácil entendimento para quem deseja aprender sobre o uso de micros

Também tem como premissa enfatizar a eficiencia de testes unitarios. 
![CodeCoverage](https://github.com/LuizGPG/OficinaPitStop/blob/master/CodeCoverage.PNG)

Esses serviços devem ser testados através de <a href=https://docs.microsoft.com/pt-br/dotnet/core/testing>testes unitarios</a>, cada teste deve ser executado com a menor quantidade de responsabilidade possível, 
caso um mesmo metodo tenha diversas situações, todos os possíveis caminhos devem ser testados separadamente.

A camada de repository geralmente é coberta através de <a href=https://docs.microsoft.com/pt-br/aspnet/core/test/integration-tests>testes de integração</a>. Mas também é possível faze-los isoladamente com testes unitários.

Nessa API os testes de integração foram feitos com acesso a base de dados que é utilizada no projeto.
Dessa forma garantimos que o mapeamento das tabelas e suas entidades estão sempre corretos, caso a estrutura da base seja alterada de alguma forma os testes de integração não vão obter sucesso.

<b>Banco de dados - Instalação</b>
O banco de dados utilizado é o <a href=https://www.mysql.com/downloads/>MySQL</a> e deve ser criado conforme scripts do diretorio de <a href=https://github.com/LuizGPG/OficinaPitStop/tree/master/OficinaPitStop.Repositories/Banco%20de%20dados> repositório</a>.

Conforme mencionado anteriormente os testes de integração são executados na base de dados. Estes foram criados para que utilize apenas a estrutura do banco, sendo assim, não é necessário a criação de registros para que os testes passem.
Também fiz de uma maneira que a integração seja feita de ponta a ponta com o crud, criando, atualizando, consultando e por fim removendo o registro, dessa forma não fica lixo na base.

<b>Action ![.NET Core](https://github.com/LuizGPG/OficinaPitStop/workflows/.NET%20Core/badge.svg?branch=master)</b>

Foi criada uma action para validar a cada commit se o codigo esta buildando e os teste estão passando.
Pode ser visto o na aba <a href=https://github.com/LuizGPG/OficinaPitStop/actions>actions</a>.

<b>Docker</b>
A imagem da API foi colocada no DOCKER HUB e pode ser 
