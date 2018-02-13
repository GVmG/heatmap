using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace heatmap
{
    class HitObject
    {
        public List<Point> position = new List<Point>(); //list because the ones over the 0th are sliderpoints.
        public int type, time, //types are 0:Circle, 1:Slider, 2:Spinner
            endtime; //this is pretty much useless for the heatmap. I'm still saving it cause idk.
        public string slidertype; //types are L:inear, P:erfect (aka Passthrough), B:ezier, C:atmull

        public HitObject(List<Point> position, int time, int type)
        {
            this.position = position;
            this.time = time;
            this.type = type;
        }

        public HitObject(string hitobj)
        {
            string[] hitobjstr = hitobj.Split(',');
            //position = new Point[] { };

            if (Int32.TryParse(hitobjstr[3], out type)) //succesfully parsed the type
            {
                position.Add(new Point(Int32.Parse(hitobjstr[0]), Int32.Parse(hitobjstr[1])));
                
                time = Int32.Parse(hitobjstr[2]);
                type = OsuUtils.ObjectType(type);

                //special cases
                if (type == 1) //slider
                {
                    string[] pointsstr = hitobjstr[5].Split('|');
                    slidertype = pointsstr[0];
                    for (int i=1; i<pointsstr.Length; i++) //for each point
                    {
                        string[] curpointstr = pointsstr[i].Split(':'); //get the two coords
                        Point curpoint = new Point(Int32.Parse(curpointstr[0]), Int32.Parse(curpointstr[1])); //make a point out of them
                        position.Add(curpoint); //and add said point to the list. note that the 0th item will just be the position of the sliderhead.
                    }
                }
                else if (type == 2) //spinner
                {
                    String endstr = (hitobjstr[5].Split(':'))[0]; //split the final part (endtime+extras), and take the 0th item (the endtime)
                    endtime = Int32.Parse(endstr);
                }
            }
            else { throw new Exception($"Couldn't create HitObject from string [{hitobj}]."); }
        }

        public void RenderSoft(Graphics g, int xoff, int yoff, int cs, float strength)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(position[0].X + xoff - (int)(cs * 0.5), position[0].Y + yoff - (int)(cs * 0.5), cs, cs);
            PathGradientBrush brush = new PathGradientBrush(path)
            {
                CenterColor = Color.FromArgb((int)(strength * 255), Color.White), //gonna have to rework the strength
                SurroundColors = new Color[] { Color.FromArgb(0, Color.White) }
            };
            g.FillEllipse(brush, position[0].X + xoff - (int)(cs * 0.5), position[0].Y + yoff - (int)(cs * 0.5), cs, cs);
            brush.Dispose();
            path.Dispose();
        }

        //set the sliderpoints - returns false if this isn't a slider, true otherwise.
        //this isn't really used... yet. idk if I'll use it. I'm still keeping it, I grew attached to this ok? :'c
        public bool SetSliderPoints(List<Point> points)
        {
            if (type!=1) { return false; }
            position = points;
            return true;
        }
    }
}
