using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using GameplayKit;
/// <summary>
//This code is based on code from Xamarin sample project "four in a row" at https://developer.xamarin.com/samples/monotouch/ios9/FourInARow/
//written/modified by Daniel Reilander
/// </summary>
namespace StudyBugApp
{
    //This is the class for the the gameplay environment
    public class Board : NSObject, IGKGameModel
    {
        //Number of Columns
        public const int Width = 7;
        //Number of cubes that can be stacked (height limit)
        public const int Height = 11;

        public Cube[] Cells { get; private set; }

        public Player CurrentPlayer { get; set; }

        //determines if game is full by looping through columns and seeing if they're full
        public bool IsFull
        {
            get
            {
                for (int column = 0; column < Width; column++)
                {
                    if (CanMoveInColumn(column))
                        return false;
                }

                return true;
            }
        }

        //sets current player - could be adapted to multiple players with database functionality, but doesn't work
        public Board()
        {
            CurrentPlayer = Player.thisPlayer;
            Cells = new Cube[Width * Height];
        }
        //method to test if a cube exists at a given location in the grid
        public Cube CubeInColumnRow(int column, int row)
        {
            var index = row + column * Height;
            return (index >= Cells.Length) ? Cube.None : Cells[index];
        }
        //test to see if a cube can move into a column - used to test the "isfull" boolean
        public bool CanMoveInColumn(int column)
        {
            return NextEmptySlotInColumn(column) >= 0;
        }
        //method to set where the next cube will be added in a column
        public void AddCubeInColumn(Cube cube, int column)
        {
            int row = NextEmptySlotInColumn(column);
            if (row >= 0)
                SetCubeInColumnRow(cube, column, row);
        }
        //returns all players to the game-model, right now serves no purpose other than to return the only player
        public IGKGameModelPlayer[] GetPlayers()
        {
            return Player.AllPlayers;
        }
        //current player is always the same, but could change with database implementation for different players/settings
        public IGKGameModelPlayer GetActivePlayer()
        {
            return CurrentPlayer;
        }
        //using objective c to return the game object
        public NSObject Copy(NSZone zone)
        {
            var board = new Board();
            board.SetGameModel(this);
            return board;
        }
        //using swift to set the IGKGameModel for current player - again, multiple player functionality not yet implemented
        public void SetGameModel(IGKGameModel gameModel)
        {
            var board = (Board)gameModel;
            UpdateCubesFromBoard(board);
            CurrentPlayer = board.CurrentPlayer;
        }
        //IGKGameModelUpdate - saves an array of all of the moves made to record the game/board state
        public IGKGameModelUpdate[] GetGameModelUpdates(IGKGameModelPlayer player)
        {
            var moves = new List<Move>();

            for (int column = 0; column < Width; column++)
            {
                if (CanMoveInColumn(column))
                    moves.Add(Move.MoveInColumn(column));
            }

            return moves.ToArray();
        }
        //applies game update, responsible for actually adding cubes based on commands passed to it from update method
        public void ApplyGameModelUpdate(IGKGameModelUpdate gameModelUpdate)
        {
            AddCubeInColumn(CurrentPlayer.Cube, ((Move)gameModelUpdate).Column);
        }

        //boolean to determine if the player can win
        public bool IsWin(Player player)
        {
            return false;
        }

        //this detects the neighboring cubes for a player - b


        void UpdateCubesFromBoard(Board otherBoard)
        {
            Array.Copy(otherBoard.Cells, Cells, Cells.Length);
        }
        //inserts cubes into desginated space on grid
        void SetCubeInColumnRow(Cube cube, int column, int row)
        {
            Cells[row + column * Height] = cube;
        }
        //finds the next empty spot in column
        int NextEmptySlotInColumn(int column)
        {
            for (int row = 0; row < Height; row++)
            {
                if (CubeInColumnRow(column, row) == Cube.None)
                    return row;
            }

            return -1;
        }
    }
}