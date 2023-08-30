using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Text;

namespace MeasureText
{
    public partial class MainForm : Form
    {
        private enum FontSizeUnit
        {
            Point,
            Pixel
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // �t�H���g�t�@�~��
            foreach (var fontFamily in SKFontManager.Default.FontFamilies)
            {
                fontFamilyNameComboBox.Items.Add(fontFamily);
            }
            if (fontFamilyNameComboBox.Items.Count > 0)
            {
                fontFamilyNameComboBox.SelectedIndex = 0;
            }

            // �t�H���g�T�C�Y�P��
            fontSizeUnitComboBox.Items.Add(FontSizeUnit.Point);
            fontSizeUnitComboBox.Items.Add(FontSizeUnit.Pixel);
            fontSizeUnitComboBox.SelectedIndex = 0;
        }

        private void fontFamilyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void fontSizeUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void guideXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void guideYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // �e�L�X�g�摜�X�V
            UpdateTextPicture();
        }

        private void UpdateTextPicture()
        {
            try
            {
                var text = textTextBox.Text;
                var width = textPictureBox.Width;
                var height = textPictureBox.Height;
                var fontFamilyName = (string?)fontFamilyNameComboBox.SelectedItem ?? string.Empty;
                var fontSize = (float)fontSizeNumericUpDown.Value;
                var fontSizeUnit = (FontSizeUnit?)fontSizeUnitComboBox.SelectedItem ?? FontSizeUnit.Point;
                var guideX = (float)guideXNumericUpDown.Value;
                var guideY = (float)guideYNumericUpDown.Value;

                // �`�惊�\�[�X����
                using var paint = new SKPaint();
                using var bitmap = new SKBitmap(width, height);
                using var canvas = new SKCanvas(bitmap);
                canvas.Clear(SKColors.White);

                // �t�H���g�����擾
                using var typeFace = SKTypeface.FromFamilyName(fontFamilyName, SKFontStyle.Normal);
                var pxFontSize = 0.0f;
                switch (fontSizeUnit)
                {
                    case FontSizeUnit.Point:
                        pxFontSize = fontSize / 72.0f * 96.0f;
                        break;
                    case FontSizeUnit.Pixel:
                        pxFontSize = fontSize;
                        break;
                }

                // �e�L�X�g�t�H���g���g���N�X���擾
                paint.Reset();
                paint.Typeface = typeFace;
                paint.TextSize = pxFontSize;
                var textFontMetrics = paint.FontMetrics;
                var baseline = -textFontMetrics.Top;

                // �����G���A�`��
                //paint.Reset();
                //paint.Color = SKColors.LightYellow;
                //paint.Style = SKPaintStyle.Fill;
                //canvas.DrawRect(0.0f, baseline - textFontMetrics.XHeight / 2.0f - pxFontSize / 2.0f, width, pxFontSize, paint);

                // Top�`��
                var top = 0.0f;
                paint.Reset();
                paint.Color = SKColors.Pink;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, top, width, top, paint);

                // Ascent�`��
                var ascent = baseline + textFontMetrics.Ascent;
                paint.Reset();
                paint.Color = SKColors.Green;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, ascent, width, ascent, paint);

                // CapHeight�`��
                var capHeight = baseline - textFontMetrics.CapHeight;
                paint.Reset();
                paint.Color = SKColors.Purple;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, capHeight, width, capHeight, paint);

                // XHeight�`��
                var xHeight = baseline - textFontMetrics.XHeight;
                paint.Reset();
                paint.Color = SKColors.DarkGray;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, xHeight, width, xHeight, paint);

                // Baseline�`��
                paint.Reset();
                paint.Color = SKColors.Red;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, baseline, width, baseline, paint);

                // Descent�`��
                var descent = baseline + textFontMetrics.Descent;
                paint.Reset();
                paint.Color = SKColors.Green;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, descent, width, descent, paint);

                // Bottom�`��
                var bottom = baseline + textFontMetrics.Bottom;
                paint.Reset();
                paint.Color = SKColors.Pink;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, bottom, width, bottom, paint);

                // �e�L�X�g���`��
                var textWidth = paint.MeasureText(text);
                paint.Reset();
                paint.Typeface = typeFace;
                paint.TextSize = pxFontSize;
                paint.Color = SKColors.Blue;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, 0.0f, 0.0f, bottom, paint);
                canvas.DrawLine(textWidth, 0.0f, textWidth, bottom, paint);

                // �e�L�X�g�`��
                paint.Reset();
                paint.Typeface = typeFace;
                paint.TextSize = pxFontSize;
                paint.Color = SKColors.Black;
                canvas.DrawText(text, 0.0f, baseline, paint);

                // �K�C�h�`��
                paint.Reset();
                paint.Color = SKColors.Orange;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(guideX, 0.0f, guideX, height, paint);
                canvas.DrawLine(0.0f, guideY, width, guideY, paint);

                // �e�L�X�g�摜�X�V
                var oldImage = textPictureBox.Image;
                textPictureBox.Image = bitmap.ToBitmap();
                oldImage?.Dispose();

                // �e�L�X�g���X�V
                var info = new StringBuilder();
                info.AppendLine("[Font]");
                info.AppendLine($"FontFamilyName�F{fontFamilyName}");
                info.AppendLine($"FontSize�F{fontSize} {(fontSizeUnit == FontSizeUnit.Point ? "pt" : "px")}");
                info.AppendLine();
                info.AppendLine("[Text]");
                info.AppendLine($"Text�F{text}");
                info.AppendLine($"TextWidth(Blue)�F{textWidth} px");
                info.AppendLine();
                info.AppendLine("[FontMetrics]");
                info.AppendLine($"Top(Pink)�F{top} px");
                info.AppendLine($"Ascent(Green)�F{ascent} px");
                info.AppendLine($"CapHeight(Purple)�F{capHeight} px");
                info.AppendLine($"XHeight(DarkGray)�F{xHeight} px");
                info.AppendLine($"Baseline(Red)�F{baseline} px");
                info.AppendLine($"Descent(Green)�F{descent} px");
                info.AppendLine($"Bottom(Pink)�F{bottom} px");
                infoTextBox.Text = info.ToString();
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder();
                msg.AppendLine("�e�L�X�g�v���Ɏ��s���܂���");
                msg.AppendLine();
                msg.AppendLine("�G���[�F");
                msg.AppendLine(ex.Message);
                msg.AppendLine();
                msg.AppendLine("�X�^�b�N�g���[�X�F");
                msg.AppendLine(ex.StackTrace);
                MessageBox.Show(msg.ToString(), "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}