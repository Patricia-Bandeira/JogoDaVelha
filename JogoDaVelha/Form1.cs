using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        bool xis = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bt11.Click += new EventHandler(BClick);
            bt12.Click += new EventHandler(BClick);
            bt13.Click += new EventHandler(BClick);
            bt21.Click += new EventHandler(BClick);
            bt22.Click += new EventHandler(BClick);
            bt23.Click += new EventHandler(BClick);
            bt31.Click += new EventHandler(BClick);
            bt32.Click += new EventHandler(BClick);
            bt33.Click += new EventHandler(BClick);

            foreach (Control item in this.Controls)// percorre a lista de todos os controles 
            {
                if (item is Button) // se o item for um botao faça  
                {
                    item.TabStop = false; // desliga a propriedade TabStop, para que o jogador nao seja influenciado a apertar 
                                          // o proximo botão 
                }

            }
        }
        private void BClick(object sender, EventArgs e)
        {
            ((Button)sender).Text = this.xis ? "X" : "O";// se o texto X for true ou vise e versa 
            ((Button)sender).Enabled = false;

            verificarGanhador();

            xis = !xis;
            label1.Text = string.Format("{0}, é a sua vez!", this.xis ? "x" : "0");
        }

        private void verificarGanhador()
        {



            if ( 
               bt11.Text != String.Empty && bt11.Text == bt12.Text && bt12.Text == bt13.Text || //linha 1  
               bt21.Text != String.Empty && bt21.Text == bt22.Text && bt22.Text == bt23.Text || //linha 2
               bt31.Text != String.Empty && bt31.Text == bt32.Text && bt32.Text == bt33.Text || //linha 3

               bt11.Text != String.Empty && bt11.Text == bt21.Text && bt21.Text == bt31.Text || //coluna 1
               bt12.Text != String.Empty && bt12.Text == bt22.Text && bt22.Text == bt32.Text || //coluna 2
               bt13.Text != String.Empty && bt13.Text == bt23.Text && bt23.Text == bt33.Text || //coluna 3


               bt11.Text != String.Empty && bt11.Text == bt22.Text && bt22.Text == bt33.Text || // diagonal  \
               bt13.Text != String.Empty && bt13.Text == bt22.Text && bt22.Text == bt31.Text    // diagonal  /
               )
            {
                MessageBox.Show(string.Format("O ganhador é o [{0}]", xis ? "X" : "O"), " Voce é o Vencedor", // da uma messagem referindo ao jogador que ganhou
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Reiniciar();
            }
            else
            {
                verificarEmpate();
            }
        }
        private void verificarEmpate()
        {

            bool todoDesabilitados = true;

            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Enabled)
                {
                    todoDesabilitados = false;
                    break;
                }
            }


            if (todoDesabilitados)
            {
                MessageBox.Show(String.Format("deu empate"), "OPs !!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Reiniciar();

            }

        }


        private void Reiniciar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                    item.Enabled = true;
                item.Text = String.Empty;
            }
        }




    }
}

