using System;

namespace PUC.Desafio.SecretariaEscolar.Core.Utilitarios
{
	public class Leitor
	{
		private readonly String[] _linhas;
		public Int32 Posicao { get; private set; }
		public Int32 Count => _linhas.Length;

		public Leitor(String conteudo)
		{
			Posicao = 0;
			_linhas = conteudo.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
		}

		public Int32 LerInteiro() => Int32.TryParse(LerString(), out var valor) ? valor : 0;

		public String LerString()
		{
			try
			{
				return ObterLinha();
			}
			finally
			{
				PularLinha();
			}
		}

		private void PularLinha()
		{
			Posicao++;
		}

		private String ObterLinha()
		{
			return _linhas[Posicao];
		}
	}
}