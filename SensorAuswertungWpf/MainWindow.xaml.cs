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
        public List<Value> values = new List<Value>();
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
            Random random = new Random(Seed);
            for(int i = 0; i < nWerte; i++)
            {
                Value v = new Value((i%maxSensor).ToString(),random.Next(maxWert).ToString());
                values.Add(v);
            }
            GridAktualisieren();
        }

        private void btnStatBerechnen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBeenden_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataSensorID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void GridAktualisieren()
        {
            dataSensorID.ItemsSource = null;
            dataSensorID.ItemsSource = values;
        }
    }
    public class Value
    {
        public string SensorId { get; set; }
        public string Wert { get; set; }
        public string Timestamp { get; set; }

        public Value()
        {
        }

        public Value(string sensorId, string wert)
        {
            SensorId = sensorId;
            Wert = wert;
            Timestamp = DateTime.Now.ToString();
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
        }
    }
}