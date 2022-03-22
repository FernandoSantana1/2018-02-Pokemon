using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pokemon
{
    class Pokemon
    {
        public string nome { get; set; }
        public string apelido { get; set; }
        public int identificador { get; set; }
        public string evolucao { get; set; }
        public string imagem { get; set; }
        public double peso { get; set; }
        public double altura { get; set; }
        public int efeito { get; set; }
        public double forca { get; set; }
        public string caminho { get; set; }
        public void calcularForca()
        {
            forca = altura * peso + efeito;
        }
        public void calcularID()
        {
            Random random = new Random();
            identificador = random.Next(1111,9999); 
        }
        public void calcularEfeito()
        {
            Random random = new Random();
            efeito = random.Next(1, 6); //numeros aleatorios entre 1 e 6
        }
        public void mostrar()
        {
            Console.WriteLine(nome + Environment.NewLine + "#" + identificador + Environment.NewLine + evolucao + Environment.NewLine + imagem + Environment.NewLine + peso + Environment.NewLine + altura + Environment.NewLine + efeito + Environment.NewLine + forca +Environment.NewLine +"caminho => "+ caminho);
        }
        public void salvartudo()
        {
            using (StreamWriter arquivo = File.AppendText(caminho + @"\Pokemons.txt"))
            {
                arquivo.WriteLine("#" + identificador); 
                arquivo.WriteLine(nome);
                arquivo.WriteLine(apelido);
                arquivo.WriteLine(evolucao);
                arquivo.WriteLine(peso);
                arquivo.WriteLine(altura);
                arquivo.WriteLine(efeito);
                arquivo.WriteLine(forca);
                arquivo.WriteLine(imagem);
            }
        }
    }
}
