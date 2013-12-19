using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Controls.MakePictureFromtext
{
    public partial class MakePictureFromText : System.Web.UI.UserControl
    {
        private string questionText;
        public string QuestionText
        {
            get 
            {
                return this.questionText;
            }
            set
            {
                if (value!=null)
                {
                   this.Session["questionText"] = value;
                }
                this.questionText = value;
            }
           
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            var textAsImage = questionText;

            if (textAsImage == null)
            {
                textAsImage = this.Session["questionText"].ToString();
               
            }
           
            if (!string.IsNullOrEmpty(textAsImage))
            {
                System.Web.UI.WebControls.Image imgQuestionText = new System.Web.UI.WebControls.Image();
                using (Bitmap bitMap = new Bitmap(15000, 300))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M", 160);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        SolidBrush whiteBrush = new SolidBrush(Color.FromArgb( 245, 245, 245));
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        graphics.DrawString(textAsImage, oFont, blackBrush, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] byteImage = ms.ToArray();

                        Convert.ToBase64String(byteImage);
                        imgQuestionText.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(byteImage);
                    }
                    plVisitors.Controls.Add(imgQuestionText);
                }
            }
        }
    }
}