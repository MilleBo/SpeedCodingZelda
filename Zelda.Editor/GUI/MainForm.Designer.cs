namespace Zelda.Editor.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMeta = new System.Windows.Forms.GroupBox();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCameraPosition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTexture = new System.Windows.Forms.Panel();
            this.picTexture = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbLayerCollision = new System.Windows.Forms.RadioButton();
            this.rdbLayerOne = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMeta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTexture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMeta
            // 
            this.grpMeta.Controls.Add(this.txtMapName);
            this.grpMeta.Controls.Add(this.label2);
            this.grpMeta.Controls.Add(this.txtFileName);
            this.grpMeta.Controls.Add(this.label1);
            this.grpMeta.Location = new System.Drawing.Point(12, 30);
            this.grpMeta.Name = "grpMeta";
            this.grpMeta.Size = new System.Drawing.Size(347, 47);
            this.grpMeta.TabIndex = 0;
            this.grpMeta.TabStop = false;
            this.grpMeta.Text = "Meta";
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(234, 13);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(100, 20);
            this.txtMapName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(67, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 20);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCameraPosition);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // lblCameraPosition
            // 
            this.lblCameraPosition.AutoSize = true;
            this.lblCameraPosition.Location = new System.Drawing.Point(59, 16);
            this.lblCameraPosition.Name = "lblCameraPosition";
            this.lblCameraPosition.Size = new System.Drawing.Size(10, 13);
            this.lblCameraPosition.TabIndex = 2;
            this.lblCameraPosition.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Position:";
            // 
            // pnlTexture
            // 
            this.pnlTexture.AutoScroll = true;
            this.pnlTexture.Controls.Add(this.picTexture);
            this.pnlTexture.Location = new System.Drawing.Point(16, 272);
            this.pnlTexture.Name = "pnlTexture";
            this.pnlTexture.Size = new System.Drawing.Size(343, 266);
            this.pnlTexture.TabIndex = 2;
            // 
            // picTexture
            // 
            this.picTexture.Image = global::Zelda.Editor.Properties.Resources.overworld_tiles;
            this.picTexture.Location = new System.Drawing.Point(9, 3);
            this.picTexture.Name = "picTexture";
            this.picTexture.Size = new System.Drawing.Size(325, 431);
            this.picTexture.TabIndex = 0;
            this.picTexture.TabStop = false;
            this.picTexture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTexture_MouseClick);
            this.picTexture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTexture_MouseMove);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(284, 544);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbLayerCollision);
            this.groupBox2.Controls.Add(this.rdbLayerOne);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiles";
            // 
            // rdbLayerCollision
            // 
            this.rdbLayerCollision.AutoSize = true;
            this.rdbLayerCollision.Location = new System.Drawing.Point(87, 19);
            this.rdbLayerCollision.Name = "rdbLayerCollision";
            this.rdbLayerCollision.Size = new System.Drawing.Size(63, 17);
            this.rdbLayerCollision.TabIndex = 1;
            this.rdbLayerCollision.TabStop = true;
            this.rdbLayerCollision.Text = "Collision";
            this.rdbLayerCollision.UseVisualStyleBackColor = true;
            this.rdbLayerCollision.Click += new System.EventHandler(this.rdbLayerCollision_Click);
            // 
            // rdbLayerOne
            // 
            this.rdbLayerOne.AutoSize = true;
            this.rdbLayerOne.Location = new System.Drawing.Point(9, 19);
            this.rdbLayerOne.Name = "rdbLayerOne";
            this.rdbLayerOne.Size = new System.Drawing.Size(72, 17);
            this.rdbLayerOne.TabIndex = 0;
            this.rdbLayerOne.TabStop = true;
            this.rdbLayerOne.Text = "Layer one";
            this.rdbLayerOne.UseVisualStyleBackColor = true;
            this.rdbLayerOne.Click += new System.EventHandler(this.rdbLayerOne_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(367, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileLoad});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuFileLoad
            // 
            this.mnuFileLoad.Name = "mnuFileLoad";
            this.mnuFileLoad.Size = new System.Drawing.Size(100, 22);
            this.mnuFileLoad.Text = "Load";
            this.mnuFileLoad.Click += new System.EventHandler(this.mnuFileLoad_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 579);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTexture);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMeta);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.grpMeta.ResumeLayout(false);
            this.grpMeta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTexture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMeta;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCameraPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTexture;
        private System.Windows.Forms.PictureBox picTexture;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbLayerCollision;
        private System.Windows.Forms.RadioButton rdbLayerOne;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileLoad;
    }
}

//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------


