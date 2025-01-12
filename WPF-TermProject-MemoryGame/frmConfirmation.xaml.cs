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

namespace WPF_TermProject_MemoryGame
{
    /// <summary>
    /// Interaction logic for frmConfirmation.xaml
    /// </summary>
    public partial class frmConfirmation : Window
    {
        private frmGameView frmGameView;
        private string gridMode;
        private string playerMode;

        public frmConfirmation(frmGameView frmGameView, string gridMode, string playerMode)
        {
            InitializeComponent();

            this.frmGameView = frmGameView;
            this.gridMode = gridMode;
            this.playerMode = playerMode;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            frmGameView.Close();
            this.Close();

            frmGameView newFrmGameView = new frmGameView(gridMode, playerMode);
            newFrmGameView.ShowDialog();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            frmGameView.Close();
            this.Close();

            int gridSize;
            if (gridMode == "2x2")
            {
                gridSize = 4;
            }
            else if (gridMode == "4x4")
            {
                gridSize = 16;
            }
            else if (gridMode == "6x6")
            {
                gridSize = 36;
            }
            else if (gridMode == "8x8")
            {
                gridSize = 64;
            }
            else if (gridMode == "10x10")
            {
                gridSize = 100;
            }
            else
            {
                gridSize = 0;
            }

            int continueGridSize = (int)Math.Pow((Math.Sqrt(gridSize) + 2), 2);

            if(continueGridSize == 16)
            {
                gridMode = "4x4";
            }
            else if(continueGridSize == 36)
            {
                gridMode = "6x6";
            }
            else if(continueGridSize == 64)
            {
                gridMode = "8x8";
            }
            else if(continueGridSize == 100)
            {
                gridMode = "10x10";
            }
            else
            {
                gridMode = "";
            }

            frmGameView newFrmGameView = new frmGameView(gridMode, playerMode);
            newFrmGameView.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            frmGameView.Close();
            this.Close();
        }
    }
}