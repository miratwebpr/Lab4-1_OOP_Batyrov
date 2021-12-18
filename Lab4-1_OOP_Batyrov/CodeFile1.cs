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
    class Circle
    {
        public int x, y;
        public bool selected = false;
        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 20; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.DarkGoldenrod);
            darkGoldPen.Width = 4;
            darkGoldPen.EndCap = LineCap.ArrowAnchor;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawCircle(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedCircle(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawALLGraph(Storage<Circle> V)
        {
            //рисуем вершины
            for (int i = 0; i < V.getCount(); i++)
            {
                drawCircle(V[i].x, V[i].y, (i + 1).ToString());
            }
        }
        public void unSelect(Storage<Circle> V)
        {
            for(int i = 0; i < V.getCount(); i++)
            {
                V[i].selected = false;
            }
        }
        public void erasePicked(Storage<Circle> V)
        {
            for (int i = 0; i < V.getCount(); i++)
            {
                if (V[i].selected == true)
                {
                    V[i].selected = false;
                    V.getObjectAndDel(i);
                }
            }
        }

    }
}