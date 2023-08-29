namespace MeasureText
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textPictureBox = new PictureBox();
            fontSizeLabel = new Label();
            textLabel = new Label();
            textTextBox = new TextBox();
            infoTextBox = new TextBox();
            fontSizeNumericUpDown = new NumericUpDown();
            fontSizeUnitComboBox = new ComboBox();
            guideLabel = new Label();
            guideXNumericUpDown = new NumericUpDown();
            guideYNumericUpDown = new NumericUpDown();
            tableLayoutPanel = new TableLayoutPanel();
            fontFamilyNameLabel = new Label();
            fontFamilyNameComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)textPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fontSizeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guideXNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guideYNumericUpDown).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // textPictureBox
            // 
            textPictureBox.BackColor = Color.White;
            textPictureBox.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel.SetColumnSpan(textPictureBox, 6);
            textPictureBox.Dock = DockStyle.Fill;
            textPictureBox.Location = new Point(3, 90);
            textPictureBox.Name = "textPictureBox";
            textPictureBox.Size = new Size(570, 148);
            textPictureBox.TabIndex = 0;
            textPictureBox.TabStop = false;
            // 
            // fontSizeLabel
            // 
            fontSizeLabel.AutoSize = true;
            fontSizeLabel.Dock = DockStyle.Fill;
            fontSizeLabel.Location = new Point(291, 0);
            fontSizeLabel.Name = "fontSizeLabel";
            fontSizeLabel.Size = new Size(64, 29);
            fontSizeLabel.TabIndex = 4;
            fontSizeLabel.Text = "サイズ：";
            fontSizeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Dock = DockStyle.Fill;
            textLabel.Location = new Point(3, 29);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(64, 29);
            textLabel.TabIndex = 5;
            textLabel.Text = "テキスト：";
            textLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textTextBox
            // 
            tableLayoutPanel.SetColumnSpan(textTextBox, 5);
            textTextBox.Dock = DockStyle.Fill;
            textTextBox.Location = new Point(73, 32);
            textTextBox.Name = "textTextBox";
            textTextBox.Size = new Size(500, 23);
            textTextBox.TabIndex = 4;
            textTextBox.Text = "TEXT";
            textTextBox.TextChanged += textTextBox_TextChanged;
            // 
            // infoTextBox
            // 
            infoTextBox.BorderStyle = BorderStyle.FixedSingle;
            infoTextBox.Dock = DockStyle.Fill;
            infoTextBox.Location = new Point(579, 3);
            infoTextBox.Multiline = true;
            infoTextBox.Name = "infoTextBox";
            infoTextBox.ReadOnly = true;
            tableLayoutPanel.SetRowSpan(infoTextBox, 4);
            infoTextBox.Size = new Size(202, 235);
            infoTextBox.TabIndex = 7;
            // 
            // fontSizeNumericUpDown
            // 
            fontSizeNumericUpDown.DecimalPlaces = 5;
            fontSizeNumericUpDown.Dock = DockStyle.Fill;
            fontSizeNumericUpDown.Location = new Point(361, 3);
            fontSizeNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            fontSizeNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            fontSizeNumericUpDown.Size = new Size(103, 23);
            fontSizeNumericUpDown.TabIndex = 2;
            fontSizeNumericUpDown.Value = new decimal(new int[] { 32, 0, 0, 0 });
            fontSizeNumericUpDown.ValueChanged += fontSizeNumericUpDown_ValueChanged;
            // 
            // fontSizeUnitComboBox
            // 
            fontSizeUnitComboBox.Dock = DockStyle.Fill;
            fontSizeUnitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fontSizeUnitComboBox.FormattingEnabled = true;
            fontSizeUnitComboBox.Location = new Point(470, 3);
            fontSizeUnitComboBox.Name = "fontSizeUnitComboBox";
            fontSizeUnitComboBox.Size = new Size(103, 23);
            fontSizeUnitComboBox.TabIndex = 3;
            fontSizeUnitComboBox.SelectedIndexChanged += fontSizeUnitComboBox_SelectedIndexChanged;
            // 
            // guideLabel
            // 
            guideLabel.AutoSize = true;
            guideLabel.Dock = DockStyle.Fill;
            guideLabel.Location = new Point(3, 58);
            guideLabel.Name = "guideLabel";
            guideLabel.Size = new Size(64, 29);
            guideLabel.TabIndex = 6;
            guideLabel.Text = "ガイド：";
            guideLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // guideXNumericUpDown
            // 
            guideXNumericUpDown.DecimalPlaces = 5;
            guideXNumericUpDown.Dock = DockStyle.Fill;
            guideXNumericUpDown.Location = new Point(73, 61);
            guideXNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            guideXNumericUpDown.Name = "guideXNumericUpDown";
            guideXNumericUpDown.Size = new Size(103, 23);
            guideXNumericUpDown.TabIndex = 5;
            guideXNumericUpDown.ValueChanged += guideXNumericUpDown_ValueChanged;
            // 
            // guideYNumericUpDown
            // 
            guideYNumericUpDown.DecimalPlaces = 5;
            guideYNumericUpDown.Dock = DockStyle.Fill;
            guideYNumericUpDown.Location = new Point(182, 61);
            guideYNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            guideYNumericUpDown.Name = "guideYNumericUpDown";
            guideYNumericUpDown.Size = new Size(103, 23);
            guideYNumericUpDown.TabIndex = 6;
            guideYNumericUpDown.ValueChanged += guideYNumericUpDown_ValueChanged;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 7;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel.Controls.Add(fontFamilyNameLabel, 0, 0);
            tableLayoutPanel.Controls.Add(infoTextBox, 6, 0);
            tableLayoutPanel.Controls.Add(guideYNumericUpDown, 2, 2);
            tableLayoutPanel.Controls.Add(textPictureBox, 0, 3);
            tableLayoutPanel.Controls.Add(fontFamilyNameComboBox, 1, 0);
            tableLayoutPanel.Controls.Add(guideXNumericUpDown, 1, 2);
            tableLayoutPanel.Controls.Add(textLabel, 0, 1);
            tableLayoutPanel.Controls.Add(guideLabel, 0, 2);
            tableLayoutPanel.Controls.Add(fontSizeLabel, 3, 0);
            tableLayoutPanel.Controls.Add(fontSizeNumericUpDown, 4, 0);
            tableLayoutPanel.Controls.Add(textTextBox, 1, 1);
            tableLayoutPanel.Controls.Add(fontSizeUnitComboBox, 5, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(784, 241);
            tableLayoutPanel.TabIndex = 8;
            // 
            // fontFamilyNameLabel
            // 
            fontFamilyNameLabel.AutoSize = true;
            fontFamilyNameLabel.Dock = DockStyle.Fill;
            fontFamilyNameLabel.Location = new Point(3, 0);
            fontFamilyNameLabel.Name = "fontFamilyNameLabel";
            fontFamilyNameLabel.Size = new Size(64, 29);
            fontFamilyNameLabel.TabIndex = 4;
            fontFamilyNameLabel.Text = "フォント：";
            fontFamilyNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fontFamilyNameComboBox
            // 
            tableLayoutPanel.SetColumnSpan(fontFamilyNameComboBox, 2);
            fontFamilyNameComboBox.Dock = DockStyle.Fill;
            fontFamilyNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fontFamilyNameComboBox.FormattingEnabled = true;
            fontFamilyNameComboBox.Location = new Point(73, 3);
            fontFamilyNameComboBox.Name = "fontFamilyNameComboBox";
            fontFamilyNameComboBox.Size = new Size(212, 23);
            fontFamilyNameComboBox.TabIndex = 1;
            fontFamilyNameComboBox.SelectedIndexChanged += fontFamilyNameComboBox_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 241);
            Controls.Add(tableLayoutPanel);
            Name = "MainForm";
            Text = "MeasureText";
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            ((System.ComponentModel.ISupportInitialize)textPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fontSizeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)guideXNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)guideYNumericUpDown).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox textPictureBox;
        private Label fontSizeLabel;
        private Label textLabel;
        private TextBox textTextBox;
        private TextBox infoTextBox;
        private NumericUpDown fontSizeNumericUpDown;
        private ComboBox fontSizeUnitComboBox;
        private Label guideLabel;
        private NumericUpDown guideXNumericUpDown;
        private NumericUpDown guideYNumericUpDown;
        private TableLayoutPanel tableLayoutPanel;
        private Label fontFamilyNameLabel;
        private ComboBox fontFamilyNameComboBox;
    }
}