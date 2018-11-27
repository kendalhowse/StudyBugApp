using System;
using System.Linq;

using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using GameplayKit;
using UIKit;
//Code based on sample project "four in a row from Xamarin's site at: https://developer.xamarin.com/samples/monotouch/ios9/FourInARow/
//Written/modified by Daniel Reilander
namespace StudyBugApp
{
    public partial class StudyCubesViewController2 : UIViewController
    {
        //instantiating CAShapeLayer object
        CAShapeLayer[][] cubeLayers;

        Board board;
        UIBezierPath cubePath;

        //swift constructer for serialized studycubes controller
        [Export("initWithCoder:")]
        public StudyCubesViewController2(NSCoder coder) : base(coder)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            //generating the columns based on board width
            var columns = new CAShapeLayer[Board.Width][];
            for (int column = 0; column < Board.Width; column++)
                columns[column] = new CAShapeLayer[Board.Height];

            cubeLayers = columns;
            ResetBoard();
        }

        public override void ViewDidLayoutSubviews()
        {
            var button = columnButtons[0];
            //size of the object (uses the button frame to determine size)
            nfloat lenght = NMath.Min(button.Frame.Width - 10, button.Frame.Height / 6 - 10);

            //creating the object
            var rect = new CGRect(0f, 0f, lenght, lenght);

            //Creating the vector/object plus the object path
            cubePath = UIBezierPath.FromRect(rect);


            for (int i = 0; i < cubeLayers.Length; i++)
            {
                for (int j = 0; j < cubeLayers[i].Length; j++)
                {
                    CAShapeLayer cube = cubeLayers[i][j];

                    if (cube == null)
                        continue;

                    cube.Path = cubePath.CGPath;
                    cube.Frame = cubePath.Bounds;
                    cube.Position = PositionForCubeLayerAtColumnRow(i, j);
                }
            }
        }
        //Event handler for pressing on the column buttons - adds a cube in a column when you tap the screen
        partial void MakeMove(UIButton sender)
        {
            var column = (int)sender.Tag;
            if (!board.CanMoveInColumn(column))
                return;

            board.AddCubeInColumn(board.CurrentPlayer.Cube, column);
            UpdateButton(sender);
            UpdateGame();
        }

        void UpdateButton(UIControl button)
        {
            var column = (int)button.Tag;
            button.Enabled = board.CanMoveInColumn(column);
            int row = Board.Height;
            var cube = Cube.None;

            while (cube == Cube.None && row > 0)
                cube = board.CubeInColumnRow(column, --row);

            if (cube != Cube.None)
                AddCubeLayerAtColumnRowColor(column, row, Player.PlayerForCube(cube).Color);
        }

        CGPoint PositionForCubeLayerAtColumnRow(int column, int row)
        {
            UIButton columnButton = columnButtons[column];
            nfloat xOffset = columnButton.Frame.GetMidX();
            nfloat yStride = cubePath.Bounds.Height + 10;
            nfloat yOffset = columnButton.Frame.GetMaxY() - yStride / 2;
            return new CGPoint(xOffset, yOffset - yStride * row);
        }

        void AddCubeLayerAtColumnRowColor(int column, int row, UIColor color)
        {
            int count = cubeLayers[column].Count(c => c != null);
            if (count < row + 1)
            {
                var newCube = (CAShapeLayer)CAShapeLayer.Create();
                newCube.Path = cubePath.CGPath;
                newCube.Frame = cubePath.Bounds;
                newCube.FillColor = color.CGColor;
                newCube.Position = PositionForCubeLayerAtColumnRow(column, row);

                View.Layer.AddSublayer(newCube);
                CABasicAnimation animation = CABasicAnimation.FromKeyPath("position.y");
                animation.From = NSNumber.FromNFloat(newCube.Frame.Height);
                animation.To = NSNumber.FromNFloat(newCube.Position.Y);
                animation.Duration = 0.5;

                animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseIn);
                newCube.AddAnimation(animation, null);
                cubeLayers[column][row] = newCube;
            }
        }
        //method to reset the game board on game launch - as well as pressing "play again" after loss
        void ResetBoard()
        {
            board = new Board();
            foreach (UIButton button in columnButtons)
                UpdateButton(button);

            UpdateUI();
            

            foreach (var innerArray in cubeLayers)
            {
                for (int j = 0; j < innerArray.Length; j++)
                    innerArray[j]?.RemoveFromSuperLayer();
                Array.Clear(innerArray, 0, innerArray.Length);
            }
        }
        //updates the game state and checks for win/loss conditions
        void UpdateGame()
        {
            string gameOverTitle = string.Empty;

            if (board.IsWin(board.CurrentPlayer))
                gameOverTitle = string.Format("{0} Wins!", "Danny");
            else if (board.IsFull)
                gameOverTitle = "You Lose!";

            if (!string.IsNullOrEmpty(gameOverTitle))
            {
                //Generates the alert popup with "play again" button
                var alert = UIAlertController.Create(gameOverTitle, null, UIAlertControllerStyle.Alert);
                var alertAction = UIAlertAction.Create("Play Again", UIAlertActionStyle.Default, _ => ResetBoard());
                alert.AddAction(alertAction);
                PresentViewController(alert, true, null);
                return;
            }

            UpdateUI();
        }

        //Updates the title bar of the UI specifically at the moment, could have been used to hold a score for user but not implemented
        void UpdateUI()
        {
            //setting the title of the game page
            NavigationItem.Title = string.Format("Study Cubes");
            // Setting the title background color to blue
            NavigationController.NavigationBar.BackgroundColor = UIColor.Blue;

        }


    }
}