using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Text;

namespace MeasureText
{
    public partial class MainForm : Form
    {
        private enum FontSizeUnit
        {
            Pixel,
            Point
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // フォントファミリ
            foreach (var fontFamily in SKFontManager.Default.FontFamilies)
            {
                fontFamilyNameComboBox.Items.Add(fontFamily);
            }
            if (fontFamilyNameComboBox.Items.Count > 0)
            {
                fontFamilyNameComboBox.SelectedIndex = 0;
            }

            // フォントサイズ単位
            fontSizeUnitComboBox.Items.Add(FontSizeUnit.Pixel);
            fontSizeUnitComboBox.Items.Add(FontSizeUnit.Point);
            fontSizeUnitComboBox.SelectedIndex = 0;
        }

        private void fontFamilyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void MainForm_Resize(object sender, EventArgs e)
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
                var fontFamilyName = (string?)fontFamilyNameComboBox.SelectedItem ?? string.Empty;
                var fontSize = (float)fontSizeNumericUpDown.Value;
                var fontSizeUnit = (FontSizeUnit?)fontSizeUnitComboBox.SelectedItem ?? FontSizeUnit.Point;
                var guideX = (float)guideXNumericUpDown.Value;
                var guideY = (float)guideYNumericUpDown.Value;

                // キャンバス生成生成
                using var bitmap = new SKBitmap(width, height);
                using var canvas = new SKCanvas(bitmap);
                canvas.Clear(SKColors.White);

                // フォント生成
                using var typeFace = SKTypeface.FromFamilyName(fontFamilyName, SKFontStyle.Normal);
                var pxFontSize = 0.0f;
                switch (fontSizeUnit)
                {
                    case FontSizeUnit.Pixel:
                        pxFontSize = fontSize;
                        break;
                    case FontSizeUnit.Point:
                        pxFontSize = fontSize / 72.0f * 96.0f;
                        break;
                }
                using var font = new SKFont(typeFace, pxFontSize);

                // ペイント生成
                using var paint = new SKPaint(font);
                var metrics = paint.FontMetrics;

                // 計算
                var baseline1 = -metrics.Ascent;
                var ascent = baseline1 + metrics.Ascent;
                var capHeight = baseline1 - metrics.CapHeight;
                var xHeight = baseline1 - metrics.XHeight;
                var descent = baseline1 + metrics.Descent;
                var leading = metrics.Leading;
                var textWidth = paint.MeasureText(text);
                var textHeight = descent - ascent;
                var baseline2 = baseline1 + metrics.Descent + metrics.Leading + -metrics.Ascent;
                var baseline3 = baseline2 + metrics.Descent + metrics.Leading + -metrics.Ascent;
                var baseline4 = baseline3 + metrics.Descent + metrics.Leading + -metrics.Ascent;
                var baseline5 = baseline4 + metrics.Descent + metrics.Leading + -metrics.Ascent;

                // テキストエリア描画
                paint.Color = SKColors.Yellow;
                paint.Style = SKPaintStyle.Fill;
                canvas.DrawRect(0.0f, ascent, textWidth, textHeight, paint);

                // Leadingエリア描画
                paint.Color = SKColors.LightGreen;
                canvas.DrawRect(0.0f, descent, width, leading, paint);

                // Ascent描画
                paint.Color = SKColors.Green;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, ascent, width, ascent, paint);

                // CapHeight描画
                paint.Color = SKColors.Purple;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, capHeight, width, capHeight, paint);

                // XHeight描画
                paint.Color = SKColors.DarkGray;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, xHeight, width, xHeight, paint);

                // Baseline描画
                paint.Color = SKColors.Red;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, baseline1, width, baseline1, paint);

                // Descent描画
                paint.Color = SKColors.Green;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(0.0f, descent, width, descent, paint);

                // テキスト描画
                paint.Color = SKColors.Black;
                canvas.DrawText(text, 0.0f, baseline1, paint);
                canvas.DrawText(text, 0.0f, baseline2, paint);
                canvas.DrawText(text, 0.0f, baseline3, paint);
                canvas.DrawText(text, 0.0f, baseline4, paint);
                canvas.DrawText(text, 0.0f, baseline5, paint);

                // ガイド描画
                paint.Color = SKColors.Orange;
                paint.StrokeWidth = 1.0f;
                canvas.DrawLine(guideX, 0.0f, guideX, height, paint);
                canvas.DrawLine(0.0f, guideY, width, guideY, paint);

                // テキスト画像更新
                var oldImage = textPictureBox.Image;
                textPictureBox.Image = bitmap.ToBitmap();
                oldImage?.Dispose();

                // テキスト情報更新
                var info = new StringBuilder();
                info.AppendLine("[Font]");
                info.AppendLine($"FontFamilyName：{fontFamilyName}");
                info.AppendLine($"FontSize：{fontSize} {(fontSizeUnit == FontSizeUnit.Point ? "pt" : "px")}");
                info.AppendLine();
                info.AppendLine("[Text]");
                info.AppendLine($"Text：{text}");
                info.AppendLine($"TextWidth(Yellow)：{textWidth} px");
                info.AppendLine($"TextHeight(Yellow)：{textHeight} px");
                info.AppendLine();
                info.AppendLine("[FontMetrics]");
                info.AppendLine($"Top：{baseline1 + metrics.Top} px");
                info.AppendLine($"Ascent(Green)：{ascent} px");
                info.AppendLine($"CapHeight(Purple)：{capHeight} px");
                info.AppendLine($"XHeight(DarkGray)：{xHeight} px");
                info.AppendLine($"Baseline(Red)：{baseline1} px");
                info.AppendLine($"Descent(Green)：{descent} px");
                info.AppendLine($"Bottom：{baseline1 + metrics.Bottom} px");
                info.AppendLine($"Leading(LightGreen)：{leading} px");
                infoTextBox.Text = info.ToString();
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder();
                msg.AppendLine("テキスト計測に失敗しました");
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