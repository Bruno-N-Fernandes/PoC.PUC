using PUC.Desafio.Logistica.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.Logistica.Domain.Entity
{
	public class Diaria
	{
		internal List<Rota> Rotas { get; } = new List<Rota>();
		public decimal ConsumoMedioTotal => Rotas.Sum(r => r.ConsumoMedioTotal);

		public Diaria(IEnumerable<Veiculo> veiculos, LeitorDeLinhas leitorDeLinhas)
		{
			var qtdVeiculos = veiculos.Count();
			for (var i = 0; i < qtdVeiculos; i++)
			{
				var codigoVeiculo = leitorDeLinhas.LerLinha();
				var veiculo = veiculos.FirstOrDefault(c => c.Codigo == codigoVeiculo);

				var rota = new Rota(veiculo, leitorDeLinhas);
				Rotas.Add(rota);
			}
		}
	}
}