using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Xml.Linq;
using WPF_TermProject_MemoryGame.Model;

namespace WPF_TermProject_MemoryGame
{
    /// <summary>
    /// Interaction logic for frmGameView.xaml
    /// </summary>
    public partial class frmGameView : Window
    {
        private string gridMode;
        private string playerMode;

        private TextBlock tbPlayer1Score;
        private TextBlock tbPlayer2Score;
        private Ellipse ellipse1;
        private Ellipse ellipse2;

        private List<Card> cards;
        private Card firstCard;
        private Card secondCard;

        private Player player1;
        private Player player2;

        public frmGameView(string gridMode, string playerMode)
        {
            InitializeComponent();

            cards = new List<Card>();
            player1 = new Player(1, false); //init player1, because player1 is a default player
            
            this.gridMode = gridMode;
            this.playerMode = playerMode;

            renderPlayer();
            renderCard();
        }

        private int getNumberOfPlayer(string playerMode)
        {
            if(playerMode == "1 Player")
            {
                return 1;
            }
            return 2; //playerMode == "2 Players"
        }

        private int getGridSize(string gridMode)
        {
            if(gridMode == "2x2")
            {
                return 4;
            }
            else if(gridMode == "4x4")
            {
                return 16;
            }
            else if(gridMode == "6x6")
            {
                return 36;
            }
            else if(gridMode == "8x8")
            {
                return 64;
            }
            else if(gridMode == "10x10")
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        private List<string> generateCard(int gridSize)
        {
            //list of all image sources
            List<string> cardNames = new List<string>()
            {
                "Images/card1.png","Images/card2.png","Images/card3.png","Images/card4.png","Images/card5.png"
                ,"Images/card6.png","Images/card7.png","Images/card8.png","Images/card9.png","Images/card10.png"
                ,"Images/card11.png","Images/card12.png","Images/card13.png","Images/card14.png","Images/card15.png"
                ,"Images/card16.png","Images/card17.png","Images/card18.png","Images/card19.png","Images/card20.png"
                ,"Images/card21.png","Images/card22.png","Images/card23.png","Images/card24.png","Images/card25.png"
                ,"Images/card26.png","Images/card27.png","Images/card28.png","Images/card29.png","Images/card30.png"
                ,"Images/card31.png","Images/card32.png","Images/card33.png","Images/card34.png","Images/card35.png"
                ,"Images/card36.png","Images/card37.png","Images/card38.png","Images/card39.png","Images/card40.png"
                ,"Images/card41.png","Images/card42.png","Images/card43.png","Images/card44.png","Images/card45.png"
                ,"Images/card46.png","Images/card47.png","Images/card48.png","Images/card49.png","Images/card50.png"
            };

            List<string> cards = new List<string>();

            Random random = new Random();
            cardNames = cardNames.OrderBy(c => random.Next()).ToList(); //shuffle

            for(int i=0; i<gridSize/2; i++) //loop until gridSize/2, because only needs half of grid size, because 1 source can be used for 2 times
            {
                if (!cards.Contains(cardNames[i])) //prevent the same card/image source
                {
                    cards.Add(cardNames[i]);
                }
                else
                {
                    i--;
                };
            }
            return cards;
        }

        private void renderPlayer()
        {
            int player = getNumberOfPlayer(playerMode);

            TextBlock tbPlayer1Name = new TextBlock
            {
                Text = "Player 1",
                Margin = new Thickness(10,0,0,0),
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            tbPlayer1Score = new TextBlock
            {
                Text = "Score: 0",
                Margin = new Thickness(10, 0, 0, 0),
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };
            ellipse1 = new Ellipse
            {
                Width = 13,
                Height = 13,               
                Fill = new SolidColorBrush(Colors.LightGreen),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 0.5,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetRow(tbPlayer1Name, 0);
            Grid.SetColumn(tbPlayer1Name, 0);
            gridPlayerMode.Children.Add(tbPlayer1Name);

            Grid.SetRow(tbPlayer1Score, 1);
            Grid.SetColumn(tbPlayer1Score, 0);
            gridPlayerMode.Children.Add(tbPlayer1Score);

            Grid.SetRow(ellipse1, 0);
            Grid.SetColumn(ellipse1, 1);
            gridPlayerMode.Children.Add(ellipse1);

            if (player == 2)
            {
                player2 = new Player(2, true);

                TextBlock tbPlayer2 = new TextBlock
                {
                    Text = "Player 2",
                    FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Center
                };
                tbPlayer2Score = new TextBlock
                {
                    Text = "Score: 0",
                    FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Center
                };
                ellipse2 = new Ellipse
                {
                    Width = 13,
                    Height = 13,
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 0.5,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.SetRow(tbPlayer2, 0);
                Grid.SetColumn(tbPlayer2, 2);
                gridPlayerMode.Children.Add(tbPlayer2);

                Grid.SetRow(tbPlayer2Score, 1);
                Grid.SetColumn(tbPlayer2Score, 2);
                gridPlayerMode.Children.Add(tbPlayer2Score);

                Grid.SetRow(ellipse2, 0);
                Grid.SetColumn(ellipse2, 3);
                gridPlayerMode.Children.Add(ellipse2);
            }
        }

        private void AddImagesToGrid(int gridSize) 
        {
            List<string> imageSources = generateCard(gridSize); //count = gridSize/2

            //loop until gridSize/2, because if loop until gridSize, the imageSources[i] will be out of range as imageSources length = gridSize/2
            for (int i=0; i<gridSize/2; i++) 
            { //so loop until gridSize/2, and in each loop will add 2 objects at a time, so that cards list still has the length of gridSize that's needed
                cards.Add(new Card { ImageFront = imageSources[i], ImageBack = "Images/imageBackBlue.jpg" });
                cards.Add(new Card { ImageFront = imageSources[i], ImageBack = "Images/imageBackBlue.jpg" });
            }

            Random random = new Random();
            cards = cards.OrderBy(c => random.Next()).ToList(); //shuffle (optional)

            gridCard.Children.Clear();

            int gridColumns = (int)Math.Sqrt(gridSize);
            gridCard.Columns = gridColumns;

            //Add images to the grid dynamically
            for (int i = 0; i < cards.Count; i++) 
            {
                Card card = cards[i];
                Image image;

                if (gridSize == 4)
                {
                    image = new Image
                    {
                        Width = 180,
                        Height = 180,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Source = new BitmapImage(new Uri(card.ImageBack, UriKind.Relative))
                    };
                }
                else if(gridSize == 16)
                {
                    image = new Image
                    {
                        Width = 100,
                        Height = 100,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Source = new BitmapImage(new Uri(card.ImageBack, UriKind.Relative))
                    };
                }
                else if(gridSize == 36)
                {
                    image = new Image
                    {
                        Width = 70,
                        Height=70,
                        VerticalAlignment =VerticalAlignment.Center,
                        HorizontalAlignment=HorizontalAlignment.Center,
                        Source = new BitmapImage(new Uri(card.ImageBack, UriKind.Relative))
                    };
                }
                else
                {
                    image = new Image
                    {
                        Width = 50,
                        Height = 50,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Source = new BitmapImage(new Uri(card.ImageBack, UriKind.Relative))
                    };
                }

                image.MouseDown += Image_MouseDown; //add method to event

                image.DataContext = card;

                gridCard.Children.Add(image);
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            Card card = image.DataContext as Card;
            FlipCard(card);
        }

        private void renderCard()
        {
            int gridSize = getGridSize(gridMode);

            AddImagesToGrid(gridSize);
        }

        private async void FlipCard(Card card)
        {
            int playerCount = getNumberOfPlayer(playerMode);

            if(playerCount == 1)
            {
                //Player currentPlayer = player1;

                //if card is already face up or matched, can't flip card anymore
                if (card.IsFaceUp == true || card.IsMatched == true) return;

                //if == false, means can flip
                card.IsFaceUp = true;
                UpdateUI();

                if (firstCard == null) // ==null means start off with first selection
                {
                    firstCard = card;
                    return; //return so that player can choose second card
                }

                //if firstCard != null, means firstCard is already selected
                secondCard = card;

                if (firstCard.ImageFront == secondCard.ImageFront)
                {
                    firstCard.IsMatched = true;
                    secondCard.IsMatched = true;

                    firstCard.IsFaceUp = true;
                    secondCard.IsFaceUp = true;

                    player1.Score++;
                    tbPlayer1Score.Text = $"Score: {player1.Score}";
                    playCorrectSound();
                }
                else
                {
                    firstCard.IsFaceUp = false;
                    secondCard.IsFaceUp = false;

                    firstCard.IsMatched = false;
                    secondCard.IsMatched = false;
                }

                firstCard = secondCard = null;
                await Task.Delay(500);
                UpdateUI();
                findWinner(playerCount);
            }
            else if(playerCount == 2)
            {
                //player takes turn to pick cards
                Player currentPlayer = player1.IsPicked == false ? player1 : player2;

                if (card.IsFaceUp == true || card.IsMatched == true) return;

                card.IsFaceUp = true;
                UpdateUI();

                if (firstCard == null)
                {
                    firstCard = card;
                    return;
                }

                secondCard = card;

                if (firstCard.ImageFront == secondCard.ImageFront)
                {
                    firstCard.IsMatched = true;
                    secondCard.IsMatched = true;

                    firstCard.IsFaceUp = true;
                    secondCard.IsFaceUp = true;

                    currentPlayer.Score++;
                    if(currentPlayer.Id == 1) 
                        tbPlayer1Score.Text = $"Score: {player1.Score}"; 
                    else 
                        tbPlayer2Score.Text = $"Score: {player2.Score}"; 

                    playCorrectSound();
                }
                else
                {
                    firstCard.IsFaceUp = false;
                    secondCard.IsFaceUp = false;

                    firstCard.IsMatched = false;
                    secondCard.IsMatched = false;
                }

                //do this so that if isPicked==true, it'll turn false, and false turns to true
                //ensure that only one player at a time
                player1.IsPicked = !player1.IsPicked; 
                player2.IsPicked = !player2.IsPicked;

                firstCard = secondCard = null;
                await Task.Delay(500);
                UpdateUI();
                findWinner(playerCount);

                //if player1 already pick (true) 2 cards, green circle will move to player2, which means it's player2's turn
                if (player1.IsPicked == true) 
                {
                    ellipse2.Fill = new SolidColorBrush(Colors.LightGreen);
                    ellipse1.Fill = new SolidColorBrush(Colors.White);
                }
                else
                {
                    ellipse1.Fill = new SolidColorBrush(Colors.LightGreen);
                    ellipse2.Fill = new SolidColorBrush(Colors.White);
                }
            }
        }

        private void UpdateUI()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Card card = cards[i];
                Image image = gridCard.Children[i] as Image;

                if (card.IsFaceUp == true)
                {
                  image.Source = new BitmapImage(new Uri(card.ImageFront, UriKind.Relative));
                }
                else
                {
                  image.Source = new BitmapImage(new Uri(card.ImageBack, UriKind.Relative));
                }

                image.IsEnabled = !card.IsMatched;
            }
        }

        private void findWinner(int playerCount)
        {
            if (playerCount == 1)
            {
                if (player1.Score == cards.Count / 2)
                {
                    playCongratsSound();
                    MessageBox.Show("You win!");

                    playAgainOrNot();
                }
            }
            else if (playerCount == 2) //16 player1: 5; player2: 3  
            {
                //check in case there's winner even before all cards are faced up
                if (player1.Score > cards.Count / 4) //score > 50%, win
                {
                    playCongratsSound();
                    MessageBox.Show("Player1 win!");

                    playAgainOrNot();
                    return;
                    
                }
                else if (player2.Score > cards.Count / 4)
                {
                    playCongratsSound();
                    MessageBox.Show("Player2 win!");

                    playAgainOrNot();
                    return;
                }

                bool allCardsFaceUp = true;
                foreach (Card c in cards)
                {
                    if (c.IsFaceUp == false)
                    {
                        allCardsFaceUp = false;
                        break;
                    }
                }

                //check after all cards are faced up
                if (allCardsFaceUp == true)
                {
                    if (player1.Score > player2.Score)
                    {
                        playCongratsSound();
                        MessageBox.Show("Player1 win!");

                        playAgainOrNot();
                        return;
                    }
                    else if (player2.Score > player1.Score)
                    {
                        playCongratsSound();
                        MessageBox.Show("Player2 win!");

                        playAgainOrNot();
                        return;
                    }
                    else if (player1.Score == player2.Score)
                    {
                        playCongratsSound();
                        MessageBox.Show("It's a draw");

                        playAgainOrNot();
                        return;
                    }
                }
            }          
        }

        private void playCorrectSound()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("correctSound.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void playCongratsSound()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("congratsSound.mp3", UriKind.Relative));
            mediaPlayer.Volume = 0.3;
            mediaPlayer.Play();
        }

        private void playAgainOrNot()
        {
            frmConfirmation frmConfirmation = new frmConfirmation(this, gridMode, playerMode);
            frmConfirmation.ShowDialog();
        }
    }
}