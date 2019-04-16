using System;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	[Flags]
	public enum TipoPessoa : uint
	{
		Aluno = 1,
		Professor = 2
	}
}