using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PUC.Desafio.Logistica.Domain.ExtensionMethod
{
	public static class ArquivoExtension
	{
		public static string NomeDoArquivoDeSaidaFuncATxt = "saida_func_a.txt";
		public static string NomeDoArquivoDeSaidaFuncBTxt = "saida_func_b.txt";
		public static string CaminhoLocal = $"{AppDomain.CurrentDomain.BaseDirectory}/Arquivos";
		public static string CaminhoArquivoDeSaidaA = Path.Combine(CaminhoLocal, NomeDoArquivoDeSaidaFuncATxt);
		public static string CaminhoArquivoDeSaidaB = Path.Combine(CaminhoLocal, NomeDoArquivoDeSaidaFuncBTxt);

		public static void GerarArquivoSaidaA(this IEnumerable<string> dadosDeSaidaDto)
			=> File.WriteAllLines(CaminhoArquivoDeSaidaA, dadosDeSaidaDto.ToArray());
		public static void GerarArquivoSaidaB(this IEnumerable<string> dadosDeSaidaDto)
			=> File.WriteAllLines(CaminhoArquivoDeSaidaB, dadosDeSaidaDto.ToArray());

		public static string[] ObterArquivoEntrada(string nomeArquivo)
			=> File.ReadAllLines(Path.Combine(CaminhoLocal, nomeArquivo));

		public static string ObterCaminhoCompletoArquivoSaidaA => CaminhoArquivoDeSaidaA;
		public static string ObterCaminhoCompletoArquivoSaidaB => CaminhoArquivoDeSaidaB;
	}
}