using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LetsCreateZelda.Editor.MyEventArgs;
using LetsCreateZelda.Editor.Properties;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using OpenTK.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Point = System.Drawing.Point;

namespace LetsCreateZelda.Editor.GUI
{
    public partial class MainForm : Form
    {
        private ManagerCamera _camera;
        public string FileName { get; private set; }

        private event EventHandler<MapNameEventArgs> _loadMap; 

        public event EventHandler<MapNameEventArgs> LoadMap
        {
            add { _loadMap += value; }
            remove { _loadMap -= value; }
        }


        public List<Vector2> TilePoints { get; private set; }
        private List<PictureBox> _tileSelectImages;  


        public CurrentLayer CurrentLayer { get; private set; }

        public MainForm(ManagerCamera managerCamera)
        {
            InitializeComponent();
            _camera = managerCamera; 
            //UpdateCameraPositionText();
            _tileSelectImages = new List<PictureBox>();
            TilePoints = new List<Vector2>();
        }

        public void UpdateCameraPositionText()
        {
            lblCameraPosition.Invoke(
                new Action(
                    () =>
                        lblCameraPosition.Text = string.Format("x: {0}, y: {1}", _camera.Position.X, _camera.Position.Y)));
            ; 
        }

        private void picTexture_MouseClick(object sender, MouseEventArgs e)
        {
            //AddTextureTile();
            if (e.Button == MouseButtons.Right)
            {
                TilePoints.Clear();
                foreach (var tileSelectImage in _tileSelectImages)
                {
                    pnlTexture.Controls.Remove(tileSelectImage);
                }
                _tileSelectImages.Clear();
            }

            if (e.Button == MouseButtons.Left)
            {
                AddTextureTile();
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            FileName = txtFileName.Text; 
        }

        private void rdbLayerOne_Click(object sender, EventArgs e)
        {
            CurrentLayer = CurrentLayer.LayerOne; 
        }

        private void rdbLayerCollision_Click(object sender, EventArgs e)
        {
            CurrentLayer = CurrentLayer.Collision; 
        }

        private void mnuFileLoad_Click(object sender, EventArgs e)
        {
            var form = new LoadMapForm();
            if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(form.MapName))
            {
                if(_loadMap != null)
                    _loadMap(this, new MapNameEventArgs(form.MapName));
            }
        }

        private void AddTextureTile()
        {
            var ptCursor = Cursor.Position;
            ptCursor = picTexture.PointToClient(ptCursor);
            var textureX = (ptCursor.X - pnlTexture.Location.X - 16) / 16;
           var textureY = (ptCursor.Y - pnlTexture.Location.Y - 16) / 16;



            if (TilePoints.Any(t => t.X == textureX && t.Y == textureY))
                return;

            TilePoints.Add(new Vector2(textureX, textureY));
            TilePoints.Sort(delegate(Vector2 x, Vector2 y)
            {
                if (x.X > y.X)
                    return 1;
                if (x.Y == y.Y)
                    return 1;
                return -1;
            });

            var image = new PictureBox();
            image.Height = 16;
            image.Width = 16;
            image.Location = new Point(picTexture.Location.X + (16 + 1) * textureX + 1, picTexture.Location.Y + (16 + 1) * textureY + 1);
            _tileSelectImages.Add(image);
            pnlTexture.Controls.Add(image);
            image.BringToFront();
        }

        private void picTexture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AddTextureTile();
            }
        }

    }
}


//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------


