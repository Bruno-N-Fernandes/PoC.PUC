using PUC.Desafio.Logistica.Domain.Utils;
using System;

namespace PUC.Desafio.Logistica.Domain.Entity
{
	public class Veiculo
	{
		public int Codigo { get; }
		public decimal ConsumoMedio { get; }
		public Veiculo(LeitorDeLinhas leitorDeLinhas)
		{
			var informacao = leitorDeLinhas.LerArray();
			Codigo = Convert.ToInt32(informacao[0]);
			ConsumoMedio = Convert.ToDecimal(informacao[1]);
		}
	}
}