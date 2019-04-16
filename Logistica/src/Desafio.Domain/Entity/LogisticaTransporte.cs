using PUC.Desafio.Logistica.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PUC.Desafio.Logistica.Domain.Entity
{
	public class LogisticaTransporte
	{
		private static readonly IFormatProvider _cultureInfo = new CultureInfo("en-US");
		private decimal QuantidadeLitrosDisponiveis { get; set; } = 0;
		private List<Veiculo> Veiculos { get; } = new List<Veiculo>();
		private List<Diaria> Diarias { get; } = new List<Diaria>();
		private decimal ConsumoMedioTotal => Diarias.Sum(d => d.ConsumoMedioTotal);

		public LogisticaTransporte(LeitorDeLinhas leitorDeLinhas)
		{
			var qtdCarros = leitorDeLinhas.LerLinha();
			for (int i = 0; i < qtdCarros; i++)
			{
				var veiculo = new Veiculo(leitorDeLinhas);
				Veiculos.Add(veiculo);
			}
			leitorDeLinhas.PularLinha();

			var qtdDias = leitorDeLinhas.LerLinha();
			for (int i = 0; i < qtdDias; i++)
			{
				var diaria = new Diaria(Veiculos, leitorDeLinhas);
				Diarias.Add(diaria);
			}
		}

		public void ConfigurarLitrosDisponiveis(LeitorDeLinhas leitorDeLinhas)
		{
			QuantidadeLitrosDisponiveis = leitorDeLinhas.LerLinha();
		}

		public IEnumerable<string> Saida_func_A()
		{
			yield return Diarias.Count().ToString();

			foreach (var diaria in Diarias)
			{
				foreach (var rota in diaria.Rotas)
					yield return rota.Veiculo.Codigo + " " + rota.ConsumoMedioTotal.ToString("0.00", _cultureInfo);
				yield return "";
			}
		}

		public IEnumerable<string> Saida_func_B()
		{
			var qtdParcial = QuantidadeLitrosDisponiveis;
			yield return Math.Max(qtdParcial - ConsumoMedioTotal, 0).ToString("0.##", _cultureInfo);
			yield return "";

			foreach (var diaria in Diarias)
			{
				qtdParcial -= diaria.ConsumoMedioTotal;
				yield return Math.Max(qtdParcial, 0).ToString("0.##", _cultureInfo);
			}
			yield return "";
		}
	}
}