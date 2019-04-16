namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	public class Aluno : PessoaWrapper
	{
		public override TipoPessoa TipoPessoa => TipoPessoa.Aluno;

		public Aluno() : base() { }

		public Aluno(Pessoa pessoa) : base(pessoa) { }

		public void Inscrever(Disciplina disciplina)
		{
			if (Adicionar(disciplina))
				disciplina.InscreverAluno(this);
		}
	}
}