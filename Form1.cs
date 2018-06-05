using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastro frm = new Cadastro();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e) //traz os registros cadastrados em um componente datagridview 
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM estoque_tb", conexao.conectar()); //consulta

            SqlDataAdapter sqlAdpter = new SqlDataAdapter();
            sqlAdpter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlAdpter.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            sqlAdpter.Update(dt);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /**
             * Excluir
             Primeiramente no desing selecione o datagridview e
             passe a propriedade "SelectionMode=FullRowSelect"
             */
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            SqlCommand cmd = new SqlCommand("DELETE FROM estoque_tb WHERE id= '" + id.ToString() + "'", conexao.conectar());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Excluido com sucesso");
        }
    }
}
