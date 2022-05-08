/**
 * 
 * Algoritmo que determina a soma com o menor número de elementos.
 * 
 * @author Jessé Amaro da Costa (jesse.amaro7@gmail.com)
 */
namespace WarrenDesafio03
{
    public class Program
    {
        public static void Main()
        {
            List<List<int>> somas = new List<List<int>>();

            int limite = 0;
            List<int>? arr = null;

            // Solicita o valor do limite.
            Console.WriteLine("Insira o valor limite:");
            int.TryParse(Console.ReadLine(), out limite);

            // Solicita os valores para soma. 
            Console.WriteLine("Insira os valores para soma separados por vírgula. Exemplo: 1, 2, 3.");

            arr = Console.ReadLine()?.Split(',').Select(number => 
            {
                int temp;
                int.TryParse(number, out temp);
                return temp;
            }).ToList();

            Console.Clear();
            Console.WriteLine("Calculando somas...");
            Console.WriteLine();

            // Verifica se a lista esta vazia. 
            if (arr == null)
            {
                Console.WriteLine("Valores para soma são inválidos.");
                return;
            }

            // Percorre todo array e adiciona os valores para uma nova lista. 
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i; j < arr.Count; j++)
                {
                    List<int> temp = new List<int>();
                    temp.Add(arr[i]);
                    temp.Add(arr[j]);

                    // Soma os valores dentro da lista e guarda em resultado.
                    int resultado = temp.Sum();

                    // Enquanto o resultado for menor que o limite, adiciona ele mesmo na lista e refaz a soma. 
                    while (resultado < limite)
                    {
                        temp.Add(arr[j]);
                        resultado = temp.Sum();
                    }

                    somas.Add(temp);
                }
            }

            int menorSoma = int.MaxValue;
            int menorDiferenca = int.MaxValue;
            List<List<int>> numerosFiltrados = new List<List<int>>();

            // Faz um for dentro da lista de somas
            foreach (var item in somas)
            {

                //
                int diferenca = Math.Abs(limite - item.Sum());

                if (diferenca <= menorDiferenca)
                {
                    menorDiferenca = diferenca;
                }
                else
                {
                    continue;
                }

                // Verifica se o valor é <= a menor soma.
                if (item.Count() <= menorSoma)
                {
                    if (item.Count() < menorSoma)
                    {
                        numerosFiltrados.Clear();
                    }

                    menorSoma = item.Count();
                    numerosFiltrados.Add(item);
                }
            }

            // Verifica se a lista esta vazia. 
            if (somas.Count == 0)
            {
                Console.WriteLine("A Lista esta vazia");
                return;
            }

            Console.WriteLine($"Somas encontradas para o número {limite}:");

            // Exibe no console as somas encontradas baseado no numero informado como limite. 
            foreach (List<int> numerosDaSoma in numerosFiltrados)
            {
                Console.Write("(");

                foreach (int numeroDaSoma in numerosDaSoma)
                {
                    Console.Write(numeroDaSoma + "");
                }

                Console.WriteLine(")");
            }
        }
    }
}