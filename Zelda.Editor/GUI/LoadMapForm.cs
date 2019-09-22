using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Zelda.Editor.GUI
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


//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------


