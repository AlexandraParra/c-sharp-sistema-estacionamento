namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            string? resultado;
            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = (Console.ReadLine() ?? "").ToUpper().Replace("-", "").Trim();
                resultado = ValidarPlaca(placa);

                if (resultado != "Placa válida")
                {
                    Console.WriteLine("Pressione uma tecla para tentar novamente...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    veiculos.Add(placa);
                }
            } while (resultado != "Placa válida");
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        
        /// <summary>
        /// Valida uma placa de veículo no padrão Mercosul.
        /// </summary>
        /// <param name="placa">Representa a placa do veículo no formato ABC1D23</param>
        /// <returns>
        /// Mensagem indicando o resultado da validação:
        /// - "Placa válida", se estiver no formato correto;
        /// - Mensagens de erro específicas caso a placa esteja nula, com tamanho incorreto ou fora do padrão esperado.
        /// </returns>
        public string ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return "A placa não pode ser nula ou vazia.";

            if (placa.Length != 7)
                return "A placa deve conter exatamente 7 caracteres.";


            int[] letras = new int[] { 0, 1, 2, 4 };
            int[] digitos = new int[] { 3, 5, 6 };
            if (!letras.All(i => char.IsLetter(placa[i])) ||
            !digitos.All(i => char.IsDigit(placa[i]))
            )
                return "Formato inválido. Confira o formato da placa: ABC1D23";
            return "Placa válida";
        }
    }
}
