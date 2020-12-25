using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.WPF
{
    public class InfoImage
    {
        public string Image { get; set; }
        public string ImageName { get; set; }
        public string Text { get; set; }

        public InfoImage(string Image, string Text, string ImageName)
        {
            this.Image = Image;
            this.Text = Text;
            this.ImageName = ImageName;
        }
    }
}
