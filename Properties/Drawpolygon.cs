using Gtk;
using Cairo;
using System;
using System.IO;
//using System.Windows.Forms;
class SharpApp : Window
{
    // my cordinactions txtfile path
    public  string filepath ="";

    // to define where to start showing txt on screen
    public PointD messegepoint =new PointD (500, 500);


    public SharpApp() : base("Polgon")
    {
        
        OpenOFD();
        SetDefaultSize(830, 650);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Gtk.Application.Quit(); }; ;

        DrawingArea darea = new DrawingArea();
        darea.ExposeEvent += OnExpose;

        Add(darea);

        ShowAll();
    }

    void OnExpose(object sender, ExposeEventArgs args)
    {


        // Draw the Polygon lines 
        ReadCordinactionfromTxt person1 = new ReadCordinactionfromTxt();
        person1.ReadCordinections(filepath);
        foreach (ReadCordinactionfromTxt.Twopointsline o in person1.MyPolygoncorinactions)
        {
           
            drawline(o.point1.X, o.point1.Y, o.point2.X, o.point2.Y, sender);

          }



   
        // and object for the polygon with functions to calculate the area and check if closed
        PolygonSegments polygon1 = new PolygonSegments();

        //  polygon1.CalculateArea(person1.linescorinactions);

        /* check if it's Single closed Polygon 
         * As i undestand a Single close polgon is a simple close polygon. 
         * it's simple close polygon when every two lines conected with one points.
         */

        // check if it's close single polygon
        if (polygon1.IsSingleColsed(person1.MyPolygoncorinactions))
        {
            Console.WriteLine(" Single closed Polygon");
            // Print The meseges on the Screen 
            printtxt(" Single closed Polygon", sender);

            // calculate the Area if it's single close polygon
            double polugonArea = polygon1.CalculateArea(person1.MyPolygoncorinactions);

            Console.WriteLine("The Area  of the Polygon is:  " + polugonArea);
            // Print The meseges on the Screen 
            printtxt("The Area  of the Polygon is:  " + polugonArea, sender);


        }
        else
        {
            Console.WriteLine(" Open Polygon ");
            // Print The meseges on the Screen 
            printtxt(" Open Polygon ", sender);



        }

    }



private void OpenOFD()
    {
        Gtk.FileChooserDialog filechooser =
            new Gtk.FileChooserDialog("Choose the file to open",
                this,
                FileChooserAction.Open,
                "Cancel", ResponseType.Cancel,
                "Open", ResponseType.Accept);

        if (filechooser.Run() == (int)ResponseType.Accept)
        {
            System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
            Console.WriteLine("file name " + filechooser.Filename);
            filepath = filechooser.Filename;
            file.Close();
        }

        filechooser.Destroy();
    }


    // Draw line Function
    void drawline (double p1x, double p1y , double p2x , double p2y, object sender){

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


    // print Txt Function
    void printtxt ( string theResultmessge, object sender)
    {

        DrawingArea area = (DrawingArea)sender;
        Cairo.Context cr = Gdk.CairoHelper.Create(area.GdkWindow);

       
        cr.MoveTo(messegepoint);

        // give a color to line (red in this case)
        cr.Color = new Color(0, 0, 0);
        // this is line type

        cr.ShowText(theResultmessge);

        messegepoint.Y += 15;

        cr.Stroke();
        ((IDisposable)cr).Dispose();

    }
    public static void Main()
    {

       





        Gtk.Application.Init();
        new SharpApp();
        Gtk.Application.Run();
    }






}
