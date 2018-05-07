using System;
using System.Collections.Generic;
using Cairo;

namespace gtkline
{
    public class Polygon
    {
        
        public Polygon()
        {



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
                 int p1_count = 0;
         int p2_count =0 ;

                foreach (ReadCordinactionfromTxt.Twopointsline line2 in linescorinactions)
                {
                   
                    if (Equals(line.point1, line2.point1) || Equals(line.point1, line2.point2))
                        p1_count += 1;
                    if (Equals(line.point2, line2.point1) || Equals(line.point2, line2.point2))
                        p2_count += 1;
                }

                if (p2_count != 2 || p1_count != 2)
                    
                    Console.WriteLine("Open");
                    return false;
               
                   
                }
            Console.WriteLine("single closed");
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

            area = Math.Abs( area / 2);
            Console.WriteLine("Area  +  " + area);
            return area;
        }
    }




}

