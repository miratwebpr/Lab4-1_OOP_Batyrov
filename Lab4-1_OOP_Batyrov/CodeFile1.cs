using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Lab4_1_OOP_Batyrov
{
    class Node<T>
    {
        internal Node<T> next;
        internal Node<T> prev;
        internal T Obj;
    }
    class Storage<T> : Subject
    {
        protected Node<T> first;
        protected Node<T> last;
        protected int count;
        public Storage()
        {
            first = null;
            last = null;
            count = 0;
        }
        public void subscribeAllFigures()
        {
            if(first.Obj is GeoFigure)
            {
                Node<T> current = first;
                for (int i = 0; i < count; i++)
                {
                    for(int j = 0; j < subjectObservers.Count; j++)
                    {
                        (current.Obj as GeoFigure).addObserver(subjectObservers[j]);
                        current = current.next;
                    }
                }
            }
        }
        public void subscribeAllFigures(Observer newObs)
        {
            if (first.Obj is GeoFigure)
            {
                Node<T> current = first;
                for (int i = 0; i < count; i++)
                {
                    (current.Obj as GeoFigure).addObserver(newObs);
                    current = current.next;
                }
            }
        }
        public void subscribeFigure(T obj)
        {
            
            if (first.Obj is GeoFigure)
            {
                for(int i = 0; i < subjectObservers.Count; i++)
                {
                    (obj as GeoFigure).addObserver(subjectObservers[i]);
                }
            }
                
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
            subscribeFigure(newNode.Obj);
            notifyEveryOne();
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
            subscribeFigure(newNode.Obj);
            notifyEveryOne();
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
                notifyEveryOne();
                return current.Obj;
            }
            if (current == first)
            {
                Node<T> AftCurrent = current.next;
                AftCurrent.prev = null;
                first = AftCurrent;
                count--;
                notifyEveryOne();
                return current.Obj;
            }
            else if (current == last)
            {
                Node<T> BefCurrent = current.prev;
                BefCurrent.next = null;
                last = BefCurrent;
                count--;
                notifyEveryOne();
                return current.Obj;
            }
            else
            {
                Node<T> BefCurrent = current.prev;
                Node<T> AftCurrent = current.next;
                BefCurrent.next = AftCurrent;
                AftCurrent.prev = BefCurrent;
                count--;
                notifyEveryOne();
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
            notifyEveryOne();
        }
        public class Iterator
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
    abstract class GeoFigure : Subject
    {
        public Rectangle frame;
        protected int x, y;
        protected bool selected = false;
        protected Brush myBrush;
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        abstract public bool isCursorIn(int X, int Y);
        abstract public void drawFigure(Graphics gr);
        abstract public void drawSelectedFigure(Graphics gr);
        abstract public void enlargeFigure(int addN);
        abstract public void reduceFigure(int minusN);
        abstract public void findFrame(int X, int Y);
        virtual public void select()
        {
            selected = true;
            notifyEveryOne();
        }
        virtual public void unSelect()
        {
            selected = false;
            notifyEveryOne();
        }
        virtual public bool checkSelected()
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
        virtual public void changeColor(Color color)
        {
            Brush newBrush = new SolidBrush(color); 
            myBrush = newBrush;
        }
        abstract public bool isAbleToMove(int addX, int addY, PictureBox sheet);
        public string getInfo()
        {
            return this.GetType().Name + "  X:" + this.x + "  Y:" + this.y;
        }
        public bool checkIntersectionOfTwoRectangles(Rectangle r2)
        {
            Point[] Frame1Points = frame.getPointsOfRect();
            Point[] Frame2Points = r2.getPointsOfRect();
            //Y not intersects

            if (Frame1Points[0].Y > Frame2Points[3].Y || Frame1Points[3].Y < Frame2Points[0].Y)
            {

                return false;

            }
            //TODO: Done: Исправить рамку треугольника, она вниз уезжает, а сверху протыкает,
            // исправить конфликты со storage observerom, т.к. переполнение стекаплюс, при выборе
            //фигур, нотифается сторэдж обсервер и из за этого скорее всего

            //X not intersects

            if (Frame1Points[3].X < Frame2Points[0].X || Frame1Points[0].X > Frame2Points[3].X)
            {

                return false;

            }

            return true;
        }
        public bool checkIntersectionOfTwoLines(Point p1, Point p2, Point p3, Point p4)
        {
            //сначала расставим точки по порядку, т.е. чтобы было p1.x <= p2.x
            if (p2.X < p1.X)
            {
                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }
            //и p3.x <= p4.x
            if (p4.X < p3.X)
            {
                Point tmp = p3;
                p3 = p4;
                p4 = tmp;
            }

            //проверим существование потенциального интервала для точки пересечения отрезков
            if (p2.X < p3.X)
            {
                return false; //ибо у отрезков нету взаимной абсциссы
            }

            //если оба отрезка вертикальные
            if ((p1.X - p2.X == 0) && (p3.X - p4.X == 0))
            {

                //если они лежат на одном X
                if (p1.X == p3.X)
                {

                    //проверим пересекаются ли они, т.е. есть ли у них общий Y
                    //для этого возьмём отрицание от случая, когда они НЕ пересекаются
                    if (!((Math.Max(p1.Y, p2.Y) < Math.Min(p3.Y, p4.Y)) ||
                            (Math.Min(p1.Y, p2.Y) > Math.Max(p3.Y, p4.Y))))
                    {
                        return true;
                    }
                }

                return false;
            }

            //найдём коэффициенты уравнений, содержащих отрезки
            //f1(x) = A1*x + b1 = y
            //f2(x) = A2*x + b2 = y

            //если первый отрезок вертикальный
            if (p1.X - p2.X == 0)
            {
                //найдём Xa, Ya - точки пересечения двух прямых
                int XA = p1.X;
                int a2 = (p3.Y - p4.Y) / (p3.X - p4.X);
                int B2 = p3.Y - a2 * p3.X;
                int Ya = a2 * XA + B2;

                if (p3.X <= XA && p4.X >= XA && Math.Min(p1.Y, p2.Y) <= Ya &&
                        Math.Max(p1.Y, p2.Y) >= Ya)
                {
                    return true;
                }

                return false;
            }

            //если второй отрезок вертикальный
            if (p3.X - p4.X == 0)
            {

                //найдём Xa, Ya - точки пересечения двух прямых
                int XA = p3.X;
                int a1 = (p1.Y - p2.Y) / (p1.X - p2.Y);
                int B1 = p1.Y - a1 * p1.Y;
                int Ya = a1 * XA + B1;

                if (p1.X <= XA && p2.X >= XA && Math.Min(p3.Y, p4.Y) <= Ya &&
                        Math.Max(p3.Y, p4.Y) >= Ya)
                {

                    return true;
                }

                return false;
            }

            //оба отрезка невертикальные
            int A1 = (p1.Y - p2.Y) / (p1.X - p2.X);
            int A2 = (p3.X - p4.X) / (p3.X - p4.X);
            int b1 = p1.Y - A1 * p1.X;
            int b2 = p3.Y - A2 * p3.X;

            if (A1 == A2)
            {
                return false; //отрезки параллельны
            }

            //Xa - абсцисса точки пересечения двух прямых
            int Xa = (b2 - b1) / (A1 - A2);

            if ((Xa < Math.Max(p1.X, p3.X)) || (Xa > Math.Min(p2.X, p4.X)))
            {
                return false; //точка Xa находится вне пересечения проекций отрезков на ось X 
            }
            else
            {
                return true;
            }
        }
    }
    class Group : GeoFigure
    {
        private int maxCount;
        private int count;
        private GeoFigure [] figures;
        public Group(int maxCount)
        {
            this.maxCount = maxCount;
            count = 0;
            figures = new GeoFigure[maxCount];
        }
        public override void findFrame(int X, int Y)
        {
            return;
        }
        public override void select()
        {
            for(int i = 0; i < count; i++)
            {
                figures[i].select();
            }
            selected = true;
            notifyEveryOne();
        }
        public override void unSelect()
        {
            for (int i = 0; i < count; i++)
            {
                figures[i].unSelect();
            }
            selected = false;
            notifyEveryOne();
        }
        public void addFigure(GeoFigure newFigure)
        {
            if(count >= maxCount)
                return;
            count++;
            figures[count - 1] = newFigure;
        }
        public GeoFigure[] getFigures()
        {
            return figures;
        }
        public int getCount()
        {
            return count;
        }
        public override bool isAbleToMove(int addX, int addY, PictureBox sheet)
        {
            for (int i = 0; i < count; i++)
            {
                if (figures[i].isAbleToMove(addX, addY, sheet) == false)
                    return false;
            }
            return true;
        }
        public override void moveFigure(int addX, int addY, PictureBox sheet)
        {
            if (this.isAbleToMove(addX, addY, sheet) == false) 
                return;
            for(int i = 0; i < count; i++)
            {
                figures[i].moveFigure(addX, addY, sheet);
            }
        }
        public override bool isCursorIn(int x, int y)
        {
            for(int i = 0; i < count; i++)
            {
                if(figures[i].isCursorIn(x, y))
                    return true;
            }
            return false;
        }
        public override void drawFigure(Graphics gr)
        {
            for(int i = 0; i < count; i++)
            {
                figures[i].drawFigure(gr);
            }
        }
        public override void drawSelectedFigure(Graphics gr)
        {
            for(int i = 0; i < count; i++)
            {
                figures[i].drawSelectedFigure(gr);
            }
        }
        public override void enlargeFigure(int addN)
        {
            for (int i = 0; i < count; i++)
            {
                figures[i].enlargeFigure(addN);
            }
        }
        public override void reduceFigure(int minusN)
        {
            for(int i = 0; i < count; i++)
            {
                figures[i].reduceFigure(minusN);
            }
        }
        public override void changeColor(Color color)
        {
            for (int i = 0; i < count; i++)
            {
                figures[i].changeColor(color);
            }
        }
        public override bool checkSelected()
        {
            for (int i = 0; i < count; i++)
            {
                if(figures[i].checkSelected() == false)
                    return false;
            }
            return true;
        }
    }
    class Circle : GeoFigure
    {
        private int R;
        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
            R = 20;
            myBrush = Brushes.White;
            findFrame(x, y);
        }
        public override void findFrame(int X, int Y)
        {
            int width = R * 2;
            int height = R * 2;
            frame = new Rectangle(x, y, width, height);
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
            if (selected == true) 
                drawSelectedFigure(gr);
            else 
                gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
        }
        public override void drawSelectedFigure(Graphics gr)
        {
            Pen redPen = new Pen(Color.Red);
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }
        public override void enlargeFigure(int addR)
        {
            if(R > 0)
                R += addR;
            findFrame(x, y);
        }
        public override void reduceFigure(int minusR)
        {
            if (R > 0)
                R -= minusR;
            findFrame(x, y);
        }
        public override bool isAbleToMove(int addX, int addY, PictureBox sheet)
        {
            if (addX != 0 && (x + addX > 20 || addX > 0) && (x + addX < sheet.Width - 20 || addX < 0))
            {
                return true;
            }
            else if (addY != 0 && (y + addY > 20 || addX > 0) && (y + addY < sheet.Height - 20 || addY < 0))
            {
                return true;
            }
            return false;
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
            findFrame(x, y);
            notifyConcrete(subjectObservers[1]);
        }

    }
    class Triangle : GeoFigure
    {
        Point[] points = new Point[3];

        public Triangle(int x, int y)
        {
            this.x = x;
            this.y = y;
            points[0].X = x;
            points[0].Y = y - 40;

            points[1].X = x - 20;
            points[1].Y = y + 20;

            points[2].X = x + 20;
            points[2].Y = y + 20;

            myBrush = Brushes.White;
            findFrame(x, y);
        }
        public override void findFrame(int X, int Y)
        {
            int width = points[2].X - points[1].X;
            int height = points[1].Y - points[0].Y;
            frame = new Rectangle(x, y - 12, width, height);
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
            gr.FillPolygon(myBrush, points);
            if (selected == true) 
                drawSelectedFigure(gr);
            else 
                gr.DrawPolygon(blackPen, points);
            //gr.DrawRectangle(blackPen, frame.leftUpAngle.X, frame.leftUpAngle.Y, frame.width, frame.height);
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
            findFrame(x, y);
        }
        public override void reduceFigure(int minusN)
        {
            points[0].Y += minusN;
            points[1].X += minusN;
            points[2].X -= minusN;
            findFrame(x, y);
        }
        public override bool isAbleToMove(int addX, int addY, PictureBox sheet)
        {
            if (addX != 0 && (points[1].X - 10 >= 0 || addX > 0) && (points[2].X <= sheet.Width - 10 || addX < 0))
                return true;
            else if (addY != 0 && (points[0].Y - 10 >= 0 || addY > 0) && (points[1].Y <= sheet.Height - 10 || addY < 0))
                return true;
            return false;
        }
        public override void moveFigure(int addX, int addY, PictureBox sheet)
        {
            int tempX = x - points[1].X;
            int tempY0 = y - points[0].Y;
            int tempY1 = y - points[1].Y;
            if((points[1].X - 10 >= 0 || addX > 0) && (points[2].X <= sheet.Width - 10 || addX < 0))
                x += addX;
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
            findFrame(x, y);
            notifyConcrete(subjectObservers[1]);
        }
    }
    class Rectangle : GeoFigure
    {
        public int width;
        public int height;
        public Point leftUpAngle = new Point();
        public Rectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
            width = 50;
            height = 50;
            leftUpAngle.X = x - width / 2;
            leftUpAngle.Y = y - height / 2;
            myBrush = Brushes.White;
            frame = this;
        }
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            leftUpAngle.X = x - width / 2;
            leftUpAngle.Y = y - height / 2;
            myBrush = Brushes.White;
        }
        public Point[] getPointsOfRect()
        {
            Point [] pointsOf = new Point[4];
            pointsOf[0] = leftUpAngle;
            pointsOf[1].X = leftUpAngle.X + width;
            pointsOf[1].Y = leftUpAngle.Y;
            pointsOf[2].X = leftUpAngle.X;
            pointsOf[2].Y = leftUpAngle.Y + height;
            pointsOf[3].X = leftUpAngle.X + width;
            pointsOf[3].Y = leftUpAngle.Y + height;
            return pointsOf;
        }
        public override void findFrame(int X, int Y)
        {
            return;
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
            gr.FillRectangle(myBrush, leftUpAngle.X, leftUpAngle.Y, width, height);
            if (selected == true) drawSelectedFigure(gr);
            else gr.DrawRectangle(blackPen, leftUpAngle.X, leftUpAngle.Y, width, height);
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
            frame = this;
        }
        public override void reduceFigure(int minusN)
        {
            width -= minusN;
            height -= minusN;
            leftUpAngle.X = x - width / 2;
            leftUpAngle.Y = y - height / 2;
            frame = this;
        }
        public override bool isAbleToMove(int addX, int addY, PictureBox sheet)
        {
            if (addX != 0 && (x - width / 2 + addX > 20 || addX > 0) && (x + width / 2 + addX < sheet.Width - 20 || addX < 0))
            {
                return true;
            }
            else if (addY != 0 && (y - height / 2 + addY > 20 || addX > 0) && (y + height / 2 + addY < sheet.Height - 20 || addY < 0))
            {
                return true;
            }
            return false;
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
            frame = this;
            notifyConcrete(subjectObservers[1]);
        }
    }
    abstract class FiguresFactory
    {
        abstract public GeoFigure createObj(string type, int x, int y);
    }
    class MyFiguresFactory : FiguresFactory
    {
        public override GeoFigure createObj(string type, int x, int y)
        {
            GeoFigure Figure = null;
            switch (type)
            {
                case "Lab4_1_OOP_Batyrov.Circle":
                    Figure = new Circle(x, y);
                    break;
                case "Lab4_1_OOP_Batyrov.Triangle":
                    Figure = new Triangle(x, y);
                    break;
                case "Lab4_1_OOP_Batyrov.Rectangle":
                    Figure = new Rectangle(x, y);
                    break;
            }
            return Figure;
        }
        public void load(Storage<GeoFigure> myStorage)
        {
            if (File.Exists("text.txt"))
            {
                StreamReader sr = new StreamReader("text.txt");
                int cnt = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < cnt; i++)
                {
                    string type = sr.ReadLine();
                    int x = Convert.ToInt32(sr.ReadLine());
                    int y = Convert.ToInt32(sr.ReadLine());
                    GeoFigure newFigure = createObj(type, x, y);
                    if(newFigure != null) 
                        myStorage.pushBack(newFigure);
                }
                sr.Close();
            }
        }
        public void save(Storage<GeoFigure> myStorage)
        {
            if (File.Exists("text.txt"))
                File.Delete("Text.txt");
            StreamWriter sw = new StreamWriter("text.txt");
            sw.WriteLine(myStorage.getCount().ToString());
            for (int i = 0; i < myStorage.getCount(); i++)
            {
                sw.WriteLine(myStorage[i].GetType());
                sw.WriteLine(myStorage[i].getX());
                sw.WriteLine(myStorage[i].getY());
            }
            sw.Close();
        }
    }
    abstract class Observer
    {
        public abstract void onSubjectChanged(Subject subject);
    }
    class StorageObserver : Observer
    {
        TreeView myTreeNode;
        Storage<GeoFigure> myStorage;
        public StorageObserver(TreeView tn, Storage <GeoFigure> storage)
        {
            myTreeNode = tn;
            myStorage = storage;
        }
        public override void onSubjectChanged(Subject subject)
        {
            if (subject is GeoFigure)
            {
                if ((subject as GeoFigure).checkSelected())
                {
                    for (int i = 0; i < myStorage.getCount(); i++)
                    {
                        if (myStorage[i] == subject)
                        {
                            myTreeNode.SelectedNode = myTreeNode.Nodes[0].Nodes[i];
                            break;
                        }
                            
                    }
                }
            }
            else
                printTree();
        }
        public void printTree()
        {
            myTreeNode.Nodes.Clear();
            if(myStorage.getCount() != 0)
            {
                myTreeNode.Nodes.Add("Все фигуры в рабочей области");
                for (int i = 0; i < myStorage.getCount(); i++)
                {
                    processNode(myTreeNode.Nodes[0], myStorage[i]);
                }
            }
            myTreeNode.ExpandAll();
        }
        public void processNode(TreeNode tn, Subject subject)
        {
            if(subject is Group && (subject as Group).getFigures().Length != 0)
            {
                TreeNode newTreeNode = new TreeNode(subject.GetType().Name);
                for(int i = 0; i < (subject as Group).getFigures().Length; i++)
                {
                    processNode(newTreeNode, (subject as Group).getFigures()[i]);
                }
                tn.Nodes.Add(newTreeNode);
            }
            else
            {
                tn.Nodes.Add((subject as GeoFigure).getInfo());
            }
        }
    }
    class StickObserver:Observer
    {
        Storage<GeoFigure> myStorage;
        public StickObserver(Storage<GeoFigure> newStorage)
        {
            myStorage = newStorage;
        }
        public override void onSubjectChanged(Subject subject)
        {
            GeoFigure newFigure = subject as GeoFigure;
            for(int i = 0; i < myStorage.getCount(); i++)
            {
                if (newFigure.checkSelected() == true && newFigure.stick == true)
                {
                    if(myStorage[i].frame != null && newFigure.checkIntersectionOfTwoRectangles(myStorage[i].frame) == true)
                    {
                        myStorage[i].select();
                    }
                }
            }
        }
    }
    class Subject
    {
        protected List <Observer> subjectObservers;
        public bool stick;
        public Subject()
        {
            subjectObservers = new List<Observer>();
        }
        public void addObserver(Observer newObserver)
        {
            subjectObservers.Add(newObserver);
        }
        public void notifyEveryOne()
        {
            
                subjectObservers[0].onSubjectChanged(this);
            
        }
        public void notifyConcrete(Observer obs)
        {
            obs.onSubjectChanged(this);
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

        public void drawALLGraph(Storage<GeoFigure> V)
        {
            //рисуем вершины
            for (int i = 0; i < V.getCount(); i++)
            { 
                V[i].drawFigure(gr);
            }
        }
        public void unSelectAll(Storage<GeoFigure> V)
        {
            for(int i = 0; i < V.getCount(); i++)
            {
                V[i].unSelect();
            }
        }
        public void erasePicked(Storage<GeoFigure> V)
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
        public void addStorageObs(Storage<GeoFigure> V, TreeView myTreeView)
        {
            StorageObserver newStorageObs = new StorageObserver(myTreeView, V);
            for (int i = 0; i < V.getCount(); i++)
            {
                V[i].addObserver(newStorageObs);
            }
        }

    }
}