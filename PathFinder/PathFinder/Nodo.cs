using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder
{
    class Nodo
    {
        int id;
        Pair<int, int> padre;
        public Boton_panel button;
        string nombre;
        int F;
        int G;
        int H;
        int tipo;
        Pair<int, int> coords;
        bool visitado;
        public Nodo() { }
        public Nodo(int id, Pair<int, int> padre, Boton_panel button, string nombre, int f, int g, int h, Pair<int,int> coords)
        {
            this.id = id;
            this.padre = padre;
            this.button = button;
            this.nombre = nombre;
            this.F = f;
            this.G = g;
            this.H = h;
            this.tipo = 1;
            this.coords = coords;
            this.visitado = false;
        }
        public int getId() { return this.id; }
        public void setId(int id) { this.id = id; }
        public Pair<int, int> getPadre() { return this.padre; }
        public void setPadre(Pair<int, int> padre) { this.padre = padre; }
        public Boton_panel getButton() { return this.button; }
        public void setButton(Boton_panel button) { this.button = button; }
        public string getNombre() { return this.nombre; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public int getF() { return this.F; }
        public void setF(int F) { this.F = F; }
        public int getG() { return this.G; }
        public void setG(int G) { this.G = G; }
        public int getH() { return this.H; }
        public void setH(int H) { this.H = H; }
        public int getTipo() { return this.tipo; }
        public void setTipo(int tipo) { this.tipo = tipo; }
        public Pair<int,int> getCoords() { return this.coords; }
        public bool getVisitado() { return this.visitado; }
        public void Visitar(){ visitado = true; }
    }

}
