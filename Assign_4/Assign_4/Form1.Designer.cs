﻿namespace Assign_4
{
    partial class Form1
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
            this.PriceRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.PriceQueryButton = new System.Windows.Forms.Button();
            this.MaxPriceTrackBar = new System.Windows.Forms.TrackBar();
            this.MaxPriceLabel = new System.Windows.Forms.Label();
            this.MinPriceLabel = new System.Windows.Forms.Label();
            this.MinPriceTrackBar = new System.Windows.Forms.TrackBar();
            this.SchoolCheckBox = new System.Windows.Forms.CheckBox();
            this.BusinessCheckBox = new System.Windows.Forms.CheckBox();
            this.ResidentialtCheckBox = new System.Windows.Forms.CheckBox();
            this.SchoolRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.SchoolQueryButton = new System.Windows.Forms.Button();
            this.SchoolDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.SchoolDistanceLabel = new System.Windows.Forms.Label();
            this.SchoolLabel = new System.Windows.Forms.Label();
            this.SchoolCombobox = new System.Windows.Forms.ComboBox();
            this.ParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.DetachedGarageCheckBox = new System.Windows.Forms.CheckBox();
            this.GarageCheckBox = new System.Windows.Forms.CheckBox();
            this.ParametersQueryButton = new System.Windows.Forms.Button();
            this.SqFtUpDown = new System.Windows.Forms.NumericUpDown();
            this.SqFtLabel = new System.Windows.Forms.Label();
            this.BathUpDown = new System.Windows.Forms.NumericUpDown();
            this.BathLabel = new System.Windows.Forms.Label();
            this.BedUpDown = new System.Windows.Forms.NumericUpDown();
            this.BedLabel = new System.Windows.Forms.Label();
            this.ApartmentCheckBox = new System.Windows.Forms.CheckBox();
            this.HouseCheckBox = new System.Windows.Forms.CheckBox();
            this.QueryResultsLabel = new System.Windows.Forms.Label();
            this.BusinessRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.BusinessQueryButton = new System.Windows.Forms.Button();
            this.BusinessDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.BusinessDistacnceLabel = new System.Windows.Forms.Label();
            this.ForSaleLabel = new System.Windows.Forms.Label();
            this.ForSaleCombobox = new System.Windows.Forms.ComboBox();
            this.Map = new System.Windows.Forms.PictureBox();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.reset_button = new System.Windows.Forms.Button();
            this.PriceRangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPriceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPriceTrackBar)).BeginInit();
            this.SchoolRangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchoolDistanceUpDown)).BeginInit();
            this.ParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SqFtUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BathUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BedUpDown)).BeginInit();
            this.BusinessRangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessDistanceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.SuspendLayout();
            // 
            // PriceRangeGroupBox
            // 
            this.PriceRangeGroupBox.Controls.Add(this.PriceQueryButton);
            this.PriceRangeGroupBox.Controls.Add(this.MaxPriceTrackBar);
            this.PriceRangeGroupBox.Controls.Add(this.MaxPriceLabel);
            this.PriceRangeGroupBox.Controls.Add(this.MinPriceLabel);
            this.PriceRangeGroupBox.Controls.Add(this.MinPriceTrackBar);
            this.PriceRangeGroupBox.Controls.Add(this.SchoolCheckBox);
            this.PriceRangeGroupBox.Controls.Add(this.BusinessCheckBox);
            this.PriceRangeGroupBox.Controls.Add(this.ResidentialtCheckBox);
            this.PriceRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceRangeGroupBox.Location = new System.Drawing.Point(24, 23);
            this.PriceRangeGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.PriceRangeGroupBox.Name = "PriceRangeGroupBox";
            this.PriceRangeGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.PriceRangeGroupBox.Size = new System.Drawing.Size(860, 294);
            this.PriceRangeGroupBox.TabIndex = 0;
            this.PriceRangeGroupBox.TabStop = false;
            this.PriceRangeGroupBox.Text = "For Sale Properties Within Price Range";
            // 
            // PriceQueryButton
            // 
            this.PriceQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceQueryButton.Location = new System.Drawing.Point(692, 46);
            this.PriceQueryButton.Margin = new System.Windows.Forms.Padding(6);
            this.PriceQueryButton.Name = "PriceQueryButton";
            this.PriceQueryButton.Size = new System.Drawing.Size(150, 44);
            this.PriceQueryButton.TabIndex = 7;
            this.PriceQueryButton.Text = "Query";
            this.PriceQueryButton.UseVisualStyleBackColor = true;
            this.PriceQueryButton.Click += new System.EventHandler(this.PriceQueryButton_Click);
            // 
            // MaxPriceTrackBar
            // 
            this.MaxPriceTrackBar.LargeChange = 1;
            this.MaxPriceTrackBar.Location = new System.Drawing.Point(202, 198);
            this.MaxPriceTrackBar.Margin = new System.Windows.Forms.Padding(6);
            this.MaxPriceTrackBar.Maximum = 350000;
            this.MaxPriceTrackBar.Name = "MaxPriceTrackBar";
            this.MaxPriceTrackBar.Size = new System.Drawing.Size(308, 90);
            this.MaxPriceTrackBar.TabIndex = 6;
            this.MaxPriceTrackBar.Scroll += new System.EventHandler(this.MaxPriceTrackBar_Scroll);
            // 
            // MaxPriceLabel
            // 
            this.MaxPriceLabel.AutoSize = true;
            this.MaxPriceLabel.Location = new System.Drawing.Point(214, 162);
            this.MaxPriceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MaxPriceLabel.Name = "MaxPriceLabel";
            this.MaxPriceLabel.Size = new System.Drawing.Size(165, 36);
            this.MaxPriceLabel.TabIndex = 5;
            this.MaxPriceLabel.Text = "Max Price:";
            // 
            // MinPriceLabel
            // 
            this.MinPriceLabel.AutoSize = true;
            this.MinPriceLabel.Location = new System.Drawing.Point(214, 48);
            this.MinPriceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MinPriceLabel.Name = "MinPriceLabel";
            this.MinPriceLabel.Size = new System.Drawing.Size(158, 36);
            this.MinPriceLabel.TabIndex = 4;
            this.MinPriceLabel.Text = "Min Price:";
            // 
            // MinPriceTrackBar
            // 
            this.MinPriceTrackBar.LargeChange = 1;
            this.MinPriceTrackBar.Location = new System.Drawing.Point(202, 87);
            this.MinPriceTrackBar.Margin = new System.Windows.Forms.Padding(6);
            this.MinPriceTrackBar.Maximum = 350000;
            this.MinPriceTrackBar.Name = "MinPriceTrackBar";
            this.MinPriceTrackBar.Size = new System.Drawing.Size(312, 90);
            this.MinPriceTrackBar.TabIndex = 3;
            this.MinPriceTrackBar.Scroll += new System.EventHandler(this.MinPriceTrackBar_Scroll);
            // 
            // SchoolCheckBox
            // 
            this.SchoolCheckBox.AutoSize = true;
            this.SchoolCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolCheckBox.Location = new System.Drawing.Point(14, 158);
            this.SchoolCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.SchoolCheckBox.Name = "SchoolCheckBox";
            this.SchoolCheckBox.Size = new System.Drawing.Size(140, 40);
            this.SchoolCheckBox.TabIndex = 2;
            this.SchoolCheckBox.Text = "School";
            this.SchoolCheckBox.UseVisualStyleBackColor = true;
            // 
            // BusinessCheckBox
            // 
            this.BusinessCheckBox.AutoSize = true;
            this.BusinessCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessCheckBox.Location = new System.Drawing.Point(14, 102);
            this.BusinessCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.BusinessCheckBox.Name = "BusinessCheckBox";
            this.BusinessCheckBox.Size = new System.Drawing.Size(169, 40);
            this.BusinessCheckBox.TabIndex = 1;
            this.BusinessCheckBox.Text = "Buisness";
            this.BusinessCheckBox.UseVisualStyleBackColor = true;
            // 
            // ResidentialtCheckBox
            // 
            this.ResidentialtCheckBox.AutoSize = true;
            this.ResidentialtCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResidentialtCheckBox.Location = new System.Drawing.Point(14, 46);
            this.ResidentialtCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.ResidentialtCheckBox.Name = "ResidentialtCheckBox";
            this.ResidentialtCheckBox.Size = new System.Drawing.Size(188, 40);
            this.ResidentialtCheckBox.TabIndex = 0;
            this.ResidentialtCheckBox.Text = "Residental";
            this.ResidentialtCheckBox.UseVisualStyleBackColor = true;
            // 
            // SchoolRangeGroupBox
            // 
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolQueryButton);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolDistanceUpDown);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolDistanceLabel);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolLabel);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolCombobox);
            this.SchoolRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolRangeGroupBox.Location = new System.Drawing.Point(24, 329);
            this.SchoolRangeGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.SchoolRangeGroupBox.Name = "SchoolRangeGroupBox";
            this.SchoolRangeGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.SchoolRangeGroupBox.Size = new System.Drawing.Size(860, 169);
            this.SchoolRangeGroupBox.TabIndex = 1;
            this.SchoolRangeGroupBox.TabStop = false;
            this.SchoolRangeGroupBox.Text = "For Sale Residences Within Range of a School";
            // 
            // SchoolQueryButton
            // 
            this.SchoolQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolQueryButton.Location = new System.Drawing.Point(692, 87);
            this.SchoolQueryButton.Margin = new System.Windows.Forms.Padding(6);
            this.SchoolQueryButton.Name = "SchoolQueryButton";
            this.SchoolQueryButton.Size = new System.Drawing.Size(150, 44);
            this.SchoolQueryButton.TabIndex = 4;
            this.SchoolQueryButton.Text = "Query";
            this.SchoolQueryButton.UseVisualStyleBackColor = true;
            this.SchoolQueryButton.Click += new System.EventHandler(this.SchoolQueryButton_Click);
            // 
            // SchoolDistanceUpDown
            // 
            this.SchoolDistanceUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolDistanceUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SchoolDistanceUpDown.Location = new System.Drawing.Point(392, 88);
            this.SchoolDistanceUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.SchoolDistanceUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SchoolDistanceUpDown.Name = "SchoolDistanceUpDown";
            this.SchoolDistanceUpDown.Size = new System.Drawing.Size(270, 41);
            this.SchoolDistanceUpDown.TabIndex = 3;
            // 
            // SchoolDistanceLabel
            // 
            this.SchoolDistanceLabel.AutoSize = true;
            this.SchoolDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolDistanceLabel.Location = new System.Drawing.Point(384, 46);
            this.SchoolDistanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SchoolDistanceLabel.Name = "SchoolDistanceLabel";
            this.SchoolDistanceLabel.Size = new System.Drawing.Size(130, 36);
            this.SchoolDistanceLabel.TabIndex = 2;
            this.SchoolDistanceLabel.Text = "Distance";
            // 
            // SchoolLabel
            // 
            this.SchoolLabel.AutoSize = true;
            this.SchoolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolLabel.Location = new System.Drawing.Point(14, 46);
            this.SchoolLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SchoolLabel.Name = "SchoolLabel";
            this.SchoolLabel.Size = new System.Drawing.Size(108, 36);
            this.SchoolLabel.TabIndex = 1;
            this.SchoolLabel.Text = "School";
            // 
            // SchoolCombobox
            // 
            this.SchoolCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolCombobox.FormattingEnabled = true;
            this.SchoolCombobox.Location = new System.Drawing.Point(12, 87);
            this.SchoolCombobox.Margin = new System.Windows.Forms.Padding(6);
            this.SchoolCombobox.Name = "SchoolCombobox";
            this.SchoolCombobox.Size = new System.Drawing.Size(360, 33);
            this.SchoolCombobox.TabIndex = 0;
            this.SchoolCombobox.DropDown += new System.EventHandler(this.SchoolCombobox_DropDown);
            // 
            // ParametersGroupBox
            // 
            this.ParametersGroupBox.Controls.Add(this.DetachedGarageCheckBox);
            this.ParametersGroupBox.Controls.Add(this.GarageCheckBox);
            this.ParametersGroupBox.Controls.Add(this.ParametersQueryButton);
            this.ParametersGroupBox.Controls.Add(this.SqFtUpDown);
            this.ParametersGroupBox.Controls.Add(this.SqFtLabel);
            this.ParametersGroupBox.Controls.Add(this.BathUpDown);
            this.ParametersGroupBox.Controls.Add(this.BathLabel);
            this.ParametersGroupBox.Controls.Add(this.BedUpDown);
            this.ParametersGroupBox.Controls.Add(this.BedLabel);
            this.ParametersGroupBox.Controls.Add(this.ApartmentCheckBox);
            this.ParametersGroupBox.Controls.Add(this.HouseCheckBox);
            this.ParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersGroupBox.Location = new System.Drawing.Point(960, 200);
            this.ParametersGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.ParametersGroupBox.Name = "ParametersGroupBox";
            this.ParametersGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.ParametersGroupBox.Size = new System.Drawing.Size(856, 183);
            this.ParametersGroupBox.TabIndex = 2;
            this.ParametersGroupBox.TabStop = false;
            this.ParametersGroupBox.Text = "Specific Residence Parameters";
            // 
            // DetachedGarageCheckBox
            // 
            this.DetachedGarageCheckBox.AutoSize = true;
            this.DetachedGarageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetachedGarageCheckBox.Location = new System.Drawing.Point(524, 94);
            this.DetachedGarageCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.DetachedGarageCheckBox.Name = "DetachedGarageCheckBox";
            this.DetachedGarageCheckBox.Size = new System.Drawing.Size(182, 40);
            this.DetachedGarageCheckBox.TabIndex = 9;
            this.DetachedGarageCheckBox.Text = "Attached?";
            this.DetachedGarageCheckBox.UseVisualStyleBackColor = true;
            // 
            // GarageCheckBox
            // 
            this.GarageCheckBox.AutoSize = true;
            this.GarageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GarageCheckBox.Location = new System.Drawing.Point(524, 46);
            this.GarageCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.GarageCheckBox.Name = "GarageCheckBox";
            this.GarageCheckBox.Size = new System.Drawing.Size(145, 40);
            this.GarageCheckBox.TabIndex = 8;
            this.GarageCheckBox.Text = "Garage";
            this.GarageCheckBox.UseVisualStyleBackColor = true;
            // 
            // ParametersQueryButton
            // 
            this.ParametersQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersQueryButton.Location = new System.Drawing.Point(688, 46);
            this.ParametersQueryButton.Margin = new System.Windows.Forms.Padding(6);
            this.ParametersQueryButton.Name = "ParametersQueryButton";
            this.ParametersQueryButton.Size = new System.Drawing.Size(150, 44);
            this.ParametersQueryButton.TabIndex = 5;
            this.ParametersQueryButton.Text = "Query";
            this.ParametersQueryButton.UseVisualStyleBackColor = true;
            this.ParametersQueryButton.Click += new System.EventHandler(this.ParametersQueryButton_Click);
            // 
            // SqFtUpDown
            // 
            this.SqFtUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqFtUpDown.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.SqFtUpDown.Location = new System.Drawing.Point(366, 94);
            this.SqFtUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.SqFtUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.SqFtUpDown.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.SqFtUpDown.Name = "SqFtUpDown";
            this.SqFtUpDown.Size = new System.Drawing.Size(140, 41);
            this.SqFtUpDown.TabIndex = 7;
            this.SqFtUpDown.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // SqFtLabel
            // 
            this.SqFtLabel.AutoSize = true;
            this.SqFtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqFtLabel.Location = new System.Drawing.Point(360, 46);
            this.SqFtLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SqFtLabel.Name = "SqFtLabel";
            this.SqFtLabel.Size = new System.Drawing.Size(151, 36);
            this.SqFtLabel.TabIndex = 6;
            this.SqFtLabel.Text = "Min Sq Ft.";
            // 
            // BathUpDown
            // 
            this.BathUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BathUpDown.Location = new System.Drawing.Point(272, 94);
            this.BathUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.BathUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.BathUpDown.Name = "BathUpDown";
            this.BathUpDown.Size = new System.Drawing.Size(68, 41);
            this.BathUpDown.TabIndex = 5;
            // 
            // BathLabel
            // 
            this.BathLabel.AutoSize = true;
            this.BathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BathLabel.Location = new System.Drawing.Point(272, 46);
            this.BathLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.BathLabel.Name = "BathLabel";
            this.BathLabel.Size = new System.Drawing.Size(76, 36);
            this.BathLabel.TabIndex = 4;
            this.BathLabel.Text = "Bath";
            // 
            // BedUpDown
            // 
            this.BedUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedUpDown.Location = new System.Drawing.Point(192, 94);
            this.BedUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.BedUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.BedUpDown.Name = "BedUpDown";
            this.BedUpDown.Size = new System.Drawing.Size(68, 41);
            this.BedUpDown.TabIndex = 3;
            // 
            // BedLabel
            // 
            this.BedLabel.AutoSize = true;
            this.BedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedLabel.Location = new System.Drawing.Point(192, 46);
            this.BedLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.BedLabel.Name = "BedLabel";
            this.BedLabel.Size = new System.Drawing.Size(68, 36);
            this.BedLabel.TabIndex = 2;
            this.BedLabel.Text = "Bed";
            // 
            // ApartmentCheckBox
            // 
            this.ApartmentCheckBox.AutoSize = true;
            this.ApartmentCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApartmentCheckBox.Location = new System.Drawing.Point(12, 98);
            this.ApartmentCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.ApartmentCheckBox.Name = "ApartmentCheckBox";
            this.ApartmentCheckBox.Size = new System.Drawing.Size(183, 40);
            this.ApartmentCheckBox.TabIndex = 1;
            this.ApartmentCheckBox.Text = "Apartment";
            this.ApartmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // HouseCheckBox
            // 
            this.HouseCheckBox.AutoSize = true;
            this.HouseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HouseCheckBox.Location = new System.Drawing.Point(12, 44);
            this.HouseCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.HouseCheckBox.Name = "HouseCheckBox";
            this.HouseCheckBox.Size = new System.Drawing.Size(133, 40);
            this.HouseCheckBox.TabIndex = 0;
            this.HouseCheckBox.Text = "House";
            this.HouseCheckBox.UseVisualStyleBackColor = true;
            // 
            // QueryResultsLabel
            // 
            this.QueryResultsLabel.AutoSize = true;
            this.QueryResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryResultsLabel.Location = new System.Drawing.Point(3786, 71);
            this.QueryResultsLabel.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.QueryResultsLabel.Name = "QueryResultsLabel";
            this.QueryResultsLabel.Size = new System.Drawing.Size(216, 36);
            this.QueryResultsLabel.TabIndex = 3;
            this.QueryResultsLabel.Text = "Query Results";
            // 
            // BusinessRangeGroupBox
            // 
            this.BusinessRangeGroupBox.Controls.Add(this.BusinessQueryButton);
            this.BusinessRangeGroupBox.Controls.Add(this.BusinessDistanceUpDown);
            this.BusinessRangeGroupBox.Controls.Add(this.BusinessDistacnceLabel);
            this.BusinessRangeGroupBox.Controls.Add(this.ForSaleLabel);
            this.BusinessRangeGroupBox.Controls.Add(this.ForSaleCombobox);
            this.BusinessRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessRangeGroupBox.Location = new System.Drawing.Point(960, 15);
            this.BusinessRangeGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.BusinessRangeGroupBox.Name = "BusinessRangeGroupBox";
            this.BusinessRangeGroupBox.Padding = new System.Windows.Forms.Padding(12);
            this.BusinessRangeGroupBox.Size = new System.Drawing.Size(990, 185);
            this.BusinessRangeGroupBox.TabIndex = 5;
            this.BusinessRangeGroupBox.TabStop = false;
            this.BusinessRangeGroupBox.Text = "Hiring Business(es) Witin Range of For Sale Residence";
            // 
            // BusinessQueryButton
            // 
            this.BusinessQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessQueryButton.Location = new System.Drawing.Point(692, 87);
            this.BusinessQueryButton.Margin = new System.Windows.Forms.Padding(6);
            this.BusinessQueryButton.Name = "BusinessQueryButton";
            this.BusinessQueryButton.Size = new System.Drawing.Size(150, 44);
            this.BusinessQueryButton.TabIndex = 4;
            this.BusinessQueryButton.Text = "Query";
            this.BusinessQueryButton.UseVisualStyleBackColor = true;
            this.BusinessQueryButton.Click += new System.EventHandler(this.BusinessQueryButton_Click);
            // 
            // BusinessDistanceUpDown
            // 
            this.BusinessDistanceUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessDistanceUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.BusinessDistanceUpDown.Location = new System.Drawing.Point(392, 88);
            this.BusinessDistanceUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.BusinessDistanceUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.BusinessDistanceUpDown.Name = "BusinessDistanceUpDown";
            this.BusinessDistanceUpDown.Size = new System.Drawing.Size(270, 41);
            this.BusinessDistanceUpDown.TabIndex = 3;
            // 
            // BusinessDistacnceLabel
            // 
            this.BusinessDistacnceLabel.AutoSize = true;
            this.BusinessDistacnceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessDistacnceLabel.Location = new System.Drawing.Point(384, 46);
            this.BusinessDistacnceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.BusinessDistacnceLabel.Name = "BusinessDistacnceLabel";
            this.BusinessDistacnceLabel.Size = new System.Drawing.Size(130, 36);
            this.BusinessDistacnceLabel.TabIndex = 2;
            this.BusinessDistacnceLabel.Text = "Distance";
            // 
            // ForSaleLabel
            // 
            this.ForSaleLabel.AutoSize = true;
            this.ForSaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForSaleLabel.Location = new System.Drawing.Point(12, 54);
            this.ForSaleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ForSaleLabel.Name = "ForSaleLabel";
            this.ForSaleLabel.Size = new System.Drawing.Size(278, 36);
            this.ForSaleLabel.TabIndex = 1;
            this.ForSaleLabel.Text = "For-Sale Residence";
            // 
            // ForSaleCombobox
            // 
            this.ForSaleCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForSaleCombobox.FormattingEnabled = true;
            this.ForSaleCombobox.Location = new System.Drawing.Point(12, 98);
            this.ForSaleCombobox.Margin = new System.Windows.Forms.Padding(6);
            this.ForSaleCombobox.MaxDropDownItems = 10;
            this.ForSaleCombobox.Name = "ForSaleCombobox";
            this.ForSaleCombobox.Size = new System.Drawing.Size(360, 33);
            this.ForSaleCombobox.TabIndex = 0;
            this.ForSaleCombobox.DropDown += new System.EventHandler(this.ForSaleCombobox_DropDown);
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Map.Location = new System.Drawing.Point(78, 521);
            this.Map.Margin = new System.Windows.Forms.Padding(4);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(1044, 529);
            this.Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Map.TabIndex = 7;
            this.Map.TabStop = false;
            this.Map.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_Paint);
            this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            this.Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_MouseUp);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Location = new System.Drawing.Point(30, 521);
            this.ZoomIn.Margin = new System.Windows.Forms.Padding(4);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(40, 42);
            this.ZoomIn.TabIndex = 8;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomInClick);
            // 
            // ZoomOut
            // 
            this.ZoomOut.AccessibleName = "";
            this.ZoomOut.Location = new System.Drawing.Point(30, 585);
            this.ZoomOut.Margin = new System.Windows.Forms.Padding(4);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(40, 42);
            this.ZoomOut.TabIndex = 9;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOutClick);
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(941, 409);
            this.reset_button.Margin = new System.Windows.Forms.Padding(6);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(142, 63);
            this.reset_button.TabIndex = 10;
            this.reset_button.Text = "Reset";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2054, 1123);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.BusinessRangeGroupBox);
            this.Controls.Add(this.QueryResultsLabel);
            this.Controls.Add(this.ParametersGroupBox);
            this.Controls.Add(this.SchoolRangeGroupBox);
            this.Controls.Add(this.PriceRangeGroupBox);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PriceRangeGroupBox.ResumeLayout(false);
            this.PriceRangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPriceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPriceTrackBar)).EndInit();
            this.SchoolRangeGroupBox.ResumeLayout(false);
            this.SchoolRangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchoolDistanceUpDown)).EndInit();
            this.ParametersGroupBox.ResumeLayout(false);
            this.ParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SqFtUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BathUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BedUpDown)).EndInit();
            this.BusinessRangeGroupBox.ResumeLayout(false);
            this.BusinessRangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessDistanceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PriceRangeGroupBox;
        private System.Windows.Forms.GroupBox SchoolRangeGroupBox;
        private System.Windows.Forms.GroupBox ParametersGroupBox;
        private System.Windows.Forms.Label QueryResultsLabel;
        private System.Windows.Forms.Button PriceQueryButton;
        private System.Windows.Forms.TrackBar MaxPriceTrackBar;
        private System.Windows.Forms.Label MaxPriceLabel;
        private System.Windows.Forms.Label MinPriceLabel;
        private System.Windows.Forms.TrackBar MinPriceTrackBar;
        private System.Windows.Forms.CheckBox SchoolCheckBox;
        private System.Windows.Forms.CheckBox BusinessCheckBox;
        private System.Windows.Forms.CheckBox ResidentialtCheckBox;
        private System.Windows.Forms.Button SchoolQueryButton;
        private System.Windows.Forms.NumericUpDown SchoolDistanceUpDown;
        private System.Windows.Forms.Label SchoolDistanceLabel;
        private System.Windows.Forms.Label SchoolLabel;
        private System.Windows.Forms.ComboBox SchoolCombobox;
        private System.Windows.Forms.GroupBox BusinessRangeGroupBox;
        private System.Windows.Forms.Button BusinessQueryButton;
        private System.Windows.Forms.NumericUpDown BusinessDistanceUpDown;
        private System.Windows.Forms.Label BusinessDistacnceLabel;
        private System.Windows.Forms.Label ForSaleLabel;
        private System.Windows.Forms.ComboBox ForSaleCombobox;
        private System.Windows.Forms.NumericUpDown BedUpDown;
        private System.Windows.Forms.Label BedLabel;
        private System.Windows.Forms.CheckBox ApartmentCheckBox;
        private System.Windows.Forms.CheckBox HouseCheckBox;
        private System.Windows.Forms.NumericUpDown SqFtUpDown;
        private System.Windows.Forms.Label SqFtLabel;
        private System.Windows.Forms.NumericUpDown BathUpDown;
        private System.Windows.Forms.Label BathLabel;
        private System.Windows.Forms.CheckBox GarageCheckBox;
        private System.Windows.Forms.Button ParametersQueryButton;
        private System.Windows.Forms.CheckBox DetachedGarageCheckBox;
        private System.Windows.Forms.PictureBox Map;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.Button ZoomOut;
        private System.Windows.Forms.Button reset_button;
    }
}

