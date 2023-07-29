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
            foreach (var family in FontFamily.Families)
            {
                fontNameComboBox.Items.Add(family.Name);
            }
            if (fontNameComboBox.Items.Count > 0)
            {
                fontNameComboBox.SelectedIndex = 0;
            }
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

        private void textTextBox_TextChanged(object sender, EventArgs e)
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
                var fontName = fontNameComboBox.SelectedItem?.ToString() ?? string.Empty;
                var fontSize = (float)fontSizeNumericUpDown.Value;

                // �`�惊�\�[�X����
                var bitmap = new Bitmap(width, height);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                using var font = new Font(fontName, fontSize, FontStyle.Regular, GraphicsUnit.Point);
                using var format = StringFormat.GenericTypographic;
                format.FormatFlags = StringFormatFlags.NoFontFallback;

                using var baselinePen = new Pen(Color.Blue, 1.0f);
                baselinePen.DashStyle = DashStyle.Dash;

                using var descentlinePen = new Pen(Color.Green, 1.0f);
                descentlinePen.DashStyle = DashStyle.Dash;

                using var framePen = new Pen(Color.Red, 1);

                // �t�H���g���擾
                var family = font.FontFamily;
                var ascent = family.GetCellAscent(font.Style);
                var descent = family.GetCellDescent(font.Style);
                var emHeight = family.GetEmHeight(font.Style);

                var fontSizePx = font.SizeInPoints / 72.0f * 96.0f;
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

                // �e�L�X�g�摜�X�V
                var oldImage = textPictureBox.Image;
                textPictureBox.Image = bitmap;
                oldImage?.Dispose();

                // �e�L�X�g���X�V
                var info = new StringBuilder();
                info.AppendLine($"�e�L�X�g�F{text}");
                info.AppendLine($"�t�H���g�F{fontName}");
                info.AppendLine($"�T�C�Y(pt)�F{fontSize}");
                info.AppendLine($"�x�[�X���C��Y(px)�F{baselineY}");
                info.AppendLine($"�f�B�Z���_���C��Y(px)�F{descentlineY}");
                info.AppendLine($"�t���[��XYWH(px)�F{frameRectF.X},{frameRectF.Y},{frameRectF.Width},{frameRectF.Height}");
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