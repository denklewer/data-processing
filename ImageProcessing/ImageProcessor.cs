using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Graphics.util;
using Graphics.forms;
using System.Text.RegularExpressions;

namespace ImageProcessing
{
    public partial class ImageProcessor : Form
    {
        enum ImageType { NONE, XCR , JPEG };
        enum ByteDirection { Straight, Inverted };
        private class PictureData {
            public ImageType ImageType { get; set; }
            public PictureBox Picture { get; set; }

            public PictureData(PictureBox picture, ImageType imageType)
            {
                Picture = picture;
                ImageType = imageType;

            }

            public override bool Equals(object obj)
            {
                var data = obj as PictureData;
                return data != null &&
                       ImageType == data.ImageType &&
                       EqualityComparer<PictureBox>.Default.Equals(Picture, data.Picture);
            }

            public override int GetHashCode()
            {
                var hashCode = -876149837;
                hashCode = hashCode * -1521134295 + ImageType.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<PictureBox>.Default.GetHashCode(Picture);
                return hashCode;
            }
        }


        //    private Func<Double[], Double[], Double[]> transformX = new Func<double[], double[], double[]>((x, y) => x);
        private Func<Double[], Double[], Double[]> transformY = new Func<double[], double[], double[]>((x, y) => x);
        private Func<Double[][], Double[], Double[][]> transformWhole = new Func<double[][], double[], double[][]>((x, y) => x);
        private List< PictureData> pictureList = new List<PictureData>();
        private double dT = 0.001;


        static List<double[][]> data= new List<double[][]>();
        static ImageType currImageType = ImageType.NONE;
        static int width;
        static int height;

        public ImageProcessor()
        {

            InitializeComponent();
            pictureList.Add(new PictureData (pictureBox1, ImageType.NONE));
            data.Add(new double[1][]);
            pictureList.Add(new PictureData(pictureBox2, ImageType.NONE));
            data.Add(new double[1][]);

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            tbFile.Text = filename;
            ImageType imgType;
            var tmp = readXcr(filename, out imgType);
        
            currImageType = imgType;
            PictureBox picture;

            int pictureNum = int.Parse(cbArea.Text);

            if (pictureNum < data.Count)
            {
                picture = pictureList[pictureNum].Picture;
                pictureList[pictureNum].ImageType = imgType;
            }
            else
            {
                picture = new PictureBox();
                picture.Dock = DockStyle.Fill;
                picture.BorderStyle = BorderStyle.FixedSingle;
                picture.Name = pictureNum.ToString();
                pictureList.Add(new PictureData(picture, imgType));
                data.Add(tmp);

                if (pictureList.Count % 2 == 1)
                {
                    tableLayOut.RowCount += 1;
                    tableLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                }
                tableLayOut.Controls.Add(picture);
                cbArea.Items.Clear();
                for (int i = 0; i < pictureList.Count; i++)
                {
                    cbArea.Items.Add(i);
                }
            }
            data[pictureNum] = tmp;
          //  data[pictureNum] = RescaleImage(data[pictureNum]);
            DisplayImage(RescaleImage(data[pictureNum]), pictureList[pictureNum]);

        }

        private void DisplayImage(double[][] source, PictureData pictureData)
        {
            width = source.Length;
            height = source[0].Length;
            Bitmap bmp = new Bitmap(width,height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                   
                    int value = (int)source[i][j];
                    Color c = Color.FromArgb(255,
                     value,
                     value,
                     value);
                    bmp.SetPixel(i, j, c);

                }
            }
            pictureData.Picture.Image = Image.FromHbitmap(bmp.GetHbitmap());
            tbWidth.Text = "" + source.Length;
            tbHeight.Text = "" + source[0].Length;
        }

        private static double[][] readXcr(string filename, out ImageType imgType)
        {
            BinaryReader reader = null;

            String[] arr = filename.Split('.');
             width = 1024;
             height = 1024;
            double[][] result = new double[height][];
            imgType = ImageType.NONE;
            switch (arr.Last())
            {
                case "jpg":
                    {
                        imgType = ImageType.JPEG;
                        Bitmap bmp = new Bitmap(Image.FromFile(filename));
                        width = bmp.Width;
                        height = bmp.Height;
                        result = new double[width][];

                        for (int i = 0; i <width; i++)
                        {
                                       
                            result[i] = new double[height];
                            for (int j = 0; j < height; j++)
                            {
                                int value = bmp.GetPixel(i, j).ToArgb();

                                result[i][j] = value;
                            }
                        }
                        result = RescaleImage(result);

                        break;
                    };
                case "xcr":
                    {
                        ByteDirection direction;
                        imgType = ImageType.XCR;
                        reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
                        string[] splited = filename.Split('\\');
                        if (splited.Last().StartsWith("c"))
                        {
                            reader.BaseStream.Position = 0x800;     // The offset you are reading the data from
                            direction = ByteDirection.Inverted;
                        }
                        else {
                          string[]  sizes =  splited.Last().Substring(1,splited.Last().Length-5).Split('x');
                            height = int.Parse(sizes[0]);
                            width = int.Parse(sizes[1]);
                            result = new double[width][];
                            direction = ByteDirection.Straight;

                        }

                        for (int i = 0; i < width; i++)
                        {
                            result[i] = new double[height];
                            for (int j = 0; j < height; j++)
                            {
                                int value;
                                if (direction == ByteDirection.Inverted)
                                {
                                    value = (UInt16)((reader.ReadByte() << 8) + reader.ReadByte());
                                }
                                else {
                                    value = reader.ReadUInt16();
                                }

                                result[i][j] = value;
                            }
                        }
                        break;
                    }
                case "dat": {
                        Regex regex = new Regex(@"\d+x\d+");
                        Match match = regex.Match(filename);
                        if (match.Success)
                        {
                            String[] sizes = regex.Match(filename).Value.Split('x');

                            result = readHex2D(filename, int.Parse(sizes[1]), int.Parse(sizes[0]));
                            width = result.Length;
                            height = result[0].Length;
                        }


                        break;


                    }

                default:
                    {
                        break;
                    }

            }



           // RescaleImage(result);
            return  result;

        }

     public   static double[][] readHex2D(string filename, int width, int height)
        {
    
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;     // The offset you are reading the data from
            double[][] data = new double[width][];
            /*for (int i = 0; i < height; i++)
            {
                data[i] = new double[width];
            }*/

         
                for (int i = 0; i < width; i++)
            {
                data[i] = new double[height];
                for (int j = 0; j < height; j++)
                {
                    //data[i] = new double[height];

                    data[i][j] = reader.ReadSingle();          

            }

            }

            reader.Close();

            return data;

        }


        private static double[][] RescaleImage(double[][] source)
        {
            double[][] target = new double[source.Length][];
            double max = Int16.MinValue;
            double min = Int16.MaxValue;
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    double value = source[j][i];

                    if (value < min)
                    {
                        min = value;
                    }
                    if (value > max)
                    {
                        max = value;
                    }
                }
            }
            for (int i = 0; i < width; i++)
            {
                target[i] = new double[source[i].Length];
                for (int j = 0; j < height; j++)
                {
                    double value = source[i][j];
                    value = (int)(((double)(value - min) / (double)(max - min)) * 255);

                    target[i][j] = value;
                }
            }
            return target;
        }



        private double[] TransformFunY(double[] x)
        {
            Control.ControlCollection controls = panelTransformParams.Controls;
            double[] args = new double[controls.Count / 2];
            int i = controls.Count / 2 - 1;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }
            }
            //  double[] funValue = new double[x.Length];
            double[] funValue = transformY(x, args);
            return funValue;

        }


        private double[][] TransformFunWhole(double[][] x)
        {
            Control.ControlCollection controls = panelTransformParams.Controls;
            double[] args = new double[controls.Count / 2];
            int i = controls.Count / 2 - 1;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }
            }
            //  double[] funValue = new double[x.Length];
            double[][] funValue = transformWhole(x, args);

            width = funValue.Length;
            height = funValue[0].Length;

            return funValue;

        }


        private void addParameters(Panel panel, String[] parameters)
        {
            panel.Controls.Clear();
            Label label;
            TextBox textBox;
            String[] reversedParamenters = parameters.Reverse().ToArray();

            foreach (string item in reversedParamenters)
            {

                label = new Label();
                label.Text = item + ": ";
                textBox = new TextBox();

                panel.Controls.Add(textBox);
                panel.Controls.Add(label);

                /*label.Anchor = AnchorStyles.Top;
                textBox.Anchor = AnchorStyles.Top;*/
                label.Dock = DockStyle.Top;
                textBox.Dock = DockStyle.Top;

            }
            panel.AutoScroll = true;

        }


        private void btTransform_Click_1(object sender, EventArgs e)
        {
            int pictureNum = int.Parse(cbArea.Text);
            double[] y = null;
            for (int i = 0; i < data[pictureNum].Length; i++)
            {
                y = data[pictureNum][i];
                y = TransformFunY(y);
                data[pictureNum][i] = y;
            }

            data[pictureNum] = TransformFunWhole(data[pictureNum]);

            width = data[pictureNum].Length;
            height = data[pictureNum][0].Length;

            //data[pictureNum] = RescaleImage(data[pictureNum]);

            DisplayImage(RescaleImage(data[pictureNum]),pictureList[pictureNum]);
        }

        double[][] cached;

        private void cbTransform_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTransform.Text)
            {

                case "Fourier":
                    {           
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.FurieFunction(y));
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "ForwardFurie":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ForwardFurie(y).Select(x => x.Imaginary + x.Real).ToArray());
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }

                case "ReverseFurie":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ReverseFurie(y).Select(x => x.Imaginary + x.Real).ToArray());
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }

                case "CombFilter":
                    {

                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {

                            double[] res = Transformations.CombFilter(y, args[0], (int)args[1]);
                            return res;
                        });
                        addParameters(panelTransformParams, new string[] { "g", "M" });
                        break;
                    }
                case "Spikes(F(x),M,Sigma)":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.SpikesFunction(y, args[0], args[1]));
                        addParameters(panelTransformParams, new string[] { "M", "sigma" });
                        break;
                    }
                case "Shift(F(x),shift)":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ShiftFunction(y, args[0]));
                        addParameters(panelTransformParams, new string[] { "shift" });
                        break;
                    }
                case "RandomSpikes(x,spikes)":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.RandomSpikes(y, (int)args[0], args[1]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "spikes", "sigma" });
                        break;
                    }
                case "ConvolutionWithHeartBeat(x,f0,alpha,hLeft,hRight,hStep)":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ConvolutionWithHeartBeat(y, args[0], args[1], args[2], args[3], args[4], Double.Parse(tbStep.Text)));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "f0", "alpha", "hLeft", "hRight", "hStep" });
                        break;
                    }
                case "Zoom":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ZoomKnearest(y, args[0]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "k" });
                        break;
                    }
                case "ZoomInterpolation":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ZoomInterpilation(y, args[0]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "k" });
                        break;
                    }
                case "Negative":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.Nagative(y, 255));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "Gamma-correction":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.GammaCorrection(y,args[0],args[1]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "C", "gamma"});
                        break;
                    }
                case "Logarithmic":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.Logarithmic(y, args[0]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "C" });
                        break;
                    }
                case "Equalization":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Histogram.HistEquilization(y,256));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] {});
                        break;
                    }
                case "Reduction":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Histogram.HistReduction(y, 256));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "Recovery":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.recovery(y,tbAuxFile.Text));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "Recovery with noize":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.RecoveryWithNoize(y, tbAuxFile.Text, args[0]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] {"regularization" });
                        break;
                    }
                case "Rotate": {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.Rotate(y));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { });
                        break;

                    }
                case "CheckGrid": {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => { Transformations.CheckGrid(y[(int)args[0]]); return y; });
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "row"});
                        break;

                    }

                case "CheckGridWithCrossCorrelation":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => { Transformations.CheckGridWithCross(y, (int)args[0], (int)args[1]); return y; });
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "row1", "row2" });
                        break;

                    }
                case "RemoveGrid":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.RemoveGrid(y, args[0], args[1], args[2]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "freq1", "freq2", "m"});
                        break;

                    }
                case "ConturLPF":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ConturLPF(y,args[0],args[1],args[2]));

                        addParameters(panelTransformParams, new string[] { "threshold", "fcut", "m" });
                        break;

                    }
                case "Threshold":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ThresholdFun(y, args[0], args[1], 8));

                        addParameters(panelTransformParams, new string[] { "min_threshold", "max_threshold"});
                        break;

                    }
                case "LPF_Whole":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.LPF(y, args[0], args[1]));

                        addParameters(panelTransformParams, new string[] { "fcut", "m" });
                        break;

                    }
                case "HPF_Whole":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.HPF(y, args[0], args[1]));

                        addParameters(panelTransformParams, new string[] { "fcut", "m" });
                        break;

                    }
                case "Minus":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.Minus(y, data[(int)args[0]]));

                        addParameters(panelTransformParams, new string[] { "pictureNum"});
                        break;

                    }
                case "Gradient":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.Gradient(y));

                        addParameters(panelTransformParams, new string[] {});
                        break;

                    }
                case "Laplassian":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.Laplassian(y));

                        addParameters(panelTransformParams, new string[] { });
                        break;

                    }
                case "Erosion":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ApplyMaskErosion(y, (int)args[0], args[1]));

                        addParameters(panelTransformParams, new string[] {"mask width" , "threshold" });
                        break;

                    }
                case "Dilation":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ApplyMaskDilatation(y, (int)args[0], args[1]));

                        addParameters(panelTransformParams, new string[] { "mask width", "threshold" });
                        break;

                    }
                case "AddRandNoize":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ApplyRandNoize(y, args[0]));

                        addParameters(panelTransformParams, new string[] { "power"});
                        break;

                    }
                case "AddImpulseNoize":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.ApplyNoizeSaltAndPepper(y, args[0]));

                        addParameters(panelTransformParams, new string[] { "power" });
                        break;

                    }
                case "AvgFilter":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.AvgFilter(y, (int)args[0]));

                        addParameters(panelTransformParams, new string[] { "mask width" });
                        break;

                    }
                case "MedianFilter":
                    {
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformWhole = new Func<double[][], double[], double[][]>((y, args) => Transformations.MedianFilter(y, (int)args[0]));

                        addParameters(panelTransformParams, new string[] { "mask width" });
                        break;

                    }




                /* case "ConvolutionWithPlot":
                     {

                         transformX = new Func<Double[], Double[], Double[]>((y, args) => {


                             Series series = chart.Series.FindByName(args[0].ToString());
                             int m = series.Points.Select(item => item.YValues[0]).ToArray().Length;


                             return y.ToArray();
                         });
                         transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                             Series series = chart.Series.FindByName(args[0].ToString());
                             double[] h = series.Points.Select(item => item.YValues[0]).ToArray();
                             double[] res = Transformations.ConvolutionWithPlot(h, y);

                             return Transformations.Normalize(res);
                         });
                         addParameters(panelTransformParams, new string[] { "Plot number" });
                         break;
                     }*/
                default:
                    {
                        break;
                    }

            }
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            int pictureNum = int.Parse(cbArea.Text);
            data[pictureNum] = RescaleImage(data[pictureNum]);
            DisplayImage(data[pictureNum], pictureList[pictureNum]);

        }

        private void btHist_Click(object sender, EventArgs e)
        {
            int pictureNum = int.Parse(cbArea.Text);
            Histogram hist = new Histogram(data[pictureNum],256);
            
            hist.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btAddArea_Click(object sender, EventArgs e)
        {
            int pictureNum = int.Parse(cbArea.Text);
            PictureBox picture = new PictureBox();
            picture.Dock = DockStyle.Fill;
            picture.BorderStyle = BorderStyle.FixedSingle;
            picture.Name =  pictureNum.ToString();
            picture.SizeMode = PictureBoxSizeMode.Zoom;

            pictureList.Add(new PictureData(picture, ImageType.NONE));
            data.Add(new double[1][]);

            if (pictureList.Count % 2 == 1) {
                tableLayOut.RowCount += 1;
               tableLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            tableLayOut.Controls.Add(picture);

            cbArea.Items.Clear();
            for (int i = 0; i < pictureList.Count; i++)
            {
                cbArea.Items.Add(i);

            }



           // cbArea.Items.Add(chartAreaNum);
          //  validateSetings();
        }

        private void btDeleteArea_Click(object sender, EventArgs e)
        {
            int pictureNum =  int.Parse(cbArea.Text);
            try
            {
                tableLayOut.Controls.Remove(pictureList[pictureNum].Picture);
                pictureList.Remove(pictureList[pictureNum]);
                data.RemoveAt(pictureNum);
            }
            catch (Exception ex) {
                MessageBox.Show("Element does not exists");
                return;
            }


            if (pictureList.Count % 2 == 0) {
                tableLayOut.RowCount--;
            }

            cbArea.Items.Clear();
            for (int i = 0; i < pictureList.Count; i++)
            {
                cbArea.Items.Add(i);

            }


        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btWrite_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Image(*.jpg)|*.jpg|Image(*.jpeg)|*.jpeg|Image(*.bmp)|*.bmp";
            saveFileDialog1.Title = "Choose destination";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

         
            
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            int pictureNum = int.Parse(cbArea.Text);
        
            width = data[pictureNum].Length;
            height = data[pictureNum][0].Length;
            Bitmap bmp = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    int value = (int)data[pictureNum][i][j];
                    Color c = Color.FromArgb(255,
                     value,
                     value,
                     value);
                    bmp.SetPixel(i, j, c);

                }
            }
            Image.FromHbitmap(bmp.GetHbitmap()).Save(filename);
            

        }

        private void btStatistics_Click(object sender, EventArgs e)
        {
            if (tableLayOut.ColumnCount == 2)
            {
                tableLayOut.ColumnCount = 1;
            }
                
            else
                tableLayOut.ColumnCount = 2;
        }

        private void btAuxFile_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            tbAuxFile.Text = filename;

        }
    }
}
