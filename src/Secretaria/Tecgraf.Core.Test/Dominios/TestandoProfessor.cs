using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using System;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Dominios
{
	[TestClass]
	public class TestandoProfessor
	{
		[TestMethod]
		public void QuandoInstanciarUmProfessorInformandoParametrosNoContrutor_AsPropriedadesDevemRefletirInformados()
		{
			var professor = new Professor(new Pessoa(1, "Professor 1"));

			Assert.AreEqual(1, professor.Matricula);
			Assert.AreEqual("Professor 1", professor.Nome);
		}


		[TestMethod]
		public void QuandoAlterarNomeDoProfessor_DeveRetornarONomeDoProfessorAlterado()
		{
			var professor1 = new Professor(new Pessoa(1, "Professor 1"));
			var nomeDoProfessorTitular = professor1.Nome;

			professor1.AlterarNome("Professor Bruno");
			var nomeDoProfessorTitularAlterado = professor1.Nome;

			Assert.AreEqual("Professor 1", nomeDoProfessorTitular);
			Assert.AreEqual("Professor Bruno", nomeDoProfessorTitularAlterado);
		}

		[TestMethod]
		public void QuandoSolicitarDisciplinasDeUmProfessor_DeveRetornarAListaDeDisciplinasQueProfessorLeciona()
		{
			var professor1 = new Professor(new Pessoa(1, "Professor 1"));

			SetupProfessor(professor1, 5);

			Assert.AreEqual(5, professor1.ObterDisciplinas().Count());
		}

		private static void SetupProfessor(Professor professor, Int32 qtdDisciplinas)
		{
			for (var i = 0; i < qtdDisciplinas; i++)
			{
				var disciplina1 = new Disciplina(i, $"Disciplina {i}");
				professor.Lecionar(disciplina1);

			}
		}
	}
}
