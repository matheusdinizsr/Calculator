# Calculator

Calculadora criada em Maui, inspirada na calculadora nativa do Windows 11.

O app possui as funcionalidades de uma calculadora básica. Certifiquei de que botões de operação (sinais de igual, subtração, multiplicação, etc.) tivessem a mesma funcionalidade de uma calculadora comum, **repetindo a operação quando o mesmo botão for apertado repetidamente**. Também possui **formatação automática** de seperador de milhar, bem como funcionalidade de vírgula.

## Stack Utilizada
- **Front-end**:  C#, Xaml, .Net, Maui.

## Demonstração

![Calculadora em funcionamento.](https://i.imgur.com/gGkBaQF.gif)

## Funcionalidades

- Soma
- Subtração
- Multiplicação
- Divisão
- Inversão de sinal (positivo, negativo)
- Vírgula
- Clear
- Clear Entry

## Aprendizados
Neste projeto aprendi e utilizei:

- **Switch Case**: Utilizado para verificação de estado. **Cada entrada do usuário representa um ponto de funcionamento** da calculadora, como primeiro número digitado, escolha da operação a ser realizada, segundo número digitado, realização da operação e reinicialização da calculadora.
- **Binding dos botões com métodos**: Aprendi a relacionar os botões aos métodos do código, fazendo com que cada clique em botão de número ou sinal operacional *(OnClick{tecla})* execute a função correspondente e exiba corretamente o texto na tela.
- **Formatação de texto no label**: Utilizando C#, precisei criar um código que exibisse os números inseridos pelo usuário na ordem correta, concatenando as entradas númericas, sinais de operação e separadores (decimal e milhar).
- **Formatação da UI**: Com o Xaml, aprendi a criar o *layout* da aplicação, deixando a sua aparência similar a do Windows, utilizando elementos básicos como *VerticalStackLayout*, *HorizontalStackLayout* e *Label*, e também a inicializar a aplicação no tamanho correto.
## Desafios
Codificar a realização das operações foi o mais trabalhoso e desafiador. Cada sinal de operação representa **um bloco de código diferente** que a aplicação deve executar, e a possbilidade do usuário **apertar duas ou mais vezes a mesma tecla** de operação cria **diferentes cenários** de execução da aplicação, criando o desafio de **encadear cada possibilidade** de combinação de teclas de operação inseridas pelo usuário a funcionalidade correspondente.  A utilização do *switch* foi a engrenagem que possibilitou deixar a aplicação executando corretamente em todos esses cenários.
