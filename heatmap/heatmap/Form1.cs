using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            SetDefaultMapInfo(beatmapinfo);

            UpdateMapData();
        }

        private void SetDefaultMapInfo(Dictionary<string, string> infodic)
        {
            infodic["artist"] = "(unknown)";
            infodic["title"] = "(unknown)";
            infodic["mapper"] = "(unknown)";
            infodic["diffname"] = "(unknown)";
            infodic["source"] = "(unknown)";
            infodic["cs"] = "(unknown)";
            infodic["ar"] = "(unknown)";
            infodic["od"] = "(unknown)";
            infodic["hp"] = "(unknown)";
            infodic["id"] = "(unknown)";
            infodic["setid"] = "(unknown)";
            infodic["version"] = "(unknown)";
        }

        //updates the data shown in the form
        private void UpdateMapData()
        {
            string artist = beatmapinfo["artist"], title = beatmapinfo["title"], mapper = beatmapinfo["mapper"],
                diffname = beatmapinfo["diffname"], source = beatmapinfo["source"],
                cs = beatmapinfo["cs"], od = beatmapinfo["od"], hp = beatmapinfo["hp"], ar = beatmapinfo["ar"],
                id = beatmapinfo["id"], setid = beatmapinfo["setid"], version = beatmapinfo["version"];

            int pixelcs = 0;
            if (beatmapinfo["cs"] != "(unknown)") { pixelcs = (int)CStoOsuPixels(float.Parse(cs, CultureInfo.InvariantCulture)); }

            float[] msvalues = { 0, 0, 0 };
            if (beatmapinfo["od"]!="(unknown)") { msvalues = ODtoMilliseconds(float.Parse(od, CultureInfo.InvariantCulture)); }

            int arms = 0;
            if (beatmapinfo["ar"] != "(unknown)") { arms = ARtoMilliseconds(float.Parse(ar, CultureInfo.InvariantCulture)); }

            string updatedinfo = $"Title: {title}\nArtist: {artist}\nDifficulty: {diffname}\nMapset by: {mapper}\n" +
                $"Source: {source}\nApproach Rate: {ar} ({arms}ms)\nCircle Size: {cs} ({pixelcs} osu!pixels)\nHP Drain: {hp}\n" +
                $"Overall Difficulty: {od}\n(300: ±{(int)msvalues[0]}ms, 100: ±{(int)msvalues[1]}ms, 50: ±{(int)msvalues[2]}ms)" +
                $"\nBeatmap Version: v{version}";

            //update the links
            //note that the hardcoded values are the length of the strings before where the url should start because
            //I'm way too lazy to actually get them and I don't plan on having translations for this thing anyway.
            labelBeatmapInfo.Text = updatedinfo;
            labelBeatmapInfo.LinkArea = new LinkArea(updatedinfo.IndexOf("Mapset by: ") + 11, mapper.Length);

            labelBeatmapID.Text = "Difficulty ID: " + id;
            labelBeatmapID.LinkArea = new LinkArea(15, id.Length);

            labelBeatmapSetID.Text = "Mapset ID: " + setid;
            labelBeatmapSetID.LinkArea = new LinkArea(11, setid.Length);
        }

        //updates the map info with a new dictionary
        private void UpdateMapInfo(Dictionary<string, string> data) { beatmapinfo = data; }

        // utilities - functions I can use for various things - probably gonna move them to a class later on

        // CS to osu!pixels - osu!pixels are what the diameter of the circles would be in a 512x384 resolution.
        // formula is rough but it does its job. originally found here: https://osu.ppy.sh/forum/p/4282387 (thx Cl8n!)
        private float CStoOsuPixels(float cs) { return (int)(109 - 9 * cs); }

        // OD to milliseconds - returns an array where the 0th item is for 300s, the 1st is for 100s and the third is for 50s.
        // formula might not be correct, idk where this guy got it: https://www.reddit.com/r/osugame/comments/781ot4/od_in_milliseconds/doqngos (thx anyway /u/Fukiyel!)
        private float[] ODtoMilliseconds(float od) { return new float[]{ -(6f * (od - 13.25f)), -(8f * (od - 17.4375f)), -(10f * (od - 19.95f))}; }

        // AR to milliseconds - returns the milliseconds the circle will stay on screen for with any given AR.
        // the formula should be the correct one. sauce has been long lost in my search history from years ago.
        private int ARtoMilliseconds(float ar) { return (int)(ar < 5 ? (1800 - (ar * 120)) : (1200 - ((ar - 5) * 150))); }

        // returns the distance between 2 points - in float because fite me - also backup float-array one cause vectors
        private float PointDistance(float x1, float y1, float x2, float y2) { return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); }
        private float PointDistance(float[] p1, float[] p2) { return PointDistance(p1[0], p1[1], p2[0], p2[1]); }

        // end of the utility functions

        private void LoadBeatmap(string path)
        {
            //MessageBox.Show(path);
            string[] filelines;
            Dictionary<string, string> newinfo = new Dictionary<string, string>();
            bool[] changed = { false, false, false, false, false, false, false, false, false, false, false, false };
            string[] changes = {"Title", "Artist", "Mapper", "Difficulty Name", "Source", "Difficulty ID", "Mapset ID",
                "HP", "CS", "OD", "AR", "File Version" };

            SetDefaultMapInfo(newinfo);

            try { filelines = File.ReadAllLines(path); } //attempt to read the entire file at once
            catch (Exception ex)
            {
                MessageBox.Show($"Trying to load the file raised an exception:\n{ex.Message}", "Couldn't load file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!filelines[0].StartsWith("osu file format")) //check out the file format - if there is one, that is
            {
                MessageBox.Show("This doesn't look like an osu! beatmap file.", "Invalid file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else //if it does have a file format, set its value
            {
                newinfo["version"] = filelines[0].Replace("osu file format v", "").Trim();
                changed[11] = true;
            }

            

            foreach (string line in filelines) //parse all lines
            {
                if (line.StartsWith("Mode:")) //dont parse if this isn't the right gamemode
                {
                    int mode = Int32.Parse(line.Replace("Mode:", ""));
                    if (mode!=0)
                    {
                        MessageBox.Show($"[{mode}] is not a valid gamemode!", "Invalid gamemode!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //update beatmap info
                if (line.StartsWith("Title:")) { newinfo["title"] = line.Replace("Title:", "").Trim(); changed[0] = true; }
                else if (line.StartsWith("Artist:")) { newinfo["artist"] = line.Replace("Artist:", "").Trim(); changed[1] = true; }
                else if (line.StartsWith("Creator:")) { newinfo["mapper"] = line.Replace("Creator:", "").Trim(); changed[2] = true; }
                else if (line.StartsWith("Version:")) { newinfo["diffname"] = line.Replace("Version:", "").Trim(); changed[3] = true; }
                else if (line.StartsWith("Source:")) { newinfo["source"] = line.Replace("Source:", "").Trim(); changed[4] = true; }
                else if (line.StartsWith("BeatmapID:")) { newinfo["id"] = line.Replace("BeatmapID:", "").Trim(); changed[5] = true; }
                else if (line.StartsWith("BeatmapSetID:")) { newinfo["setid"] = line.Replace("BeatmapSetID:", "").Trim(); changed[6] = true; }
                else if (line.StartsWith("HPDrainRate:")) { newinfo["hp"] = line.Replace("HPDrainRate:", "").Trim(); changed[7] = true; }
                else if (line.StartsWith("CircleSize:")) { newinfo["cs"] = line.Replace("CircleSize:", "").Trim(); changed[8] = true; }
                else if (line.StartsWith("OverallDifficulty:")) { newinfo["od"] = line.Replace("OverallDifficulty:", "").Trim(); changed[9] = true; }
                else if (line.StartsWith("ApproachRate:")) { newinfo["ar"] = line.Replace("ApproachRate:", "").Trim(); changed[10] = true; }
            }

            for (int i = 0; i < changed.Length; i++) //check if all the data has been changed
            {
                if (!changed[i]) //if something hasn't been changed, give a warning - the default values are already set
                {
                    MessageBox.Show($"[{changes[i]}] could not be updated. The program will attempt to use default values.", "Couldn't find all info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }
            }

            UpdateMapInfo(newinfo);
            UpdateMapData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void labelBeatmapPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (beatmapinfo["id"] == "(unknown)")
            {
                MessageBox.Show("Difficulty ID is unknown, cannot open map page.", "Couldn't open beatmap page!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                System.Diagnostics.Process.Start($"http://osu.ppy.sh/b/{beatmapinfo["id"]}");
            }
        }

        private void labelBeatmapSetID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (beatmapinfo["setid"] == "(unknown)")
            {
                MessageBox.Show("Mapset ID is unknown, cannot open map page.", "Couldn't open beatmap page!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                System.Diagnostics.Process.Start($"http://osu.ppy.sh/s/{beatmapinfo["setid"]}");
            }
        }

        private void labelBeatmapInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (beatmapinfo["mapper"] == "(unknown)")
            {
                MessageBox.Show("Mapper is unknown, cannot open their page.", "Couldn't open user page!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                System.Diagnostics.Process.Start($"http://osu.ppy.sh/u/{beatmapinfo["mapper"]}");
            }
        }
    }
}
