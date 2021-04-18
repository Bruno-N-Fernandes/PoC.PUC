using System;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	public class Disciplina
	{
		public Int32 Codigo { get; private set; }
		public String Nome { get; private set; }
		private Professor ProfessorTitular { get; set; }
		private List<Aluno> Alunos { get; set; }

		public Disciplina(Int32 codigo, String nome)
		{
			Codigo = codigo;
			Nome = nome;
			Alunos = new List<Aluno>();
		}

		public void AlterarNome(String nome)
		{
			Nome = nome;
		}

		public void InscreverAluno(IEnumerable<Aluno> alunos)
		{
			foreach (var aluno in alunos)
				InscreverAluno(aluno);
		}

		public void InscreverAluno(Aluno aluno)
		{
			if (!Alunos.Any(a => a.Matricula == aluno.Matricula))
			{
				Alunos.Add(aluno);
				aluno.Inscrever(this);
			}
		}

		public IEnumerable<Aluno> ObterAlunos()
		{
			return Alunos.ToArray();
		}

		public Aluno ObterAlunoPor(Int32 matricula)
		{
			return Alunos.SingleOrDefault(a => a.Matricula == matricula);
		}

		public void DefinirTitular(Professor professorTitular)
		{
			if (ProfessorTitular?.Matricula != professorTitular?.Matricula)
			{
				ProfessorTitular = professorTitular;
				professorTitular?.Lecionar(this);
			}
		}

		public Professor ObterProfessorTitular()
		{
			return ProfessorTitular;
		}


		public static String RelatorioSaida(Disciplina disciplina)
		{
			return $"{disciplina?.Nome} {disciplina?.ProfessorTitular?.Nome}";
		}
	}
}