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
            // フォントファミリ
            fontNameComboBox.DisplayMember = "Name";
            foreach (var family in FontFamily.Families)
            {
                fontNameComboBox.Items.Add(family);
            }
            if (fontNameComboBox.Items.Count > 0)
            {
                fontNameComboBox.SelectedIndex = 0;
            }

            // フォントサイズ単位
            fontSizeUnitComboBox.Items.Add(GraphicsUnit.Point);
            fontSizeUnitComboBox.Items.Add(GraphicsUnit.Pixel);
            fontSizeUnitComboBox.SelectedIndex = 0;
        }

        private void fontNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // テキスト画像更新
            UpdateTextPicture();
        }

        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // テキスト画像更新
            UpdateTextPicture();
        }

        private void fontSizeUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // テキスト画像更新
            UpdateTextPicture();
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            // テキスト画像更新
            UpdateTextPicture();
        }

        private void guideXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // テキスト画像更新
            UpdateTextPicture();
        }

        private void guideYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // テキスト画像更新
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

                // 描画リソース生成
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

                // フォント情報取得
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

                // ベースライン、ディセンダラインY座標算出
                var baselineY = 0.0f + ascentHeight;
                var descentlineY = ascentHeight + descentHeight;

                // フレーム座標算出
                var frameSize = graphics.MeasureString(text, font, int.MaxValue, format);
                var frameRectF = new RectangleF(0.0f, 0.0f, frameSize.Width, frameSize.Height);

                // テキスト描画
                graphics.DrawString(text, font, Brushes.Black, PointF.Empty, format);
                // ベースライン描画
                graphics.DrawLine(baselinePen, new PointF(0.0f, baselineY), new PointF(width, baselineY));
                // ディセンダライン描画
                graphics.DrawLine(descentlinePen, new PointF(0.0f, descentlineY), new PointF(width, descentlineY));
                // フレーム描画
                graphics.DrawRectangle(framePen, frameRectF);
                // ガイドライン描画
                graphics.DrawLine(guidelinePen, new PointF(guideX, 0.0f), new PointF(guideX, height));
                graphics.DrawLine(guidelinePen, new PointF(0.0f, guideY), new PointF(width, guideY));

                // テキスト画像更新
                var oldImage = textPictureBox.Image;
                textPictureBox.Image = bitmap;
                oldImage?.Dispose();

                // テキスト情報更新
                var info = new StringBuilder();
                info.AppendLine($"フォント：{fontFamily.Name}");
                info.AppendLine($"サイズ({fontSizeUnit})：{fontSize}");
                info.AppendLine($"テキスト：{text}");
                info.AppendLine($"ベースラインY({GraphicsUnit.Pixel})：{baselineY}");
                info.AppendLine($"ディセンダラインY({GraphicsUnit.Pixel})：{descentlineY}");
                info.AppendLine($"フレームXYWH({GraphicsUnit.Pixel})：{frameRectF.X},{frameRectF.Y},{frameRectF.Width},{frameRectF.Height}");
                infoTextBox.Text = info.ToString();
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder();
                msg.AppendLine("テキスト画像の描画に失敗しました");
                msg.AppendLine();
                msg.AppendLine("エラー：");
                msg.AppendLine(ex.Message);
                msg.AppendLine();
                msg.AppendLine("スタックトレース：");
                msg.AppendLine(ex.StackTrace);
                MessageBox.Show(msg.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}