using Gtk;
using Cairo;
using System;

class SharpApp : Window
{


    public SharpApp() : base("Simple drawing")
    {
        SetDefaultSize(530, 150);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); }; ;

        DrawingArea darea = new DrawingArea();
        darea.ExposeEvent += OnExpose;

        Add(darea);

        ShowAll();
    }

    void OnExpose(object sender, ExposeEventArgs args)
    {
        
        drawline(10, 10, 10, 100,sender);
        drawline(10, 100, 100, 100,sender);
       



    }

    void drawline (int p1x, int p1y , int p2x , int p2y, object sender){

        DrawingArea area = (DrawingArea) sender;
        Cairo.Context cr = Gdk.CairoHelper.Create(area.GdkWindow);

       PointD p1, p2;

        p1 = new PointD(p1x, p1y);
        p2 = new PointD(p2x, p2y);
      
        cr.MoveTo(p1);
        cr.LineTo(p2);

        // give a color to line (red in this case)
        cr.Color = new Color(1, 0, 0);
        // this is line type
        cr.Stroke();
        ((IDisposable)cr).Dispose();

    }

    public static void Main()
    {
       
        Person person1 = new Person(@"/Users/omer/Desktop/sqr.txt");
        Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

        person1.writepolyogn();



        foreach (Twopointsline o in person1.linescorinactions)
        {
            Console.WriteLine(o.point1.X.ToString());
            drawline(o.point1.X, o.point1.y, o.point2.X, o.point2.X, sender);
        }
        //Console.WriteLine(person1.linescorinactions);
        Console.WriteLine( "Cant open the file");
        Application.Init();
        new SharpApp();
        Application.Run();
    }



}

