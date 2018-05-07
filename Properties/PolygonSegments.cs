using System;
using System.Collections.Generic;
using System.IO;

using Gtk;
using Cairo;


using System.Linq;
public class PolygonSegments
{
    public string Name { get; set; }
    public int Age { get; set; }
    //public List<Twopointsline> linescorinactions = new List<Twopointsline>();

    public PolygonSegments()
    {
        

        //

        // writepolyogn(filePath);
        //endofclass
    }
    /* 
        * As i undestand a Single close polgon is a simple close polygon. 
        * it's simple close polygon when every two lines  shared just one point.
        */
    public bool IsSingleColsed(List<ReadCordinactionfromTxt.Twopointsline> linescorinactions)
    {
        //bool isSingleClosed = true ;

        foreach (ReadCordinactionfromTxt.Twopointsline line in linescorinactions)
        {
          //  Console.WriteLine("loop1: " + line.point1.X + " point12x " + line.point2.X + "   " + line.point1.Y + " point12y " + line.point2.Y);
            int p2_count = 0;
            int p1_count = 0;
            foreach (ReadCordinactionfromTxt.Twopointsline line2 in linescorinactions)
            {
                

               // Console.WriteLine(line.point1.X + " point12x " + line.point2.X + "   " + line.point1.Y + " point12y " + line.point2.Y);
            //    Console.WriteLine("loop 2:  " + line2.point1.X + " point12x " + line2.point2.X + "   " + line2.point1.Y + " point12y " + line2.point2.Y);
                    if (Point.Equals(line.point1, line2.point1) || Point.Equals(line.point1, line2.point2))
                        p1_count += 1;
                    if (Equals(line.point2, line2.point1) || Equals(line.point2, line2.point2))
                        p2_count += 1;
                }
            Console.WriteLine("p1count = " + p1_count + "  p2count" + p2_count);

            if (p2_count != 2 || p1_count != 2)
            {
               // Console.WriteLine("Open");
                return false;

            }
             


        }
    //    Console.WriteLine(" Single closed");
        return true;

    }

    // the formila to calucalte the Area is: Area = abs (p1.x * p2.y - p1.y*p2.x  + pn.x*pn+1.y - ......... pn.y * pn+1.x)/2

    public double CalculateArea(List<ReadCordinactionfromTxt.Twopointsline> linescorinactions)
    {
        double area = 0;

        foreach (ReadCordinactionfromTxt.Twopointsline line in linescorinactions)
        {
            ///

            area += (line.point1.X * line.point2.Y - line.point1.Y * line.point2.X);

            //

        }

        area = Math.Abs((area / 2));
       // Console.WriteLine("Area  +  " + area);
        return area;
    }
}


  