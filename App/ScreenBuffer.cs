using System;

namespace Oregon
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public static class ScreenBuffer
    {

        private static int width = Console.WindowWidth;
        private static int height = Console.WindowHeight;
        //initiate important variables
        public static char[,] screenBufferArray = new char[width, height]; //main buffer array
        public static string screenBuffer; //buffer as string (used when drawing)
        public static Char[] arr; //temporary array for drawing string
        public static int i = 0; //keeps track of the place in the array to draw to
        public static Position CurrentCursorPosition = new Position();

        //this method takes a string, and a pair of coordinates and writes it to the buffer
        public static void Draw(string text, int x, int y)
        {
            CurrentCursorPosition = new Position(x, y);
            //split text into array
            arr = text.ToCharArray(0, text.Length);
            //iterate through the array, adding values to buffer 
            i = 0;
            foreach (char c in arr)
            {
               // if (c != '\r') {
                    screenBufferArray[x + i, y] = c;
                //}
                    i++;

            }
               
        }

        public static void DrawScreen()
        {
            
            screenBuffer = "";
            //iterate through buffer, adding each value to screenBuffer
            for (int iy = 0; iy < height - 1; iy++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    screenBuffer += screenBufferArray[ix, iy];
                }
            }
            //set cursor position to top left and draw the string
            Console.SetCursorPosition(0, 0);
            
            Console.Write(screenBuffer);
            screenBufferArray = new char[width, height];
            //note that the screen is NOT cleared at any point as this will simply overwrite the existing values on screen. Clearing will cause flickering again.
        }

    }


}

