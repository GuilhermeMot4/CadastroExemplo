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
    public partial class Editar : Form
    {
        int Id;
        public Editar(int id) //recebe o id
        {          
            InitializeComponent();
            Id = id; 
        }

        private void Editar_Load(object sender, EventArgs e) //preenche os campos nos formulários com os dados do registro
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM estoque_tb WHERE id = '" +Id+ "'", conexao.conectar()); //comando
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows) {
                while (reader.Read()) {
                    textBox1.Text = reader.GetString(1); //transfere o valor recebido para um componente do form
                    textBox2.Text = reader.GetString(2);
                    maskedTextBox1.Text = reader.GetString(3);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //ao clicar no botão Editar
        {
            SqlCommand cmd = new SqlCommand("UPDATE estoque_tb SET nome = @nome, qtd = @qtd, data = @data WHERE id = '"+Id+"'", conexao.conectar()); //comando
            cmd.Parameters.AddWithValue("@nome", textBox1.Text); //parametro nome
            cmd.Parameters.AddWithValue("@qtd", textBox2.Text);  //parametro qtd
            cmd.Parameters.AddWithValue("@data", maskedTextBox1.Text); //parametro data
            cmd.ExecuteNonQuery(); //executa comando            
        }
    }
}
