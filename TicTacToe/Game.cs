namespace TicTacToe
{
    public class Game
    {
        public int Turn = 1; //Player 1 && Player 2
        private string e1 = " ", e2 = " ", e3 = " ", e4 = " ", e5 = " ", e6 = " ", e7 = " ", e8 = " ", e9 = " ";
        public int Moves;
        public Input input { get; set; }
        public Section section { get; set; }
        public enum Input { X, O }
        public enum Section { BottomLeft, BottomMiddle, BottomRight, MiddleLeft, MiddleMiddle, MiddleRight, TopLeft, TopMiddle, TopRight }

        public void PlayGame()
        {
            while (!GameStatus()) //result of tie & winner should end game
            {
                Console.Title = "Tic-Tac-Toe Console App";
                DisplayBoard();
                if (Moves == 9) { break; }
                Console.WriteLine("Where would you like to place your input? Use the number pad to guide your choice.");
                Console.Write($"Player {Turn}: ");
                int input = Convert.ToInt16(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        PlaceMark(Turn, Section.BottomLeft);
                        break;
                    case 2:
                        PlaceMark(Turn, Section.BottomMiddle);
                        break;
                    case 3:
                        PlaceMark(Turn, Section.BottomRight);
                        break;
                    case 4:
                        PlaceMark(Turn, Section.MiddleLeft);
                        break;
                    case 5:
                        PlaceMark(Turn, Section.MiddleMiddle);
                        break;
                    case 6:
                        PlaceMark(Turn, Section.MiddleRight);
                        break;
                    case 7:
                        PlaceMark(Turn, Section.TopLeft);
                        break;
                    case 8:
                        PlaceMark(Turn, Section.TopMiddle);
                        break;
                    case 9:
                        PlaceMark(Turn, Section.TopRight);
                        break;
                }
                if (!GameStatus()) { TurnChanger(); }
            }
            DisplayBoard();
            if (GameStatus()) { Console.Write($"Congratulations! Player {Turn} won! "); }
            if (Moves == 9) { Console.WriteLine("It's a tie!"); }
        }
        public void PlaceMark(int turn, Section section)
        {
            switch (turn, section)
            {
                case (1, Section.BottomLeft):
                    if (e1 == " ") { e1 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.BottomMiddle):
                    if (e2 == " ") { e2 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.BottomRight):
                    if (e3 == " ") { e3 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.MiddleLeft):
                    if (e4 == " ") { e4 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.MiddleMiddle):
                    if (e5 == " ") { e5 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.MiddleRight):
                    if (e6 == " ") { e6 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.TopLeft):
                    if (e7 == " ") { e7 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.TopMiddle):
                    if (e8 == " ") { e8 = Enum.GetName(Input.X); }
                    break;
                case (1, Section.TopRight):
                    if (e9 == " ") { e9 = Enum.GetName(Input.X); }
                    break;
                case (2, Section.BottomLeft):
                    if (e1 == " ") { e1 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.BottomMiddle):
                    if (e2 == " ") { e2 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.BottomRight):
                    if (e3 == " ") { e3 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.MiddleLeft):
                    if (e4 == " ") { e4 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.MiddleMiddle):
                    if (e5 == " ") { e5 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.MiddleRight):
                    if (e6 == " ") { e6 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.TopLeft):
                    if (e7 == " ") { e7 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.TopMiddle):
                    if (e8 == " ") { e8 = Enum.GetName(Input.O); }
                    break;
                case (2, Section.TopRight):
                    if (e9 == " ") { e9 = Enum.GetName(Input.O); }
                    break;
            }
            Moves += 1;
        }
        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine($" {e7} | {e8} | {e9}  "); //top row
            Console.WriteLine($"---+---+---"); //top line
            Console.WriteLine($" {e4} | {e5} | {e6}  "); //middle row
            Console.WriteLine($"---+---+---"); //top line //middle line
            Console.WriteLine($" {e1} | {e2} | {e3}   "); //bottom row
        }

        public int TurnChanger()
        {
            return Turn == 1 ? Turn += 1 : Turn -= 1;
        }

        public bool GameStatus()
        {
            (string, string, string) xWinner = ("X", "X", "X");
            (string, string, string) oWinner = ("O", "O", "O");

            (string, string, string) BottomRow = (e1, e2, e3);
            (string, string, string) MiddleRow = (e4, e5, e6);
            (string, string, string) TopRow = (e7, e8, e9);
            (string, string, string) FirstColumn = (e7, e4, e1);
            (string, string, string) SecondColumn = (e8, e5, e2);
            (string, string, string) ThirdColumn = (e9, e6, e3);
            (string, string, string) LeftDiagonal = (e7, e5, e3);
            (string, string, string) RightDiagonal = (e1, e5, e9);

            object[] winCon =
            {
                BottomRow,
                MiddleRow,
                TopRow,
                FirstColumn,
                SecondColumn,
                ThirdColumn,
                LeftDiagonal,
                RightDiagonal
            };
            if (winCon.Contains(xWinner) || winCon.Contains(oWinner)) return true; return false;
        }
    }
}
