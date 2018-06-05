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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //evento do botão
        {
            String query = "Insert into estoque_tb(nome,qtd,data) Values(@nome,@qtd,@data)"; //Consulta BD
            SqlCommand cmd = new SqlCommand(query, conexao.conectar()); //Instância do comando
            cmd.Parameters.AddWithValue("@nome", textBox1.Text);       //parâmetro nome
            cmd.Parameters.AddWithValue("@qtd", textBox2.Text);        //parâmetro qtd
            cmd.Parameters.AddWithValue("@data", maskedTextBox1.Text); //parâmetro data
            cmd.ExecuteNonQuery(); //exexuta comando
            MessageBox.Show("Cadastrado com sucesso"); //feedback
        }
    }
}
