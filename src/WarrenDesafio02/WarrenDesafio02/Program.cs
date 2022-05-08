/**
 * 
 * Algoritmo que determina se a classe vai ser cancelada ou não ("Aula cancelada” ou “Aula normal”).
 * 
 * @author Jessé Amaro da Costa (jesse.amaro7@gmail.com)
 */
namespace WarrenDesafio02
{
    public class Program
    {
        public static void Main()
        {
            int limiteMinimo;
            int minutos;
            int quantidadeHorasNormais = 0;
            List<int> tempoChegada = new List<int>();

            while (true)
            {
                Console.WriteLine("> INFORME O LIMITE MÍNIMO DE ALUNOS QUE DEVEM CHEGAR NO HORÁRIO: ");
                
                // Tenta converter o valor informado para um Int e informa uma mensagem caso seja um valor inválido. 
                bool success = int.TryParse(Console.ReadLine(), out limiteMinimo);

                if (!success)
                {
                    Console.WriteLine(" ----------------------------- ");
                    Console.WriteLine(" O VALOR INFORMADO É INVALIDO! ");
                    Console.WriteLine(" ----------------------------- ");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
                Console.WriteLine();
            }

            while (true)
            {
                Console.WriteLine("> INFORME QUANTOS MINUTOS O ALUNO CHEGOU ATRASADO OU ADIANTADO  \r\n  " +
                                  "OU DIGITE F PARA FINALIZAR E VERIFICAR O STATUS DA AULA. ");
                string? dados = Console.ReadLine();

                // Interrompe o loop caso seja digitado F no console.
                if (string.Compare(dados, "F", true) == 0)
                {
                    break;
                }
                else
                {
                    // Tenta converter o valor informado para um Int e informa uma mensagem caso seja um valor inválido. 
                    bool success = int.TryParse(dados, out minutos);

                    if (!success)
                    {
                        Console.WriteLine(" ----------------------------- ");
                        Console.WriteLine(" O VALOR INFORMADO É INVALIDO! ");
                        Console.WriteLine(" ----------------------------- ");
                        Console.WriteLine();
                    }
                    else
                    {
                        // Adiciona o minuto informado na lista tempoChegada.
                        tempoChegada.Add(minutos);

                        // Verifica se o minuto corresponde a hora normal ou atraso. 
                        if (minutos <= 0)
                        {
                            quantidadeHorasNormais++;
                        }

                        Console.WriteLine();
                    }
                }
            }

            // Verifica se vai haver aula ou não com base nos dados informados. 
            if (quantidadeHorasNormais >= limiteMinimo)
            {
                Console.WriteLine(" AULA NORMAL! ");
            }
            else
            {
                Console.WriteLine(" AULA CANCELADA! ");
            }
        }
    }
}