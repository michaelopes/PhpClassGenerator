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
        private List<string> Campos = new List<string>();
        private List<string> TypeField = new List<string>();
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
            criarAquivo(sp.ToString(), txtClasse.Text + "VO", "vo");

        }

        private void txtGerar_Click(object sender, EventArgs e)
        {
            var tabela = cmbTabela.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(tabela))
            {
                Campos.Clear();
                TypeField.Clear();
                var conn = new DBConnect(txtHost.Text, txtBanco.Text, txtUsuario.Text, txtSenha.Text);
                var reader = conn.GetMySqlDataReader("SHOW COLUMNS FROM " + tabela);

                while (reader.Read())
                {
                    Campos.Add((string)reader["Field"] + "");
                    TypeField.Add((string)reader["Type"] + "");
                }
                reader.Close();
                conn.CloseConnection();
            }
            if (!String.IsNullOrEmpty(txtPasta.Text))
            {
                gerarVo();
                gerarDAO();
            }
            else
            {
                MetroMessageBox.Show(this, "Não foi possivel encontrar uma pasta de destino!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gerarDAO()
        {
            var sp = new StringBuilder();

            sp.AppendLine("<?php");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine("class " + txtClasse.Text + "DAO extends " + txtHerancaDao.Text + " { ");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine("      public $DatabaseIndex= \"DB_MYSQL\";");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine("      public function __construct(Database $database) {              ");
            sp.AppendLine("       	    try{                                                   ");
            sp.AppendLine("       	    	parent::__construct($database);                    ");
            sp.AppendLine("       	    }catch(Exception $ex){                                 ");
            sp.AppendLine("       	    	throw $ex;                                         ");
            sp.AppendLine("       	    }                                                      ");
            sp.AppendLine("      }                                                             ");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine(gerarDAOCreate());

            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine(gerarDAOUpdate());

            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine(gerarDAODelete());

            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine(gerarDAORead());

            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine(gerarDAOReadAll());
            sp.AppendLine("}");

            txaClasseDao.Text = sp.ToString();
            criarAquivo(sp.ToString(), txtClasse.Text + "DAO", "dao");


        }

        private string gerarDAOCreate()
        {
            var sp = new StringBuilder();
            var tabela = cmbTabela.SelectedItem.ToString();
            int count = 0;
            sp.AppendLine("    public function create(ValueObject $objVO) {");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("try{");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("$query =  \" INSERT INTO " + tabela);
            sp.Append(' ', 40).AppendLine("(");
            foreach (string campo in Campos)
            {
                if (count == 0)
                    sp.Append(' ', 57).AppendLine(campo);
                else
                    sp.Append(' ', 55).AppendLine(", " + campo);
                count++;
            }
            sp.Append(' ', 40).AppendLine(")");
            sp.Append(' ', 40).AppendLine("VALUES");
            sp.Append(' ', 40).AppendLine("(");
            count = 0;
            foreach (string campo in Campos)
            {
                if (count == 0)
                    sp.Append(' ', 56).AppendLine(":" + campo);
                else
                    sp.Append(' ', 54).AppendLine(", :" + campo);
                count++;
            }
            sp.Append(' ', 50).AppendLine(")\";");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 20).AppendLine("$dataObject = null;");
            sp.Append(' ', 20).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("parent::get_database()->query($query);");
            sp.AppendLine();
            sp.AppendLine();
            for (int i = 0; i < Campos.Count; i++)
            {
                if (!String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("id") >= 0)
                {
                    sp.Append(' ', 30).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "") + ".Id, " + getDataType(TypeField[i]) + ");");
                }
                else if (!String.IsNullOrEmpty(Campos[i]))
                {
                    sp.Append(' ', 30).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i] + ", " + getDataType(TypeField[i]) + ");");
                }

            }
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("parent::get_database()->execute();");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("if( parent::get_database()->row_count() == 0) {");
            sp.Append(' ', 40).AppendLine("throw new Exception(\"Some error occured while trying to insert the client\", 500);");
            sp.Append(' ', 30).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("$dataObject = new " + txtClasse.Text + "VO();");
            sp.Append(' ', 30).AppendLine("$dataObject->Id = parent::get_database()->last_inserted_id();");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("return $dataObject;");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("} catch(Exception $ex) {");
            sp.Append(' ', 20).AppendLine("throw $ex;");
            sp.Append(' ', 10).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 5).AppendLine("}");

            return sp.ToString();
        }

        private string gerarDAOUpdate()
        {
            var sp = new StringBuilder();
            var tabela = cmbTabela.SelectedItem.ToString();
            int count = 0;
            sp.AppendLine("    public function update(ValueObject $objVO) {");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("try{");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("$query =  \" UPDATE " + tabela);
            sp.Append(' ', 45).AppendLine("SET");
            foreach (string campo in Campos)
            {
                if (count == 0)
                    sp.Append(' ', 57).Append(campo).AppendLine(" = :" + campo);
                else
                    sp.Append(' ', 55).Append(", " + campo).AppendLine(" = :" + campo);
                count++;
            }
            sp.Append(' ', 36).AppendLine("\";");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 20).AppendLine("$dataObject = null;");
            sp.Append(' ', 20).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("parent::get_database()->query($query);");
            sp.AppendLine();
            sp.AppendLine();
            for (int i = 0; i < Campos.Count; i++)
            {
                if (!String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("id") >= 0)
                {
                    sp.Append(' ', 30).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "") + ".Id, " + getDataType(TypeField[i]) + ");");
                }
                else if (!String.IsNullOrEmpty(Campos[i]))
                {
                    sp.Append(' ', 30).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i] + ", " + getDataType(TypeField[i]) + ");");
                }

            }
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("parent::get_database()->execute();");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("if( parent::get_database()->row_count() == 0) {");
            sp.Append(' ', 30).AppendLine("throw new Exception(\"Some error occured while trying to update the client\", 500);");
            sp.Append(' ', 30).AppendLine("}else{");
            sp.Append(' ', 40).AppendLine("return true;");
            sp.Append(' ', 30).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("} catch(Exception $ex) {");
            sp.Append(' ', 20).AppendLine("throw $ex;");
            sp.Append(' ', 10).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 5).AppendLine("}");

            return sp.ToString();
        }

        private string gerarDAORead()
        {
            var sp = new StringBuilder();
            var tabela = cmbTabela.SelectedItem.ToString();



            sp.AppendLine("    public function read(ValueObject $objVO) {");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("try{");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("$query =  \"" + txaConsultaSql.Text + " WHERE 1 = 1 \"");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            for (int i = 0; i < Campos.Count; i++)
            {
                if (!String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("id") >= 0)
                {
                    string field = Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "");
                    sp.Append(' ', 30).AppendLine("if (is_object($objVO->" + field + ") && $objVO->" + field + ".Id > 0) {");
                    sp.Append(' ', 40).AppendLine("$query .= \" AND " + Campos[i] + " = : " + Campos[i] + "\";");
                    sp.Append(' ', 30).AppendLine("}");
                }
                else if (!String.IsNullOrEmpty(Campos[i]))
                {
                    if (getDataType(TypeField[i]).Equals("PDO::PARAM_INT"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " > 0) {");
                    else if (getDataType(TypeField[i]).Equals("PDO::PARAM_STR"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " != null) {");

                    sp.Append(' ', 40).AppendLine("$query .= \" AND " + Campos[i] + " = :" + Campos[i] + "\";");
                    sp.Append(' ', 30).AppendLine("}");
                }
                sp.AppendLine();
            }
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 20).AppendLine("parent::get_database()->query($query.\" ORDER BY " + tabela + ".Id DESC LIMIT 1\");");

            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            for (int i = 0; i < Campos.Count; i++)
            {
                if (!String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("id") >= 0)
                {
                    string field = Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "");
                    sp.Append(' ', 30).AppendLine("if (is_object($objVO->" + field + ") && $objVO->" + field + ".Id > 0) {");
                    sp.Append(' ', 40).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "") + ".Id, " + getDataType(TypeField[i]) + ");");
                    sp.Append(' ', 30).AppendLine("}");
                }
                else if (!String.IsNullOrEmpty(Campos[i]))
                {
                    if (getDataType(TypeField[i]).Equals("PDO::PARAM_INT"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " > 0) {");
                    else if (getDataType(TypeField[i]).Equals("PDO::PARAM_STR"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " != null) {");

                    sp.Append(' ', 40).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i] + ", " + getDataType(TypeField[i]) + ");");
                    sp.Append(' ', 30).AppendLine("}");
                }
                sp.AppendLine();
            }
            sp.Append(' ', 20).AppendLine("}");


            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("$resultSet = parent::get_database()->result_set();");
            sp.Append(' ', 20).AppendLine("$dataObject = null;");
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 20).AppendLine("if(count($resultSet) == 1) {");
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("$objectVO = new " + txtClasse.Text + "VO");

            foreach (string campo in Campos)
            {
                if (!String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("id") >= 0)
                {
                    sp.Append(' ', 30).AppendLine("$objectVO->" + campo.Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "") + ".Id = $resultSet[0]['" + campo + "']");
                }
                else if (!String.IsNullOrEmpty(campo))
                {
                    sp.Append(' ', 30).AppendLine("$objectVO->" + campo + " = $resultSet[0]['" + campo + "']");
                }
            }

            sp.Append(' ', 30).AppendLine("$dataObject = $objectVO;");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("return $dataObject;");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("} catch(Exception $ex) {");
            sp.Append(' ', 20).AppendLine("throw $ex;");
            sp.Append(' ', 10).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 5).AppendLine("}");

            return sp.ToString();
        }

        private string gerarDAOReadAll()
        {
            var sp = new StringBuilder();
            var tabela = cmbTabela.SelectedItem.ToString();

            sp.AppendLine("    public function readAll(ValueObject $objVO) {");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("try{");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("$query =  \"" + txaConsultaSql.Text + " WHERE 1 = 1 \"");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            for (int i = 0; i < Campos.Count; i++)
            {
                if (!String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("id") >= 0)
                {
                    string field = Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "");
                    sp.Append(' ', 30).AppendLine("if (is_object($objVO->" + field + ") && $objVO->" + field + ".Id > 0) {");
                    sp.Append(' ', 40).AppendLine("$query .= \" AND " + Campos[i] + " = : " + Campos[i] + "\";");
                    sp.Append(' ', 30).AppendLine("}");
                }
                else if (!String.IsNullOrEmpty(Campos[i]))
                {
                    if (getDataType(TypeField[i]).Equals("PDO::PARAM_INT"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " > 0) {");
                    else if (getDataType(TypeField[i]).Equals("PDO::PARAM_STR"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " != null) {");

                    sp.Append(' ', 40).AppendLine("$query .= \" AND " + Campos[i] + " = :" + Campos[i] + "\";");
                    sp.Append(' ', 30).AppendLine("}");
                }
                sp.AppendLine();
            }
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 20).AppendLine("parent::get_database()->query($query.\" ORDER BY " + tabela + ".Id DESC \");");

            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            for (int i = 0; i < Campos.Count; i++)
            {
                if (!String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(Campos[i]) && Campos[i].Length > 2 && Campos[i].ToLower().IndexOf("id") >= 0)
                {
                    string field = Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "");
                    sp.Append(' ', 30).AppendLine("if (is_object($objVO->" + field + ") && $objVO->" + field + ".Id > 0) {");
                    sp.Append(' ', 40).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i].Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "") + ".Id, " + getDataType(TypeField[i]) + ");");
                    sp.Append(' ', 30).AppendLine("}");
                }
                else if (!String.IsNullOrEmpty(Campos[i]))
                {
                    if (getDataType(TypeField[i]).Equals("PDO::PARAM_INT"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " > 0) {");
                    else if (getDataType(TypeField[i]).Equals("PDO::PARAM_STR"))
                        sp.Append(' ', 30).AppendLine("if ($objVO->" + Campos[i] + " != null) {");

                    sp.Append(' ', 40).AppendLine("parent::get_database()->bind(':" + Campos[i] + "', $objVO->" + Campos[i] + ", " + getDataType(TypeField[i]) + ");");
                    sp.Append(' ', 30).AppendLine("}");
                }
                sp.AppendLine();
            }
            sp.Append(' ', 20).AppendLine("}");


            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("$resultSet = parent::get_database()->result_set();");
            sp.Append(' ', 20).AppendLine("$dataObject = null;");
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 20).AppendLine("if(count($resultSet) > 0) {");
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("$objectList = new ArrayList();");
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("foreach($resultSet as $result) {");
            sp.AppendLine();
            sp.Append(' ', 40).AppendLine("$objectVO = new " + txtClasse.Text + "VO");
            foreach (string campo in Campos)
            {
                if (!String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("_id") >= 0 || !String.IsNullOrEmpty(campo) && campo.Length > 2 && campo.ToLower().IndexOf("id") >= 0)
                {
                    sp.Append(' ', 40).AppendLine("$objectVO->" + campo.Replace("_id", "").Replace("id", "").Replace("_Id", "").Replace("_Id", "") + ".Id = $result['" + campo + "']");
                }
                else if (!String.IsNullOrEmpty(campo))
                {
                    sp.Append(' ', 40).AppendLine("$objectVO->" + campo + " = $result['" + campo + "']");
                }

            }
            sp.Append(' ', 40).AppendLine("$objectList->add($objectVO , $objectVO->Id);");
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("$dataObject = $objectList;");
            sp.AppendLine();
            sp.Append(' ', 40).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("return $dataObject;");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("} catch(Exception $ex) {");
            sp.Append(' ', 20).AppendLine("throw $ex;");
            sp.Append(' ', 10).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 5).AppendLine("}");


            return sp.ToString();
        }

        private string gerarDAODelete()
        {
            var sp = new StringBuilder();
            var tabela = cmbTabela.SelectedItem.ToString();
            sp.AppendLine("    public function delete(ValueObject $objVO) {");
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("try{");
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("$query =  \" DELETE FROM " + tabela + " WHERE Id = :Id\";");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();

            sp.Append(' ', 30).AppendLine("$dataObject = null;");
            sp.Append(' ', 30).AppendLine("if(is_object($objVO)) {");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 40).AppendLine("parent::get_database()->query($query);");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 40).AppendLine("parent::get_database()->bind(':Id', $objVO->Id , PDO::PARAM_INT);");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 40).AppendLine("parent::get_database()->execute();");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 40).AppendLine("if( parent::get_database()->row_count() == 0) {");
            sp.Append(' ', 50).AppendLine("throw new Exception(\"Some error occured while trying to delete the client\", 500);");
            sp.Append(' ', 40).AppendLine("}else{");
            sp.Append(' ', 50).AppendLine("return true;");
            sp.Append(' ', 40).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 30).AppendLine("}");
            sp.AppendLine();
            sp.AppendLine();
            sp.AppendLine();
            sp.Append(' ', 20).AppendLine("} catch(Exception $ex) {");
            sp.Append(' ', 30).AppendLine("throw $ex;");
            sp.Append(' ', 20).AppendLine("}");
            sp.AppendLine();
            sp.Append(' ', 10).AppendLine("}");

            return sp.ToString();
        }

        private void txaConsultaSql_TextChanged(object sender, EventArgs e)
        {

        }

        private string getDataType(string type)
        {
            if (type.ToLower().IndexOf("int") >= 0
                || type.ToLower().IndexOf("bigint") >= 0)
                return "PDO::PARAM_INT";
            else if (type.ToLower().IndexOf("varchar") >= 0
                || type.ToLower().IndexOf("date") >= 0
                || type.ToLower().IndexOf("datetime") >= 0
                || type.ToLower().IndexOf("longtext") >= 0)
                return "PDO::PARAM_STR";

            return "";
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
