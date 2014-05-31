using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LetsCreateZelda.Editor.GUI
{
    public partial class LoadMapForm : Form
    {

        public string MapName { get; private set; }

        public LoadMapForm()
        {
            InitializeComponent();
            var list = Directory.GetDirectories(Directory.GetCurrentDirectory() + "/Content/Maps/");
            foreach (string s in list)
            {
                var folderName = s.Split(new[] {'/'});
                lstMaps.Items.Add(folderName.Last()); 
            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (lstMaps.SelectedIndex == -1)
                return;
            MapName = lstMaps.SelectedItem.ToString(); 
        }
    }
}
