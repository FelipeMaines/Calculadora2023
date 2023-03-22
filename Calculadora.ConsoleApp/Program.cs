namespace Calculadora.ConsoleApp
{
    internal class Program
    {

        static decimal[] resultadosAntigos = new decimal[100];
        static int quantidadeDeResultados = 0;

        static void mensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
        static string MostrarMenu()
        {
            Console.WriteLine("Qual a operacao? (1) Soma / (2) Subtracao / (3) Divisao / (4) Multi: / (5) Ver resultados Antigos! / (6) Para Sair ");
            string operacao = Console.ReadLine();

            return operacao;

        }

        static bool operacaoInvalida(string opcao)
        {
            bool opcaoInvalida =
                opcao != "1" &&
                opcao != "2" &&
                opcao != "3" &&
                opcao != "4" &&
                opcao != "5" &&
                opcao != "6";

            return opcaoInvalida;
        }

        static decimal pegarValores(string palavras)
        {
            Console.WriteLine(palavras);
            decimal valor = decimal.Parse(Console.ReadLine());

            return valor;
        }

        static decimal soma (decimal resultado, decimal valor1, decimal valor2, ref int quantidadeDeResultados)
        {
            resultado = valor1 + valor2;
            quantidadeDeResultados++;
            resultadosAntigos[quantidadeDeResultados - 1] = resultado;

            return resultado;
        }

        static decimal subtracao (decimal valor1, decimal valor2, decimal resultado, ref int quantidadeDeResultados)
        {
            resultado = valor1 - valor2;
            quantidadeDeResultados++;
            resultadosAntigos[quantidadeDeResultados - 1] = resultado;

            return resultado;
        }

        static decimal divisao(decimal valor1, ref decimal valor2, decimal resultado, ref int quantidadeDeResultados)

        {
            if (valor2 != 0)
            {
                resultado = valor1 / valor2;
                quantidadeDeResultados++;
                resultadosAntigos[quantidadeDeResultados - 1] = resultado;
                return resultado;
            }
            else {

                do
                {
                    mensagemErro("Segundo valor invalido!");
                    Console.WriteLine("Digite outro valor: ");
                    valor2 = decimal.Parse(Console.ReadLine());
                } while (valor2 == 0);

                resultado = valor1 / valor2;
                quantidadeDeResultados++;
                return resultado;
            }
        }

        static decimal multiplicacao(decimal valor1, decimal valor2, decimal resultado, ref int quantidadeDeResultado)
        {
            resultado = valor1 * valor2;
            quantidadeDeResultado++;
            resultadosAntigos[quantidadeDeResultados - 1] = resultado;
            return resultado;
        }

        static void mostrarResultadosAntigos()
        {
            Console.WriteLine("Resultados antigos:");
            if (quantidadeDeResultados != null) {

                for (int i = 0; i < quantidadeDeResultados; i++)
                {

                    Console.WriteLine(resultadosAntigos[i]);
                }

            }
            else
            {
                mensagemErro("Nenhum resultado encontrado! ");
            }
            
        }

        static void mostrarResultado (decimal resultado)
        {
            Console.WriteLine($"O resultado eh {Math.Round(resultado, 2)}");
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Calculadora!! ");

            decimal resultado = 0;
           
            
            string palavra;
            decimal valor1 = 0; 
            decimal valor2 = 0;
            bool continuar = true;

            //Cancelar a operacao caso Escreva "Parar"
            while (continuar) 
            {
                Console.Clear();

               string opcao = MostrarMenu();
               int operacao = int.Parse(opcao);

                if (operacaoInvalida(opcao))
                {
                    mensagemErro("Numero Invalido!");
                    break;
                }


                if (operacao == 6)
                    break;
                

                if (operacao != 5)
                {
                    valor1 = pegarValores("Qual o primeiro valor: ");
                    valor2 = pegarValores("Qual o segundo valor: ");
                }



                //De acordo com a operacao desejada fez a execulcao
                switch (operacao)
                {
                    case 1:
                        resultado = soma(resultado, valor1, valor2, ref quantidadeDeResultados);
                        mostrarResultado(resultado);
                        break;

                    case 2:
                        resultado = subtracao(resultado, valor1, valor2, ref quantidadeDeResultados);
                        mostrarResultado(resultado);
                        break;

                    case 3:
                        //divisao por 0 da infinito (Erro)
                        resultado = divisao(valor1, ref valor2, resultado, ref quantidadeDeResultados);
                        mostrarResultado(resultado);
                        break;

                    case 4:
                        resultado = multiplicacao(valor1, valor2, resultado, ref quantidadeDeResultados);
                        mostrarResultado(resultado);
                        break;

                    case 5:
                        mostrarResultadosAntigos();
                        break;

                    default:
                        mensagemErro("ERRO");
                        break;
                }

            }

        }
    }
}

