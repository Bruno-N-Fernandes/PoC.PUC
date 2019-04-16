using PUC.Desafio.Logistica.Domain.ExtensionMethod;
using PUC.Desafio.Logistica.Domain.Service;
using PUC.Desafio.Logistica.Domain.Utils;

namespace PUC.Desafio.Logistica.ConsoleApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var relatorioService = new RelatorioService();

			var entrada_func_a = ArquivoExtension.ObterArquivoEntrada("entrada_func_a.txt");
			var leitorDeLinhasA = new LeitorDeLinhas(entrada_func_a);
			var relatorioA = relatorioService.Criar_RelatorioA(leitorDeLinhasA);

			var entrada_func_b = ArquivoExtension.ObterArquivoEntrada("entrada_func_b.txt");
			var leitorDeLinhasB = new LeitorDeLinhas(entrada_func_b);
			var relatorioB = relatorioService.Criar_RelatorioB(leitorDeLinhasB);
		}
	}
}