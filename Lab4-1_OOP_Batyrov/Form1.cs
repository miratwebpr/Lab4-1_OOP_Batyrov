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
            sheet.Image = G.GetBitmap();
        }
        
        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (isCtrl == false)
            {
                bool flag = false;
                for (int i = 0; i < V.getCount(); i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
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
                            V[i].selected = true;
                            G.drawSelectedCircle(V[i].x, V[i].y);
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
                    V[V.getCount() - 1].selected = true;
                    G.drawCircle(e.X, e.Y, V.getCount().ToString());
                    G.clearSheet();
                    G.drawALLGraph(V);
                    sheet.Image = G.GetBitmap();
                    G.drawSelectedCircle(e.X, e.Y);
                }

            }
            else
            {
                for (int i = 0; i < V.getCount(); i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                            G.drawSelectedCircle(V[i].x, V[i].y);
                            V[i].selected = true;
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
            }
            return;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = false;
            }
            if (e.KeyCode == Keys.Delete)
            {
                G.clearSheet();
                G.drawALLGraph(V);
                sheet.Image = G.GetBitmap();
            }
        }

    }
}
