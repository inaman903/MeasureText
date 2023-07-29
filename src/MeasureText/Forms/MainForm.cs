using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace MeasureText
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // �t�H���g�t�@�~��
            fontNameComboBox.DisplayMember = "Name";
            foreach (var family in FontFamily.Families)
            {
                fontNameComboBox.Items.Add(family);
            }
            if (fontNameComboBox.Items.Count > 0)
            {
                fontNameComboBox.SelectedIndex = 0;
            }

            // �t�H���g�T�C�Y�P��
            fontSizeUnitComboBox.Items.Add(GraphicsUnit.Point);
            fontSizeUnitComboBox.Items.Add(GraphicsUnit.Pixel);
            fontSizeUnitComboBox.SelectedIndex = 0;
        }

        private void fontNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void UpdateTextPicture()
        {
            try
            {
                var text = textTextBox.Text;
                var width = textPictureBox.Width;
                var height = textPictureBox.Height;
                var fontFamily = (FontFamily)fontNameComboBox.SelectedItem ?? FontFamily.GenericMonospace;
                var fontSize = (float)fontSizeNumericUpDown.Value;
                var fontSizeUnit = (GraphicsUnit?)fontSizeUnitComboBox.SelectedItem ?? GraphicsUnit.Point;
                var guideX = (float)guideXNumericUpDown.Value;
                var guideY = (float)guideYNumericUpDown.Value;

                // �`�惊�\�[�X����
                var bitmap = new Bitmap(width, height);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                using var font = new Font(fontFamily, fontSize, FontStyle.Regular, fontSizeUnit);
                using var format = StringFormat.GenericTypographic;
                format.FormatFlags = StringFormatFlags.NoFontFallback;

                using var guidelinePen = new Pen(Color.Orange, 1.0f);
                guidelinePen.DashStyle = DashStyle.Dash;

                using var baselinePen = new Pen(Color.Blue, 1.0f);
                baselinePen.DashStyle = DashStyle.Dash;

                using var descentlinePen = new Pen(Color.Green, 1.0f);
                descentlinePen.DashStyle = DashStyle.Dash;

                using var framePen = new Pen(Color.Red, 1);

                // �t�H���g���擾
                var ascent = fontFamily.GetCellAscent(font.Style);
                var descent = fontFamily.GetCellDescent(font.Style);
                var emHeight = fontFamily.GetEmHeight(font.Style);

                var fontSizePx = 0.0f;
                switch (fontSizeUnit)
                {
                    case GraphicsUnit.Point:
                        fontSizePx = font.SizeInPoints / 72.0f * 96.0f;
                        break;
                    case GraphicsUnit.Pixel:
                        fontSizePx = font.Size;
                        break;
                }
                var fontHeight = font.GetHeight(graphics);
                var ascentHeight = fontSizePx * ascent / emHeight;
                var descentHeight = fontSizePx * descent / emHeight;

                // �x�[�X���C���A�f�B�Z���_���C��Y���W�Z�o
                var baselineY = 0.0f + ascentHeight;
                var descentlineY = ascentHeight + descentHeight;

                // �t���[�����W�Z�o
                var frameSize = graphics.MeasureString(text, font, int.MaxValue, format);
                var frameRectF = new RectangleF(0.0f, 0.0f, frameSize.Width, frameSize.Height);

                // �e�L�X�g�`��
                graphics.DrawString(text, font, Brushes.Black, PointF.Empty, format);
                // �x�[�X���C���`��
                graphics.DrawLine(baselinePen, new PointF(0.0f, baselineY), new PointF(width, baselineY));
                // �f�B�Z���_���C���`��
                graphics.DrawLine(descentlinePen, new PointF(0.0f, descentlineY), new PointF(width, descentlineY));
                // �t���[���`��
                graphics.DrawRectangle(framePen, frameRectF);
                // �K�C�h���C���`��
                graphics.DrawLine(guidelinePen, new PointF(guideX, 0.0f), new PointF(guideX, height));
                graphics.DrawLine(guidelinePen, new PointF(0.0f, guideY), new PointF(width, guideY));

                // �e�L�X�g�摜�X�V
                var oldImage = textPictureBox.Image;
                textPictureBox.Image = bitmap;
                oldImage?.Dispose();

                // �e�L�X�g���X�V
                var info = new StringBuilder();
                info.AppendLine($"�t�H���g�F{fontFamily.Name}");
                info.AppendLine($"�T�C�Y({fontSizeUnit})�F{fontSize}");
                info.AppendLine($"�e�L�X�g�F{text}");
                info.AppendLine($"�x�[�X���C��Y({GraphicsUnit.Pixel})�F{baselineY}");
                info.AppendLine($"�f�B�Z���_���C��Y({GraphicsUnit.Pixel})�F{descentlineY}");
                info.AppendLine($"�t���[��XYWH({GraphicsUnit.Pixel})�F{frameRectF.X},{frameRectF.Y},{frameRectF.Width},{frameRectF.Height}");
                infoTextBox.Text = info.ToString();
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder();
                msg.AppendLine("�e�L�X�g�摜�̕`��Ɏ��s���܂���");
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