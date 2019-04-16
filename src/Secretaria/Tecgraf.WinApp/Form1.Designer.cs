namespace PUC.Desafio.SecretariaEscolar.WinApp
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSelecionarArquivo = new System.Windows.Forms.Button();
			this.lblLocalArquivo = new System.Windows.Forms.Label();
			this.txtLocalArquivo = new System.Windows.Forms.TextBox();
			this.btnAbrir = new System.Windows.Forms.Button();
			this.dgvPessoas = new System.Windows.Forms.DataGridView();
			this.dgvAlunos = new System.Windows.Forms.DataGridView();
			this.dgvProfessores = new System.Windows.Forms.DataGridView();
			this.dgvDisciplinas = new System.Windows.Forms.DataGridView();
			this.btnPessoas = new System.Windows.Forms.Button();
			this.btnAlunos = new System.Windows.Forms.Button();
			this.btnProfessores = new System.Windows.Forms.Button();
			this.btnDisciplinas = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvPessoas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAlunos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvProfessores)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSelecionarArquivo
			// 
			this.btnSelecionarArquivo.Location = new System.Drawing.Point(630, 5);
			this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
			this.btnSelecionarArquivo.Size = new System.Drawing.Size(97, 23);
			this.btnSelecionarArquivo.TabIndex = 0;
			this.btnSelecionarArquivo.Text = "Selecionar";
			this.btnSelecionarArquivo.UseVisualStyleBackColor = true;
			this.btnSelecionarArquivo.Click += new System.EventHandler(this.btnSelecionarArquivo_Click);
			// 
			// lblLocalArquivo
			// 
			this.lblLocalArquivo.AutoSize = true;
			this.lblLocalArquivo.Location = new System.Drawing.Point(9, 9);
			this.lblLocalArquivo.Name = "lblLocalArquivo";
			this.lblLocalArquivo.Size = new System.Drawing.Size(42, 13);
			this.lblLocalArquivo.TabIndex = 1;
			this.lblLocalArquivo.Text = "arquivo";
			// 
			// txtLocalArquivo
			// 
			this.txtLocalArquivo.Location = new System.Drawing.Point(60, 7);
			this.txtLocalArquivo.Name = "txtLocalArquivo";
			this.txtLocalArquivo.ReadOnly = true;
			this.txtLocalArquivo.Size = new System.Drawing.Size(564, 20);
			this.txtLocalArquivo.TabIndex = 2;
			// 
			// btnAbrir
			// 
			this.btnAbrir.Location = new System.Drawing.Point(733, 5);
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.Size = new System.Drawing.Size(97, 23);
			this.btnAbrir.TabIndex = 3;
			this.btnAbrir.Text = "Abrir";
			this.btnAbrir.UseVisualStyleBackColor = true;
			this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
			// 
			// dgvPessoas
			// 
			this.dgvPessoas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPessoas.Location = new System.Drawing.Point(12, 139);
			this.dgvPessoas.Name = "dgvPessoas";
			this.dgvPessoas.Size = new System.Drawing.Size(406, 292);
			this.dgvPessoas.TabIndex = 4;
			// 
			// dgvAlunos
			// 
			this.dgvAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAlunos.Location = new System.Drawing.Point(424, 139);
			this.dgvAlunos.Name = "dgvAlunos";
			this.dgvAlunos.Size = new System.Drawing.Size(406, 292);
			this.dgvAlunos.TabIndex = 5;
			// 
			// dgvProfessores
			// 
			this.dgvProfessores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProfessores.Location = new System.Drawing.Point(12, 437);
			this.dgvProfessores.Name = "dgvProfessores";
			this.dgvProfessores.Size = new System.Drawing.Size(406, 177);
			this.dgvProfessores.TabIndex = 6;
			// 
			// dgvDisciplinas
			// 
			this.dgvDisciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisciplinas.Location = new System.Drawing.Point(424, 437);
			this.dgvDisciplinas.Name = "dgvDisciplinas";
			this.dgvDisciplinas.Size = new System.Drawing.Size(406, 177);
			this.dgvDisciplinas.TabIndex = 7;
			// 
			// btnPessoas
			// 
			this.btnPessoas.Location = new System.Drawing.Point(12, 33);
			this.btnPessoas.Name = "btnPessoas";
			this.btnPessoas.Size = new System.Drawing.Size(200, 100);
			this.btnPessoas.TabIndex = 8;
			this.btnPessoas.Text = "0 Pessoas";
			this.btnPessoas.UseVisualStyleBackColor = true;
			// 
			// btnAlunos
			// 
			this.btnAlunos.Location = new System.Drawing.Point(218, 33);
			this.btnAlunos.Name = "btnAlunos";
			this.btnAlunos.Size = new System.Drawing.Size(200, 100);
			this.btnAlunos.TabIndex = 9;
			this.btnAlunos.Text = "0 Alunos";
			this.btnAlunos.UseVisualStyleBackColor = true;
			// 
			// btnProfessores
			// 
			this.btnProfessores.Location = new System.Drawing.Point(424, 33);
			this.btnProfessores.Name = "btnProfessores";
			this.btnProfessores.Size = new System.Drawing.Size(200, 100);
			this.btnProfessores.TabIndex = 10;
			this.btnProfessores.Text = "0 Professores";
			this.btnProfessores.UseVisualStyleBackColor = true;
			// 
			// btnDisciplinas
			// 
			this.btnDisciplinas.Location = new System.Drawing.Point(630, 33);
			this.btnDisciplinas.Name = "btnDisciplinas";
			this.btnDisciplinas.Size = new System.Drawing.Size(200, 100);
			this.btnDisciplinas.TabIndex = 11;
			this.btnDisciplinas.Text = "0 Disciplinas";
			this.btnDisciplinas.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(843, 622);
			this.Controls.Add(this.btnDisciplinas);
			this.Controls.Add(this.btnProfessores);
			this.Controls.Add(this.btnAlunos);
			this.Controls.Add(this.btnPessoas);
			this.Controls.Add(this.dgvDisciplinas);
			this.Controls.Add(this.dgvProfessores);
			this.Controls.Add(this.dgvAlunos);
			this.Controls.Add(this.dgvPessoas);
			this.Controls.Add(this.btnAbrir);
			this.Controls.Add(this.txtLocalArquivo);
			this.Controls.Add(this.lblLocalArquivo);
			this.Controls.Add(this.btnSelecionarArquivo);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dgvPessoas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAlunos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvProfessores)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSelecionarArquivo;
		private System.Windows.Forms.Label lblLocalArquivo;
		private System.Windows.Forms.TextBox txtLocalArquivo;
		private System.Windows.Forms.Button btnAbrir;
		private System.Windows.Forms.DataGridView dgvPessoas;
		private System.Windows.Forms.DataGridView dgvAlunos;
		private System.Windows.Forms.DataGridView dgvProfessores;
		private System.Windows.Forms.DataGridView dgvDisciplinas;
		private System.Windows.Forms.Button btnPessoas;
		private System.Windows.Forms.Button btnAlunos;
		private System.Windows.Forms.Button btnProfessores;
		private System.Windows.Forms.Button btnDisciplinas;
	}
}

