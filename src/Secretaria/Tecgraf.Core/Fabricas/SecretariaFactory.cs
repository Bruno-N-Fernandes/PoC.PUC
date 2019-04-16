using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using PUC.Desafio.SecretariaEscolar.Core.Utilitarios;
using System;
using System.IO;

namespace PUC.Desafio.SecretariaEscolar.Core.Fabricas
{
	public class SecretariaFactory
	{
		public static Secretaria CriarPorArquivo(FileInfo arquivoEntrada)
		{
			var conteudo = File.ReadAllText(arquivoEntrada.FullName);
			return CriarPorConteudo(conteudo);
		}

		public static Secretaria CriarPorConteudo(String conteudo)
		{
			var secretaria = new Secretaria();
			var leitor = new Leitor(conteudo);

			CriarDisciplinas(secretaria, leitor);

			return secretaria;
		}

		private static void CriarDisciplinas(Secretaria secretaria, Leitor leitor)
		{
			var quantidadeDeDisciplinas = leitor.LerInteiro();
			for (var i = 0; i < quantidadeDeDisciplinas; i++)
			{
				var disciplina = CriarDisciplina(secretaria, leitor);

				CriarProfessor(secretaria, leitor, disciplina);

				CriarAlunos(secretaria, leitor, disciplina);
			}
		}

		private static Disciplina CriarDisciplina(Secretaria secretaria, Leitor leitor)
		{
			var linha = leitor.LerString().SplitFields();
			var disciplina = new Disciplina(linha.Codigo, linha.Descricao);
			secretaria.CriarDisciplina(disciplina);
			return disciplina;
		}

		private static Professor CriarProfessor(Secretaria secretaria, Leitor leitor, Disciplina disciplina)
		{
			var linha = leitor.LerString().SplitFields();
			var professor = secretaria.ObterProfessorPorMatricula(linha.Codigo);
			if (professor == null)
			{
				var pessoa = ObterOuMatricularPessoa(secretaria, linha.Codigo, linha.Descricao);
				professor = pessoa.TransformarEm<Professor>();
			}

			disciplina.DefinirTitular(professor);
			secretaria.Matricular(professor);
			return professor;
		}

		private static void CriarAlunos(Secretaria secretaria, Leitor leitor, Disciplina disciplina)
		{
			var quantidadeAlunos = leitor.LerInteiro();
			for (var i = 0; i < quantidadeAlunos; i++)
			{
				var aluno = CriarAluno(secretaria, leitor, disciplina);
				secretaria.Matricular(aluno);
			}
		}

		private static Aluno CriarAluno(Secretaria secretaria, Leitor leitor, Disciplina disciplina)
		{
			var linha = leitor.LerString().SplitFields();
			var aluno = secretaria.ObterAlunoPorMatricula(linha.Codigo);
			if (aluno == null)
			{
				var pessoa = ObterOuMatricularPessoa(secretaria, linha.Codigo, linha.Descricao);
				aluno = pessoa.TransformarEm<Aluno>();
			}
			disciplina.InscreverAluno(aluno);
			return aluno;
		}

		private static Pessoa ObterOuMatricularPessoa(Secretaria secretaria, Int32 matricula, String nome)
		{
			var pessoa = secretaria.ObterPessoaPorMatricula(matricula);
			if (pessoa == null)
			{
				pessoa = new Pessoa(matricula, nome);
				secretaria.Matricular(pessoa);
			}

			return pessoa;
		}
	}
}