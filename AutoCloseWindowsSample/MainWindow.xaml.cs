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

namespace AutoCloseWindowsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutoCloseWindow window = new AutoCloseWindow(10)
                {
                    Background = Brushes.AliceBlue,
                    Title = "Additional Window",
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Width = 500,
                    Height = 400,
                };
                window.Show();

                window.Closed += (_sender, args) => window.DisposeTimer();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class AutoCloseWindow : Window
    {
        public System.Timers.Timer timer;

        public AutoCloseWindow(int seconds)
        {
            timer = new System.Timers.Timer(seconds * 1000);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    this.Close();
                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            //base.OnActivated(e);

            try
            {
                timer.Stop();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected override void OnDeactivated(EventArgs e)
        {
            //base.OnDeactivated(e);

            try
            {
                timer.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DisposeTimer()
        {
            try
            {
                timer.Close();
                timer.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}