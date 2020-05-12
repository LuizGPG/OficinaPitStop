# OficinaPitStop
<br><b>Objetivo</b></br>
Projeto criado para base de estudos de projetos em GraphQL. 
O objetivo é entender o que é necessário para realizar um crud em GraphQL através de querys e mutations.

Também tem como premissa enfatizar a eficiencia de testes unitarios. 

[PRINT CODE COVERAGE]

A camada do service deve ter <b>100%</b> de cobertura, pois toda lógica/regra deve estar exclusivamente lá.
<br>Esses serviços devem ser testados através de <a href=https://www.devmedia.com.br/e-ai-como-voce-testa-seus-codigos/39478>testes unitarios</a>, cada teste deve ser executado com a menor quantidade de responsabilidade possível, 
caso um mesmo metodo tenha diversas situações, todos os possíveis caminhos devem ser testados separadamente.

A camada de repository geralmente é coberta através de <a href=https://www.devmedia.com.br/teste-de-integracao-na-pratica/31877>testes de integração</a>.
Penso que os cenários bascicos devem ser testados pois dessa forma garantimos que toda a comunicação da API, 
de ponta a ponta esta sendo validada. 

Nessa API os testes de integração foram feitos com uma base de dados em memoria. 
Dessa forma não é criada uma dependencia com uma base de dados. Não vejo 
