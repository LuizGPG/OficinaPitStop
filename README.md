# OficinaPitStop
<br><b>Objetivo</b></br>
API criada para base de estudos de projetos em GraphQL. 
O objetivo é entender o que é necessário para realizar um crud em GraphQL através de querys e mutations.
A complexidade da API foi reduzida para que seja de fácil entendimento para quem deseja aprender sobre o uso de micros

Também tem como premissa enfatizar a eficiencia de testes unitarios. 
![CodeCoverage](https://github.com/LuizGPG/OficinaPitStop/blob/master/CodeCoverage.PNG)

<br>Esses serviços devem ser testados através de <a href=https://www.devmedia.com.br/e-ai-como-voce-testa-seus-codigos/39478>testes unitarios</a>, cada teste deve ser executado com a menor quantidade de responsabilidade possível, 
caso um mesmo metodo tenha diversas situações, todos os possíveis caminhos devem ser testados separadamente.

A camada de repository geralmente é coberta através de <a href=https://www.devmedia.com.br/teste-de-integracao-na-pratica/31877>testes de integração</a>. Mas também é possível faze-los isoladamente com testes unitários.

Nessa API os testes de integração foram feitos com acesso a base de dados que é utilizada no projeto.
Dessa forma garantimos que o mapeamento das tabelas e suas entidades estão sempre corretos, caso a estrutura da base seja alterada de alguma forma os testes de integração não vão obter sucesso.

<br><b>Banco de dados - Instalação</b></br>
O banco de dados utilizado é o <a href=https://www.mysql.com/downloads/>MySQL</a> e deve ser criado conforme scripts do diretorio X.

Conforme mencionado anteriormente os testes de integração são executados na base de dados. Estes foram criados para que utilize apenas a estrutura do banco, sendo assim, não é necessário a criação de registros para que os testes passem.
Também fiz de uma maneira que a integração seja feita de ponta a ponta com o crud, criando, atualizando, consultando e por fim removendo o registro, dessa forma não fica lixo na base.

<br><b>Docker</b></br>
A imagem da API foi colocada no DOCKER HUB e pode ser 
