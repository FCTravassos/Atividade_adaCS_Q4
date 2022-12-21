namespace Atividade4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continua;  // Verifica se o usuário quer continuar realizando o cálculo do POV

            do
            {
                realizaOperacao();  // Pede para usuário digitar o total negociado e a porcentagem desejada
                Console.WriteLine("Pressione S para sair ou pressione qualquer outra tecla para continuar.");
                continua = Console.ReadLine() == "S";   // Termina o programa caso o usuário digite "S"
            } while (!continua);
            
        }

        //  Cálculo do POV
        static int funcaoRetornaQuantitadePOV(decimal porcentagem, int totalNegociado)
            => (int)((totalNegociado * porcentagem) / (1m - porcentagem));

        static void realizaOperacao()
        {
            int resultado;
            int totalNegociado;
            decimal porcentagem;
            bool valorValido;

            do
            {
                Console.Write("Digite a porcentagem (entre 0 e 1): ");
                valorValido = decimal.TryParse(Console.ReadLine(), out porcentagem);
                valorValido &= porcentagem < 1 && porcentagem >= 0; // Verificando se o valor da porcentagem informado é válido
                if (!valorValido)
                    Console.WriteLine("Valor invalido.");
            } while (!valorValido);

            do
            {
                Console.Write("Digite o total negociado: ");
                valorValido = int.TryParse(Console.ReadLine(), out totalNegociado);
                valorValido &= totalNegociado >= 0; // Verificando se o total negociado é maior que 0
                if (!valorValido)
                    Console.WriteLine("Valor invalido.");
            } while (!valorValido);

            resultado = funcaoRetornaQuantitadePOV(porcentagem, totalNegociado);

            Console.WriteLine($"Resultado: {resultado}");
        }
    }
}