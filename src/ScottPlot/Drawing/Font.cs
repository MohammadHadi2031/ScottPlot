using System;
using System.Drawing;

namespace ScottPlot.Drawing
{
    public class Font
    {
        public float Size
        {
            get => size;
            set
            {
                size = value;
                BaseFont = new System.Drawing.Font(Name, value, FontStyle);
            }
        }
        public Color Color = Color.Black;
        public Alignment Alignment = Alignment.UpperLeft;
        public bool Bold
        {
            get => bold; set
            {
                bold = value;
                BaseFont = new System.Drawing.Font(Name, Size, FontStyle);
            }
        }
        public float Rotation { get; set; } = 0;
        public System.Drawing.Font BaseFont
        {
            get => baseFont;
            private set
            {
                if (baseFont != null)
                    baseFont.Dispose();

                baseFont = value;
            }
        }

        private string _Name;
        private float size = 12;
        private System.Drawing.Font baseFont;
        private bool bold = false;

        private FontStyle FontStyle => bold ? FontStyle.Bold : FontStyle.Regular;

        public string Name
        {
            get => _Name;
            set
            {
                _Name = InstalledFont.ValidFontName(value); // ensure only valid font names can be assigned
                BaseFont = new System.Drawing.Font(value, Size, FontStyle);
            }
        }

        public Font() => Name = InstalledFont.Sans();
    }
}
