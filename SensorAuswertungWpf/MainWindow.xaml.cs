using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SensorAuswertungWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Value> values = [];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSensorObjErzeugen_Click(object sender, RoutedEventArgs e)
        {
            values.Clear();
            int nWerte = Convert.ToInt32(txtAnzahlWerte.Text);
            int Seed = Convert.ToInt32(txtSeed.Text);
            int maxSensor = Convert.ToInt32(txtSeed.Text);
            int maxWert = Convert.ToInt32(txtWertMax.Text);
            Random random = new(Seed);
            for (int i = 0; i < nWerte; i++)
            {
                Value v = new(i % maxSensor, random.Next(maxWert));
                values.Add(v);
            }
            GridAktualisieren();
        }

        private void btnStatBerechnen_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            int min = Convert.ToInt32(txtWertMax.Text);
            int max = 0;
            foreach (Value v in values)
            {
                sum += v.Wert;
                if( max < v.Wert)
                {
                    max = v.Wert;
                }
                if( min > v.Wert)
                {
                    min = v.Wert;
                }
            }
            Statistik statistik = new(values.Count, min, max, sum/values.Count);
            lbStatistik.Items.Add(statistik);
            GridAktualisieren();
        }

        private void btnBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        public void GridAktualisieren()
        {
            dataSensorID.ItemsSource = null;
            dataSensorID.ItemsSource = values;
        }
    }
    public class Value
    {
        public int SensorId { get; set; }
        public int Wert { get; set; }
        public DateTime Timestamp { get; set; }

        public Value()
        {
        }

        public Value(int sensorId, int wert)
        {
            SensorId = sensorId;
            Wert = wert;
            Timestamp = DateTime.Now;
        }

    }
    public class Statistik
    {
        public DateTime Datum;
        public int Anzahl;
        public double Minimum;
        public double Maximum;
        public double Mittelwert;

        public Statistik(int anzahl, double minimum, double maximum, double mittelwert)
        {
            Anzahl = anzahl;
            Minimum = minimum;
            Maximum = maximum;
            Mittelwert = mittelwert;
            Datum = DateTime.Now;
        }
        public override string ToString()
        {
            string str = "";
            str += "Anzahl: " + Anzahl;
            str += "\nMinimum: " + Minimum;
            str += "\nMaximum: " + Maximum;
            str += "\nMittelwert: " + Mittelwert;
            str += "\nDatum: " + Datum;
            return str;
        }
    }
}