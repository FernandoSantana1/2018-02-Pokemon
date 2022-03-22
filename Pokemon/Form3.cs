using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        private void excluirPokemon()
        {
            var file = new List<string>(File.ReadAllLines(pasta1 + @"Pokemons.txt"));
            for (int i = 0; i < 9; i++)
            {
                file.RemoveAt(0);// 0 = posicao da linha que irá ser removida
                File.WriteAllLines(pasta1 + @"Pokemons.txt", file.ToArray());
            }
        }
        private void carregarCombobox()
        {
            if (File.Exists(pasta1 + "Pokemons.txt"))
            {
                using (StreamReader lerLinha = new StreamReader(pasta1 + @"\Pokemons.txt"))
                {
                    string linha1;
                    while ((linha1 = lerLinha.ReadLine()) != null) //ID
                    {
                        string linha2 = lerLinha.ReadLine();//nome
                        string linha3 = lerLinha.ReadLine();//apelido
                        string linha4 = lerLinha.ReadLine();//evolucao
                        string linha5 = lerLinha.ReadLine();//altura
                        string linha6 = lerLinha.ReadLine();//peso
                        string linha7 = lerLinha.ReadLine();//efeito
                        string linha8 = lerLinha.ReadLine();//forca
                        string linha9 = lerLinha.ReadLine();//imagem
                        comboBox1.Items.Add(linha1 + "   " + linha2 + "   " + linha8 + " PW" + "   " + linha3);
                    }
                }
            }
        }
        private void progresso()
        {
            string linha = ""; int contador = 0; int linhaComeca = 0;
            using (StreamReader lerLinha = new StreamReader(pasta1 + "Pokemons.txt"))
            {
                while ((linha = lerLinha.ReadLine()) != null)//Id
                {
                    contador++;
                    if (comboBox2.SelectedItem.ToString() == "ID")
                    {
                        if (linha == comboBox1.SelectedItem.ToString().Remove(5)) //.remove(5) = para remover tudo que tem após a 5 posicao na textbox(tudo após o id))
                        {
                            linhaComeca = contador + 7;
                            double melhoria = 0.05 * Convert.ToDouble(lb6.Text);
                            melhoria = Math.Round(melhoria, 1); //arredonda os valores
                            double total = melhoria + Convert.ToDouble(lb6.Text);
                            total = Math.Round(total, 1);
                            lb6.Text = total.ToString();
                            MessageBox.Show("Parabéns você ganhou " + melhoria.ToString() + " pontos de força", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (linha == comboBox1.SelectedItem.ToString().Substring(comboBox1.SelectedItem.ToString().Length - 5)) //se a linha do arquivo for igual aos 5 ultimos caracteres do item selecionado (ID)
                        {
                            linhaComeca = contador + 7;
                            double melhoria = 0.05 * Convert.ToDouble(lb6.Text);
                            melhoria = Math.Round(melhoria, 1); //arredonda os valores
                            double total = melhoria + Convert.ToDouble(lb6.Text);
                            total = Math.Round(total, 1);
                            lb6.Text = total.ToString();
                            MessageBox.Show("Parabéns você ganhou " + melhoria.ToString() + " pontos de força", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            //salvar progresso

            int linhaEditar = linhaComeca; //linha 8
            string novoTexto = lb6.Text;
            string[] arrLinha = File.ReadAllLines(pasta1 + @"Pokemons.txt");
            arrLinha[linhaEditar - 1] = novoTexto;
            File.WriteAllLines(pasta1 + @"Pokemons.txt", arrLinha);
            MessageBox.Show("Arquivo salvo com sucesso!", "Salvou", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void desbBtn()
        {
            label3.Enabled = true; label5.Enabled = true; label12.Enabled = true;
            textBox2.Text = ""; comboBox1.Enabled = true; comboBox2.Enabled = true; comboBox2.Text = "ID";
            button3.Enabled = true;
        }
        public string pasta1 { get; set; }//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void criarPokémonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.pasta = pasta1;
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            carregarCombobox();
            comboBox2.SelectedIndex = 3;
        }
        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (comboBox2.SelectedItem.ToString() != "")
            {
                comboBox1.Items.Clear();
                if (File.Exists(pasta1 + "Pokemons.txt"))
                {
                    using (StreamReader lerLinha = new StreamReader(pasta1 + @"\Pokemons.txt"))
                    {
                        string linha1;
                        while ((linha1 = lerLinha.ReadLine()) != null) //ID
                        {

                            string linha2 = lerLinha.ReadLine();//nome
                            string linha3 = lerLinha.ReadLine();//apelido
                            string linha4 = lerLinha.ReadLine();//evolucao
                            string linha5 = lerLinha.ReadLine();//altura
                            string linha6 = lerLinha.ReadLine();//peso
                            string linha7 = lerLinha.ReadLine();//efeito
                            string linha8 = lerLinha.ReadLine();//forca
                            string linha9 = lerLinha.ReadLine();//imagem

                            if (comboBox2.SelectedItem.ToString() == "Alfabética")
                            {
                                comboBox1.Items.Add(linha2 + "   " + linha3 + "   " + linha8 + " PW" + "   " + linha1);
                            }
                            if (comboBox2.SelectedItem.ToString() == "Força")
                            {
                                comboBox1.Items.Add(linha8 + " PW" + "   " + linha2 + "   " + linha3 + "   " + linha1);
                            }
                            if (comboBox2.SelectedItem.ToString() == "Altura")
                            {
                                comboBox1.Items.Add(linha5 + "   " + linha2 + "   " + linha3 + "   " + linha1);
                            }
                            if (comboBox2.SelectedItem.ToString() == "ID")
                            {
                                comboBox1.Items.Add(linha1 + "   " + linha2 + "   " + linha3 + "   " + linha8 + " PW");
                            }
                            if (comboBox2.SelectedItem.ToString() == "Apelido")
                            {
                                comboBox1.Items.Add(linha3 + "   " + linha2 + "   " + linha8 + " PW" + "   " + linha1);
                            }
                            comboBox1.Sorted = true;
                        }
                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //carregar dados do pokemon
        {
            button1.Enabled = comboBox1.Text != "";
            button3.Enabled = comboBox1.Text != "";
            label7.Text = "";
            using (StreamReader lerLinha = new StreamReader(pasta1 + @"Pokemons.txt"))
            {
                string linha;
                while ((linha = lerLinha.ReadLine()) != null)//Id
                {
                    if (comboBox1.SelectedItem != null)
                    {
                        if (comboBox2.SelectedItem.ToString() == "ID")
                        {
                            if (linha == comboBox1.SelectedItem.ToString().Remove(5))
                            {
                                string linha1 = lerLinha.ReadLine();//nome
                                string linha2 = lerLinha.ReadLine();//apelido
                                string linha3 = lerLinha.ReadLine();//evolucao
                                string linha4 = lerLinha.ReadLine();//altura
                                string linha5 = lerLinha.ReadLine();//peso
                                string linha6 = lerLinha.ReadLine();//efeito
                                string linha7 = lerLinha.ReadLine();//forca
                                string linha8 = lerLinha.ReadLine();//imagem
                                pictureBox1.Image = new Bitmap(linha8);
                                lb1.Text = linha1;
                                lb2.Text = linha2;
                                lb3.Text = linha;
                                lb4.Text = linha3;
                                lb5.Text = linha6;
                                lb6.Text = linha7;
                            }
                        }
                        else
                        {
                            if (linha == comboBox1.SelectedItem.ToString().Substring(comboBox1.SelectedItem.ToString().Length - 5)) //se a linha do arquivo for igual aos 5 ultimos caracteres do item selecionado (ID)
                            {
                                string linha1 = lerLinha.ReadLine();//nome
                                string linha2 = lerLinha.ReadLine();//apelido
                                string linha3 = lerLinha.ReadLine();//evolucao
                                string linha4 = lerLinha.ReadLine();//altura
                                string linha5 = lerLinha.ReadLine();//peso
                                string linha6 = lerLinha.ReadLine();//efeito
                                string linha7 = lerLinha.ReadLine();//forca
                                string linha8 = lerLinha.ReadLine();//imagem
                                pictureBox1.Image = new Bitmap(linha8);
                                lb1.Text = linha1;
                                lb2.Text = linha2;
                                lb3.Text = linha;
                                lb4.Text = linha3;
                                lb5.Text = linha6;
                                lb6.Text = linha7;
                            }
                        }
                    }
                }
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Treinar")
            {
                button1.Text = "Parar";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Enabled = false;
                timer1.Start();
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja parar a evolução? Todo o progresso será perdido!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    button1.Text = "Treinar";
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    button3.Enabled = true;
                    //resetar o cronometro
                    timer1.Stop();
                    segundos = 0; minutos = 0; horas = 0;
                    lblCronometro.Text = "00" + ":" + "00" + ":" + "00";
                }
            }
        }
        int segundos = 0; int minutos = 0; int horas = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 60)
            {
                minutos++;
                if (minutos == 60)
                {
                    horas++;
                    progresso();
                }
                minutos = minutos % 60;
            }
            segundos = segundos % 60;
            lblCronometro.Text = horas.ToString("00") + ":" + minutos.ToString("00") + ":" + segundos.ToString("00");
        }

        private void button3_Click(object sender, EventArgs e) //btn excluir
        {
            if (MessageBox.Show("Tem certeza que deseja este Pokémon? Todo o progresso dele será perdido!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                button1.Enabled = false;
                if (comboBox1.SelectedItem != null)
                {
                    string linha = ""; int contador = 0; int posicaoExcluir = 0;
                    using (StreamReader lerLinha = new StreamReader(pasta1 + "Pokemons.txt"))
                    {
                        while ((linha = lerLinha.ReadLine()) != null)//Id
                        {
                            if (linha != comboBox1.SelectedItem.ToString().Remove(5)) //.remove(5) = para remover tudo que tem após a 5 posicao na textbox(tudo após o id))
                            {
                                contador++;
                            }
                            if (linha == comboBox1.SelectedItem.ToString().Remove(5)) //.remove(5) = para remover tudo que tem após a 5 posicao na textbox(tudo após o id))
                            {
                                posicaoExcluir = contador;
                            }
                        }
                    }//Exclui as linhas do pokemon...
                    var file = new List<string>(File.ReadAllLines(pasta1 + @"Pokemons.txt"));
                    for (int i = 0; i < 9; i++)
                    {
                        file.RemoveAt(posicaoExcluir);//posicao da linha que irá ser removida
                        File.WriteAllLines(pasta1 + @"Pokemons.txt", file.ToArray());
                    }
                    label7.Text = "Pokemon excluido com sucesso!";
                    label7.ForeColor = Color.Green;
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                }
                else
                {
                    label7.Text = "Selecione o pokemon que deseja excluir!";
                    label7.ForeColor = Color.Red;
                }

            }
        }
        private void voltarToolStripMenuItem_Click(object sender, EventArgs e) //voltar
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int encontrarPokemon = 0;
            foreach (string item in comboBox1.Items)
            {
                if (item.Remove(5) == "#" + textBox2.Text)
                {
                    comboBox1.Text = item;
                    desbBtn();
                    encontrarPokemon = 1;
                }
            }
            if(encontrarPokemon == 0)
            {
                MessageBox.Show("Pokémon não encontrado!", "Pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Enabled = textBox2.Text == ""; label5.Enabled = textBox2.Text == ""; label12.Enabled = textBox2.Text == "";
            comboBox1.Enabled = textBox2.Text == ""; comboBox2.Enabled = textBox2.Text == ""; comboBox2.Text = "ID"; 
            button3.Enabled = textBox2.Text == "";
        }
    }

    
}