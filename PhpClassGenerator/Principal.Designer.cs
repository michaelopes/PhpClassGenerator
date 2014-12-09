namespace PhpClassGenerator
{
    partial class Principal
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
            this.txtHost = new MetroFramework.Controls.MetroTextBox();
            this.tabPrincipal = new MetroFramework.Controls.MetroTabControl();
            this.consutaSql = new MetroFramework.Controls.MetroTabPage();
            this.classeVO = new MetroFramework.Controls.MetroTabPage();
            this.classeBE = new MetroFramework.Controls.MetroTabPage();
            this.classeDAO = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtSenha = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtClasse = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtBanco = new MetroFramework.Controls.MetroTextBox();
            this.btnConsultar = new MetroFramework.Controls.MetroButton();
            this.cmbTabela = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtHeranca = new MetroFramework.Controls.MetroTextBox();
            this.txtGerar = new MetroFramework.Controls.MetroButton();
            this.txaConsultaSql = new System.Windows.Forms.RichTextBox();
            this.txaClasseVo = new System.Windows.Forms.RichTextBox();
            this.txaClasseBe = new System.Windows.Forms.RichTextBox();
            this.txaClasseDao = new System.Windows.Forms.RichTextBox();
            this.tabPrincipal.SuspendLayout();
            this.consutaSql.SuspendLayout();
            this.classeVO.SuspendLayout();
            this.classeBE.SuspendLayout();
            this.classeDAO.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Lines = new string[] {
        "localhost"};
            this.txtHost.Location = new System.Drawing.Point(11, 88);
            this.txtHost.MaxLength = 32767;
            this.txtHost.Name = "txtHost";
            this.txtHost.PasswordChar = '\0';
            this.txtHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHost.SelectedText = "";
            this.txtHost.Size = new System.Drawing.Size(251, 29);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "localhost";
            this.txtHost.UseSelectable = true;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.consutaSql);
            this.tabPrincipal.Controls.Add(this.classeVO);
            this.tabPrincipal.Controls.Add(this.classeBE);
            this.tabPrincipal.Controls.Add(this.classeDAO);
            this.tabPrincipal.Location = new System.Drawing.Point(7, 217);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 1;
            this.tabPrincipal.Size = new System.Drawing.Size(1226, 616);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.UseSelectable = true;
            // 
            // consutaSql
            // 
            this.consutaSql.Controls.Add(this.txaConsultaSql);
            this.consutaSql.HorizontalScrollbarBarColor = true;
            this.consutaSql.HorizontalScrollbarHighlightOnWheel = false;
            this.consutaSql.HorizontalScrollbarSize = 10;
            this.consutaSql.Location = new System.Drawing.Point(4, 38);
            this.consutaSql.Name = "consutaSql";
            this.consutaSql.Size = new System.Drawing.Size(1218, 574);
            this.consutaSql.TabIndex = 0;
            this.consutaSql.Text = "Consulta SQL";
            this.consutaSql.VerticalScrollbarBarColor = true;
            this.consutaSql.VerticalScrollbarHighlightOnWheel = false;
            this.consutaSql.VerticalScrollbarSize = 10;
            this.consutaSql.Click += new System.EventHandler(this.consutaSql_Click);
            // 
            // classeVO
            // 
            this.classeVO.Controls.Add(this.txaClasseVo);
            this.classeVO.HorizontalScrollbarBarColor = true;
            this.classeVO.HorizontalScrollbarHighlightOnWheel = false;
            this.classeVO.HorizontalScrollbarSize = 10;
            this.classeVO.Location = new System.Drawing.Point(4, 38);
            this.classeVO.Name = "classeVO";
            this.classeVO.Size = new System.Drawing.Size(1218, 574);
            this.classeVO.TabIndex = 1;
            this.classeVO.Text = "Classe VO";
            this.classeVO.VerticalScrollbarBarColor = true;
            this.classeVO.VerticalScrollbarHighlightOnWheel = false;
            this.classeVO.VerticalScrollbarSize = 10;
            this.classeVO.Click += new System.EventHandler(this.metroTabPage2_Click);
            // 
            // classeBE
            // 
            this.classeBE.Controls.Add(this.txaClasseBe);
            this.classeBE.HorizontalScrollbarBarColor = true;
            this.classeBE.HorizontalScrollbarHighlightOnWheel = false;
            this.classeBE.HorizontalScrollbarSize = 10;
            this.classeBE.Location = new System.Drawing.Point(4, 38);
            this.classeBE.Name = "classeBE";
            this.classeBE.Size = new System.Drawing.Size(1218, 574);
            this.classeBE.TabIndex = 2;
            this.classeBE.Text = "Classe BE";
            this.classeBE.VerticalScrollbarBarColor = true;
            this.classeBE.VerticalScrollbarHighlightOnWheel = false;
            this.classeBE.VerticalScrollbarSize = 10;
            // 
            // classeDAO
            // 
            this.classeDAO.Controls.Add(this.txaClasseDao);
            this.classeDAO.HorizontalScrollbarBarColor = true;
            this.classeDAO.HorizontalScrollbarHighlightOnWheel = false;
            this.classeDAO.HorizontalScrollbarSize = 10;
            this.classeDAO.Location = new System.Drawing.Point(4, 38);
            this.classeDAO.Name = "classeDAO";
            this.classeDAO.Size = new System.Drawing.Size(1218, 574);
            this.classeDAO.TabIndex = 3;
            this.classeDAO.Text = "Classe DAO";
            this.classeDAO.VerticalScrollbarBarColor = true;
            this.classeDAO.VerticalScrollbarHighlightOnWheel = false;
            this.classeDAO.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(11, 66);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(35, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Host";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(11, 145);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Escolha uma tabela";
            // 
            // txtSenha
            // 
            this.txtSenha.Lines = new string[] {
        "bdmichael"};
            this.txtSenha.Location = new System.Drawing.Point(782, 88);
            this.txtSenha.MaxLength = 32767;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '\0';
            this.txtSenha.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSenha.SelectedText = "";
            this.txtSenha.Size = new System.Drawing.Size(251, 29);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.Text = "bdmichael";
            this.txtSenha.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(782, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(44, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Lines = new string[] {
        "root"};
            this.txtUsuario.Location = new System.Drawing.Point(525, 88);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.Size = new System.Drawing.Size(251, 29);
            this.txtUsuario.TabIndex = 5;
            this.txtUsuario.Text = "root";
            this.txtUsuario.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(528, 66);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(53, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Usuário";
            // 
            // txtClasse
            // 
            this.txtClasse.Lines = new string[0];
            this.txtClasse.Location = new System.Drawing.Point(268, 167);
            this.txtClasse.MaxLength = 32767;
            this.txtClasse.Name = "txtClasse";
            this.txtClasse.PasswordChar = '\0';
            this.txtClasse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClasse.SelectedText = "";
            this.txtClasse.Size = new System.Drawing.Size(251, 29);
            this.txtClasse.TabIndex = 7;
            this.txtClasse.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(268, 66);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(105, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Banco de Dados";
            // 
            // txtBanco
            // 
            this.txtBanco.Lines = new string[] {
        "dbpittifyou"};
            this.txtBanco.Location = new System.Drawing.Point(268, 88);
            this.txtBanco.MaxLength = 32767;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.PasswordChar = '\0';
            this.txtBanco.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBanco.SelectedText = "";
            this.txtBanco.Size = new System.Drawing.Size(251, 29);
            this.txtBanco.TabIndex = 9;
            this.txtBanco.Text = "dbpittifyou";
            this.txtBanco.UseSelectable = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(1050, 87);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 29);
            this.btnConsultar.TabIndex = 11;
            this.btnConsultar.Text = "Conectar";
            this.btnConsultar.UseSelectable = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cmbTabela
            // 
            this.cmbTabela.FormattingEnabled = true;
            this.cmbTabela.ItemHeight = 23;
            this.cmbTabela.Location = new System.Drawing.Point(11, 167);
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(251, 29);
            this.cmbTabela.TabIndex = 12;
            this.cmbTabela.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(268, 145);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(105, 19);
            this.metroLabel6.TabIndex = 13;
            this.metroLabel6.Text = "Nome da Classe";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(528, 145);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(117, 19);
            this.metroLabel7.TabIndex = 15;
            this.metroLabel7.Text = "Nome da Herança";
            // 
            // txtHeranca
            // 
            this.txtHeranca.Lines = new string[] {
        "AbstractVO"};
            this.txtHeranca.Location = new System.Drawing.Point(528, 167);
            this.txtHeranca.MaxLength = 32767;
            this.txtHeranca.Name = "txtHeranca";
            this.txtHeranca.PasswordChar = '\0';
            this.txtHeranca.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHeranca.SelectedText = "";
            this.txtHeranca.Size = new System.Drawing.Size(251, 29);
            this.txtHeranca.TabIndex = 14;
            this.txtHeranca.Text = "AbstractVO";
            this.txtHeranca.UseSelectable = true;
            // 
            // txtGerar
            // 
            this.txtGerar.Location = new System.Drawing.Point(799, 167);
            this.txtGerar.Name = "txtGerar";
            this.txtGerar.Size = new System.Drawing.Size(75, 29);
            this.txtGerar.TabIndex = 16;
            this.txtGerar.Text = "Gerar classes";
            this.txtGerar.UseSelectable = true;
            this.txtGerar.Click += new System.EventHandler(this.txtGerar_Click);
            // 
            // txaConsultaSql
            // 
            this.txaConsultaSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txaConsultaSql.Location = new System.Drawing.Point(0, 3);
            this.txaConsultaSql.Name = "txaConsultaSql";
            this.txaConsultaSql.Size = new System.Drawing.Size(1215, 568);
            this.txaConsultaSql.TabIndex = 2;
            this.txaConsultaSql.Text = "";
            this.txaConsultaSql.TextChanged += new System.EventHandler(this.txaConsultaSql_TextChanged);
            // 
            // txaClasseVo
            // 
            this.txaClasseVo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txaClasseVo.Location = new System.Drawing.Point(2, 3);
            this.txaClasseVo.Name = "txaClasseVo";
            this.txaClasseVo.Size = new System.Drawing.Size(1215, 568);
            this.txaClasseVo.TabIndex = 3;
            this.txaClasseVo.Text = "";
            // 
            // txaClasseBe
            // 
            this.txaClasseBe.Location = new System.Drawing.Point(2, 3);
            this.txaClasseBe.Name = "txaClasseBe";
            this.txaClasseBe.Size = new System.Drawing.Size(1215, 568);
            this.txaClasseBe.TabIndex = 3;
            this.txaClasseBe.Text = "";
            // 
            // txaClasseDao
            // 
            this.txaClasseDao.Location = new System.Drawing.Point(2, 3);
            this.txaClasseDao.Name = "txaClasseDao";
            this.txaClasseDao.Size = new System.Drawing.Size(1215, 568);
            this.txaClasseDao.TabIndex = 3;
            this.txaClasseDao.Text = "";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1237, 856);
            this.Controls.Add(this.txtGerar);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtHeranca);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cmbTabela);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtClasse);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.txtHost);
            this.Name = "Principal";
            this.Text = "Principal";
            this.tabPrincipal.ResumeLayout(false);
            this.consutaSql.ResumeLayout(false);
            this.classeVO.ResumeLayout(false);
            this.classeBE.ResumeLayout(false);
            this.classeDAO.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtHost;
        private MetroFramework.Controls.MetroTabControl tabPrincipal;
        private MetroFramework.Controls.MetroTabPage consutaSql;
        private MetroFramework.Controls.MetroTabPage classeVO;
        private MetroFramework.Controls.MetroTabPage classeBE;
        private MetroFramework.Controls.MetroTabPage classeDAO;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtClasse;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtSenha;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtUsuario;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtBanco;
        private MetroFramework.Controls.MetroButton btnConsultar;
        private MetroFramework.Controls.MetroComboBox cmbTabela;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtHeranca;
        private MetroFramework.Controls.MetroButton txtGerar;
        private System.Windows.Forms.RichTextBox txaConsultaSql;
        private System.Windows.Forms.RichTextBox txaClasseVo;
        private System.Windows.Forms.RichTextBox txaClasseBe;
        private System.Windows.Forms.RichTextBox txaClasseDao;
    }
}