using PUC.Desafio.Logistica.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.Logistica.Domain.Entity
{
	public class Rota
	{
		internal Veiculo Veiculo { get; }
		private List<Trecho> Trechos { get; } = new List<Trecho>();
		public decimal ConsumoMedioTotal => Trechos.Sum(t => t.ConsumoMedioTotal);

		public Rota(Veiculo veiculo, LeitorDeLinhas leitorDeLinhas)
		{
			Veiculo = veiculo;
			var qtdTrechos = leitorDeLinhas.LerLinha();
			for (var i = 0; i < qtdTrechos; i++)
			{
				var trecho = new Trecho(this, leitorDeLinhas);
				Trechos.Add(trecho);
			}
			leitorDeLinhas.PularLinha();
		}
	}
}