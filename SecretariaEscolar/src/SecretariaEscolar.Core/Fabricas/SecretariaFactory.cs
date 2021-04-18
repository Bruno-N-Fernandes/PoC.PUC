using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using PUC.Desafio.SecretariaEscolar.Core.Utilitarios;
using System;
using System.Collections.Generic;
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

				var professor = CriarProfessor(secretaria, leitor);
				disciplina.DefinirTitular(professor);

				var alunos = CriarAlunos(secretaria, leitor);
				disciplina.InscreverAluno(alunos);
			}
		}

		private static Disciplina CriarDisciplina(Secretaria secretaria, Leitor leitor)
		{
			var linha = leitor.LerString().SplitFields();
			var disciplina = new Disciplina(linha.Codigo, linha.Descricao);
			secretaria.AdicionarDisciplina(disciplina);
			return disciplina;
		}

		private static Professor CriarProfessor(Secretaria secretaria, Leitor leitor)
		{
			var linha = leitor.LerString().SplitFields();
			var professor = secretaria.ObterProfessorPorMatricula(linha.Codigo);
			if (professor == null)
			{
				var pessoa = ObterPessoa(secretaria, linha.Codigo, linha.Descricao);
				professor = pessoa.TransformarEm<Professor>();
				secretaria.Matricular(professor);
			}

			return professor;
		}

		private static IEnumerable<Aluno> CriarAlunos(Secretaria secretaria, Leitor leitor)
		{
			var alunos = new List<Aluno>();
			var quantidadeAlunos = leitor.LerInteiro();
			for (var i = 0; i < quantidadeAlunos; i++)
			{
				var aluno = CriarAluno(secretaria, leitor);
				alunos.Add(aluno);
			}
			return alunos;
		}

		private static Aluno CriarAluno(Secretaria secretaria, Leitor leitor)
		{
			var linha = leitor.LerString().SplitFields();
			var aluno = secretaria.ObterAlunoPorMatricula(linha.Codigo);
			if (aluno == null)
			{
				var pessoa = ObterPessoa(secretaria, linha.Codigo, linha.Descricao);
				aluno = pessoa.TransformarEm<Aluno>();
				secretaria.Matricular(aluno);
			}
			return aluno;
		}

		private static Pessoa ObterPessoa(Secretaria secretaria, Int32 matricula, String nome)
		{
			var pessoa = secretaria.ObterPessoaPorMatricula(matricula);

			return pessoa ?? new Pessoa(matricula, nome);
		}
	}
}