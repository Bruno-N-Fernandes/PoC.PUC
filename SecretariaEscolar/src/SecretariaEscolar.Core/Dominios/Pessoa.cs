using System;
using System.Collections.Generic;
using System.Linq;

namespace PUC.Desafio.SecretariaEscolar.Core.Dominios
{
	public class Pessoa
	{
		private List<PessoaWrapper> Papeis { get; set; }
		public TipoPessoa TipoPessoa { get; private set; }
		public int Matricula { get; private set; }
		public string Nome { get; private set; }

		public Pessoa(Int32 matricula, String nome)
		{
			Papeis = new List<PessoaWrapper>();
			Matricula = matricula;
			Nome = nome;
		}

		public void AlterarNome(String nome)
		{
			Nome = nome;
		}

		public TPessoaWrapper TransformarEm<TPessoaWrapper>() where TPessoaWrapper : PessoaWrapper, new()
		{
			var pessoaWrapper = new TPessoaWrapper { Pessoa = this };
			Papeis.Add(pessoaWrapper);
			TipoPessoa |= pessoaWrapper.TipoPessoa;
			return pessoaWrapper;
		}

		public static String RelatorioSaida(Pessoa pessoa)
		{
			var disciplinas = pessoa.Papeis.SelectMany(d => d.ObterDisciplinas());
			return $"{pessoa.Nome} {disciplinas.Count()}";
		}
	}
}