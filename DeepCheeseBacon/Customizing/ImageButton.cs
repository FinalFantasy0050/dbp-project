using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepcheesebacon.Customizing
{
    public class ImageButton : Panel
    {
        private Image image01 = SystemIcons.Hand.ToBitmap();

        [Browsable(true)]
        public Image Image_01
        {
            get { return image01; }
            set
            {
                image01 = value;
                BackgroundImage = image01;
            }
        }

        [Browsable(true)]
        public Image Image_02
        {
            get { return image02; }
            set { image02 = value; }
        }

        public ImageButton()
        {
            MouseDown += ImageButton_MouseDown;
            MouseUp += ImageButton_MouseUp;

            BackgroundImage = image01;
            BackgroundImageLayout = ImageLayout.Zoom;
        }

        void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = image02;
        }

        void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundImage = image01;
        }
    }
}
