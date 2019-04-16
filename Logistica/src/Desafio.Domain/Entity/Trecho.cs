using PUC.Desafio.Logistica.Domain.Utils;
using System;

namespace PUC.Desafio.Logistica.Domain.Entity
{
	public class Trecho
	{
		private Rota Rota { get; }
		private string CidadeDestino { get; }
		private decimal Distancia { get; }
		public decimal ConsumoMedioTotal => Distancia / Rota.Veiculo.ConsumoMedio;

		public Trecho(Rota rota, LeitorDeLinhas leitorDeLinhas)
		{
			Rota = rota;
			var informacao = leitorDeLinhas.LerArray();
			CidadeDestino = informacao[0];
			Distancia = Convert.ToDecimal(informacao[1]);
		}
	}
}