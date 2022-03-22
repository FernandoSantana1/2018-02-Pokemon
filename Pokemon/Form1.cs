using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokemon
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button1.Enabled = false;
        }
        

            private void button1_Click(object sender, EventArgs e) //cadastrar
        {
            string pasta = @"C:\Pokemon\Pokemon\bin\Debug\" + textBox1.Text + @"\";
            if (!Directory.Exists(pasta))//se a pasta do usuario nao existir ele cria
            {
                if ((textBox1.Text != "") && (textBox2.Text != ""))
                {
                    Directory.CreateDirectory(pasta);
                    //escreve as informacoes de login no arquivo dentro da pasta
                    using (StreamWriter arquivo = new StreamWriter(pasta + textBox1.Text + ".txt", false, Encoding.Default))
                    {
                        arquivo.WriteLine(textBox1.Text); // salvar o usuario
                        arquivo.WriteLine(textBox2.Text); // salvar a senha
                        label1.Text = "Usuário cadastrado com sucesso!";
                        label1.ForeColor = Color.Green;
                    }
                }
                else
                {
                    label1.Text = "Informe usuário e a senha!";
                    label1.ForeColor = Color.Red;
                }
            }
            else
            {
                label1.Text = "Usúario já cadastrado!";
                label1.ForeColor = Color.Red;
            }
        }  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            button1.Enabled = !(string.IsNullOrWhiteSpace(textBox1.Text));
            button2.Enabled = !(string.IsNullOrWhiteSpace(textBox1.Text)); //! de nada ou space
            button3.Enabled = !(string.IsNullOrWhiteSpace(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e) //entrar
        {
            string caminho = @"C:\Pokemon\Pokemon\bin\Debug\" + textBox1.Text + @"\" + textBox1.Text + ".txt";
              FileInfo existeArquivo = new FileInfo(caminho); //verifica se o arquivo do usuario existe

                if (existeArquivo.Exists)
                {
                    using (StreamReader leitor = new StreamReader(caminho))
                    {
                        string linha1 = leitor.ReadLine(); //usuario
                        string linha2 = leitor.ReadLine(); //senha
                        if ((linha1 == textBox1.Text) && (linha2 == textBox2.Text))//verifica o usuario e senha
                        {
                            this.Hide();
                            Form3 form3 = new Form3();
                            form3.pasta1 = @"C:\Pokemon\Pokemon\bin\Debug\" + textBox1.Text + @"\"; //passa para o form3 o nome do usuario!
                            form3.Closed += (s, args) => this.Close();
                            form3.Show();
                        }
                        else
                        {
                            label1.Text = "Senha incorreta!";
                            label1.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    label1.Text = "Usuário não cadastrado!";
                    label1.ForeColor = Color.Red;
                }
                
            
        }
    
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
