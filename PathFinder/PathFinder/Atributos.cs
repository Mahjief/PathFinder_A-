using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class Atributos : Form
    {
        TextBox tb_alto;
        TextBox tb_ancho;
        public Atributos()
        {
            InitializeComponent();
            tb_alto = textBox1;
            tb_ancho = textBox2;
        }

        private void Atributos_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablero tablero = new Tablero(tb_alto.Text, tb_ancho.Text);
            tablero.ShowDialog();

        }
    }
}
