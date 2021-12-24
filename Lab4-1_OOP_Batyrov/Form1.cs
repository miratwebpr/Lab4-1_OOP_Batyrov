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
            if (cursorBut.Enabled == false)
            {
                if (isCtrl == false)
                {
                    for (int i = 0; i < V.getCount(); i++)
                    {
                        if (V[i].isCursorIn(e.X, e.Y))
                        {
                            if (selected1 != -1)
                            {
                                selected1 = -1;
                                G.unSelectAll(V);
                                G.clearSheet();
                                G.drawALLGraph(V);
                                sheet.Image = G.GetBitmap();
                            }
                            if (selected1 == -1)
                            {
                                V[i].select();
                                V[i].drawSelectedFigure(G.getGraphics());
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < V.getCount(); i++)
                    {
                        if (V[i].isCursorIn(e.X, e.Y))
                        {
                            V[i].drawSelectedFigure(G.getGraphics());
                            V[i].select();
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            break;
                        }
                    }
                }
            }
            else if (circleBut.Enabled == false)
            {
                G.unSelectAll(V);
                V.pushBack(new Circle(e.X, e.Y));
                V[V.getCount() - 1].select();
                V[V.getCount() - 1].drawFigure(G.getGraphics());
                G.clearSheet();
                G.drawALLGraph(V);
                sheet.Image = G.GetBitmap();
                V[V.getCount() - 1].drawSelectedFigure(G.getGraphics());
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
            if(e.KeyCode == Keys.PageUp)
            {
                if(cursorBut.Enabled == false)
                {
                    for(int i = 0; i < V.getCount(); i++)
                    {
                        if (V[i].checkSelected())
                        {
                            V[i].enlargeFigure(1);
                        }
                    }
                    G.clearSheet();
                    G.drawALLGraph(V);
                    sheet.Image = G.GetBitmap();
                }
            }
            if (e.KeyCode == Keys.PageDown)
            {
                if (cursorBut.Enabled == false)
                {
                    for (int i = 0; i < V.getCount(); i++)
                    {
                        if (V[i].checkSelected())
                        {
                            V[i].reduceFigure(1);
                        }
                    }
                    G.clearSheet();
                    G.drawALLGraph(V);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = false;
            }
        }

        private void cursorBut_Click(object sender, EventArgs e)
        {
            cursorBut.Enabled = false;
            circleBut.Enabled = true;
            triangleBut.Enabled = true;
            rectangleBut.Enabled = true;
            colorBut.Enabled = true;
        }

        private void circleBut_Click(object sender, EventArgs e)
        {
            circleBut.Enabled = false;
            cursorBut.Enabled = true;
            triangleBut.Enabled = true;
            rectangleBut.Enabled = true;
            colorBut.Enabled = true;
        }
    }
}
