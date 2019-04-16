using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Dominios
{
	[TestClass]
	public class TestandoAluno
	{
		[TestMethod]
		public void QuandoInstanciarUmAlunoInformandoParametrosNoContrutor_AsPropriedadesDevemRefletirInformados()
		{
			var aluno = new Aluno(new Pessoa(1235, "Aluno 1235"));

			Assert.AreEqual(1235, aluno.Matricula);
			Assert.AreEqual("Aluno 1235", aluno.Nome);
		}

		[TestMethod]
		public void QuandoSolicitarAlterarNome_DeveRetornarNomeAlterado()
		{
			var aluno1 = new Aluno(new Pessoa(1, "Aluno 1"));
			var nomeAluno = aluno1.Nome;

			aluno1.AlterarNome("Aluno 2");

			Assert.AreEqual("Aluno 1", nomeAluno);
			Assert.AreEqual("Aluno 2", aluno1.Nome);
		}

		[TestMethod]
		public void QuandoInscreverAlunoAUmaDisciplina_DeveAumentarONumeroNaListaDeDisciplinasDoAluno()
		{
			var aluno = new Aluno(new Pessoa(1, "Pessoa 1"));
			var disciplina = new Disciplina(1, "Historia");

			aluno.Inscrever(disciplina);

			Assert.AreEqual(1, aluno.ObterDisciplinas().Count());
		}

		[TestMethod]
		public void QuandoInscreverUmAlunoParaUmDisciplina_EsseDisciplinaDeveSerAdicionadoNoAluno()
		{
			var aluno = new Aluno(new Pessoa(1, "Pessoa 1"));
			var disciplina1 = new Disciplina(1, "História");
			var disciplina2 = new Disciplina(2, "Matemática");
			var disciplina3 = new Disciplina(3, "Geografia");

			aluno.Inscrever(disciplina1);
			aluno.Inscrever(disciplina2);
			aluno.Inscrever(disciplina3);

			Assert.AreEqual("História", aluno.ObterDisciplinaPor(1).Nome);
			Assert.AreEqual("Geografia", aluno.ObterDisciplinaPor(3).Nome);
			Assert.AreEqual("Matemática", aluno.ObterDisciplinaPor(2).Nome);
		}

		[TestMethod]
		public void QuandoInscreverDuasDisciplinasIguaisParaOMesmoAluno_DeveInscreverAPrimeiraEIgnorarASegunda()
		{
			var aluno = new Aluno(new Pessoa(1, "Pessoa 1"));
			var disciplina = new Disciplina(1, "História");
			var disciplina1 = new Disciplina(1, "História");
			var disciplina2 = new Disciplina(2, "matemática");

			aluno.Inscrever(disciplina);
			aluno.Inscrever(disciplina1);
			aluno.Inscrever(disciplina2);

			Assert.AreEqual(2, aluno.ObterDisciplinas().Count());
		}
	}
}