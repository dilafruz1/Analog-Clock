using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Clock
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            size2 = (Width * .78f) / (2);
            size1 = (Height * .9f) / (2);
            rad = Width / 2;
            cen = new Point(Width / 2, Height / 2);

        }
      
        

            Timer t = new Timer();
        private new int Width = 400, Height = 400;
        private Bitmap bmp;
        private Graphics g;
        private float rad;
        private PointF cen;
        private Color handcolor = Color.HotPink;
        private Color innercolor = Color.DarkGoldenrod;
        private Color outercolor = Color.Black;
        private Color tickcolor = Color.DarkGray;
        private Color secondhandcolor = Color.Red;
        private float size1;
        private float size2;
        private DateTime currentTime = DateTime.Now;
        private DateTime selectedTime = DateTime.Now;
        private Calendar calendar = new GregorianCalendar();
        private Color hourcolor = Color.DarkGoldenrod;
       

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Width + 1, Height + 1);
            this.BackColor = Color.DimGray;
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
       
        }
        private void t_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);

            currentTime = currentTime.AddSeconds(1);

            int sec = currentTime.Second;
            int min = currentTime.Minute;
            int hour = currentTime.Hour;
            g.Clear(Color.White);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, Width, Height);
            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = innercolor;
            pgb.SurroundColors = new Color[] { outercolor };
            g.FillEllipse(pgb, 0, 0, Width, Height);
            g.DrawEllipse(new Pen(Color.DarkGray, 2f), 0, 0, Width, Height);
            g.DrawString(hour + ":" + min + ":" + sec, new Font("Arial", 25), Brushes.LightBlue, new PointF(130, 280));
            g.DrawString("55", new Font("Impact", 10), Brushes.DarkRed, new PointF(98, 26));
            g.DrawString("60", new Font("Impact", 10), Brushes.DarkRed, new PointF(190, 1));
            g.DrawString("5", new Font("Impact", 10), Brushes.DarkRed, new PointF(290, 25));
            g.DrawString("10", new Font("Impact", 10), Brushes.DarkRed, new PointF(358, 97));
            g.DrawString("15", new Font("Impact", 10), Brushes.DarkRed, new PointF(384, 190));
            g.DrawString("20", new Font("Impact", 10), Brushes.DarkRed, new PointF(355, 286));
            g.DrawString("25", new Font("Impact", 10), Brushes.DarkRed, new PointF(285, 359));
            g.DrawString("30", new Font("Impact", 10), Brushes.DarkRed, new PointF(192, 393));
            g.DrawString("35", new Font("Impact", 10), Brushes.DarkRed, new PointF(95, 357));
            g.DrawString("40", new Font("Impact", 10), Brushes.DarkRed, new PointF(27, 286));
            g.DrawString("45", new Font("Impact", 10), Brushes.DarkRed, new PointF(1, 193));
            g.DrawString("50", new Font("Impact", 10), Brushes.DarkRed, new PointF(26, 95));
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                    g.DrawLine(new Pen(tickcolor, rad * .015f),
                             (float)Math.Cos(i * 6 * Math.PI / 180) * rad * .95f + cen.X,
                             (float)Math.Sin(i * 6 * Math.PI / 180) * rad * .95f + cen.Y,
                             (float)Math.Cos(i * 6 * Math.PI / 180) * rad + cen.X,
                             (float)Math.Sin(i * 6 * Math.PI / 180) * rad + cen.Y);
            }
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                    g.DrawLine(new Pen(hourcolor, size1 * .04f),
                             (float)Math.Cos(i * 6 * Math.PI / 180) * size1 * .95f + cen.X,
                             (float)Math.Sin(i * 6 * Math.PI / 180) * size1 * .95f + cen.Y,
                             (float)Math.Cos(i * 6 * Math.PI / 180) * size1 + cen.X,
                             (float)Math.Sin(i * 6 * Math.PI / 180) * size1 + cen.Y);
            }
            Color c = Color.FromArgb((innercolor.R + outercolor.R) / 2,
                (innercolor.G + outercolor.G) / 2,
                (innercolor.B + outercolor.B) / 2);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            g.FillRectangle(Brushes.White,
                cen.X + size2 * .46f, cen.Y - size2 * .06f,
                size2 * .24f, size2 * .12f);

            g.DrawRectangle(new Pen(Color.DarkGoldenrod, size2 * .015f),
               cen.X + size2 * .46f, cen.Y - size2 * .06f,
               size2 * 24f, size2 * .12f);


            g.DrawString(DateTime.Now.DayOfWeek.ToString().Substring(0, 3).ToUpper(),
                new Font("Lucida Console",
                size2 * .09f, FontStyle.Bold), Brushes.Black,
                cen.X + size2 * .585f, cen.Y - size2 * .05f, sf);

            g.FillRectangle(Brushes.White,
               cen.X + size2 * .7f, cen.Y - size2 * .06f,
               size2 * .16f, size2 * .12f);

            g.DrawRectangle(new Pen(Color.DarkGoldenrod, size2 * .015f),
              cen.X + size2 * .7f, cen.Y - size2 * .06f,
              size2 * .16f, size2 * .12f);
            g.DrawString(calendar.GetDayOfMonth(DateTime.Now).ToString(),
                new Font("Lucida Console",
                size2 * .08f, FontStyle.Bold), Brushes.Black,
                cen.X + size2 * .785f, cen.Y - size2 * .04f, sf);

            FontFamily ff = new FontFamily("Arial");

            System.Drawing.Font font_1 = new System.Drawing.Font(ff, 20f);

            g.DrawString("Clock", font_1, Brushes.LightBlue, new PointF(155, 75));

            Font font_2 = new Font(ff, 7f);

            g.DrawString("DILAFRO'Z", font_2, Brushes.LightBlue, new PointF(67, 120));



            g.FillPolygon(new SolidBrush(handcolor),
             new PointF[]
             {new PointF (
                 cen.X-(float) (Math.Sin((hour *30+min/12*6) *Math.PI/180))*rad*.1f,
                 cen.Y-(float) (-Math.Cos((hour* 30+ min / 12*6)*Math.PI/180))* rad*.1f),

            new PointF (
                 cen.X-(float) (Math.Sin((hour *30+min/12*6+90) *Math.PI/180))*rad*.05f,
                 cen.Y-(float) (-Math.Cos((hour* 30+ min / 12*6+90)*Math.PI/180))* rad*.05f),

            new PointF (
                 (float) (Math.Sin((hour *30+min/12*6) *Math.PI/180))*rad*.5f+cen.X,
                (float) (-Math.Cos((hour* 30+ min / 12*6)*Math.PI/180))* rad*.5f+cen.Y),

             new PointF (
                 cen.X-(float) (Math.Sin((hour *30+min/12*6-90) *Math.PI/180))*rad*.05f,
                 cen.Y-(float) (-Math.Cos((hour* 30+ min / 12*6-90)*Math.PI/180))* rad*.05f)
             });

        g.FillPolygon(new SolidBrush(handcolor),
            new PointF[]
             {new PointF (
                 cen.X-(float) (Math.Sin(min *6 *Math.PI/180))*rad*.1f,
                 cen.Y-(float) (-Math.Cos(min* 6*Math.PI/180))* rad*.1f),

            new PointF (
                 cen.X-(float) (Math.Sin((min*6+90) *Math.PI/180))*rad*.05f,
                 cen.Y-(float) (-Math.Cos((min* 30+90)*Math.PI/180))* rad*.05f),

            new PointF (
                 (float) (Math.Sin(min*6 *Math.PI/180))*rad*.7f+cen.X,
                (float) (-Math.Cos(min*6*Math.PI/180))* rad*.7f+cen.Y),

            new PointF (
                 cen.X-(float) (Math.Sin((min*6-90) *Math.PI/180))*rad*.05f,
                 cen.Y-(float) (-Math.Cos((min*6-90)*Math.PI/180))* rad*.05f)
                
             });
            g.DrawLine(new Pen(secondhandcolor, size1 * .01f),
            cen.X - (float)(Math.Sin(sec * 6 * Math.PI / 180)) * rad * .2f,
            cen.Y - (float)(-Math.Cos(sec * 6 * Math.PI / 180)) * rad * .1f,
            (float)(Math.Sin(sec * 6 * Math.PI / 180)) * rad * .7f + cen.X,
            (float)(-Math.Cos(sec * 6 * Math.PI / 180)) * rad * .7f + cen.Y);

            g.FillEllipse(new SolidBrush(secondhandcolor), cen.X - rad * .03f, cen.Y - rad * .03f, rad * .06f, rad * .06f);
            clock.Image = bmp;   
            Text="soat-"+hour+":"+min+":"+sec;
            g.Dispose();
}

        private void button1_Click_1(object sender, EventArgs e)
        {
           
                using (DateTimePicker dateTimePicker = new DateTimePicker())
                {
                    dateTimePicker.Format = DateTimePickerFormat.Time;  // Faqat vaqtni tanlash
                    dateTimePicker.ShowUpDown = true;  // Vaqtni faqat soat va daqiqa shaklida tanlash
                    dateTimePicker.Value = DateTime.Now;  // Hozirgi vaqtni default sifatida olish

                    // Foydalanuvchiga vaqtni tanlash imkoniyatini berish
                    Form tempForm = new Form
                    {
                        Text = "Vaqtni tanlang",
                        Width = 250,
                        Height = 120,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        StartPosition = FormStartPosition.CenterParent
                    };

                    Button okButton = new Button { Text = "OK", DialogResult = DialogResult.OK, Dock = DockStyle.Bottom };
                    tempForm.Controls.Add(okButton);
                    tempForm.Controls.Add(dateTimePicker);
                    dateTimePicker.Dock = DockStyle.Top;

                    // Tanlangan vaqtni olish va o'rnatish
                    if (tempForm.ShowDialog() == DialogResult.OK)
                    {
                        selectedTime = dateTimePicker.Value;  // Foydalanuvchi tanlagan vaqtni saqlash
                        currentTime = DateTime.Today + selectedTime.TimeOfDay;  // Soatni shu vaqtdan boshlash
                        MessageBox.Show("Soat yangilandi: " + currentTime.ToLongTimeString());
                    }
                }
            }


        }
    }

