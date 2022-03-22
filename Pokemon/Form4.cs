using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string caminho = @"C:\Pokemon\Pokemon\bin\Debug\"; 
        private void travarBtn()
        {
            textBox1.Enabled = false;
            label3.Enabled = false;
            button1.Enabled = false;
            comboBox2.SelectedItem = "";
            comboBox2.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox2.Clear();
            textBox1.Clear();
            comboBox1.Focus();
        }
        private void carregarCombobox()
        {
            foreach (string item in Directory.GetDirectories(caminho))
            {
                comboBox1.Items.Add(item.Remove(0, caminho.Length));
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            carregarCombobox();
            travarBtn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja EXCLUIR o usúario? Isso resultará na perda de todos os Pokemons e todo o progresso deste usuário!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && comboBox1.Text != "")
            {
                if (Directory.Exists(caminho + comboBox1.Text))//verifica a existencia da pasta
                { string caminhoPokemons = caminho + comboBox1.Text + @"\Pokemons.txt";
                    DirectoryInfo diretorios = new DirectoryInfo(caminho + comboBox1.Text);
                    foreach (FileInfo arquivos in diretorios.GetFiles()) //deleta todos os arquivos dentro da pasta do usuario
                    {
                        arquivos.Delete();
                    }
                    Directory.Delete(caminho + comboBox1.Text); //deleta a pasta do usuario
                    label1.Text = "Usuário excluido com sucesso!";
                    label1.ForeColor = Color.Green;
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    travarBtn();
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void voltarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Editar nome do do usuário")
            {
                textBox1.Enabled = true;
                label3.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false; 
                label3.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = comboBox1.Text != "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != textBox1.Text)
            {
                string nomeAntigo = comboBox1.Text; string nomeNovo = textBox1.Text;
                File.Move(caminho + nomeAntigo + @"\" + nomeAntigo + @".txt", caminho + nomeAntigo + @"\" + nomeNovo + @".txt"); //renomeia o arquivo do usuario 
                Directory.Move(caminho + comboBox1.Text, caminho + textBox1.Text); //renomeia a pasta do usuario
                                                                                   //reescreve a primeira linha no arquivo 
                int linhaEditar = 1; //linha 1
                string novoTexto = textBox1.Text;
                string[] arrLinha = File.ReadAllLines(caminho + nomeNovo + @"\" + nomeNovo + @".txt");
                arrLinha[linhaEditar - 1] = novoTexto;////////
                File.WriteAllLines(caminho + nomeNovo + @"\" + nomeNovo + @".txt", arrLinha);
                comboBox1.Items.Clear();
                label6.Text = "Usuário alterado com sucesso!";
                label6.ForeColor = Color.Green;
                travarBtn();
                foreach (string item in Directory.GetDirectories(caminho)) //"atualizar" a combobox
                {
                    comboBox1.Items.Add(item.Remove(0, caminho.Length));
                }
            }
            else
            {
                MessageBox.Show("Usuário já está em uso!");
            }
        }

        private void button3_Click(object sender, EventArgs e) //Btn procurar
        {
            int usuarioEncontrado = 0;
            foreach (string item in comboBox1.Items)
            {
                if (item == textBox2.Text)
                {
                    MessageBox.Show("Usuário '" + item + "' Encontrado!", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.SelectedItem = item;
                    usuarioEncontrado = 1;
                }
            }
            if (usuarioEncontrado == 0)
            {
                MessageBox.Show("Usuário não encontrado!", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
    }
}
