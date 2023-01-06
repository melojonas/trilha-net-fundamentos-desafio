using System.Text.RegularExpressions;

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
            // Pede para o usuário digitar uma placa válida e adiciona na lista "veiculos"
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(placa)) { break; }

                bool validade = ValidarPlaca(placa);

                if (validade)
                {
                    veiculos.Add(placa);
                    break;
                }
                else {
                    Console.WriteLine("Placa inválida. Clique 'Enter' para sair.");
                }
            }

        }

        private static bool ValidarPlaca(string placa)
        {
            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4))
            {
                // Verifica o formato ABC1D23.
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica o formato ABC1234.
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(placa)) { break; }

                bool validade = ValidarPlaca(placa);

                if (!validade) 
                {
                    Console.WriteLine("Placa inválida. Clique 'Enter' para sair.");
                    continue;
                }

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {   
                    // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = int.Parse(Console.ReadLine());
                    decimal valorTotal = precoInicial + (horas * precoPorHora);

                    // Remover a placa digitada da lista de veículos
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    break;
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                int contador = 1;

                foreach (string placa in veiculos){
                    Console.WriteLine($"{contador} - {placa}");
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
