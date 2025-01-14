using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_TermProject_MemoryGame
{
    /// <summary>
    /// Interaction logic for frmLoad.xaml
    /// </summary>
    public partial class frmLoad : Window
    {
        private DispatcherTimer timer;
        private int progress = 0;

        public frmLoad()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };

            timer.Tick += (sender, e) =>
            {
                progress++;

                if (progress > 100)
                {
                    timer.Stop();
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.ShowDialog();
                }
                progressBar.Value = progress;
                loadingText.Text = $"Loading {progress}%";
            };

            timer.Start();
        }
    }
}
