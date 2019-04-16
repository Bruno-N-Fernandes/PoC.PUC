using PUC.Desafio.Logistica.Domain.Entity;
using PUC.Desafio.Logistica.Domain.ExtensionMethod;
using PUC.Desafio.Logistica.Domain.Utils;
using System.Diagnostics;

namespace PUC.Desafio.Logistica.Domain.Service
{
	public class RelatorioService
	{
		public string Criar_RelatorioA(LeitorDeLinhas leitorDeLinhas)
		{
			var logistica = new LogisticaTransporte(leitorDeLinhas);
			logistica.Saida_func_A().GerarArquivoSaidaA();

			Process.Start(ArquivoExtension.ObterCaminhoCompletoArquivoSaidaA);

			return string.Join("\r\n", logistica.Saida_func_A());
		}

		public string Criar_RelatorioB(LeitorDeLinhas leitorDeLinhas)
		{
			var logistica = new LogisticaTransporte(leitorDeLinhas);
			logistica.ConfigurarLitrosDisponiveis(leitorDeLinhas);
			logistica.Saida_func_B().GerarArquivoSaidaB();

			Process.Start(ArquivoExtension.ObterCaminhoCompletoArquivoSaidaB);

			return string.Join("\r\n", logistica.Saida_func_B());
		}
	}
}