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
    public partial class AsignarTipo : Form
    {
        public int accion;
        Button camino, pared, inicio, fin;
        public AsignarTipo()
        {
            InitializeComponent();
            camino = btn_camino;
            pared = btn_pared;
            inicio = btn_inicio;
            fin = btn_fin;
            camino.Click += new EventHandler(asignar);
            pared.Click += new EventHandler(asignar);
            inicio.Click += new EventHandler(asignar);
            fin.Click += new EventHandler(asignar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void asignar(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Tag)
            {
                case "camino":
                    this.DialogResult = DialogResult.OK;
                    accion = 1;
                    this.Close();
                    break;
                case "pared":
                    this.DialogResult = DialogResult.OK;
                    accion = 2;
                    this.Close();
                    break;
                case "inicio":
                    this.DialogResult = DialogResult.OK;
                    accion = 3;
                    this.Close();
                    break;
                case "fin":
                    this.DialogResult = DialogResult.OK;
                    accion = 4;
                    this.Close();
                    break;
            }
        }
    }
}
