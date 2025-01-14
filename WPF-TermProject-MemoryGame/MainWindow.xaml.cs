using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TermProject_MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string playerMode = "1 Player";
        private string gridMode = "2x2";
        
        private Border lastPlayerModeClick = null;
        private Border lastGridModeClick = null;

        private bool isPlayerModeClicked = true;
        private bool isGridModeClicked = true;

        public MainWindow()
        {
            InitializeComponent();

            Border playerBorder = btn1Player.Parent as Border;
            playerBorder.Background = new SolidColorBrush(Color.FromRgb(90, 200, 250));
            playerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(248, 242, 226));
            lastPlayerModeClick = playerBorder;

            Border gridBorder = btn2x2.Parent as Border;
            gridBorder.Background = new SolidColorBrush(Color.FromRgb(90, 200, 250));
            gridBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(248, 242, 226));
            lastGridModeClick = gridBorder;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (isPlayerModeClicked == false || isGridModeClicked == false)
            {
                return;
            }

            frmGameView frmGameView = new frmGameView(gridMode, playerMode);
            frmGameView.ShowDialog();

            //reset
            playerMode = "1 Player";
            gridMode = "2x2";

            Border playerBorder = btn1Player.Parent as Border;
            switchPlayerModeColor(playerBorder);

            Border gridBorder = btn2x2.Parent as Border;
            switchGridModeColor(gridBorder);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn1Player_Click(object sender, RoutedEventArgs e)
        {
            isPlayerModeClicked = true;
            playerMode = "1 Player";
            Button button = sender as Button;

            if(button != null && button.Parent is Border clickedBorder)
            {
                switchPlayerModeColor(clickedBorder);
            }
        }

        private void btn2Players_Click(object sender, RoutedEventArgs e)
        {
            isPlayerModeClicked = true;
            playerMode = "2 Players";
            Button button = sender as Button;

            if (button != null && button.Parent is Border clickedBorder)
            {
                switchPlayerModeColor(clickedBorder);
            }
        }

        private void btn2x2_Click(object sender, RoutedEventArgs e)
        {
            eachGridButtonClick(sender, "2x2");
        }

        private void btn4x4_Click(object sender, RoutedEventArgs e)
        {
            eachGridButtonClick(sender, "4x4");
        }

        private void btn6x6_Click(object sender, RoutedEventArgs e)
        {
            eachGridButtonClick(sender, "6x6");
        }

        private void btn8x8_Click(object sender, RoutedEventArgs e)
        {
            eachGridButtonClick(sender, "8x8");
        }

        private void btn10x10_Click(object sender, RoutedEventArgs e)
        {
            eachGridButtonClick(sender, "10x10");
        }

        private void switchPlayerModeColor(Border clickedBorder)
        {
            if (lastPlayerModeClick != null && lastPlayerModeClick != clickedBorder)
            {
                lastPlayerModeClick.Background = new SolidColorBrush(Colors.Transparent);
                lastPlayerModeClick.BorderBrush = new SolidColorBrush(Color.FromRgb(36, 73, 127));

                clickedBorder.Background = new SolidColorBrush(Color.FromRgb(90, 200, 250));
                clickedBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(248, 242, 226));

                lastPlayerModeClick = clickedBorder;
            }
        }

        private void eachGridButtonClick(object sender, string grid)
        {
            isGridModeClicked = true;
            gridMode = grid;
            Button button = sender as Button;

            if (button != null && button.Parent is Border clickedBorder)
            {
                switchGridModeColor(clickedBorder);
            }
        }

        private void switchGridModeColor(Border clickedBorder)
        {
            if (lastGridModeClick != null && lastGridModeClick != clickedBorder)
            {
                lastGridModeClick.Background = new SolidColorBrush(Colors.Transparent);
                lastGridModeClick.BorderBrush = new SolidColorBrush(Color.FromRgb(36, 73, 127));

                clickedBorder.Background = new SolidColorBrush(Color.FromRgb(90, 200, 250));
                clickedBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(248, 242, 226));

                lastGridModeClick = clickedBorder;
            }
        }
    }
}