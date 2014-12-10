using MetroFramework.Forms;
using MetroFramework.MetroMessageBoxes;
using PhpClassGenerator.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace PhpClassGenerator
{
    public partial class Principal : MetroForm
    {
        private List<String> Campos = new List<string>();
        public FolderBrowserDialog folderBrowserDialog { get; set; }
        public Principal()
        {
            InitializeComponent();
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void consutaSql_Click(object sender, EventArgs e)
        {

        }

        // C#
        public void ChooseFolder()
        {
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPasta.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var conn = new DBConnect(txtHost.Text, txtBanco.Text, txtUsuario.Text, txtSenha.Text);
            var reader = conn.GetMySqlDataReader("SHOW TABLES");

            while (reader.Read())
            {
                cmbTabela.Items.Add((string)reader["tables_in_" + txtBanco.Text] + "");
            }

            reader.Close();
            conn.CloseConnection();

        }

        public void criarAquivo(string texto, string nomeClasse, string tipoDeClasse)
        {
            string path = nomeClasse + ".class.php";
            string folder = txtPasta.Text + "/" + tipoDeClasse;

            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);

            }



            string completePath = folder + "/" + path;

            FileInfo VerifArq = new FileInfo(completePath);
            if (!VerifArq.Exists)
            {
                VerifArq.Create().Close();
                TextWriter tw = new StreamWriter(completePath, true);
                tw.Write(texto);
                tw.Close();
            }
            else if (VerifArq.Exists)
            {
                TextWriter tw = new StreamWriter(completePath, false);
                tw.Write(texto);
                tw.Close();
            }
        }

        public void gerarVo()
        {

            var sp = new StringBuilder();

            sp.AppendLine("<?php");
            sp.AppendLine();
            sp.AppendLine("class " + txtClasse.Text + "VO extends " + txtHerancaVo.Text + " {");
            sp.AppendLine();

            foreach (string campo in Campos)
            {

                if (!String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("id") >= 0)
                {
                    sp.AppendLine("        public $" + campo.Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", ""));
                }
                else if (!String.IsNullOrEmpty(campo))
                {
                    sp.AppendLine("        public $" + campo);
                }
            }
            sp.AppendLine();
            sp.AppendLine("        public function __construct($arrAttr = array()) {");
            sp.AppendLine("           parent::__construct($arrAttr);");
            sp.AppendLine("        }");
            sp.AppendLine();
            sp.AppendLine("}");
            sp.AppendLine();
            txaClasseVo.Text = sp.ToString();
            criarAquivo(sp.ToString(), txtClasse.Text + "VO", "VO");

        }

        private void txtGerar_Click(object sender, EventArgs e)
        {
            var tabela = cmbTabela.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(tabela))
            {
                Campos.Clear();
                var conn = new DBConnect(txtHost.Text, txtBanco.Text, txtUsuario.Text, txtSenha.Text);
                var reader = conn.GetMySqlDataReader("SHOW COLUMNS FROM " + tabela);

                while (reader.Read())
                {
                    Campos.Add((string)reader["Field"] + "");
                }
                reader.Close();
                conn.CloseConnection();
            }
            if (!String.IsNullOrEmpty(txtPasta.Text))
            {
                gerarVo();
            }
            else
            {
                MetroMessageBox.Show(this, "Não foi possivel encontrar uma pasta de destino!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txaConsultaSql_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void cmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabela = cmbTabela.SelectedItem.ToString();
            txtClasse.Text = tabela.Substring(0, 1).ToUpper() + tabela.Substring(1, tabela.Length - 1);
        }
    }
}
