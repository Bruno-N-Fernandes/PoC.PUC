using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	public class Professor : PessoaWrapper
	{
		public override TipoPessoa TipoPessoa => TipoPessoa.Professor;

		public Professor() : base() { }

		public Professor(Pessoa pessoa) : base(pessoa) { }

		public void Lecionar(Disciplina disciplina)
		{
			if (Adicionar(disciplina))
				disciplina.DefinirTitular(this);
		}
	}
}