using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_1_OOP_Batyrov
{
    public partial class Form1 : Form
    {
        DrawGraph G;
        Storage<Circle> V;
        public Form1()
        {
            InitializeComponent();
            V = new Storage<Circle>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            sheet.Image = G.GetBitmap();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            int selected1 = -1;
            if (V.getCount() == 0)
            {
                V.pushBack(new Circle(e.X, e.Y));
                G.drawCircle(e.X, e.Y, V.getCount().ToString());
                sheet.Image = G.GetBitmap();
            }
            for(int i = 0; i < V.getCount(); i++)
            {
                if(Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                {
                    if (selected1 != -1)
                    {
                        selected1 = -1;
                        G.clearSheet();
                        G.drawALLGraph(V);
                        sheet.Image = G.GetBitmap();
                    }
                    if (selected1 == -1)
                    {
                        G.drawSelectedCircle(V[i].x, V[i].y);
                        selected1 = i;
                        sheet.Image = G.GetBitmap();
                        return;
                    }
                }
                else
                {
                    V.pushBack(new Circle(e.X, e.Y));
                    G.drawCircle(e.X, e.Y, V.getCount().ToString());
                    sheet.Image = G.GetBitmap();
                    return;
                }
            }
        }
    }
}
