using MetroFramework.Forms;
using PhpClassGenerator.Util;
using System;
using System.Collections.Generic;
using System.Text;
namespace PhpClassGenerator
{
    public partial class Principal : MetroForm
    {
        private List<String> Campos = new List<string>();

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

        public void gerarVo()
        {

            var sp = new StringBuilder();

            sp.AppendLine("<?php");
            sp.AppendLine();
            sp.AppendLine("class " + txtClasse.Text + "VO extends " + txtHeranca.Text + " {");
            sp.AppendLine();

            foreach (string campo in Campos)
            {

                if (!String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("_id") >= 0 || campo.Length > 2 && campo.ToLower().IndexOf("id") >= 20)
                {
                    sp.AppendLine("        public $" + campo.Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", ""));
                }
                else if (!String.IsNullOrEmpty(campo))
                {
                    sp.AppendLine("        public $" + campo);
                }
            }
            sp.AppendLine();
            sp.AppendLine("        public function __construct() { }");
            sp.AppendLine();
            sp.AppendLine("}");
            sp.AppendLine();
            txaClasseVo.Text = sp.ToString();

        }

        private void txtGerar_Click(object sender, EventArgs e)
        {
            var tabela = cmbTabela.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(tabela))
            {
                var conn = new DBConnect(txtHost.Text, txtBanco.Text, txtUsuario.Text, txtSenha.Text);
                var reader = conn.GetMySqlDataReader("SHOW COLUMNS FROM " + tabela);
                while (reader.Read())
                {
                    Campos.Add((string)reader["Field"] + "");
                }
                reader.Close();
                conn.CloseConnection();
            }

            gerarVo();
        }

        private void txaConsultaSql_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
