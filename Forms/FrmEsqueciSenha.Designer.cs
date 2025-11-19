namespace CadastroC_
{
    partial class FrmEsqueciSenha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEsqueciSenha));
            this.txtUsuarioSenha = new System.Windows.Forms.TextBox();
            this.txtConfirmaSenha = new System.Windows.Forms.TextBox();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.lblUsuarioSenha = new System.Windows.Forms.Label();
            this.lblNovaSenha = new System.Windows.Forms.Label();
            this.lblConfirmaSenha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalvarSenha = new System.Windows.Forms.Button();
            this.btnVoltarLogin = new System.Windows.Forms.Button();
            this.btnVerSenha = new System.Windows.Forms.Button();
            this.btnSenha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuarioSenha
            // 
            this.txtUsuarioSenha.Location = new System.Drawing.Point(380, 81);
            this.txtUsuarioSenha.Name = "txtUsuarioSenha";
            this.txtUsuarioSenha.Size = new System.Drawing.Size(182, 22);
            this.txtUsuarioSenha.TabIndex = 0;
            this.txtUsuarioSenha.TextChanged += new System.EventHandler(this.txtUsuarioSenha_TextChanged);
            // 
            // txtConfirmaSenha
            // 
            this.txtConfirmaSenha.Location = new System.Drawing.Point(380, 240);
            this.txtConfirmaSenha.Name = "txtConfirmaSenha";
            this.txtConfirmaSenha.Size = new System.Drawing.Size(182, 22);
            this.txtConfirmaSenha.TabIndex = 1;
            this.txtConfirmaSenha.UseSystemPasswordChar = true;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Location = new System.Drawing.Point(380, 159);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(182, 22);
            this.txtNovaSenha.TabIndex = 2;
            this.txtNovaSenha.UseSystemPasswordChar = true;
            // 
            // lblUsuarioSenha
            // 
            this.lblUsuarioSenha.AutoSize = true;
            this.lblUsuarioSenha.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(115)))), ((int)(((byte)(208)))));
            this.lblUsuarioSenha.Location = new System.Drawing.Point(386, 55);
            this.lblUsuarioSenha.Name = "lblUsuarioSenha";
            this.lblUsuarioSenha.Size = new System.Drawing.Size(76, 23);
            this.lblUsuarioSenha.TabIndex = 3;
            this.lblUsuarioSenha.Text = "Usuário";
            // 
            // lblNovaSenha
            // 
            this.lblNovaSenha.AutoSize = true;
            this.lblNovaSenha.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(115)))), ((int)(((byte)(208)))));
            this.lblNovaSenha.Location = new System.Drawing.Point(376, 133);
            this.lblNovaSenha.Name = "lblNovaSenha";
            this.lblNovaSenha.Size = new System.Drawing.Size(119, 23);
            this.lblNovaSenha.TabIndex = 4;
            this.lblNovaSenha.Text = "Nova Senha:";
            // 
            // lblConfirmaSenha
            // 
            this.lblConfirmaSenha.AutoSize = true;
            this.lblConfirmaSenha.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(115)))), ((int)(((byte)(208)))));
            this.lblConfirmaSenha.Location = new System.Drawing.Point(376, 214);
            this.lblConfirmaSenha.Name = "lblConfirmaSenha";
            this.lblConfirmaSenha.Size = new System.Drawing.Size(150, 23);
            this.lblConfirmaSenha.TabIndex = 5;
            this.lblConfirmaSenha.Text = "Confirma Senha";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CadastroC_.Properties.Resources.Reset_password;
            this.pictureBox1.Location = new System.Drawing.Point(-7, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalvarSenha
            // 
            this.btnSalvarSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(115)))), ((int)(((byte)(208)))));
            this.btnSalvarSenha.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarSenha.ForeColor = System.Drawing.Color.White;
            this.btnSalvarSenha.Location = new System.Drawing.Point(380, 303);
            this.btnSalvarSenha.Name = "btnSalvarSenha";
            this.btnSalvarSenha.Size = new System.Drawing.Size(98, 42);
            this.btnSalvarSenha.TabIndex = 7;
            this.btnSalvarSenha.Text = "Salvar";
            this.btnSalvarSenha.UseVisualStyleBackColor = false;
            this.btnSalvarSenha.Click += new System.EventHandler(this.btnSalvarSenha_Click_1);
            // 
            // btnVoltarLogin
            // 
            this.btnVoltarLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(115)))), ((int)(((byte)(208)))));
            this.btnVoltarLogin.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltarLogin.ForeColor = System.Drawing.Color.White;
            this.btnVoltarLogin.Location = new System.Drawing.Point(503, 303);
            this.btnVoltarLogin.Name = "btnVoltarLogin";
            this.btnVoltarLogin.Size = new System.Drawing.Size(94, 42);
            this.btnVoltarLogin.TabIndex = 8;
            this.btnVoltarLogin.Text = "Voltar";
            this.btnVoltarLogin.UseVisualStyleBackColor = false;
            this.btnVoltarLogin.Click += new System.EventHandler(this.btnVoltarLogin_Click_1);
            // 
            // btnVerSenha
            // 
            this.btnVerSenha.FlatAppearance.BorderSize = 0;
            this.btnVerSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerSenha.Image = global::CadastroC_.Properties.Resources.iconVisivel;
            this.btnVerSenha.Location = new System.Drawing.Point(559, 240);
            this.btnVerSenha.Name = "btnVerSenha";
            this.btnVerSenha.Size = new System.Drawing.Size(38, 23);
            this.btnVerSenha.TabIndex = 10;
            this.btnVerSenha.UseVisualStyleBackColor = true;
            this.btnVerSenha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnVerSenha_MouseDown);
            this.btnVerSenha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnVerSenha_MouseUp);
            // 
            // btnSenha
            // 
            this.btnSenha.FlatAppearance.BorderSize = 0;
            this.btnSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSenha.Image = global::CadastroC_.Properties.Resources.iconVisivel;
            this.btnSenha.Location = new System.Drawing.Point(559, 159);
            this.btnSenha.Name = "btnSenha";
            this.btnSenha.Size = new System.Drawing.Size(38, 23);
            this.btnSenha.TabIndex = 11;
            this.btnSenha.UseVisualStyleBackColor = true;
            this.btnSenha.Click += new System.EventHandler(this.button1_Click);
            this.btnSenha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSenha_MouseDown);
            this.btnSenha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSenha_MouseUp);
            // 
            // FrmEsqueciSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 372);
            this.Controls.Add(this.btnSenha);
            this.Controls.Add(this.btnVerSenha);
            this.Controls.Add(this.btnVoltarLogin);
            this.Controls.Add(this.btnSalvarSenha);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblConfirmaSenha);
            this.Controls.Add(this.lblNovaSenha);
            this.Controls.Add(this.lblUsuarioSenha);
            this.Controls.Add(this.txtNovaSenha);
            this.Controls.Add(this.txtConfirmaSenha);
            this.Controls.Add(this.txtUsuarioSenha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEsqueciSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alteração de Senha";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuarioSenha;
        private System.Windows.Forms.TextBox txtConfirmaSenha;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.Label lblUsuarioSenha;
        private System.Windows.Forms.Label lblNovaSenha;
        private System.Windows.Forms.Label lblConfirmaSenha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSalvarSenha;
        private System.Windows.Forms.Button btnVoltarLogin;
        private System.Windows.Forms.Button btnVerSenha;
        private System.Windows.Forms.Button btnSenha;
    }
}