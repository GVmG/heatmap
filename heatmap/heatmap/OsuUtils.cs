using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace heatmap
{
    class OsuUtils
    {
        // CS to osu!pixels - osu!pixels are what the diameter of the circles would be in a 512x384 resolution.
        // formula is rough but it does its job. originally found here: https://osu.ppy.sh/forum/p/4282387 (thx Cl8n!)
        public static float CStoOsuPixels(float cs) { return (int)(109 - 9 * cs); }

        // OD to milliseconds - returns an array where the 0th item is for 300s, the 1st is for 100s and the third is for 50s.
        // formula might not be correct, idk where this guy got it: https://www.reddit.com/r/osugame/comments/781ot4/od_in_milliseconds/doqngos (thx anyway /u/Fukiyel!)
        public static float[] ODtoMilliseconds(float od) { return new float[] { -(6f * (od - 13.25f)), -(8f * (od - 17.4375f)), -(10f * (od - 19.95f)) }; }

        // AR to milliseconds - returns the milliseconds the circle will stay on screen for with any given AR.
        // the formula should be the correct one. sauce has been long lost in my search history from years ago.
        public static int ARtoMilliseconds(float ar) { return (int)(ar < 5 ? (1800 - (ar * 120)) : (1200 - ((ar - 5) * 150))); }

        // Object Type to int - returns 0, 1 or 2 depending on the input number (from the beatmap file itself)
        public static int ObjectType(int input)
        {
            if ((input & 2) != 0) { return 1; } //slider
            else if ((input & 8) != 0) { return 2; } //spinner
            else return 0; //circle (treat everything as a circle by default);
        }

        // returns the distance between 2 points - in float because fite me - also backup float-array one cause vectors
        public static float PointDistance(float x1, float y1, float x2, float y2) { return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); }
        public static float PointDistance(float[] p1, float[] p2) { return PointDistance(p1[0], p1[1], p2[0], p2[1]); }

        // returns a value or its min or max - just ints cause yes
        public static int Clamp(int value, int min, int max)
        {
            return (value < min ? min : (value > max ? max : value));
        }

        // returns a color based on the input, for the colored heatmap rendering (range 0-1)
        public static Color HeatMap(float value)
        {
            return Color.FromArgb(255, (int)(255 * value), (int)(255 * (1 - value)));
        }
    }
}
