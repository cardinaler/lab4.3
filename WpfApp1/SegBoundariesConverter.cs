using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using lab3;
namespace WpfApp1
{
    public class SegBoundariesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double[] seg = (double[])value;
            return seg[0].ToString() + " " + seg[1].ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {


                string str = ((string)value);
                int len = str.Length;
                double[] edges = new double[2];
                string num = "";
                int id1 = 0, id2 = 0;
                for (int i = 0; i < len; ++i)
                {
                    if (!('0' <= (str[i]) && (str[i]) <= '9') && str[i] != ' ')
                    {
                        throw new Exception("Некорректный ввод");
                    }
                }
                for (int i = 0; i < len; ++i)
                {
                    if (str[i] != ' ')
                    {
                        id1 = i;
                        break;
                    }
                }
                for (int i = id1; i < len; ++i)
                {
                    if (str[i] == ' ')
                    {
                        id2 = i;
                        break;
                    }
                }
                num = str.Substring(id1, id2 - id1 + 1);
                edges[0] = Int32.Parse(num);
                for (int i = id2; i < len; ++i)
                {
                    if (str[i] != ' ')
                    {
                        id2 = i;
                        break;
                    }
                }
                num = str.Substring(id2, len - id2);

                edges[1] = Int32.Parse(num);
                return edges;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                double[] k = { 0, 0 };
                return k;
            }




        }
    }
}
