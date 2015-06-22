using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using MapShell.Directions_Request_Class;
using MapShell.Directions_Result_Class;
using MapShell.StaticMap_Request_Classes;

namespace Spite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.map_box.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.map_box.Dock = System.Windows.Forms.DockStyle.Bottom;
            //this.panel1.AutoScroll = true;
            //this.map_box.SizeMode = PictureBoxSizeMode.AutoSize;
            hScrollBar1.Width = map_box.Width;
            hScrollBar1.Left = map_box.Left;
            hScrollBar1.Top = map_box.Bottom;
            hScrollBar1.Maximum = map_box.Image.Width - map_box.Width;

            vScrollBar1.Height = map_box.Height;
            vScrollBar1.Left = map_box.Left + map_box.Width;
            vScrollBar1.Top = map_box.Top;
            vScrollBar1.Maximum = map_box.Image.Height - map_box.Height;

        }

        int x = 0;
        private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            x = hScrollBar1.Value;
            map_box.Refresh();
        }

        int y = 0;
        private void vScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            y = vScrollBar1.Value;
            map_box.Refresh();
        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(map_box.Image, e.ClipRectangle, x, y, e.ClipRectangle.Width,
              e.ClipRectangle.Height, GraphicsUnit.Pixel);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            TabPage otp = loc_tab_cont.SelectedTab;
            //Create new tab
            TabPage ntp = new TabPage();
            ntp.Text = "Location "+(loc_tab_cont.TabPages.Count+1).ToString();
            //iterate through each control and clone it
            foreach(Control c in otp.Controls)
            {
                Control new_ctrl = (Control)Activator.CreateInstance(c.GetType());
                PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(c);
                foreach(PropertyDescriptor entry in pdc)
                {
                    object val = entry.GetValue(c);
                    entry.SetValue(new_ctrl, val);
                }
                ntp.Controls.Add(new_ctrl);
            }
            loc_tab_cont.TabPages.Add(ntp);
        }

        private void sub_btn_Click(object sender, EventArgs e)
        {
            if (loc_tab_cont.TabPages.Count > 1)
            {
                loc_tab_cont.Controls.Remove(loc_tab_cont.TabPages[loc_tab_cont.TabPages.Count-1]);
            }
        }

        private void get_dir_btn_Click(object sender, EventArgs e)
        {
            List<Address> address_list = new List<Address>(loc_tab_cont.TabPages.Count);
            foreach(TabPage tab in loc_tab_cont.TabPages)
            {
                List<string> tabText = new List<string>();
                foreach(Control c in tab.Controls)
                {
                    if(c is TextBox)
                    {
                        tabText.Add(c.Text);
                    }
                }
                address_list.Add(new Address(tabText[4]+tabText[3],tabText[2],tabText[1],tabText[0]));
            }
            List<List<Locations>> loc_list = new List<List<Locations>>();
          foreach(Address a in address_list)
          {
              loc_list.Add(a.getLocations());
          }
          List<Locations> final_list = new List<Locations>();
          foreach(List<Locations>flist in loc_list)
          {
              final_list.Add(flist[0]);
          }
          List<Directions> direction = DirectionsRequest.getDirections(final_list);

          map_box.Image = direction[0].mainMap;
          
        }

        
    }
}
