namespace ACDataService
{
    partial class Map
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
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.downloadDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contoursCheckBox = new System.Windows.Forms.CheckBox();
            this.waterCheckBox = new System.Windows.Forms.CheckBox();
            this.stormwaterCheckBox = new System.Windows.Forms.CheckBox();
            this.wastewaterCheckBox = new System.Windows.Forms.CheckBox();
            this.imperviousSurfaceCheckBox = new System.Windows.Forms.CheckBox();
            this.parcelCheckBox = new System.Windows.Forms.CheckBox();
            this.buildingFootprintCheckBox = new System.Windows.Forms.CheckBox();
            this.addressCheckBox = new System.Windows.Forms.CheckBox();
            this.addressSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boundingBoxLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.spatialRefCBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(15, 19);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 20;
            this.gMapControl.MinZoom = 10;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(381, 299);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 15D;
            this.gMapControl.Paint += new System.Windows.Forms.PaintEventHandler(this.gMapControl_Paint);
            this.gMapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDown);
            this.gMapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseMove);
            this.gMapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseUp);
            // 
            // downloadDataButton
            // 
            this.downloadDataButton.Location = new System.Drawing.Point(196, 413);
            this.downloadDataButton.Name = "downloadDataButton";
            this.downloadDataButton.Size = new System.Drawing.Size(152, 23);
            this.downloadDataButton.TabIndex = 1;
            this.downloadDataButton.Text = "Download Data";
            this.downloadDataButton.UseVisualStyleBackColor = true;
            this.downloadDataButton.Click += new System.EventHandler(this.downloadDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gMapControl);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 334);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Area";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.contoursCheckBox);
            this.groupBox2.Controls.Add(this.waterCheckBox);
            this.groupBox2.Controls.Add(this.stormwaterCheckBox);
            this.groupBox2.Controls.Add(this.wastewaterCheckBox);
            this.groupBox2.Controls.Add(this.imperviousSurfaceCheckBox);
            this.groupBox2.Controls.Add(this.parcelCheckBox);
            this.groupBox2.Controls.Add(this.buildingFootprintCheckBox);
            this.groupBox2.Controls.Add(this.addressCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(428, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 212);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layers";
            // 
            // contoursCheckBox
            // 
            this.contoursCheckBox.AutoSize = true;
            this.contoursCheckBox.Location = new System.Drawing.Point(6, 42);
            this.contoursCheckBox.Name = "contoursCheckBox";
            this.contoursCheckBox.Size = new System.Drawing.Size(68, 17);
            this.contoursCheckBox.TabIndex = 0;
            this.contoursCheckBox.Text = "Contours";
            this.contoursCheckBox.UseVisualStyleBackColor = true;
            // 
            // waterCheckBox
            // 
            this.waterCheckBox.AutoSize = true;
            this.waterCheckBox.Location = new System.Drawing.Point(6, 180);
            this.waterCheckBox.Name = "waterCheckBox";
            this.waterCheckBox.Size = new System.Drawing.Size(55, 17);
            this.waterCheckBox.TabIndex = 0;
            this.waterCheckBox.Text = "Water";
            this.waterCheckBox.UseVisualStyleBackColor = true;
            // 
            // stormwaterCheckBox
            // 
            this.stormwaterCheckBox.AutoSize = true;
            this.stormwaterCheckBox.Location = new System.Drawing.Point(6, 157);
            this.stormwaterCheckBox.Name = "stormwaterCheckBox";
            this.stormwaterCheckBox.Size = new System.Drawing.Size(79, 17);
            this.stormwaterCheckBox.TabIndex = 0;
            this.stormwaterCheckBox.Text = "Stormwater";
            this.stormwaterCheckBox.UseVisualStyleBackColor = true;
            // 
            // wastewaterCheckBox
            // 
            this.wastewaterCheckBox.AutoSize = true;
            this.wastewaterCheckBox.Location = new System.Drawing.Point(6, 134);
            this.wastewaterCheckBox.Name = "wastewaterCheckBox";
            this.wastewaterCheckBox.Size = new System.Drawing.Size(83, 17);
            this.wastewaterCheckBox.TabIndex = 0;
            this.wastewaterCheckBox.Text = "Wastewater";
            this.wastewaterCheckBox.UseVisualStyleBackColor = true;
            // 
            // imperviousSurfaceCheckBox
            // 
            this.imperviousSurfaceCheckBox.AutoSize = true;
            this.imperviousSurfaceCheckBox.Location = new System.Drawing.Point(6, 111);
            this.imperviousSurfaceCheckBox.Name = "imperviousSurfaceCheckBox";
            this.imperviousSurfaceCheckBox.Size = new System.Drawing.Size(117, 17);
            this.imperviousSurfaceCheckBox.TabIndex = 0;
            this.imperviousSurfaceCheckBox.Text = "Impervious Surface";
            this.imperviousSurfaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // parcelCheckBox
            // 
            this.parcelCheckBox.AutoSize = true;
            this.parcelCheckBox.Location = new System.Drawing.Point(6, 88);
            this.parcelCheckBox.Name = "parcelCheckBox";
            this.parcelCheckBox.Size = new System.Drawing.Size(56, 17);
            this.parcelCheckBox.TabIndex = 0;
            this.parcelCheckBox.Text = "Parcel";
            this.parcelCheckBox.UseVisualStyleBackColor = true;
            // 
            // buildingFootprintCheckBox
            // 
            this.buildingFootprintCheckBox.AutoSize = true;
            this.buildingFootprintCheckBox.Location = new System.Drawing.Point(6, 65);
            this.buildingFootprintCheckBox.Name = "buildingFootprintCheckBox";
            this.buildingFootprintCheckBox.Size = new System.Drawing.Size(107, 17);
            this.buildingFootprintCheckBox.TabIndex = 0;
            this.buildingFootprintCheckBox.Text = "Building Footprint";
            this.buildingFootprintCheckBox.UseVisualStyleBackColor = true;
            // 
            // addressCheckBox
            // 
            this.addressCheckBox.AutoSize = true;
            this.addressCheckBox.Location = new System.Drawing.Point(6, 19);
            this.addressCheckBox.Name = "addressCheckBox";
            this.addressCheckBox.Size = new System.Drawing.Size(64, 17);
            this.addressCheckBox.TabIndex = 0;
            this.addressCheckBox.Text = "Address";
            this.addressCheckBox.UseVisualStyleBackColor = true;
            // 
            // addressSearchBox
            // 
            this.addressSearchBox.Location = new System.Drawing.Point(97, 12);
            this.addressSearchBox.Name = "addressSearchBox";
            this.addressSearchBox.Size = new System.Drawing.Size(325, 20);
            this.addressSearchBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selected Area: ";
            // 
            // boundingBoxLabel
            // 
            this.boundingBoxLabel.AutoSize = true;
            this.boundingBoxLabel.Location = new System.Drawing.Point(183, 39);
            this.boundingBoxLabel.Name = "boundingBoxLabel";
            this.boundingBoxLabel.Size = new System.Drawing.Size(22, 13);
            this.boundingBoxLabel.TabIndex = 6;
            this.boundingBoxLabel.Text = "xxx";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(428, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(130, 23);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.spatialRefCBox);
            this.groupBox3.Location = new System.Drawing.Point(428, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 115);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Spatial Reference";
            // 
            // spatialRefCBox
            // 
            this.spatialRefCBox.FormattingEnabled = true;
            this.spatialRefCBox.Items.AddRange(new object[] {
            "Nztm",
            "Mt Eden",
            "WGS84",
            "NZ Map Grid"});
            this.spatialRefCBox.Location = new System.Drawing.Point(6, 30);
            this.spatialRefCBox.Name = "spatialRefCBox";
            this.spatialRefCBox.Size = new System.Drawing.Size(112, 21);
            this.spatialRefCBox.TabIndex = 0;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 448);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.boundingBoxLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressSearchBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.downloadDataButton);
            this.Name = "Map";
            this.Text = "Map";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Button downloadDataButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox contoursCheckBox;
        private System.Windows.Forms.CheckBox waterCheckBox;
        private System.Windows.Forms.CheckBox stormwaterCheckBox;
        private System.Windows.Forms.CheckBox wastewaterCheckBox;
        private System.Windows.Forms.CheckBox imperviousSurfaceCheckBox;
        private System.Windows.Forms.CheckBox parcelCheckBox;
        private System.Windows.Forms.CheckBox buildingFootprintCheckBox;
        private System.Windows.Forms.CheckBox addressCheckBox;
        private System.Windows.Forms.TextBox addressSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label boundingBoxLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox spatialRefCBox;
    }
}