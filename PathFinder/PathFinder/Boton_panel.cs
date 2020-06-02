using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;

namespace PathFinder
{
    class Boton_panel
    {
        public Panel panel = new Panel();
        Label LH = new Label();
        Label LG = new Label();
        Label LF = new Label();
        Label Lname = new Label();
        public Boton_panel(int left, int top, string name)
        {
            panel.Name = name;
            panel.Width = 50;
            panel.Height = 50;
            panel.Left = left;
            panel.Top = top;
            panel.BorderStyle = BorderStyle.FixedSingle;

            LH.Text = "";
            LH.Name = "LH";
            LH.Left = 30;
            LH.Top = 35;
            LH.Width = 24;
            LH.Font = new Font("Arial", 7, FontStyle.Bold);
            LH.Padding = new Padding(0);
            LH.Visible = false;

            LG.Text = "";
            LG.Name = "LG";
            LG.Left = 0;
            LG.Top = 35;
            LG.Width = 24;
            LG.Font = new Font("Arial", 7, FontStyle.Bold);
            LG.Padding = new Padding(0);
            LG.Visible = false;

            LF.Text = "";
            LF.Name = "LF";
            LF.Left = 30;
            LF.Top = 1;
            LF.Width = 24;
            LF.Font = new Font("Arial", 7, FontStyle.Bold);
            LF.Padding = new Padding(0);
            LF.Visible = false;

            Lname.Text = "";
            Lname.Name = "Lname";
            Lname.Left = 1;
            Lname.Top = 1;
            Lname.Width = 24;
            Lname.Font = new Font("Arial", 7, FontStyle.Bold);
            Lname.Padding = new Padding(0);

            /*Label LDir = new Label();
            LDir.Text = "LDir";
            LDir.Name = "LDir";
            LDir.Left = 17;
            LDir.Top = 17;
            LDir.Width = 24;
            LDir.Font = new Font("Arial", 7, FontStyle.Bold);
            LDir.Padding = new Padding(0);*/

            panel.Controls.Add(LH);
            panel.Controls.Add(LG);
            panel.Controls.Add(LF);
            panel.Controls.Add(Lname);
            //panel.Controls.Add(LDir);
        }

        public void setH(int h) {
            this.panel.Controls.RemoveByKey("LH");
            this.LH.Text = "" + h;
            this.panel.Controls.Add(this.LH);
        }
        public void setG(int g)
        {
            this.panel.Controls.RemoveByKey("LG");
            this.LG.Text = "" + g;
            this.panel.Controls.Add(this.LG);
        }
        public void setF(int f)
        {
            this.panel.Controls.RemoveByKey("LF");
            this.LF.Text = "" + f;
            this.panel.Controls.Add(this.LF);
        }
        public void setName(string name)
        {
            this.panel.Controls.RemoveByKey("Lname");
            this.Lname.Text = "" + name;
            this.panel.Controls.Add(this.Lname);
        }
        public void setVisibles()
        {
            this.LH.Visible = true;
            this.LG.Visible = true;
            this.LF.Visible = true;
        }
    }
}
