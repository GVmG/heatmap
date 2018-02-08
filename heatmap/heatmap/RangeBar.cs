using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heatmap
{
    //a very, VERY simplistic range bar - just threw together some buttons and panels and called it a day.
    //this is probably incredibly slow, stupidly coded, and wonky, but hey it works lol
    public partial class RangeBar : UserControl
    {
        private bool[] changing=new bool[3];
        private Point mousex;
        public event EventHandler RangeChanged;

        public RangeBar()
        {
            InitializeComponent();
        }

        protected virtual void OnRangeChanged(EventArgs e)
        {
            var handler = RangeChanged;
            if (handler != null)
                handler(this, e);
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            if (!changing[0]) { changing[0] = true; }
            mousex = e.Location;
        }

        private void button1_UnClick(object sender, MouseEventArgs e)
        {
            if (changing[0]) { changing[0] = false; }
        }

        private void button2_Click(object sender, MouseEventArgs e)
        {
            if (!changing[1]) { changing[1] = true; }
            mousex = e.Location;
        }

        private void button2_UnClick(object sender, MouseEventArgs e)
        {
            if (changing[1]) { changing[1] = false; }
        }

        private void panel2_Click(object sender, MouseEventArgs e)
        {
            if (!changing[2]) { changing[2] = true; }
            mousex = e.Location;
        }

        private void panel2_UnClick(object sender, MouseEventArgs e)
        {
            if (changing[2]) { changing[2] = false; }
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            if (changing[0])
            {
                int newpos = e.X + button1.Left - mousex.X;
                button1.Left = OsuUtils.Clamp(newpos, 0, GetRight());

                int left = button1.Left + GetHalfSize(),
                    right = button2.Left + GetHalfSize();
                panelRange.Left = Math.Min(left, right);
                panelRange.Width = Math.Max(left, right) - panelRange.Left;

                OnRangeChanged(e);
            }
            else if (changing[1])
            {
                int newpos = e.X + button2.Left - mousex.X;
                button2.Left = OsuUtils.Clamp(newpos, 0, GetRight());

                int left = button1.Left + GetHalfSize(),
                    right = button2.Left + GetHalfSize();
                panelRange.Left = Math.Min(left, right);
                panelRange.Width = Math.Max(left, right) - panelRange.Left;

                OnRangeChanged(e);
            }
            else if (changing[2])
            {
                int newpos = e.X + panelRange.Left - mousex.X;
                panelRange.Left = OsuUtils.Clamp(newpos, GetHalfSize(), GetRight() + GetHalfSize() - panelRange.Width);

                button1.Left = OsuUtils.Clamp(panelRange.Left - GetHalfSize(), 0, GetRight());
                button2.Left = OsuUtils.Clamp(panelRange.Right - GetHalfSize(), 0, GetRight());

                OnRangeChanged(e);
            }
        }

        //returns the leftmost value of the range
        public float GetMin() { return (float)Math.Min(GetVal1(), GetVal2()) / GetRight(); }

        //returns the rightmost value of the range
        public float GetMax() { return (float)Math.Max(GetVal1(), GetVal2()) / GetRight(); }

        //returns the value of the button with ID 1
        public int GetVal1() { return button1.Left; }

        //returns the value of the button with ID 2
        public int GetVal2() { return button2.Left; }

        //returns the max value the range could have (in pixels - used for internal calculations)
        public int GetRight() { return Width - GetThumbSize(); }
        
        //gets the size of the buttons - for internal purposes
        public int GetThumbSize() { return 12;  }
        public int GetHalfSize() { return (int)(GetThumbSize() * 0.5); }

        private void RangeBar_Load(object sender, EventArgs e)
        {
            panel1.Width = Width;
            button1.Width = GetThumbSize();
            button2.Width = GetThumbSize();

            button1.Left = 0;
            button2.Left = Width - button2.Width;
            //rn I dont feel like doing the actual math,and it's behind the buttons so it wont really matter.
            panelRange.Left = 5;
            panelRange.Width = Width - 10;
            
            mousex = new Point(0, 0);
        }
    }
}
