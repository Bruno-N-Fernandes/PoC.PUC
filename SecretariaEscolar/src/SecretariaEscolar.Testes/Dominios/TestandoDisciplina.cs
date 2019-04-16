using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using System;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Dominios
{
	[TestClass]
	public class TestandoDisciplina
	{
		/// <summary>
		/// 2.1. Haverá uma linha com o código (inteiro) da disciplina, um espaço e o nome da disciplina
		/// </summary>
		[TestMethod]
		public void QuandoInstanciarUmaDisciplinaInformandoParametrosNoContrutor_AsPropriedadesDevemRefletirInformados()
		{
			var disciplina = new Disciplina(1, "Historia");

			Assert.AreEqual(1, disciplina.Codigo);
		}

		[TestMethod]
		public void QuandoSolicitarAlterNomeDaDisciplina_DeveRetornarNomeAlterado()
		{
			var disciplina1 = new Disciplina(1, "Disciplina 1");
			var nomeDaDisciplina = disciplina1.Nome;

			disciplina1.AlterarNome("Disciplina 2");
			var nomeDaDisciplinaAlterada = disciplina1.Nome;

			Assert.AreEqual("Disciplina 1", nomeDaDisciplina);
			Assert.AreEqual("Disciplina 2", nomeDaDisciplinaAlterada);
		}

		[TestMethod]
		public void QuandoSolicitarAlunosDeUmaDisciplina_DeveRetornarListaDeAlunos()
		{
			var disciplina1 = new Disciplina(1, "Disciplina 1");

			SetupDisciplinaAluno(disciplina1, 10);

			Assert.AreEqual(10, disciplina1.ObterAlunos().Count());

		}

		private static void SetupDisciplinaAluno(Disciplina disciplina1, Int32 qtdAlunos)
		{
			for (var i = 0; i < qtdAlunos; i++)
			{
				var aluno = new Aluno(new Pessoa(i, $"Aluno {i}"));
				disciplina1.InscreverAluno(aluno);
			}
		}

		[TestMethod]
		public void QuandoInscreverUmaDisciplinaParaUmAluno_EsseAlunoDeveSerAdicionadoNaDisciplina()
		{
			var disciplina = new Disciplina(1, "Matemática");
			var aluno = new Aluno(new Pessoa(1, "Pessoa 1"));
			disciplina.InscreverAluno(aluno);

			var aluno2 = new Aluno(new Pessoa(2, "Pessoa 2"));
			disciplina.InscreverAluno(aluno2);

			var aluno3 = new Aluno(new Pessoa(3, "Pessoa 3"));
			disciplina.InscreverAluno(aluno3);

			Assert.AreEqual("Pessoa 1", disciplina.ObterAlunoPor(1).Nome);
			Assert.AreEqual("Pessoa 2", disciplina.ObterAlunoPor(2).Nome);
			Assert.AreEqual("Pessoa 3", disciplina.ObterAlunoPor(3).Nome);
		}

		[TestMethod]
		public void QuandoSolicitarProfessorDaDisciplina_DeveRetornarONomedoProfessor()
		{
			var disciplina1 = new Disciplina(1, "Disciplina 1");

			var professorTitular = new Professor(new Pessoa(1, "Professor 1"));

			disciplina1.DefinirTitular(professorTitular);

			Assert.AreEqual("Professor 1", disciplina1.ObterProfessorTitular().Nome);

		}

		[TestMethod]
		public void QuandoInscreverDoisAlunosIguaisParaMesmaDisciplinas_DeveInscreverAPrimeiroEIgnorarASegundo()
		{
			var disciplina = new Disciplina(1, "Matemática");
			var aluno1 = new Aluno(new Pessoa(1, "Pessoa 1"));
			var aluno2 = new Aluno(new Pessoa(1, "Pessoa 1"));
			var aluno3 = new Aluno(new Pessoa(2, "Pessoa 2"));
			var aluno4 = new Aluno(new Pessoa(3, "Pessoa 3"));

			disciplina.InscreverAluno(aluno1);
			disciplina.InscreverAluno(aluno2);
			disciplina.InscreverAluno(aluno3);
			disciplina.InscreverAluno(aluno4);

			Assert.AreEqual(3, disciplina.ObterAlunos().Count());
		}

		[TestMethod]
		public void QuandoAlterarOProfessorNaDisciplina_DeveAtualizarProfessorNaDisciplina()
		{
			var disciplina = new Disciplina(1, "Disciplina 1");
			var professor1 = new Professor(new Pessoa(1, "Professor 1"));
			var professor2 = new Professor(new Pessoa(2, "Professor 2"));
			var professorTitular = disciplina.ObterProfessorTitular();

			disciplina.DefinirTitular(professor1);
			var nomeProfessorTitular1 = disciplina.ObterProfessorTitular().Nome;
			disciplina.DefinirTitular(professor2);
			var nomeProfessorTitular2 = disciplina.ObterProfessorTitular().Nome;

			Assert.IsNull(professorTitular);
			Assert.AreEqual("Professor 1", nomeProfessorTitular1);
			Assert.AreEqual("Professor 2", nomeProfessorTitular2);
		}
	}
}