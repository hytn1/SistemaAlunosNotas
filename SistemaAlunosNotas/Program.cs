using System;

namespace SistemaAlunosNotas
{
    // Classe que representa um aluno
    class Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
    }

    class Program
    {
        // Array de objetos Aluno
        static Aluno[] alunos = new Aluno[3];

        // Array multidimensional para armazenar as notas
        // Linha = aluno
        // Coluna = disciplina
        static double[,] notas = new double[3, 3];

        // Indica se as notas já foram lançadas para cada aluno
        static bool[] notasLancadas = new bool[3];

        // Array com os nomes das disciplinas
        static string[] disciplinas =
        {
            "Lógica de Programação",
            "Banco de Dados",
            "Programação em C#"
        };

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                ExibirMenu();

                Console.Write("Escolha uma opção: ");
                int.TryParse(Console.ReadLine(), out opcao);

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        CadastrarAluno();
                        break;

                    case 2:
                        LancarNotas();
                        break;

                    case 3:
                        ConsultarResultado();
                        break;

                    case 0:
                        Console.WriteLine("Sistema encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (opcao != 0);
        }

        // Método sem parâmetros e sem retorno
        static void ExibirMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   SISTEMA DE ALUNOS E NOTAS - C#");
            Console.WriteLine("========================================");
            Console.WriteLine("1 - Cadastrar aluno");
            Console.WriteLine("2 - Lançar notas");
            Console.WriteLine("3 - Consultar resultado");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("========================================");
        }

        static void CadastrarAluno()
        {
            Console.WriteLine("===== CADASTRO DE ALUNO =====");
            Console.WriteLine();

            // Procurar posição disponível
            int posicao = -1;

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null || !alunos[i].Ativo)
                {
                    posicao = i;
                    break;
                }
            }

            if (posicao == -1)
            {
                Console.WriteLine("Limite de estudantes foi atingido.");
                return;
            }

            // Variável local
            string nome;

            do
            {
                Console.Write("Nome do estudante: ");
                nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("O nome não pode ficar vazio.");
                }

            } while (string.IsNullOrWhiteSpace(nome));

            // Variável local
            int idade;

            do
            {
                Console.Write("Idade: ");

                if (!int.TryParse(Console.ReadLine(), out idade) || idade <= 0)
                {
                    Console.WriteLine("Digite uma idade válida e maior que zero.");
                    idade = 0;
                }

            } while (idade <= 0);

            Console.WriteLine();

            // Verificação de maioridade
            if (idade >= 18)
            {
                Console.WriteLine("O estudante é MAIOR de idade.");
            }
            else
            {
                Console.WriteLine("O estudante é MENOR de idade.");
            }

            Console.WriteLine();
            Console.WriteLine("S - Confirmar");
            Console.WriteLine("N - Cancelar");
            Console.Write("Deseja confirmar o cadastro? ");

            char confirmacao;

            do
            {
                char.TryParse(Console.ReadLine().ToUpper(), out confirmacao);

                if (confirmacao != 'S' && confirmacao != 'N')
                {
                    Console.Write("Digite apenas S ou N: ");
                }

            } while (confirmacao != 'S' && confirmacao != 'N');

            if (confirmacao == 'S')
            {
                alunos[posicao] = new Aluno();

                alunos[posicao].Nome = nome;
                alunos[posicao].Idade = idade;
                alunos[posicao].Ativo = true;

                notasLancadas[posicao] = false;

                Console.WriteLine();
                Console.WriteLine("Aluno cadastrado com sucesso!");
                Console.WriteLine("Código do estudante: " + (posicao + 1));
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Cadastro cancelado.");
            }
        }

        static void LancarNotas()
        {
            Console.WriteLine("===== LANÇAMENTO DE NOTAS =====");
            Console.WriteLine();

            if (!ExistemAlunos())
            {
                Console.WriteLine("Não existem estudantes cadastrados.");
                return;
            }

            ExibirAlunos();

            Console.WriteLine();
            Console.Write("Digite o código do estudante: ");

            int codigo;

            if (!int.TryParse(Console.ReadLine(), out codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            // Método que recebe parâmetro e retorna valor
            int indice = BuscarAluno(codigo);

            if (indice == -1)
            {
                Console.WriteLine("Estudante não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Aluno selecionado: " + alunos[indice].Nome);
            Console.WriteLine();

            for (int i = 0; i < disciplinas.Length; i++)
            {
                double nota;

                do
                {
                    Console.Write(
                        "Digite a nota de " +
                        disciplinas[i] +
                        " (0 a 10): "
                    );

                    if (!double.TryParse(Console.ReadLine(), out nota))
                    {
                        Console.WriteLine("Digite um número válido.");
                        nota = -1;
                    }
                    else if (nota < 0 || nota > 10)
                    {
                        Console.WriteLine("A nota deve estar entre 0 e 10.");
                    }

                } while (nota < 0 || nota > 10);

                notas[indice, i] = nota;
            }

            notasLancadas[indice] = true;

            Console.WriteLine();
            Console.WriteLine("Notas lançadas com sucesso!");
        }

        static void ConsultarResultado()
        {
            Console.WriteLine("===== CONSULTA DE RESULTADO =====");
            Console.WriteLine();

            if (!ExistemAlunos())
            {
                Console.WriteLine("Não existem estudantes cadastrados.");
                return;
            }

            ExibirAlunos();

            Console.WriteLine();
            Console.Write("Digite o código do estudante: ");

            int codigo;

            if (!int.TryParse(Console.ReadLine(), out codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            int indice = BuscarAluno(codigo);

            if (indice == -1)
            {
                Console.WriteLine("Estudante não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("           RESULTADO ACADÊMICO");
            Console.WriteLine("========================================");

            Console.WriteLine("Nome: " + alunos[indice].Nome);
            Console.WriteLine("Idade: " + alunos[indice].Idade);

            if (alunos[indice].Idade >= 18)
            {
                Console.WriteLine("Classificação: Maior de idade");
            }
            else
            {
                Console.WriteLine("Classificação: Menor de idade");
            }

            Console.WriteLine();

            // Verificar se as notas já foram lançadas
            if (!notasLancadas[indice])
            {
                Console.WriteLine("As notas deste estudante ainda não foram lançadas.");
                return;
            }

            double soma = 0;

            for (int i = 0; i < disciplinas.Length; i++)
            {
                Console.WriteLine(
                    disciplinas[i] +
                    ": " +
                    notas[indice, i].ToString("F1")
                );

                soma += notas[indice, i];
            }

            double media = soma / disciplinas.Length;

            Console.WriteLine();
            Console.WriteLine("Média: " + media.ToString("F1"));

            string situacao;

            if (media >= 7)
            {
                situacao = "APROVADO";
            }
            else if (media >= 5 && media < 7)
            {
                situacao = "RECUPERAÇÃO";
            }
            else
            {
                situacao = "REPROVADO";
            }

            Console.WriteLine("Situação: " + situacao);
            Console.WriteLine("========================================");
        }

        // Exibe somente os alunos ativos
        static void ExibirAlunos()
        {
            Console.WriteLine("Estudantes cadastrados:");

            foreach (Aluno aluno in alunos)
            {
                if (aluno != null && aluno.Ativo)
                {
                    int codigo = Array.IndexOf(alunos, aluno) + 1;

                    Console.WriteLine(
                        codigo + " - " + aluno.Nome
                    );
                }
            }
        }

        // Método com parâmetro e retorno
        static int BuscarAluno(int codigo)
        {
            if (codigo < 1 || codigo > alunos.Length)
            {
                return -1;
            }

            int indice = codigo - 1;

            if (alunos[indice] != null && alunos[indice].Ativo)
            {
                return indice;
            }

            return -1;
        }

        // Verifica se existe pelo menos um aluno cadastrado
        static bool ExistemAlunos()
        {
            foreach (Aluno aluno in alunos)
            {
                if (aluno != null && aluno.Ativo)
                {
                    return true;
                }
            }

            return false;
        }
    }
}