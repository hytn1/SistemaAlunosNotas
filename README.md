# Sistema de Alunos e Notas

Sistema desenvolvido em **C# Console** para gerenciamento simplificado de alunos e notas. O projeto foi desenvolvido como atividade prática para aplicar conceitos fundamentais da linguagem C#.

## Sobre o projeto

O sistema permite cadastrar até **3 alunos**, lançar notas em três disciplinas e consultar o desempenho acadêmico de cada estudante.

### Funcionalidades

* Cadastro de alunos com nome e idade;
* Geração automática do código do aluno;
* Validação dos dados informados;
* Lançamento de notas de 0 a 10;
* Consulta das notas e média;
* Classificação do aluno em **Aprovado, Recuperação ou Reprovado**.

### Disciplinas

* Lógica de Programação
* Banco de Dados
* Programação em C#

## Conceitos utilizados

* Classes e objetos;
* Propriedades;
* Arrays e matrizes;
* Métodos com e sem parâmetros;
* Métodos com retorno;
* Variáveis locais e compartilhadas;
* Estruturas condicionais (`if`, `else`, `switch`);
* Estruturas de repetição (`for`, `while`, `do while`, `foreach`);
* Operadores aritméticos, relacionais e lógicos;
* Validação de dados e entrada pelo console.

### Estruturas de armazenamento

```csharp
string[]      // Disciplinas
Aluno[]       // Alunos cadastrados
double[,]     // Notas por aluno e disciplina
bool[]        // Controle de notas lançadas
```

## Critérios de avaliação

| Média         | Situação    |
| ------------- | ----------- |
| ≥ 7,0         | Aprovado    |
| ≥ 5,0 e < 7,0 | Recuperação |
| < 5,0         | Reprovado   |

## Tecnologias

* C#
* .NET
* Visual Studio
* Console Application

## Autor

**Haytan Sabeh**
Ciência da Computação | Técnico em Desenvolvimento de Sistemas
