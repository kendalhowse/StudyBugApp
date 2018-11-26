using System;

using Foundation;
using GameplayKit;

namespace StudyBugApp
//This code is based on code from Xamarin sample project "four in a row" at https://developer.xamarin.com/samples/monotouch/ios9/FourInARow/
//written/modified by Daniel Reilander
//movement class for cube game
{
    public class Move : NSObject, IGKGameModelUpdate
    {

        public nint Value { get; set; }
    //get/set column number
        public int Column { get; private set; }

        Move(int column)
        {
            Column = column;
        }
    //move method takes column parameter
        public static Move MoveInColumn(int column)
        {
            return new Move(column);
        }
    }
}