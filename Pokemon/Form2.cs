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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Btn1.Enabled = false;
            Btn2.Enabled = false;
            Btn3.Enabled = false;
            Btn4.Enabled = false;
            Btn5.Enabled = false;
            Btn6.Enabled = false;
            button1.Enabled = false;
        }
        public string pasta { get; set; }
       
        private void exibirDados()
        {
           
            label9.Text = nome;
            label10.Text = Convert.ToString(peso + " kg");
            label11.Text = Convert.ToString(altura + " m");
            button1.Enabled = true;
        }
        int contador = 0; string nome = ""; double peso = 0; double altura = 0;
        private void button1_Click(object sender, EventArgs e)  //criar
        {
            double altura1 = 0; double peso1 = 0;
            string imagem = ""; string nome = "";
            if (contador == 1)
            {
                nome = "Pikachu";
                altura1 = 0.4;
                peso1 = 6.0;
                imagem = @"C:\Pokemon\pokemons\Pikachu.png";
            }
            if (contador == 2)
            {
                nome = "Bulbasaur";
                altura1 = 0.7;
                peso1 = 6.9;
                imagem = @"C:\Pokemon\pokemons\Bulbasaur.png";
            }
            if (contador == 3)
            {
                nome = "Charlizard";
                altura1 = 0.6;
                peso1 = 8.5;
                imagem = @"C:\Pokemon\pokemons\Charlizard1.png";
            }
            if (contador == 4)
            {
                nome = "Mewtwo";
                altura1 = 2.0;
                peso1 = 122.0;
                imagem = @"C:\Pokemon\pokemons\Mewtwo.png";
            }
            if (contador == 5)
            {
                nome = "Snorlax";
                altura1 = 2.1;
                peso1 = 460.0;
                imagem = @"C:\Pokemon\pokemons\Snorlax.png";
            }
            if (contador == 6)
            {
                nome = "Squirtle";
                altura1 = 0.5;
                peso1 = 9.0;
                imagem = @"C:\Pokemon\pokemons\Squirtle.png";
            }
            if (contador != 0)
            {
                Pokemon p1 = new Pokemon();
                p1.nome = nome;
                p1.apelido = textBox1.Text;
                p1.calcularID();
                p1.evolucao = "Nv. 01";
                p1.imagem = imagem;
                p1.peso = peso1;
                p1.altura = altura1;
                p1.caminho = pasta;
                p1.calcularEfeito();
                p1.calcularForca();
                p1.mostrar();             //enviar as informacoes para a classe "Pokemon"
                p1.salvartudo();
                label13.Text = "Pokémon criado com sucesso!";
                label13.ForeColor = Color.Green;
            }
        }
        

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Btn1_Click(object sender, EventArgs e) //Pikachu
        {
            label13.Text = "";
            contador = 1;
            nome = "Pikachu";
            altura = 0.4;
            peso = 6.0;
            exibirDados();
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            contador = 2;
            nome = "Bulbasaur";
            altura = 0.7;
            peso = 6.9;
            exibirDados();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            contador = 3;
            nome = "Charlizard";
            altura = 0.6;
            peso = 8.5;
            exibirDados();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            contador = 4;
            nome = "Mewtwo";
            altura = 2.0;
            peso = 122.0;
            exibirDados();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            contador = 5;
            nome = "Snorlax";
            altura = 2.1;
            peso = 460.0;
            exibirDados();
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            contador = 6;
            nome = "Squirtle";
            altura = 0.5;
            peso = 9.0;
            exibirDados();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.pasta1 = pasta;
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Btn1.Enabled = textBox1.Text != "";
            Btn2.Enabled = textBox1.Text != "";
            Btn3.Enabled = textBox1.Text != "";
            Btn4.Enabled = textBox1.Text != "";
            Btn5.Enabled = textBox1.Text != "";
            Btn6.Enabled = textBox1.Text != "";
        }
    }
}
