using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingApplication
{   
    public partial class Grafpack : Form
    {
        private enum Menu { SELECT, SQUARE, RECTANGLE,BS_CIRCLE, ELLIPSE, RA_TRIANGLE, IS_TRIANGLE, ERASE }
        
        private Pen blackPen = new Pen(Color.Black);
        private Pen HighLight = new Pen(Color.DarkOrange);
        private List<Object> shapes;
        private int selectedShape;
        private Menu SelectedMenu;
        private bool DrawUpdate = false;
        private static Timer timer;
        bool rotateAll = false;
        Object drawnShape;
        PointF relativeHeldPos;
        bool mouseHold;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Grafpack());
        }

        public Grafpack()
        {          
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            /////////////////////////

            SelectedMenu = Menu.SELECT;
            selectedShape = -1;
            shapes = new List<Object>();
            timer = new Timer();
            timer.Tick += new EventHandler(Timer1_Tick);
            timer.Interval = 16;
            timer.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (DrawUpdate)
            {
                switch (SelectedMenu)
                {
                    case Menu.SQUARE:
                        float tempX = Math.Abs(PointToClient(Cursor.Position).X - relativeHeldPos.X);
                        float tempY = Math.Abs(PointToClient(Cursor.Position).Y - relativeHeldPos.Y);

                        if (tempX >= tempY)
                        {
                            ((PointF[])drawnShape)[2].X = relativeHeldPos.X + PointToClient(Cursor.Position).X - relativeHeldPos.X;
                            ((PointF[])drawnShape)[2].Y = relativeHeldPos.Y + PointToClient(Cursor.Position).X - relativeHeldPos.X;
                        }                                        
                        else                                     
                        {                                        
                            ((PointF[])drawnShape)[2].X = relativeHeldPos.X + PointToClient(Cursor.Position).Y - relativeHeldPos.Y;
                            ((PointF[])drawnShape)[2].Y = relativeHeldPos.Y + PointToClient(Cursor.Position).Y - relativeHeldPos.Y;
                        }

                        ((PointF[])drawnShape)[1].X = ((PointF[])drawnShape)[2].X;
                        ((PointF[])drawnShape)[3].Y = ((PointF[])drawnShape)[2].Y;


                        break;
                    case Menu.RA_TRIANGLE:
                        ((PointF[])drawnShape)[2] = PointToClient(Cursor.Position);
                        ((PointF[])drawnShape)[0].Y = PointToClient(Cursor.Position).Y;
                        break;
                    case Menu.RECTANGLE:
                        ((PointF[])drawnShape)[1].X = PointToClient(Cursor.Position).X;
                        ((PointF[])drawnShape)[2]   = PointToClient(Cursor.Position);
                        ((PointF[])drawnShape)[3].Y = PointToClient(Cursor.Position).Y;
                        break;
                    case Menu.IS_TRIANGLE:
                        ((PointF[])drawnShape)[1] = PointToClient(Cursor.Position);
                        ((PointF[])drawnShape)[2].Y = PointToClient(Cursor.Position).Y;
                        ((PointF[])drawnShape)[2].X = (-1 * (PointToClient(Cursor.Position).X - ((PointF[])drawnShape)[0].X)) + ((PointF[])drawnShape)[0].X;
                        break;
                    case Menu.BS_CIRCLE:                       
                        ((Circle)drawnShape).screenPosition.X = ((PointToClient(Cursor.Position).X - relativeHeldPos.X)/2)+ relativeHeldPos.X;
                        ((Circle)drawnShape).screenPosition.Y = ((PointToClient(Cursor.Position).Y - relativeHeldPos.Y) / 2) + relativeHeldPos.Y;
                        ((Circle)drawnShape).radius = (float)(Math.Sqrt(Math.Pow(((PointToClient(Cursor.Position).X - ((Circle)drawnShape).screenPosition.X)), 2) + Math.Pow(((PointToClient(Cursor.Position).Y - ((Circle)drawnShape).screenPosition.Y)) , 2)));
                        break;
                    case Menu.ELLIPSE:
                        drawnShape = new RectangleF
                            (
                                ((RectangleF)drawnShape).Location.X,
                                ((RectangleF)drawnShape).Location.Y,
                                PointToClient(Cursor.Position).X - ((RectangleF)drawnShape).Location.X,
                                PointToClient(Cursor.Position).Y - ((RectangleF)drawnShape).Location.Y
                            );
                        break;
                }
                
                if (mouseHold&& relativeHeldPos != null)
                {                
                    ((Shape)shapes[selectedShape]).screenPosition.X = PointToClient(Cursor.Position).X + relativeHeldPos.X;
                    ((Shape)shapes[selectedShape]).screenPosition.Y = PointToClient(Cursor.Position).Y + relativeHeldPos.Y;
                }
            }
            
            Invalidate();     
        }
        private void DrawPolygon(Graphics g,Pen pen,PointF[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if(i+1<points.Length)
                    DrawLine(g,pen,points[i],points[i+1]);
                else
                    DrawLine(g,pen, points[i], points[0]);                
            }
        }
        //DDA Line generation Algorithm
        public void DrawLine(Graphics g,Pen pen,PointF p0, PointF p1)
        {       

            // calculate dx & dy 
            int dx = (int)(p1.X - p0.X);
            int dy = (int)(p1.Y - p0.Y);

            // calculate steps required for generating pixels 
            int steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            // calculate increment in x & y for each steps 
            float Xinc = dx / (float)steps;
            float Yinc = dy / (float)steps;

            // Put pixel for each step 
            float X = p0.X;
            float Y = p0.Y;
            for (int i = 0; i <= steps; i++)
            {
                PutPixel(g,pen,new PointF(X,Y));  // put pixel at (X,Y) 
                X += Xinc;           // increment in x at each step 
                Y += Yinc;           // increment in y at each step 
                                     // for visualization of line- 
                                     // generation step by step 
            }
        }
        void PutPixel(Graphics g,Pen p, PointF pixel)
        {
            Brush aBrush = p.Brush;            
            g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
        }
        //The Bresenham Circle Drawing Algorithm 
        void DrawCircle(Graphics g,Pen pen, int centreX, int centreY, int radius)
        {
            Point plotPt = new Point(0, 0);
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;  // initial value

            while (x <= y)
            {
                // put pixel in each octant
                plotPt.X = x + centreX;
                plotPt.Y = y + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = y + centreX;
                plotPt.Y = x + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = y + centreX;
                plotPt.Y = -x + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = x + centreX;
                plotPt.Y = -y + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = -x + centreX;
                plotPt.Y = -y + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = -y + centreX;
                plotPt.Y = -x + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = -y + centreX;
                plotPt.Y = x + centreY;
                PutPixel(g, pen, plotPt);

                plotPt.X = -x + centreX;
                plotPt.Y = y + centreY;
                PutPixel(g, pen, plotPt);

                // update d value 
                if (d <= 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }
        private void DrawShapes(Graphics g)
        {
            if (rotateAll)
            {
                for (int i = 0; i < shapes.Count; i++)
                {
                    ((Shape)shapes[i]).add_angle(-2);
                }
            }
            for (int i = 0; i < shapes.Count; i++)
            {
                if (i == selectedShape)
                {
                    if (shapes[i] is Polygon) DrawPolygon(g,HighLight, ((Polygon)shapes[i]).GetForDraw());

                    else if (shapes[i] is Ellipse) g.DrawEllipse(HighLight, ((Ellipse)shapes[i]).GetForDraw());

                    else if (shapes[i] is Circle) DrawCircle(g, HighLight, (int)((Circle)shapes[i]).screenPosition.X, (int)((Circle)shapes[i]).screenPosition.Y,(int)((Circle)shapes[i]).GetScaledRadius());
                }

                else if (shapes[i] is Polygon) DrawPolygon(g, blackPen, ((Polygon)shapes[i]).GetForDraw());

                else if (shapes[i] is Ellipse) g.DrawEllipse(blackPen, ((Ellipse)shapes[i]).GetForDraw());

                else if (shapes[i] is Circle) DrawCircle(g,blackPen, (int)((Circle)shapes[i]).screenPosition.X, (int)((Circle)shapes[i]).screenPosition.Y, (int)((Circle)shapes[i]).GetScaledRadius());
            }
            if (drawnShape is PointF[]) DrawPolygon(g,blackPen, (PointF[])drawnShape);
            else if (drawnShape is RectangleF) g.DrawEllipse(blackPen,(RectangleF)drawnShape);
            else if (drawnShape is Circle) DrawCircle(g,blackPen, (int)((Circle)drawnShape).screenPosition.X, (int)((Circle)drawnShape).screenPosition.Y, (int)((Circle)drawnShape).GetScaledRadius());

        }

        protected override void OnPaint(PaintEventArgs e)
        {
          
            base.OnPaint(e);
            Graphics g = e.Graphics; // Get on screen graphics tool
            DrawShapes(g);          
        }
        
        private void rightAngleTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.RA_TRIANGLE;           
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Cursor = Cursors.Cross;
            selectedShape = -1;
        }

        private void eqilateralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.IS_TRIANGLE;
            this.Cursor = Cursors.Cross;
            selectedShape = -1;
        }
        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.ERASE;
            this.Cursor = Cursors.Hand;
            selectedShape = -1;
        }
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.SELECT;
            this.Cursor = Cursors.Default;
            selectedShape = -1;     
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {          
            switch (SelectedMenu)
            {
                case Menu.SQUARE:
                    relativeHeldPos = PointToClient(Cursor.Position);
                    drawnShape = new PointF[] { PointToClient(Cursor.Position), PointToClient(Cursor.Position), PointToClient(Cursor.Position), PointToClient(Cursor.Position) };
                    DrawUpdate = true;                    
                    break;
                case Menu.RA_TRIANGLE:
                     drawnShape = (new PointF[] { PointToClient(Cursor.Position), PointToClient(Cursor.Position), PointToClient(Cursor.Position) });
                     DrawUpdate = true;
                    break;
                case Menu.RECTANGLE:
                     drawnShape = new PointF[] { PointToClient(Cursor.Position), PointToClient(Cursor.Position), PointToClient(Cursor.Position), PointToClient(Cursor.Position) };
                     DrawUpdate = true;
                    break;
                case Menu.IS_TRIANGLE:
                    drawnShape = (new PointF[] { PointToClient(Cursor.Position), PointToClient(Cursor.Position), PointToClient(Cursor.Position) });
                    DrawUpdate = true;
                    break;
                case Menu.ELLIPSE:
                    drawnShape = (new RectangleF(PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y, 0, 0));
                    DrawUpdate = true;                    
                    break;
                case Menu.BS_CIRCLE:
                    drawnShape = new Circle(PointToClient(Cursor.Position), 0);                   
                    relativeHeldPos = PointToClient(Cursor.Position);                 
                    DrawUpdate = true;
                    break;

                case Menu.SELECT:
                    if (mouseHold == true) return;
                    int mouseW = 6;
                    PointF[] mouseBox = new PointF[]
                           {
                                new PointF(PointToClient(Cursor.Position).X-mouseW, PointToClient(Cursor.Position).Y -mouseW),
                                new PointF(PointToClient(Cursor.Position).X+mouseW, PointToClient(Cursor.Position).Y -mouseW),
                                new PointF(PointToClient(Cursor.Position).X+mouseW, PointToClient(Cursor.Position).Y +mouseW),
                                new PointF(PointToClient(Cursor.Position).X-mouseW, PointToClient(Cursor.Position).Y +mouseW),
                           };                  
                    for (int i =0; i<shapes.Count;i++)
                    {
                        if (shapes[i] is Polygon)
                        {
                            if (MathClass.ShapeOverlap_DIAGS(mouseBox, ((Polygon)shapes[i]).GetForDraw()))
                            {
                                selectedShape = i;
                                relativeHeldPos.X = ((Shape)shapes[selectedShape]).screenPosition.X - PointToClient(Cursor.Position).X;
                                relativeHeldPos.Y = ((Shape)shapes[selectedShape]).screenPosition.Y - PointToClient(Cursor.Position).Y;
                                DrawUpdate = true;
                                mouseHold = true;

                                return;
                            }
                        }
                        else if (shapes[i] is Ellipse)
                        {
                            RectangleF r = ((Ellipse)shapes[i]).GetForDraw();
                            PointF[] p = new PointF[]
                            {
                                new PointF((int)r.X,(int)r.Y),
                                new PointF((int)r.Right,(int)r.Y),
                                new PointF((int)r.Right,(int)r.Bottom),
                                new PointF((int)r.X,(int)r.Bottom),
                            };
                            if (MathClass.ShapeOverlap_DIAGS(mouseBox, p))
                            {
                                selectedShape = i;
                                relativeHeldPos.X = ((Shape)shapes[selectedShape]).screenPosition.X - PointToClient(Cursor.Position).X;
                                relativeHeldPos.Y = ((Shape)shapes[selectedShape]).screenPosition.Y - PointToClient(Cursor.Position).Y;
                                DrawUpdate = true;
                                mouseHold = true;

                                return;
                            }
                        }
                        else if (shapes[i] is Circle)
                        {
                            if (MathClass.ShapeOverlap_Circle((Circle)shapes[i], new Circle(PointToClient(Cursor.Position),10)))
                            {
                                selectedShape = i;
                                relativeHeldPos.X = ((Shape)shapes[selectedShape]).screenPosition.X - PointToClient(Cursor.Position).X;
                                relativeHeldPos.Y = ((Shape)shapes[selectedShape]).screenPosition.Y - PointToClient(Cursor.Position).Y;
                                DrawUpdate = true;
                                mouseHold = true;
                                return;
                            }
                            
                        }

                    }
                    selectedShape = -1;
                    break;                    
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {                      
            if (drawnShape != null)
            {
                if (drawnShape is PointF[]) shapes.Add(new Polygon((PointF[])drawnShape));
                else if (drawnShape is RectangleF) shapes.Add(new Ellipse((RectangleF)drawnShape));
                else if (drawnShape is Circle) shapes.Add(new Circle(((Circle)drawnShape).screenPosition, ((Circle)drawnShape).radius));
                drawnShape = null;
            }
            DrawUpdate = false;
            mouseHold = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Cursor = Cursors.Default;
                    selectedShape = -1;
                    SelectedMenu = Menu.SELECT;
                    break;
                case Keys.Delete:
                    if (selectedShape != -1)
                    {
                        shapes.RemoveAt(selectedShape);
                        selectedShape = -1;
                    }
                    break;
                case Keys.Left:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_angle(-1);
                        break;
                case Keys.Right:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_angle(1);
                    break;
                case Keys.Up:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_scale(0.05);
                    break;
                case Keys.Down:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_scale(-0.05);
                    break;
                case Keys.W:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_PositionOffet(new Point(0,-5));
                    break;
                case Keys.A:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_PositionOffet(new Point(-5, 0));
                    break;
                case Keys.S:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_PositionOffet(new Point(0, 5));
                    break;
                case Keys.D:
                    if (selectedShape != -1) ((Shape)shapes[selectedShape]).add_PositionOffet(new Point(5, 0));
                    break;
            }
        }            

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = -1;
            shapes = new List<Object>();            
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            MessageBox.Show("Controls:\nHOLD and DRAG to create selected shape type.\nHOLD and DRAG to translate selected spawned shape.\nWASD = Also translates the selected spawned shape.\nDEL = Delete the selected spawned shape.\nLEFT and RIGHT = Rotate selected spawned shape.\nUP and DOWN = Scale selected spawned shape.\nESC = Universal de-select.");
        } 

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotateAll = true;
        }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotateAll = false;
        }

        private void eLLIPSEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.ELLIPSE;
            this.Cursor = Cursors.Cross;
            selectedShape = -1;
        }

        private void bASICCIRCLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.BS_CIRCLE;
            this.Cursor = Cursors.Cross;
            selectedShape = -1;
        }

        private void rECTANGLEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.RECTANGLE;
            this.Cursor = Cursors.Cross;
            selectedShape = -1;
        }

        private void rECTANGLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedMenu = Menu.SQUARE;
            this.Cursor = Cursors.Cross;
            selectedShape = -1;
        }
    }
}
class Shape
{
    public double angle;
    public double scale;
    public PointF screenPosition;
    protected PointF[] normalizedPoints;

    public void add_PositionOffet(PointF p)
    {
        screenPosition.X += p.X;
        screenPosition.Y += p.Y;
    }
    public void add_angle(double a)
    {
        angle = (angle + a) % 360;
    }
    public void add_scale(double a)
    {
        if ((scale + a) >= 0)
        {
            scale += a;
        }
        else scale = 0;
    }
}
class Polygon : Shape
{  
    public Polygon(PointF[] points)
    {
        screenPosition = new PointF(0,0);
        for (int i = 0; i < points.Length; i++)
        {
            screenPosition.X += points[i].X;
            screenPosition.Y += points[i].Y;
        }
        screenPosition.X /= points.Length;
        screenPosition.Y /= points.Length;
        normalizedPoints = points;
        for (int i = 0; i < points.Length; i++)
        {
            normalizedPoints[i].X -= screenPosition.X;
            normalizedPoints[i].Y -= screenPosition.Y;
        }
        angle = 0;
        scale = 1;       
    }
    public PointF[] GetForDraw()
    {       
        PointF[] answ = new PointF[normalizedPoints.Length];
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i].X = this.normalizedPoints[i].X;
            answ[i].Y = this.normalizedPoints[i].Y;
        }
        //Rotation
       
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i] = MathClass.RotationTranformation(answ[i], this.angle);            
        }
        //Scaling
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i].X *= (float)scale;
            answ[i].Y *= (float)scale;
        }

        //Translation
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i].X = answ[i].X + this.screenPosition.X;
            answ[i].Y = answ[i].Y + this.screenPosition.Y;
        } 
        return answ;
    }   
}
class Circle : Shape
{
    public float radius;
    public Circle(PointF p, float r)
    {
        scale = 1;
        screenPosition = p;
        radius=r;
    }
    public float GetScaledRadius()
    {
        return radius * (float)scale;
    }

}
class Ellipse : Shape
{
    public Ellipse(RectangleF rect)
    {
        scale = 1;
        screenPosition.X = rect.X + (rect.Width/2);
        screenPosition.Y = rect.Y + (rect.Height/2);       
        normalizedPoints = new PointF[2];
        normalizedPoints[0] = new PointF(rect.X - screenPosition.X, rect.Y - screenPosition.Y);
        normalizedPoints[1] = new PointF(rect.Width, rect.Height);
    }

    public Ellipse(PointF a, PointF b)
    {
        scale = 1;
        screenPosition.X = ((b.X - a.X) / 2) + a.X;
        screenPosition.Y = ((b.Y - a.Y) / 2) + a.Y;
        normalizedPoints = new PointF[2];
        normalizedPoints[0] = new PointF(a.X-screenPosition.X,a.Y-screenPosition.Y);
        normalizedPoints[1] = new PointF(b.X - screenPosition.X, b.Y - screenPosition.Y);
    }

    public RectangleF GetForDraw()
    {
        PointF[] answ = new PointF[normalizedPoints.Length];
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i].X = this.normalizedPoints[i].X;
            answ[i].Y = this.normalizedPoints[i].Y;
        }
        //Rotation
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i] = MathClass.RotationTranformation(answ[i], this.angle);
        }
        for (int i = 0; i < answ.Length; i++)
        {
            answ[i].X *= (float)scale;
            answ[i].Y *= (float)scale;
        }
        //Translation
        answ[0].X = answ[0].X + this.screenPosition.X;
        answ[0].Y = answ[0].Y + this.screenPosition.Y;

        return new RectangleF(answ[0].X, answ[0].Y, answ[1].X, answ[1].Y);
    }
}
class MathClass
{
    //Calcualtes new position of point after rotation around origin
    public static PointF RotationTranformation(PointF p, double degrees)
    {  
        double angleR = degrees * (Math.PI / 180);
      
        return new PointF
            (
                (float)((double)p.X * Math.Cos(angleR) - (double)p.Y * Math.Sin(angleR)),
                (float)((double)p.X * Math.Sin(angleR) + (double)p.Y * Math.Cos(angleR))
            );       
    }
    public static bool ShapeOverlap_Circle(Circle c1, Circle c2)
    {        
        float d = (float)(Math.Sqrt(Math.Pow(c1.screenPosition.X - c2.screenPosition.X, 2) + Math.Pow(c1.screenPosition.Y - c2.screenPosition.Y, 2)));      
        return (c1.GetScaledRadius() + c2.GetScaledRadius() >= d && (c1.GetScaledRadius() + c2.GetScaledRadius()) <= d + 20);
    }
    //Determines if overlap has occoured, used with mouse clicks to select a spawned shape
    public static bool ShapeOverlap_DIAGS(PointF[] r1, PointF[] r2)
    {
        PointF[] poly1 = r1;
        PointF[] poly2 = r2;

        for (int shape = 0; shape < 2; shape++)
        {
            if (shape == 1)
            {
                poly1 = r2;
                poly2 = r1;
            }

            // Check diagonals of polygon...
            for (int p = 0; p < poly1.Length; p++)
            {
                PointF line_r1s = new PointF();
                for (int i = 0; i < poly1.Length; i++)
                {
                    line_r1s.X += poly1[i].X;
                    line_r1s.Y += poly1[i].Y;
                }
                line_r1s.X = line_r1s.X / poly1.Length;
                line_r1s.Y = line_r1s.Y / poly1.Length;

                PointF line_r1e = poly1[p];

                // ...against edges of the other
                for (int q = 0; q < poly2.Length; q++)
                {
                    PointF line_r2s = poly2[q];
                    PointF line_r2e = poly2[(q + 1) % poly2.Length];

                    // Standard "off the shelf" line segment intersection
                    float h = (line_r2e.X - line_r2s.X) * (line_r1s.Y - line_r1e.Y) - (line_r1s.X - line_r1e.X) * (line_r2e.Y - line_r2s.Y);
                    float t1 = ((line_r2s.Y - line_r2e.Y) * (line_r1s.X - line_r2s.X) + (line_r2e.X - line_r2s.X) * (line_r1s.Y - line_r2s.Y)) / h;
                    float t2 = ((line_r1s.Y - line_r1e.Y) * (line_r1s.X - line_r2s.X) + (line_r1e.X - line_r1s.X) * (line_r1s.Y - line_r2s.Y)) / h;

                    if (t1 >= 0.0f && t1 < 1.0f && t2 >= 0.0f && t2 < 1.0f)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }   
}
