using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Classe que representa os veículos
        class Veiculo
        {
            public string Placa { get; set; }
            public DateTime HoraEntrada { get; set; }
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(new Veiculo { Placa = placa, HoraEntrada = DateTime.Now });
            Console.WriteLine("Veículo adicionado.");
        }

        public void CalcularValorAPagar()
        {
            Console.Write("Digite a placa do veículo: ");
            string placa = Console.ReadLine();

            // Encontrar o veículo pela placa
            Veiculo veiculo = veiculos.Find(v => v.Placa.ToUpper() == placa.ToUpper());

            if (veiculo != null)
            {
                TimeSpan tempoEstacionado = DateTime.Now - veiculo.HoraEntrada;
                double horas = Math.Ceiling(tempoEstacionado.TotalHours); // Arredondar para cima
                decimal valor = precoInicial + (precoPorHora * (decimal)(horas));

                Console.WriteLine($"Valor a pagar pelo veículo de placa {placa}: R$ {valor:F2}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            Veiculo veiculo = veiculos.Find(v => v.Placa.ToUpper() == placa.ToUpper());

            if (veiculo != null)
            {
                TimeSpan tempoEstacionado = DateTime.Now - veiculo.HoraEntrada;
                double horas = Math.Ceiling(tempoEstacionado.TotalHours); // Arredondar para cima
                decimal valorTotal = precoInicial + (precoPorHora * (decimal)(horas));

                veiculos.Remove(veiculo);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa} | Hora de entrada: {veiculo.HoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
