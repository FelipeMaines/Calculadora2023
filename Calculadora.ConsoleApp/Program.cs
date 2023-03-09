namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Calculadora!! ");

            decimal resultado = 0;
            decimal[] resultadosAntigos = new decimal[100];
            int quantidadeDeResultados = 0;
            string palavra;
            decimal valor1 = 0; 
            decimal valor2 = 0;

            //Cancelar a operacao caso Escreva "Parar"
            do
            {
                Console.Clear();

                Console.WriteLine("Qual a operacao? (1) Soma / (2) Subtracao / (3) Divisao / (4) Multi: / (5) Ver resultados Antigos! ");
                decimal operacao = decimal.Parse(Console.ReadLine());

                //Pede qual operacao q vai ser usada
                while (operacao != 1 && operacao != 2 && operacao != 3 && operacao != 4 && operacao != 5)
                {
                    Console.WriteLine("Comando invalido!");

                    Console.WriteLine("Qual a operacao? (1) Soma / (2) Subtracao / (3) Divisao / (4) Multi / (5) Ver resultados Antigos! ");
                    operacao = decimal.Parse(Console.ReadLine());
                }

                
                if (operacao != 5)
                {
                    Console.Write("Qual o primeiro valor: ");
                    valor1 = decimal.Parse(Console.ReadLine());

                    Console.Write("Qual o segundo valor: ");
                    valor2 = decimal.Parse(Console.ReadLine());
                }
                

                //De acordo com a operacao desejada fez a execulcao
                switch (operacao)
                {
                    case 1:
                        resultado = valor1 + valor2;
                        quantidadeDeResultados++;
                        resultadosAntigos[quantidadeDeResultados - 1] = resultado;
                        break;

                    case 2:
                        resultado = valor1 - valor2;
                        quantidadeDeResultados++;
                        resultadosAntigos[quantidadeDeResultados - 1] = resultado;
                        break;

                    case 3:
                        //divisao por 0 da infinito (Erro)
                        while (valor2 == 0)
                        {
                            Console.WriteLine("Segundo numero nao pode ser 0, Digite novamente outro numero: ");
                            Console.Write("Qual o segundo valor: ");
                            valor2 = decimal.Parse(Console.ReadLine());
                        }
                        resultado = valor1 / valor2;
                        quantidadeDeResultados++;
                        resultadosAntigos[quantidadeDeResultados - 1] = resultado;
                        break;

                    case 4:
                        resultado = valor1 * valor2;
                        quantidadeDeResultados++;
                        resultadosAntigos[quantidadeDeResultados - 1] = resultado;
                        break;

                    case 5:
                        Console.WriteLine("Resultados antigos:");
                        for (int i = 0; i < quantidadeDeResultados; i++)
                        {
                            Console.WriteLine(resultadosAntigos[i]);
                        }
                        break;


                    default:
                        Console.WriteLine("Erro");
                        quantidadeDeResultados++;
                        resultadosAntigos[quantidadeDeResultados - 1] = 0;
                        resultado = 0;
                        break;
                }

                resultado = Math.Round(resultado, 2);

                if (operacao != 5)
                {
                    Console.WriteLine($"O resultado eh {resultado}");
                }
                
                

                //Da a opcao de candelar ou continuar
                Console.WriteLine("Se desejar parar escreva *Parar* / *Enter* para continuar ");
                palavra = Console.ReadLine();
            } while  (palavra.ToUpper() != "PARAR") ; 

        }
    }
}

