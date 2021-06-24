# Teste de Automação para QA - CI&T

### Integrantes 🧑🏽‍💻

• Luiz Gustavo Marques - 31926881

• Gabriel Cardinali - 3201376015

• Jorge Luiz Fernandes - 31928525

• Diogo Souza - 319212051

• Daniel Fernandes - 319213675


## Instruções gerais 🛠️

Iremos utilizar o site https://opentdb.com/ para realizar nosso teste, onde faremos alguns cenários utilizando a linguagem Gherkin.

À princípio, daremos um modelo para que você apenas crie os passos da automação. Depois, será necessário criar um teste baseado numa descrição de cenário. Por fim, você terá que criar um cenário que ache adequado para a situação. As descrições detalhadas dos passos estarão mais abaixo.

O teste pode ser feito em qualquer linguagem de programação e com qualquer framework de teste de interface. Fica a seu critério escolher o que se adequa mais ao seu perfil e/ou ao seu conhecimento.

A entrega desse teste deve ser feita através do seu repositório Git pessoal (GitHub, Bitbucket, etc).

Qualquer dúvida que tenha, basta entrar em contato conosco que teremos o maior prazer em te ajudar!



## Primeira parte
Temos o seguinte cenário, escrito em Gherkin, que devemos automatizar:

Funcionalidade: Busca no Banco de Questões

Cenário: Busca por questão inexistente

Dado que navego para a página de busca do banco de questões

E digito 'Science: Computers' no campo de busca

Quando clico no botão de buscar

Então visualizo uma mensagem de erro com o texto 'No questions found.


Você irá agora pegar esse cenário e realizar a automação dele no site passado anteriormente.


## Segunda parte
Agora, estamos com a seguinte informação de um novo cenário que temos que testar para o usuário final:

>Precisamos fazer uma busca na categoria por Science: Computers e verificar se a listagem de questões está com 25 itens e se o controle de paginação irá aparecer.

Com essa informação em mãos, vamos para a codificação desse cenário de teste. Leve em consideração o que foi feito previamente e tente escrever o cenário em Gherkin antes de começar qualquer código.


## Terceira parte
Por fim, você terá que criar um cenário novo que não foi descrito anteriormente. A ideia aqui é realmente ver como você faria um cenário do zero, criando o Gherkin e depois fazendo a automação dele. Abuse e use do que foi feito anteriormente para te ajudar!

## License 📄
[MIT](https://choosealicense.com/licenses/mit/)
