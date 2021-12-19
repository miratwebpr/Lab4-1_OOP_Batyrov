using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lab4_1_OOP_Batyrov
{
    public partial class Form1 : Form
    {
        DrawGraph G;
        Storage<Circle> V;
        int selected1;
        bool isCtrl = false;
        public Form1()
        {
            InitializeComponent();
            V = new Storage<Circle>();
            G = new DrawGraph(sheet.Width, sheet.Height);
        }
        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (isCtrl == false)
            {
                bool flag = false;
                for (int i = 0; i < V.getCount(); i++)
                {
                    if (V[i].isInCircle(e.X, e.Y))
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            G.unSelect(V);
                            G.clearSheet();
                            G.drawALLGraph(V);
                            sheet.Image = G.GetBitmap();
                        }
                        if (selected1 == -1)
                        {
                            V[i].selectCircle();
                            V[i].drawSelectedCircle(G.getGraphics());
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    G.unSelect(V);
                    V.pushBack(new Circle(e.X, e.Y));
                    V[V.getCount() - 1].selectCircle();
                    V[V.getCount() - 1].drawCircle(G.getGraphics(), V.getCount().ToString());
                    G.clearSheet();
                    G.drawALLGraph(V);
                    sheet.Image = G.GetBitmap();
                    V[V.getCount() - 1].drawSelectedCircle(G.getGraphics());
                }

            }
            else
            {
                for (int i = 0; i < V.getCount(); i++)
                {
                    if (V[i].isInCircle(e.X, e.Y))
                    {
                            V[i].drawSelectedCircle(G.getGraphics());
                            V[i].selectCircle();
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            break;
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                isCtrl = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                G.erasePicked(V);
                G.clearSheet();
                G.drawALLGraph(V);
                sheet.Image = G.GetBitmap();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = false;
            }
        }

    }
}
