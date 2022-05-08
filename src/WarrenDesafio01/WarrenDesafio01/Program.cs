/**
 * 
 * Algoritmo que exibe todos os números n onde a soma de n + reverso(n) resulta em números ímpares abaixo de 1 milhão.
 * 
 * @author Jessé Amaro da Costa (jesse.amaro7@gmail.com)
 */
namespace WarrenDesafio01
{
    public class Program
    {
        // Recebe um número como string e inverte as posições.
        static string InvertString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        // Verifica se o número é par ou não. 
        public static bool IsDigitsOdd(int[] digits)
        {
            foreach (var item in digits)
            {
                if (item % 2 == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Obtem todos os dígitos de um número.
        // Referência: https://stackoverflow.com/questions/829174/is-there-an-easy-way-to-turn-an-int-into-an-array-of-ints-of-each-digit
        public static IEnumerable<int> GetNumberOfDigits(int number)
        {
            do
            {
                yield return number % 10;
                number /= 10;
            } while (number > 0);
        }
        public static void Main()
        {
            // Cria um lista para salvar os números ímpares.
            List<int> listaImpares = new List<int>();

            for (int i = 0; i < 1_000_000; i++)
            {
                if (i % 10 == 0)
                {
                    continue;
                }

                // Converte i para String.
                string num = i.ToString();

                // Inverte o valor de i.
                string invertNum = InvertString(num);

                // Obtem o resultado da inversão e soma com ele mesmo (i).
                int resultado = Convert.ToInt32(invertNum) + i;

                // Obtem o resultado e verifica todos os dígitos desse número.
                IEnumerable<int> digits = GetNumberOfDigits(resultado);

                bool isDigitsOdd = IsDigitsOdd(digits.ToArray());

                // Verifica se o resultado é impar ou par. 
                if (isDigitsOdd)
                {
                    // Se o resultado for um número impar, guarda na listaImpares.
                    listaImpares.Add(resultado);
                }
            }

            // Realiza a ordenação.
            foreach (var item in listaImpares.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Total: " + listaImpares.Count);
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
