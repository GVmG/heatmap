using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace heatmap
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> beatmapinfo=new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bing!");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadBeatmap(textBox1.Text);
        }

        private void textBox1_TextEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadBeatmap(textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            beatmapinfo.Add("artist", "Camellia");
            beatmapinfo.Add("title", "bug collection");
            beatmapinfo.Add("mapper", "Rainfall");
            beatmapinfo.Add("diffname", "Arthropod");
            beatmapinfo.Add("source", "");
            beatmapinfo.Add("cs", "4.5");
            beatmapinfo.Add("ar", "9.3");
            beatmapinfo.Add("od", "8.0");
            beatmapinfo.Add("hp", "6.0");
            beatmapinfo.Add("id", "1531785");
            beatmapinfo.Add("setid", "725473");

            UpdateMapData();
        }

        private void UpdateMapData()
        {
            string artist = beatmapinfo["artist"], title = beatmapinfo["title"], mapper = beatmapinfo["mapper"],
                diffname = beatmapinfo["diffname"], source = beatmapinfo["source"],
                cs = beatmapinfo["cs"], od = beatmapinfo["od"], hp = beatmapinfo["hp"], ar = beatmapinfo["ar"],
                id = beatmapinfo["id"], setid = beatmapinfo["setid"];
            int pixelcs = (int)CStoOsuPixels(float.Parse(cs, CultureInfo.InvariantCulture));
            float[] msvalues = ODtoMilliseconds(float.Parse(od, CultureInfo.InvariantCulture));

            labelBeatmapInfo.Text = $"Title: {title}\nArtist: {artist}\nDifficulty: {diffname}\nMapset by: {mapper}\n" +
                $"Source: {source}\nApproach Rate: {ar}\nCircle Size: {cs} ({pixelcs} osu!pixels)\nHP Drain: {hp}\n" +
                $"Overall Difficulty: {od}\n(300: ±{(int)msvalues[0]}ms, 100: ±{(int)msvalues[1]}ms, 50: ±{(int)msvalues[2]}ms)" +
                $"\n\nBeatmap ID: {setid}\nDifficulty ID: {id}";
        }

        // utilities - functions I can use for various things - probably gonna move them to a class later on

        // CS to osu!pixels - osu!pixels are what the diameter of the circles would be in a 512x384 resolution.
        // formula is rough but it does its job. originally found here: https://osu.ppy.sh/forum/p/4282387 (thx Cl8n!)
        private float CStoOsuPixels(float cs) { return (int)(109 - 9 * cs); }

        // OD to milliseconds - returns an array where the 0th item is for 300s, the 1st is for 100s and the third is for 50s.
        // formula might not be correct, idk where this guy got it: https://www.reddit.com/r/osugame/comments/781ot4/od_in_milliseconds/doqngos (thx anyway /u/Fukiyel!)
        private float[] ODtoMilliseconds(float od) { return new float[]{ -(6f * (od - 13.25f)), -(8f * (od - 17.4375f)), -(10f * (od - 19.95f))}; }

        // returns the distance between 2 points - in float because fite me - also backup float-array one cause vectors
        private float PointDistance(float x1, float y1, float x2, float y2) { return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); }
        private float PointDistance(float[] p1, float[] p2) { return PointDistance(p1[0], p1[1], p2[0], p2[1]); }

        // end of the utility functions

        private void LoadBeatmap(string path)
        {
            MessageBox.Show(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void labelBeatmapPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start($"http://osu.ppy.sh/b/{beatmapinfo["id"]}");
        }
    }
}
