using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using GameplayKit;
//This code is based on code from Xamarin sample project "four in a row" at https://developer.xamarin.com/samples/monotouch/ios9/FourInARow/
//written/modified by Daniel Reilander
namespace StudyBugApp
{
    public enum Cube
    {
        None = 0,
        Red,
        Black
    }

    public class Player : NSObject, IGKGameModelPlayer
    {

        public const int CountToWin = 999;
        //number of neighboring cubes necessary to cause "elimination" - not implemented
        public const int CountToEliminate = 2;

        public static Player CurrentPlayer
        {
            get
            {
                return PlayerForCube(Cube.Black);
            }
        }
        //not currently used
        public static Player BlackPlayer
        {
            get
            {
                return PlayerForCube(Cube.Black);
            }
        }
        //this is where the profile for the current player would be - instead of setting cube to be black, colour would be randomized.  
        public static Player thisPlayer
        {
            get
            {
                return PlayerForCube(Cube.Black);
            }
        }
      
        //getters and setters for cube objects
        public Cube Cube { get; private set; }
        //setting the possible colors of cubes
        public UIColor Color
        {
            get
            {
                switch (Cube)
                {
                    case Cube.Red:
                        return UIColor.Red;
                    case Cube.Black:
                        return UIColor.Black;
                    default:
                        return UIColor.Clear;
                }
            }
        }


       

        static Player[] allPlayers;
        public static Player[] AllPlayers
        {
            get
            {
                allPlayers = allPlayers ?? new[] {
                    new Player (Cube.Red),
                    new Player (Cube.Black)
                };
                return allPlayers;
            }
        }

        public Player(Cube cube)
        {
            Cube = cube;
        }

        public static Player PlayerForCube(Cube cube)
        {
            return (cube == Cube.None) ? null : AllPlayers[(int)cube - 1];
        }
    }
}