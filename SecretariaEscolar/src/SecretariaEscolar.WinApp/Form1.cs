﻿using PUC.Desafio.SecretariaEscolar.Core.Dominios;
using PUC.Desafio.SecretariaEscolar.Core.Fabricas;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PUC.Desafio.SecretariaEscolar.WinApp
{
	public partial class Form1 : Form
	{
		private Secretaria _secretaria = new Secretaria();

		public Form1()
		{
			InitializeComponent();
		}

		private void btnSelecionarArquivo_Click(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog();
			if (DialogResult.OK == openFileDialog.ShowDialog())
			{
				txtLocalArquivo.Text = openFileDialog.FileName;
			}
			openFileDialog.Dispose();
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtLocalArquivo.Text))
				MessageBox.Show("Selecione um arquivo antes de abri-lo!");
			else
			{
				var arquivoEntrada = new FileInfo(txtLocalArquivo.Text);
				_secretaria = SecretariaFactory.CriarPorArquivo(arquivoEntrada);
				RefreshGrids();
			}
		}

		private void RefreshGrids()
		{
			var alunos = _secretaria.ObterAlunos().OrderBy(a => a.Matricula).ToArray();
			var disciplinas = _secretaria.ObterDisciplinas().OrderBy(a => a.Codigo).ToArray();
			var pessoas = _secretaria.ObterPessoas().OrderBy(a => a.Matricula).ToArray();
			var professores = _secretaria.ObterProfessores().OrderBy(a => a.Matricula).ToArray();

			dgvAlunos.DataSource = alunos;
			dgvDisciplinas.DataSource = disciplinas;
			dgvPessoas.DataSource = pessoas;
			dgvProfessores.DataSource = professores;

			btnAlunos.Text = $"{alunos.Count()} Alunos";
			btnDisciplinas.Text = $"{disciplinas.Count()} Disciplinas";
			btnPessoas.Text = $"{pessoas.Count()} Pessoas";
			btnProfessores.Text = $"{professores.Count()} Professores";
		}
	}
}