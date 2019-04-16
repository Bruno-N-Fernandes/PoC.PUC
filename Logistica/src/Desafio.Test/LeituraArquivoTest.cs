using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.Logistica.Domain.Entity;
using PUC.Desafio.Logistica.Domain.ExtensionMethod;
using PUC.Desafio.Logistica.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Test
{
	[TestClass]
	public class LeituraArquivoTest
	{
		[TestMethod]
		public void DeveObterArquivoDeEntradaA()
		{
			var entrada_func_a = ArquivoExtension.ObterArquivoEntrada("entrada_func_a.txt");

			Assert.IsTrue(entrada_func_a.Count() > 0);
		}

		[TestMethod]
		public void DeveObterArquivoDeEntradaB()
		{
			var entrada_func_b = ArquivoExtension.ObterArquivoEntrada("entrada_func_b.txt");

			Assert.IsTrue(entrada_func_b.Count() > 0);
		}

		[TestMethod]
		public void DeveObterOsVeiculos()
		{
			var entrada_func_a = ArquivoExtension.ObterArquivoEntrada("entrada_func_a.txt");
			var leitorDeLinhasA = new LeitorDeLinhas(entrada_func_a);
			var veiculos = new List<Veiculo>();
			int qtdVeiculos = leitorDeLinhasA.LerLinha();
			for (int i = 0; i < qtdVeiculos; i++)
				veiculos.Add(new Veiculo(leitorDeLinhasA));

			Assert.IsTrue(veiculos.Any());
			Assert.IsTrue(veiculos.Count() == 3);
		}
	}
}