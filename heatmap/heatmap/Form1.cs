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
        private Dictionary<string, string> beatmapinfo = new Dictionary<string, string>();
        private List<HitObject> beatmap = new List<HitObject>();
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

            UpdateMapData(beatmapinfo, new int[] { 0, 0, 0 });
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
        private void UpdateMapData(Dictionary<string, string> newinfo, int[] counts)
        {
            string artist = newinfo["artist"], title = newinfo["title"], mapper = newinfo["mapper"],
                diffname = newinfo["diffname"], source = newinfo["source"],
                cs = newinfo["cs"], od = newinfo["od"], hp = newinfo["hp"], ar = newinfo["ar"],
                id = newinfo["id"], setid = newinfo["setid"], version = newinfo["version"];

            int pixelcs = 0;
            if (newinfo["cs"] != "(unknown)") { pixelcs = (int)OsuUtils.CStoOsuPixels(float.Parse(cs, CultureInfo.InvariantCulture)); }

            float[] msvalues = { 0, 0, 0 };
            if (newinfo["od"] != "(unknown)") { msvalues = OsuUtils.ODtoMilliseconds(float.Parse(od, CultureInfo.InvariantCulture)); }

            int arms = 0;
            if (newinfo["ar"] != "(unknown)") { arms = OsuUtils.ARtoMilliseconds(float.Parse(ar, CultureInfo.InvariantCulture)); }

            string updatedinfo = $"Title: {title}\nArtist: {artist}\nDifficulty: {diffname}\nMapset by: {mapper}\n" +
                $"Source: {source}\nApproach Rate: {ar} ({arms}ms)\nCircle Size: {cs}\nHP Drain: {hp}\n" +
                $"Overall Difficulty: {od}\n\n(hover for more info!)";
            
            toolTipInfo.SetToolTip(labelBeatmapInfo, $"Beatmap Format: {version}\n\n" +
                $"300: ±{(int)msvalues[0]}ms - 100: ±{(int)msvalues[1]}ms - 50: ±{(int)msvalues[2]}ms\n" +
                $"{counts[0]}x Circles, {counts[1]}x Sliders, {counts[2]}x Spinners\n" +
                $"Circle Size is {pixelcs} osu!pixels.");

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

        //attempts to load a beatmap from a file path.
        //returns whether it succeeded or not - while this is not used yet, it can be useful so I'm doing it before I forget.
        private bool LoadBeatmap(string path)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string[] filelines;
            Dictionary<string, string> newinfo = new Dictionary<string, string>();
            List<HitObject> newmap = new List<HitObject>();
            bool[] changed = { false, false, false, false, false, false, false, false, false, false, false, false };
            string[] changes = {"Title", "Artist", "Mapper", "Difficulty Name", "Source", "Difficulty ID", "Mapset ID",
                "HP", "CS", "OD", "AR", "File Version" };
            bool parsehitobjects = false;
            int[] counts = new int[] { 0, 0, 0 };

            SetDefaultMapInfo(newinfo);

            try { filelines = File.ReadAllLines(path); } //attempt to read the entire file at once
            catch (Exception ex)
            {
                MessageBox.Show($"Trying to load the file raised an exception:\n{ex.Message}", "Couldn't load file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!filelines[0].StartsWith("osu file format")) //check out the file format - if there is one, that is
            {
                MessageBox.Show("This doesn't look like an osu! beatmap file.", "Invalid file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                        return false;
                    }
                }

                //parse hitobjects
                if (parsehitobjects)
                {
                    try
                    {
                        HitObject hitobj = new HitObject(line);
                        newmap.Add(hitobj);
                        counts[hitobj.type]++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error parsing hitobject: "+ex.Message, "Invalid HitObject!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (line.StartsWith("[HitObjects]")) { parsehitobjects = true; } //after the parsing code so it starts parsing from *the next line*.

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

            watch.Stop();
            if (!parsehitobjects)
            {
                MessageBox.Show("Looks like this beatmap has no HitObjects. The map will not be loaded.", "No HitObjects!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                MessageBox.Show($"Succesfully parsed {newmap.Count} HitObjects in {watch.ElapsedMilliseconds}ms.", "HitObjects parsed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateMapInfo(newinfo);
            beatmap = newmap;
            UpdateMapData(beatmapinfo, counts);
            //toolTipInfo.SetToolTip(labelBeatmapInfo, $"{counts[0]}x Circles, {counts[1]}x Sliders, {counts[2]}x Spinners");

            return true;
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
