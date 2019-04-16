using System;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Utilitarios
{
	public static class LinhaUtil
	{
		public static (Int32 Codigo, String Descricao) SplitFields(this String linha)
		{
			var array = linha.Split(' ');
			if (array.Length < 1)
				throw new ApplicationException("Arquivo com formato inválido");

			var codigo = Int32.TryParse(array[0], out var valor) ? valor : 0;
			var descricao = String.Join(" ", array.Skip(1));
			return (codigo, descricao);
		}
	}
}