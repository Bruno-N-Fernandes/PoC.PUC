using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Dominios;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Dominios
{
	[TestClass]
	public class TestandoPessoa
	{
		[TestMethod]
		public void QuandoInstanciaPessoaPassandoParametros_DevePreencherAsPropriedadesCorretamente()
		{
			var pessoa = new Pessoa(1234, "Jose da Silva");

			Assert.AreEqual(1234, pessoa.Matricula);
			Assert.AreEqual("Jose da Silva", pessoa.Nome);
		}

		[TestMethod]
		public void QuandoSolicitarAlterarNome_DeveRetornarNomeAlterado()
		{
			var pessoa1 = new Pessoa(1, "Pessoa 1");
			var nomePessoa = pessoa1.Nome;

			pessoa1.AlterarNome("Pessoa 1");

			Assert.AreEqual("Pessoa 1", nomePessoa);
			Assert.AreEqual("Pessoa 1", pessoa1.Nome);
		}

		[TestMethod]
		public void QuandoSolicitarPromoverPessoaAProfessor_DeveRetornarProfessorAssociadoAPessoa()
		{
			var pessoa1 = new Pessoa(1, "Pessoa 1");

			var professor = pessoa1.TransformarEm<Professor>();

			Assert.IsNotNull(professor);
			Assert.IsNotNull(professor.Nome);
			Assert.AreEqual(pessoa1.Nome, professor.Nome);
			Assert.AreEqual(pessoa1.Matricula, professor.Matricula);
		}

		[TestMethod]
		public void QuandoSolicitarPromoverPessoaAAluno_DeveRetornarAlunoAssociadoAPessoa()
		{
			var pessoa1 = new Pessoa(1, "Pessoa 1");

			var aluno = pessoa1.TransformarEm<Aluno>();

			Assert.IsNotNull(aluno);
			Assert.IsNotNull(aluno.Nome);
			Assert.AreEqual(pessoa1.Nome, aluno.Nome);
			Assert.AreEqual(pessoa1.Matricula, aluno.Matricula);
		}

		[TestMethod]
		public void QuandoSolicitarPromoverPessoaAAlunoEProfessor_DeveRetornarAlunoEProfessorAssociadosAPessoa()
		{
			var pessoa = new Pessoa(1, "Pessoa 1");
			var aluno = pessoa.TransformarEm<Aluno>();

			var professor = pessoa.TransformarEm<Professor>();

			Assert.IsNotNull(aluno);
			Assert.IsNotNull(aluno.Nome);
			Assert.AreEqual(pessoa.Nome, aluno.Nome);
			Assert.AreEqual(pessoa.Matricula, aluno.Matricula);

			Assert.IsNotNull(professor);
			Assert.IsNotNull(professor.Nome);
			Assert.AreEqual(pessoa.Nome, professor.Nome);
			Assert.AreEqual(pessoa.Matricula, professor.Matricula);
		}

		[TestMethod]
		public void QuandoPromoverPessoaParaAluno_OPapelDePessoaDeveRetornarOAluno()
		{
			var pessoa = new Pessoa(1, "Pessoa 1");

			var aluno = pessoa.TransformarEm<Aluno>();

			Assert.AreEqual(TipoPessoa.Aluno, pessoa.TipoPessoa);
		}
	}
}
