using System;
using System.Collections.Generic;
using System.IO;

using Gtk;
using Cairo;


        using System.Linq;
public class ReadCordinactionfromTxt
  {
    public string Name { get; set; }
    public int Age { get; set; }
    // // Array for all my polygon lines
    public List<Twopointsline> MyPolygoncorinactions = new List<Twopointsline>();

    public ReadCordinactionfromTxt()
    {
        

      
    }



   

    public void   ReadCordinections(string filePath)
    {
        //linescorinactions.Clear();
        string filepath = filePath;


        int counter = 0;
        string txtline;
        string[] linecorinactions;
        //List<Twopointsline>  linescorinactions = new List<Twopointsline>()  ;
        Twopointsline twopointsline = new Twopointsline();
        PointD point1;
        PointD point2;

       
        System.IO.StreamReader file =
                    new System.IO.StreamReader(filepath);
        while ((txtline = file.ReadLine()) != null)
        {
            linecorinactions = txtline.Split(',');



            // System.Console.WriteLine (linecorinactions[1]);
            point1 = new PointD(Int32.Parse(linecorinactions[0]), Int32.Parse(linecorinactions[1]));
            point2 = new PointD(Int32.Parse(linecorinactions[2]), Int32.Parse(linecorinactions[3]));

            twopointsline.point1 = point1;
            twopointsline.point2 = point2;


            MyPolygoncorinactions.Add(twopointsline);



            counter++;
        }

        file.Close();
        System.Console.WriteLine("There were {0} lines.", counter);
        // Suspend the screen.  
        System.Console.ReadLine();






        Console.WriteLine("StreamReader Done");

       
    }



    // make ne struct for a Line
    public struct Twopointsline  
{
        public PointD point1,point2;

}  
    //Other properties, methods, events...
}