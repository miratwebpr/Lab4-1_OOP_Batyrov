using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_1_OOP_Batyrov
{
    class Node<T>
    {
        internal Node<T> next;
        internal Node<T> prev;
        internal T Obj;
    }
    class Storage<T>
    {
        protected Node<T> first;
        protected Node<T> last;
        protected int count;
        protected Node<T> iterator;
        public Storage()
        {
            first = null;
            last = null;
            count = 0;
        }
        public int getCount()
        {
            return count;
        }
        public void pushBack(T newObj)
        {
            Node<T> newNode = new Node<T>();
            newNode.Obj = newObj;
            newNode.next = null;
            newNode.prev = last;
            if (count != 0) last.next = newNode;
            else first = newNode;
            last = newNode;
            count++;
        }
        public void pushFront(T newObj)
        {
            Node<T> newNode = new Node<T>();
            newNode.Obj = newObj;
            newNode.next = first;
            newNode.prev = null;
            if (count != 0) first.prev = newNode;
            else last = newNode;
            first = newNode;
            count++;
        }
        public T getObject(int index)
        {
            if (index < 0 || index >= count)
            {
                throw null;
            }
            Node<T> current = first;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.Obj;
        }
        public T getObjectAndDel(int index)
        {
            if (index < 0 || index >= count)
            {
                throw null;
            }
            Node<T> current = first;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            if (count == 1)
            {
                count = 0;
                first = null;
                last = null;
                return current.Obj;
            }
            if (current == first)
            {
                Node<T> AftCurrent = current.next;
                AftCurrent.prev = null;
                first = AftCurrent;
                count--;
                return current.Obj;
            }
            else if (current == last)
            {
                Node<T> BefCurrent = current.prev;
                BefCurrent.next = null;
                last = BefCurrent;
                count--;
                return current.Obj;
            }
            else
            {
                Node<T> BefCurrent = current.prev;
                Node<T> AftCurrent = current.next;
                BefCurrent.next = AftCurrent;
                AftCurrent.prev = BefCurrent;
                count--;
                return current.Obj;
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw null;
                }
                Node<T> current = first;
                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                return current.Obj;
            }
        }
        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }
        class Iterator
        {
            private static Node<T> current;
            public Iterator(Node<T> newCurrent)
            {
                current = newCurrent;
            }
            public static Iterator operator ++(Iterator itr)
            {
                current = current.next;
                return itr;
            }
            public static Iterator operator --(Iterator itr)
            {
                current = current.prev;
                return itr;
            }
            bool hasCurrent()
            {
                if (current != null)
                    return true;
                return false;
            }
        }
        Iterator begin()
        {
            Iterator beginIter = new Iterator(first);
            return beginIter;
        }
        Iterator end()
        {
            Iterator endIter = new Iterator(last);
            return endIter;
        }
    }
    abstract class geoFigure
    {
        //центр фигуры
        protected int x, y;
        protected bool selected = false;
        protected Brush myBrush;
        abstract public bool isCursorIn(int X, int Y);
        abstract public void drawFigure(Graphics gr);
        abstract public void drawSelectedFigure(Graphics gr);
        abstract public void enlargeFigure(int addN);
        abstract public void reduceFigure(int minusN);
        public void select()
        {
            selected = true;
        }
        public void unSelect()
        {
            selected = false;
        }
        public bool checkSelected()
        {
            if (selected)
                return true;
            return false;
        }
        virtual public void moveFigure(int addX, int addY, PictureBox sheet)
        {
            x += addX;
            y += addY;
        }
        public void changeColor(Color color)
        {
            Brush newBrush = new SolidBrush(color); 
            myBrush = newBrush;
        }
    }
    class Circle : geoFigure
    {
        private int R = 20;
        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
            myBrush = Brushes.White;
        }
        public override bool isCursorIn(int X, int Y)
        {
            return (x - X) * (x - X) + (y - Y) * (y - Y) <= R * R;
        }
        public override void drawFigure(Graphics gr)
        {
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            gr.FillEllipse(myBrush, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
        }
        public override void drawSelectedFigure(Graphics gr)
        {
            Pen redPen = new Pen(Color.Red);
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }
        public override void enlargeFigure(int addR)
        {
            R += addR;
        }
        public override void reduceFigure(int minusR)
        {
            R -= minusR;
        }
        public override void moveFigure(int addX, int addY, PictureBox sheet)
        {
            if(addX != 0 && (x + addX > 20 || addX > 0) && (x + addX < sheet.Width - 20 || addX < 0))
            {
                x += addX;
            }
            else if(addY != 0 && (y + addY > 20 || addX > 0) && (y + addY < sheet.Height - 20 || addY < 0))
            {
                y += addY;
            }
        }

    }
    class Triangle : geoFigure
    {
        Point[] points = new Point[3];

        public Triangle(int x, int y)
        {
            this.x = x;
            this.y = y;
            points[0].X = x; points[0].Y = y - 40;
            points[1].X = x - 20; points[1].Y = y + 10;
            points[2].X = x + 20; points[2].Y = y + 10;
            myBrush = Brushes.White;
        }
        public override bool isCursorIn(int X, int Y)
        {
            int a = (points[0].X - X) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - Y);
            int b = (points[1].X - X) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - Y);
            int c = (points[2].X - X) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - Y);
            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                return true;
            return false;

        }
        public override void drawFigure(Graphics gr)
        {
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            gr.DrawPolygon(blackPen, points);
            gr.FillPolygon(myBrush, points);
        }
        public override void drawSelectedFigure(Graphics gr)
        {
            Pen redPen = new Pen(Color.Red);
            redPen.Width = 2;
            gr.DrawPolygon(redPen, points);
        }
        public override void enlargeFigure(int addN)
        {
            points[0].Y -= addN;
            points[1].X -= addN;
            points[2].X += addN;
        }
        public override void reduceFigure(int minusN)
        {
            points[0].Y += minusN;
            points[1].X += minusN;
            points[2].X -= minusN;
        }
        public override void moveFigure(int addX, int addY, PictureBox sheet)
        {
            int tempX = x - points[1].X;
            int tempY0 = y - points[0].Y;
            int tempY1 = y - points[1].Y;
            if((points[1].X - 10 >= 0 || addX > 0) && (points[2].X <= sheet.Width - 10 || addX < 0)) x += addX;
            y += addY;
            if (addX != 0 )
            {
                points[0].X = x;
                points[1].X = x - tempX;
                points[2].X = x + tempX;
            }
            else if((points[0].Y - 10 >= 0 || addY > 0) && (points[1].Y <= sheet.Height - 10 || addY < 0))
            {
                points[0].Y = y - tempY0;
                points[1].Y = y - tempY1;
                points[2].Y = y - tempY1;
            }    
        }
    }
    class Rectangle : geoFigure
    {
        int width;
        int height;
        Point leftUpAngle = new Point();
        public Rectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
            width = 50;
            height = 50;
            leftUpAngle.X = x - width / 2;
            leftUpAngle.Y = y - height / 2;
            myBrush = Brushes.White;
        }
        public override bool isCursorIn(int X, int Y)
        {
            if (X >= leftUpAngle.X && X <= leftUpAngle.X + width && Y <= leftUpAngle.Y + height && Y >= leftUpAngle.Y)
                return true;
            return false;
        }
        public override void drawFigure(Graphics gr)
        {
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            gr.DrawRectangle(blackPen, leftUpAngle.X, leftUpAngle.Y, width, height);
            gr.FillRectangle(myBrush, leftUpAngle.X, leftUpAngle.Y, width, height);
        }
        public override void drawSelectedFigure(Graphics gr)
        {
            Pen redPen = new Pen(Color.Red);
            redPen.Width = 2;
            gr.DrawRectangle(redPen, leftUpAngle.X, leftUpAngle.Y, width, height);
        }
        public override void enlargeFigure(int addN)
        {
            width += addN;
            height += addN;
            leftUpAngle.X = x - width / 2;
            leftUpAngle.Y = y - height / 2;
        }
        public override void reduceFigure(int minusN)
        {
            width -= minusN;
            height -= minusN;
            leftUpAngle.X = x - width / 2;
            leftUpAngle.Y = y - height / 2;
        }
        public override void moveFigure(int addX, int addY, PictureBox sheet)
        {
            if (addX != 0 && (x - width / 2 + addX > 20 || addX > 0) && (x + width / 2 + addX < sheet.Width - 20 || addX < 0))
            {
                x += addX;
                leftUpAngle.X = x - width / 2;
            }
            else if (addY != 0 && (y - height / 2 + addY > 20 || addX > 0) && (y + height / 2 + addY < sheet.Height - 20 || addY < 0))
            {
                y += addY;
                leftUpAngle.Y = y - height / 2;
            }
        }
    }
    
    
    class DrawGraph
    {
        Bitmap bitmap;
        Graphics gr;
        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }
        public Graphics getGraphics()
        {
            return gr;
        }
        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawALLGraph(Storage<geoFigure> V)
        {
            //рисуем вершины
            for (int i = 0; i < V.getCount(); i++)
            {
                V[i].drawFigure(gr);
            }
        }
        public void unSelectAll(Storage<geoFigure> V)
        {
            for(int i = 0; i < V.getCount(); i++)
            {
                V[i].unSelect();
            }
        }
        public void erasePicked(Storage<geoFigure> V)
        {
            for (int i = 0; i < V.getCount();)
            {
                if (V[i].checkSelected())
                {
                    V.getObjectAndDel(i);
                }
                else
                {
                    i++;
                }
            }
        }

    }
}