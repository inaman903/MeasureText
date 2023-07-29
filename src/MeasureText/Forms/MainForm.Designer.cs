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
            fontNameComboBox = new ComboBox();
            fontNameLabel = new Label();
            fontSizeLabel = new Label();
            textLabel = new Label();
            textTextBox = new TextBox();
            infoTextBox = new TextBox();
            fontSizeNumericUpDown = new NumericUpDown();
            fontSizeUnitComboBox = new ComboBox();
            guideLabel = new Label();
            guideXNumericUpDown = new NumericUpDown();
            guideYNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)textPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fontSizeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guideXNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guideYNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // textPictureBox
            // 
            textPictureBox.BackColor = Color.White;
            textPictureBox.BorderStyle = BorderStyle.Fixed3D;
            textPictureBox.Location = new Point(0, 104);
            textPictureBox.Name = "textPictureBox";
            textPictureBox.Size = new Size(544, 152);
            textPictureBox.TabIndex = 0;
            textPictureBox.TabStop = false;
            // 
            // fontNameComboBox
            // 
            fontNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fontNameComboBox.FormattingEnabled = true;
            fontNameComboBox.Location = new Point(64, 8);
            fontNameComboBox.Name = "fontNameComboBox";
            fontNameComboBox.Size = new Size(256, 23);
            fontNameComboBox.TabIndex = 1;
            fontNameComboBox.SelectedIndexChanged += fontNameComboBox_SelectedIndexChanged;
            // 
            // fontNameLabel
            // 
            fontNameLabel.AutoSize = true;
            fontNameLabel.Location = new Point(8, 8);
            fontNameLabel.Name = "fontNameLabel";
            fontNameLabel.Size = new Size(52, 15);
            fontNameLabel.TabIndex = 3;
            fontNameLabel.Text = "フォント：";
            // 
            // fontSizeLabel
            // 
            fontSizeLabel.AutoSize = true;
            fontSizeLabel.Location = new Point(328, 8);
            fontSizeLabel.Name = "fontSizeLabel";
            fontSizeLabel.Size = new Size(47, 15);
            fontSizeLabel.TabIndex = 4;
            fontSizeLabel.Text = "サイズ：";
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Location = new Point(8, 40);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(54, 15);
            textLabel.TabIndex = 5;
            textLabel.Text = "テキスト：";
            // 
            // textTextBox
            // 
            textTextBox.Location = new Point(64, 40);
            textTextBox.Name = "textTextBox";
            textTextBox.Size = new Size(472, 23);
            textTextBox.TabIndex = 4;
            textTextBox.Text = "TEXT";
            textTextBox.TextChanged += textTextBox_TextChanged;
            // 
            // infoTextBox
            // 
            infoTextBox.BorderStyle = BorderStyle.FixedSingle;
            infoTextBox.Location = new Point(544, 0);
            infoTextBox.Multiline = true;
            infoTextBox.Name = "infoTextBox";
            infoTextBox.ReadOnly = true;
            infoTextBox.Size = new Size(256, 256);
            infoTextBox.TabIndex = 7;
            // 
            // fontSizeNumericUpDown
            // 
            fontSizeNumericUpDown.DecimalPlaces = 5;
            fontSizeNumericUpDown.Location = new Point(376, 8);
            fontSizeNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            fontSizeNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            fontSizeNumericUpDown.Size = new Size(96, 23);
            fontSizeNumericUpDown.TabIndex = 2;
            fontSizeNumericUpDown.Value = new decimal(new int[] { 16, 0, 0, 0 });
            fontSizeNumericUpDown.ValueChanged += fontSizeNumericUpDown_ValueChanged;
            // 
            // fontSizeUnitComboBox
            // 
            fontSizeUnitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fontSizeUnitComboBox.FormattingEnabled = true;
            fontSizeUnitComboBox.Location = new Point(480, 8);
            fontSizeUnitComboBox.Name = "fontSizeUnitComboBox";
            fontSizeUnitComboBox.Size = new Size(56, 23);
            fontSizeUnitComboBox.TabIndex = 3;
            fontSizeUnitComboBox.SelectedIndexChanged += fontSizeUnitComboBox_SelectedIndexChanged;
            // 
            // guideLabel
            // 
            guideLabel.AutoSize = true;
            guideLabel.Location = new Point(16, 72);
            guideLabel.Name = "guideLabel";
            guideLabel.Size = new Size(45, 15);
            guideLabel.TabIndex = 6;
            guideLabel.Text = "ガイド：";
            // 
            // guideXNumericUpDown
            // 
            guideXNumericUpDown.DecimalPlaces = 5;
            guideXNumericUpDown.Location = new Point(64, 72);
            guideXNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            guideXNumericUpDown.Name = "guideXNumericUpDown";
            guideXNumericUpDown.Size = new Size(96, 23);
            guideXNumericUpDown.TabIndex = 5;
            guideXNumericUpDown.ValueChanged += guideXNumericUpDown_ValueChanged;
            // 
            // guideYNumericUpDown
            // 
            guideYNumericUpDown.DecimalPlaces = 5;
            guideYNumericUpDown.Location = new Point(168, 72);
            guideYNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            guideYNumericUpDown.Name = "guideYNumericUpDown";
            guideYNumericUpDown.Size = new Size(96, 23);
            guideYNumericUpDown.TabIndex = 6;
            guideYNumericUpDown.ValueChanged += guideYNumericUpDown_ValueChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 256);
            Controls.Add(guideYNumericUpDown);
            Controls.Add(guideXNumericUpDown);
            Controls.Add(guideLabel);
            Controls.Add(fontSizeNumericUpDown);
            Controls.Add(infoTextBox);
            Controls.Add(textTextBox);
            Controls.Add(textLabel);
            Controls.Add(fontSizeLabel);
            Controls.Add(fontNameLabel);
            Controls.Add(fontSizeUnitComboBox);
            Controls.Add(fontNameComboBox);
            Controls.Add(textPictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MeasureText";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)textPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fontSizeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)guideXNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)guideYNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox textPictureBox;
        private ComboBox fontNameComboBox;
        private Label fontNameLabel;
        private Label fontSizeLabel;
        private Label textLabel;
        private TextBox textTextBox;
        private TextBox infoTextBox;
        private NumericUpDown fontSizeNumericUpDown;
        private ComboBox fontSizeUnitComboBox;
        private Label guideLabel;
        private NumericUpDown guideXNumericUpDown;
        private NumericUpDown guideYNumericUpDown;
    }
}