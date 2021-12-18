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
            
    }
}
