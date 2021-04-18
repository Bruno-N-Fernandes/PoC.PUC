using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using PUC.Desafio.SecretariaEscolar.Core.Fabricas;
using System;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Testes.Dominios
{
	[TestClass]
	public class TestandoSecretaria
	{
		[TestMethod]
		public void AoAlterarNomeDaDisciplina_DeveAtualizarNomeNaLista()
		{
			var secretaria = ObterSecretariaPreenchidaCom(4);
			var disciplinaEncontrada = secretaria.ObterDisciplinaPorCodigo(2);
			var nomeDisciplinaAntes = disciplinaEncontrada.Nome;

			disciplinaEncontrada.AlterarNome("Teste Blablabla");
			secretaria.Alterar(disciplinaEncontrada);

			var disciplinaAlterada = secretaria.ObterDisciplinaPorCodigo(2);
			Assert.AreEqual("Disciplina 2", nomeDisciplinaAntes);
			Assert.AreEqual("Teste Blablabla", disciplinaAlterada.Nome);
		}

		[TestMethod]
		public void AoCriarDisciplinaNovaNaSecretaria_ListaDeDisciplinasDeveSerAumentada()
		{
			var secretaria = ObterSecretariaPreenchidaCom(5);

			int quantidadeDisciplinas = secretaria.ObterDisciplinas().Count();

			Assert.AreEqual(5, quantidadeDisciplinas);
		}

		[TestMethod]
		public void QuandoSecretariaMatricularUmProfessor_DeveAdicionarOProfessorAListaDeProfessores()
		{
			var secretaria = new Core.Dominios.Secretaria();
			var professor1 = new Professor(new Pessoa(1, "Professor 1"));
			var professor2 = new Professor(new Pessoa(2, "Professor 2"));

			secretaria.Matricular(professor1);
			secretaria.Matricular(professor2);

			var professores = secretaria.ObterProfessores();
			Assert.IsTrue(professores.Any());
			Assert.AreEqual(2, professores.Count());
			Assert.AreEqual("Professor 1", secretaria.ObterProfessorPorMatricula(1).Nome);
			Assert.AreEqual(1, secretaria.ObterProfessorPorMatricula(1).Matricula);
		}

		[TestMethod]
		public void QuandoSecretariaMatricularUmAluno_AListaDeAlunosDeveSerAumentada()
		{
			var secretaria = new Core.Dominios.Secretaria();
			var aluno = new Aluno(new Pessoa(1, "João da Silva"));

			var quantidadeAntes = secretaria.ObterAlunos().Count();
			secretaria.Matricular(aluno);
			var quantidadeDepois = secretaria.ObterAlunos().Count();

			Assert.AreEqual(quantidadeAntes + 1, quantidadeDepois);
		}

		[TestMethod]
		public void QuandoSolicitarAListagemDeAlunos_ASecretariaDeveRetornarAlunosMatriculados()
		{
			var secretaria = ObterSecretariaPreenchidaCom(5);

			int quantidade = secretaria.ObterAlunos().Count();

			Assert.AreEqual(5, quantidade);
		}

		[TestMethod]
		public void QuandoAlterarONomeDoAluno_ASecretariaDeveAtualizarEsseAlunoNaLista()
		{
			var secretaria = ObterSecretariaPreenchidaCom(5);
			var alunoAntes = secretaria.ObterAlunoPorMatricula(3);
			var nomeAlunoAntes = alunoAntes.Nome;

			alunoAntes.AlterarNome("Aluno Bruno");
			secretaria.Alterar(alunoAntes);

			var alunoDepois = secretaria.ObterAlunoPorMatricula(3);
			Assert.AreEqual("Aluno 3", nomeAlunoAntes);
			Assert.AreEqual("Aluno Bruno", alunoAntes.Nome);
			Assert.AreEqual("Aluno Bruno", alunoDepois.Nome);
		}

		[TestMethod]
		public void QuandoSolicitaCadastrarMatriculaExistente_DeveManterAListaInalterada()
		{
			var secretaria = new Core.Dominios.Secretaria();
			var pessoa1 = new Aluno(new Pessoa(1, "Pessoa 1"));
			var pessoa2 = new Aluno(new Pessoa(2, "Pessoa 2"));
			var pessoa3 = new Aluno(new Pessoa(3, "Pessoa 3"));
			var pessoa4 = new Aluno(new Pessoa(4, "Pessoa 4"));

			secretaria.Matricular(pessoa1);
			secretaria.Matricular(pessoa1);
			secretaria.Matricular(pessoa2);
			secretaria.Matricular(pessoa3);
			secretaria.Matricular(pessoa4);

			Assert.AreEqual(4, secretaria.ObterPessoas().Count());
		}

		[TestMethod]
		public void QuandoSolicitaMatriculaExistente_DeveRetornarPessoa()
		{
			var secretaria = new Core.Dominios.Secretaria();

			secretaria.Matricular(new Aluno(new Pessoa(1, "Pessoa 1")));
			secretaria.Matricular(new Aluno(new Pessoa(2, "Pessoa 2")));

			var pessoa = secretaria.ObterPessoaPorMatricula(2);
			Assert.AreEqual(2, pessoa.Matricula);
		}

		[TestMethod]
		public void QuandoSecretariaMatricularUmaPessoa_AListaDePessoaDeveSerAumentada()
		{
			var secretaria = new Secretaria();

			secretaria.Matricular(new Aluno(new Pessoa(1, "João da Silva")));

			Assert.AreEqual(1, secretaria.ObterPessoas().Count());
		}

		[TestMethod]
		public void QuandoGerarArquivoSaidaComArquivoEntrada1_DeveGerarArquivoSaida1()
		{
			var secretaria = SecretariaFactory.CriarPorConteudo(arquivoEntrada1);
			var arquivo = secretaria.GerarArquivoSaida();

			Assert.IsNotNull(secretaria);
			Assert.IsNotNull(arquivo);
			Assert.AreEqual(arquivoSaida1, arquivo);
		}

		[TestMethod]
		public void QuandoGerarArquivoSaidaComArquivoEntrada2_DeveGerarArquivoSaida2()
		{
			var secretaria = SecretariaFactory.CriarPorConteudo(arquivoEntrada2);

			var arquivo = secretaria.GerarArquivoSaida();

			Assert.IsNotNull(secretaria);
			Assert.IsNotNull(arquivo);
			Assert.AreEqual(arquivoSaida2, arquivo);
		}

		private static Secretaria ObterSecretariaPreenchidaCom(Int32 quantidade)
		{
			var secretaria = new Core.Dominios.Secretaria();
			for (var i = 0; i < quantidade; i++)
			{
				var disciplina = new Disciplina(i, $"Disciplina {i}");
				secretaria.AdicionarDisciplina(disciplina);

				var pessoa = new Pessoa(i, $"Aluno {i}");

				var aluno = new Aluno(new Pessoa(i, $"Aluno {i}"));
				secretaria.Matricular(aluno);

				var professor = new Professor(new Pessoa(i, $"Aluno {i}"));
				secretaria.Matricular(professor);
			}
			return secretaria;
		}

		private const string arquivoEntrada1 = @"3
543 Historia
658 Patricia
2
123 Maria
222 Pedro
234 Algebra
741 Carla
3
123 Maria
246 Joao
369 Jose
987 Portugues
864 Silvia
4
246 Joao
369 Jose
222 Pedro
741 Carla";

		private const string arquivoSaida1 = @"Algebra Carla
Historia Patricia
Portugues Silvia
Maria 2
Pedro 2
Joao 2
Jose 2
Patricia 1
Carla 2
Silvia 1";

		private const string arquivoEntrada2 = @"2
11 Literatura
44 Cosme
3
33 Ana
22 Felipe
55 Renata
22 Geografia
55 Renata
2
44 Cosme
11 Marcos";

		private const string arquivoSaida2 = @"Geografia Renata
Literatura Cosme
Marcos 1
Felipe 1
Ana 1
Cosme 2
Renata 2";
	}
}