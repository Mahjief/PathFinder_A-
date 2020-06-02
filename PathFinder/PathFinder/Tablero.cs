using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PathFinder
{
    public partial class Tablero : Form
    {
        public static int CAMINO = 1;
        public static int PARED = 2;
        public static int INICIO = 3;
        public static int FIN = 4;

        class Maestro
        {
            List<List<Nodo>> Matriz;
            List<Pair<int,int> > ListaAbierta;
            List<Pair<int,int> > ListaCerrada;
            Pair<int, int> fin;
            public int Alto;
            public int Ancho;
            bool Encontrado;
            int Paredes;
            public Pair<int, int> Pivot;
            Control control = new Control();
            public Maestro(int Alto, int Ancho) {
                this.Matriz = new List<List<Nodo>>();
                this.ListaAbierta = new List<Pair<int, int>>();
                this.ListaCerrada = new List<Pair<int, int>>();
                fin = new Pair<int, int>(-1, -1);
                Pivot = new Pair<int, int>(-1, -1);
                this.Alto = Alto;
                this.Ancho = Ancho;
                this.Encontrado = false;
                this.Paredes = 0;
            }

            public List<Pair<int, int>> getListaAbierta() { return this.ListaAbierta; }
            public void addListaAbierta(Pair<int, int> id) { this.ListaAbierta.Add(id); }
            public void addListaCerrada(Pair<int, int> id) { this.ListaCerrada.Add(id); }
            public bool findListaCerrada(Pair<int,int> nodo) {
                bool v = false;
                for(int i = 0; i < ListaCerrada.Count; i++)
                {
                    if(ListaCerrada[i].First == nodo.First && ListaCerrada[i].Second == nodo.Second)
                    {
                        v = true;
                        break;
                    }
                }
                return v;
            }
            public bool getTermina() { return this.Encontrado; }
            public void setTermina() { this.Encontrado = true; }
            public void crearMapa(Control control)
            {
                int ch = 65;
                string Ch;
                for (int i = 0; i < Alto; i++)
                {
                    List<Nodo> fila = new List<Nodo>();
                    for (int j = 0; j < Ancho; j++)
                    {
                        Ch = Convert.ToChar(ch) + Convert.ToString(j + 1);
                        Boton_panel button = new Boton_panel(50 * (j + 1), 50 * (i + 1), Ch);
                        button.setName(Ch);
                        button.panel.Click += new EventHandler(btn_marcar);
                        control.Controls.Add(button.panel);
                        Pair<int, int> coords = new Pair<int, int>(j, i); 
                        Nodo nodo = new Nodo((i * Ancho) + j + 1, null, button, "" + Ch, 0, 0, 0, coords);
                        fila.Add(nodo);
                    }
                    this.Matriz.Add(fila);
                    ch++;
                }
                Button Empezar = new Button();
                Empezar.Text = "Empezar";
                Empezar.Width = 70;
                Empezar.Height = 40;
                Empezar.Left = 50 * (Ancho + 2);
                Empezar.Top = 50;
                Empezar.Click += new EventHandler(clickButton);
                control.Controls.Add(Empezar);

                Label listaAbierta = new Label();
                listaAbierta.Text = "LISTA ABIERTA:";
                listaAbierta.Top = 52 * (Alto + 1);
                listaAbierta.Left = 100;
                Label listaCerrada = new Label();
                listaCerrada.Text = "LISTA CERRADA:";
                listaCerrada.Top = 52 * (Alto + 2);
                listaCerrada.Left = 100;
                Label listaAbiertaL = new Label();
                listaAbiertaL.Text = "";
                listaAbiertaL.Top = 52 * (Alto + 1);
                listaAbiertaL.Left = 200;
                listaAbiertaL.Name = "LA";
                Label listaCerradaL = new Label();
                listaCerradaL.Text = "";
                listaCerradaL.Top = 52 * (Alto + 2);
                listaCerradaL.Left = 200;
                listaCerradaL.Name = "LC";

                control.Controls.Add(listaAbierta);
                control.Controls.Add(listaCerrada);
                control.Controls.Add(listaAbiertaL);
                control.Controls.Add(listaCerradaL);
                control.Height = 52 * (Alto + 4);
                control.Width = 50 * (Ancho + 5);

                this.control = control;

                //control.Controls.Add(panel);

            }
            public void btn_marcar(Object sender, System.EventArgs e)
            {
                Panel b = (Panel)sender;
                Marcar(b);
            }
            public void clickButton(Object sender, System.EventArgs e)
            {
                Button b = (Button)sender;
                if(ListaCerrada.Count > 0)
                {
                    Asterisk(new Pair<int, int>(ListaCerrada[0].First,ListaCerrada[0].Second));
                    if (getTermina())
                    {
                        MessageBox.Show("FINAL!");
                        DibujarCamino();
                    }
                    else MessageBox.Show("NO HAY CAMINO!");
                }

            }
            public void Marcar(Panel b)
            {
                AsignarTipo getTipo = new AsignarTipo();
                var res = getTipo.ShowDialog();
                if (res == DialogResult.OK)
                {
                    int xPos = 0;
                    int yPos = 0;
                    for (int i = 0; i < Alto; i++)
                    {
                        for (int j = 0; j < Ancho; j++)
                        {
                            if (Matriz[i][j].getButton().panel.Name.ToString() == b.Name)
                            {
                                xPos = j;
                                yPos = i;
                                break;
                            }
                        }
                    }
                    switch (getTipo.accion)
                    {
                        case 1:
                            b.BackColor = Color.LightGray;
                            Matriz[yPos][xPos].setTipo(CAMINO);
                            break;
                        case 2:
                            b.BackColor = Color.DarkGray;
                            Matriz[yPos][xPos].setTipo(PARED);
                            Paredes++;
                            break;
                        case 3:
                            if (ListaCerrada.Count == 0)
                            {
                                b.BackColor = Color.Blue;
                                Matriz[yPos][xPos].setTipo(INICIO);
                                Matriz[yPos][xPos].Visitar();
                                Pivot.First = xPos;
                                Pivot.Second = yPos;
                                addListaCerrada(new Pair<int, int>(xPos, yPos));
                            }
                            break;
                        case 4:
                            if (fin.First == -1 && fin.Second == -1)
                            {
                                b.BackColor = Color.Red;
                                Matriz[yPos][xPos].setTipo(FIN);
                                fin.First = xPos;
                                fin.Second = yPos;
                            }
                            break;
                    }
                }
            }
            public int calcH(Pair<int,int> nodo)
            {
                int H = 0;
                if (nodo.First <= fin.First) H += (fin.First - nodo.First) * 10;
                else H += (nodo.First - fin.First) * 10;

                if (nodo.Second <= fin.Second) H += (fin.First - nodo.First) * 10;
                else H += (nodo.Second - fin.Second) * 10;

                return H;
            }
            public void setValues(Pair<int, int> padre, Pair<int, int> nodo)
            {
                int x = nodo.First;
                int y = nodo.Second;
                int X = padre.First;
                int Y = padre.Second;
                int costo;
                if (x == X || y == Y) costo = 10 + Matriz[Y][X].getG();
                else costo = 14 + Matriz[Y][X].getG();
                if (!Matriz[y][x].getVisitado())
                {
                    addListaAbierta(new Pair<int, int>(x, y));
                    Matriz[y][x].Visitar();
                    Matriz[y][x].setG(costo);
                    int h = calcH(nodo);
                    Matriz[y][x].setH(h);
                    Matriz[y][x].setF(costo + h);
                    Matriz[y][x].setPadre(padre);
                    Matriz[y][x].button.setF(costo + h);
                    Matriz[y][x].button.setH(h);
                    Matriz[y][x].button.setG(costo);
                    Matriz[y][x].button.setVisibles();

                    if (y != fin.Second || x != fin.First) Matriz[y][x].button.panel.BackColor = Color.LightGreen;
                }
                if (!findListaCerrada(new Pair<int, int>(nodo.First,nodo.Second)))
                {
                    /*MessageBox.Show(Matriz[nodo.Second][nodo.First].getNombre());
                    MessageBox.Show(Matriz[Y][X].getNombre() + " a " + Matriz[nodo.Second][nodo.First].getNombre() + " padre: " + Matriz[Matriz[nodo.Second][nodo.First].getPadre().Second][Matriz[nodo.Second][nodo.First].getPadre().First].getNombre());
                    MessageBox.Show((costo) + " MEJORA a " + Matriz[y][x].getG());*/
                    if(costo < Matriz[y][x].getG())
                    {
                        Matriz[y][x].setG(costo);
                        Matriz[y][x].setF(Matriz[y][x].getG() + Matriz[y][x].getH());
                        Matriz[y][x].button.setF(Matriz[y][x].getG() + Matriz[y][x].getH());
                        Matriz[y][x].button.setG(costo);
                        Matriz[y][x].setPadre(new Pair<int, int>(X, Y));
                        //MessageBox.Show(Matriz[Y][X].getNombre() + ": " + Matriz[ListaAbierta.Last().Second][ListaAbierta.Last().First].getNombre() + " padre: " + Matriz[Matriz[ListaAbierta.Last().Second][ListaAbierta.Last().First].getPadre().Second][Matriz[ListaAbierta.Last().Second][ListaAbierta.Last().First].getPadre().First].getNombre());
                    }
                }
            }
            public void getHijos(Pair<int,int> padre)
            {
                int x = padre.First;
                int y = padre.Second;
                if (x + 1 < this.Ancho && Matriz[y][x + 1].getTipo() != PARED)// && Matriz[y][x + 1].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x + 1, y));
                }
                if (x - 1 >= 0 && Matriz[y][x - 1].getTipo() != PARED)// && Matriz[y][x - 1].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x - 1, y));
                }
                if (y + 1 < this.Alto && Matriz[y + 1][x].getTipo() != PARED)// && Matriz[y + 1][x].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x, y + 1));
                }
                if (y - 1 >= 0 && Matriz[y - 1][x].getTipo() != PARED)// && Matriz[y - 1][x].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x, y - 1));
                }
                if(y - 1 >= 0 && x + 1 < this.Ancho && Matriz[y - 1][x + 1].getTipo() != PARED)// && Matriz[y - 1][x + 1].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x + 1, y - 1));
                }
                if (y + 1 < this.Alto && x + 1 < this.Ancho && Matriz[y + 1][x + 1].getTipo() != PARED)// && Matriz[y + 1][x + 1].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x + 1, y + 1));
                }
                if (y + 1 < this.Alto && x - 1 >= 0 && Matriz[y + 1][x - 1].getTipo() != PARED)// && Matriz[y + 1][x - 1].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x - 1, y + 1)) ;
                }
                if (y - 1 >= 0 && x - 1 >= 0 && Matriz[y - 1][x - 1].getTipo() != PARED)// && Matriz[y - 1][x - 1].getTipo() != FIN)
                {
                    setValues(padre, new Pair<int, int>(x - 1, y - 1));
                }

                /*if (Matriz[y][x + 1].getTipo() == FIN || Matriz[y][x - 1].getTipo() == FIN || Matriz[y - 1][x].getTipo() == FIN || Matriz[y + 1][x].getTipo() == FIN)
                {
                    Encontrado = true;
                }*/
                
                
            }
            public void DibujarCamino()
            {
                int px = fin.First;
                int py = fin.Second;
                int Px = Matriz[py][px].getPadre().First;
                int Py = Matriz[py][px].getPadre().Second;
                px = Px;
                py = Py;
                int ix = ListaCerrada[0].First;
                int iy = ListaCerrada[0].Second;
                while (px != ix || py != iy)
                {
                    if (px != ix || py != iy)
                    {
                        Boton_panel b = Matriz[py][px].getButton();
                        b.panel.BackColor = Color.Red;
                        MessageBox.Show("SIGUIENTE: " + Matriz[py][px].getPadre().First + " " + Matriz[py][px].getPadre().Second);
                        Px = Matriz[py][px].getPadre().First;
                        Py = Matriz[py][px].getPadre().Second;
                        px = Px;
                        py = Py;
                    }
                }
                Boton_panel b2 = Matriz[iy][ix].getButton();
                b2.panel.BackColor = Color.Red;

            }
            public void Asterisk(Pair<int,int> actual)
            {
                if (ListaCerrada.Count < (this.Ancho * this.Alto) - this.Paredes)
                {
                    MessageBox.Show("ACTUAL: " + Matriz[actual.Second][actual.First].getNombre());
                    getHijos(actual);
                    int x = getListaAbierta()[0].First;
                    int y = getListaAbierta()[0].Second;
                    int X = x;
                    int Y = y;
                    int mini = Matriz[y][x].getF();
                    int index = 0;
                    for (int i = 1; i < ListaAbierta.Count; i++)
                    {
                        x = getListaAbierta()[i].First;
                        y = getListaAbierta()[i].Second;
                        if (Matriz[y][x].getF() < mini)
                        {
                            index = i;
                            mini = Matriz[y][x].getF();
                            X = x;
                            Y = y;
                        }
                    }

                    Pivot.First = X;
                    Pivot.Second = Y;

                    Pair<int, int> aux = new Pair<int, int>(X, Y);
                    //MessageBox.Show("PIVOT: " + Matriz[Y][X].getNombre());
                    string s = "";
                    string la = "";
                    
                    for (int i = 0; i < ListaAbierta.Count; i++) {
                        s += Matriz[ListaAbierta[i].Second][ListaAbierta[i].First].getNombre() + " " + Matriz[ListaAbierta[i].Second][ListaAbierta[i].First].getF() + "\n";
                        la += Matriz[ListaAbierta[i].Second][ListaAbierta[i].First].getNombre() + " - ";
                    }
                    //MessageBox.Show("Abierta:\n" + s);
                    s = "";
                    string lc = "";
                    for (int i = 0; i < ListaCerrada.Count; i++) {
                        int auxx = ListaCerrada[i].First;
                        int auxy = ListaCerrada[i].Second;
                        if (i > 0)
                        {
                            s += Matriz[auxy][auxx].getNombre() + " " + Matriz[Matriz[auxy][auxx].getPadre().Second][Matriz[auxy][auxx].getPadre().First].getNombre() + "\n";
                            lc += Matriz[auxy][auxx].getNombre() + " - ";
                        }

                        else
                        {
                            s += Matriz[auxy][auxx].getNombre() + "\n";
                            lc += Matriz[auxy][auxx].getNombre() + " - ";
                        }
                    }
                    DibujarListas(la, lc);
                    //MessageBox.Show("Cerrada\n" + s);
                    if (Pivot.First == fin.First && Pivot.Second == fin.Second)
                    {
                        setTermina();
                        MessageBox.Show(Matriz[Pivot.Second][Pivot.First].getPadre().First + " " + Matriz[Pivot.Second][Pivot.First].getPadre().Second);
                    }
                    addListaCerrada(new Pair<int, int>(X, Y));
                    ListaAbierta.RemoveAt(index);
                    Asterisk(new Pair<int, int>(X, Y));
                }
            }
            public void DibujarListas(string la, string lc)
            {
                Label LA = this.control.Controls.Find("LA",true).FirstOrDefault() as Label;
                Label LC = this.control.Controls.Find("LC", true).FirstOrDefault() as Label;
                LA.Text = la;
                LC.Text = lc;
            }

        }


        Maestro maestro;


        public Tablero(string alto, string ancho)
        {
            InitializeComponent();
            maestro = new Maestro(Convert.ToInt32(alto), Convert.ToInt32(ancho));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maestro.crearMapa(this);
        }





    }
}
