using MVVMPairs.Models;
using MVVMPairs.Services;
using MVVMPairs.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.ViewModels
{
    class Board : INotifyPropertyChanged
    {
        private const string freeTile = "/MVVMPairs;component/Resources/purpleBkgr.png";
        private const string whitePiece = "/MVVMPairs;component/Resources/whitePiece.png";
        private const string purplePiece = "/MVVMPairs;component/Resources/purplePiece.png";
        private const string validPurpleTile = "/MVVMPairs;component/Resources/purplePossibility.png";
        private const string validWhiteTile = "/MVVMPairs;component/Resources/whitePossibility.png";

        private const string purpleKing = "/MVVMPairs;component/Resources/purpleKing.png";
        private const string whiteKing = "/MVVMPairs;component/Resources/whiteKing.png";


        private const int NORTH = -1;
        private const int SOUTH = 1;
        private const int EAST = +1;
        private const int WEST = -1;

        private static int purpleCounter = 0;
        private static int whiteCounter = 0;

        private static Player purplePlayer;
        private static Player whitePlayer;

        private static Color playerColor;

        private static string purplePlayerData;
        public string PurplePlayerData
        {
            get => purplePlayerData;
            set
            {
                purplePlayerData = value;
                NotifyPropertyChanged("PurplePlayerData");
            }
        }

        private static string whitePlayerData;
        public string WhitePlayerData
        {
            get => whitePlayerData;
            set
            {
                whitePlayerData = value;
                NotifyPropertyChanged("WhitePlayerData");
            }
        }

        private string gameStatus;
        public string GameStatus
        {
            get => gameStatus;
            set
            {
                gameStatus = value;
                NotifyPropertyChanged("GameStatus");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void UpdateTurn()
        {
            if (playerColor == Color.PURPLE)
            {
                playerColor = Color.WHITE;
            }
            else
                playerColor = Color.PURPLE;
        }

        public static Board instance;

        //retains the current valid cell and the possible piece to be taken
        private static List<KeyValuePair<Cell, Cell>> validPurpleMoves = new List<KeyValuePair<Cell, Cell>>();
        private static List<KeyValuePair<Cell, Cell>> validWhiteMoves = new List<KeyValuePair<Cell, Cell>>();

        private static List<KeyValuePair<Cell, List<Cell>>> validPurpleMultiple = new List<KeyValuePair<Cell, List<Cell>>>();
        private static List<KeyValuePair<Cell, List<Cell>>> validWhiteMultiple = new List<KeyValuePair<Cell, List<Cell>>>();
        public static ObservableCollection<ObservableCollection<Cell>> GameBoard { get; set; }

        public Board()
        {
            if (GameWindow.LoadGame)
            {
                LoadData();
            }
            else
            {
                GameBoard = new ObservableCollection<ObservableCollection<Cell>>(Helper.InitGameBoard());

            }

            instance = this;

            purplePlayer = new Player(Color.PURPLE, 0);
            whitePlayer = new Player(Color.WHITE, 0);

            purplePlayerData = purplePlayer.ToString();
            whitePlayerData = whitePlayer.ToString();
        }

        public static bool isValidMove(Cell cell)
        {
            return cell.Image.Equals(validWhiteTile) || cell.Image.Equals(validPurpleTile);
        }

        public static bool IsPiece(Cell cell)
        {
            return cell.Image.Equals(whitePiece) || cell.Image.Equals(purplePiece);
        }

        public static bool showValidMoves(Cell cell)
        {

            switch (cell.Image)
            {
                case whitePiece:
                    {
                        showWhiteComplexMoves(cell);
                        showWhiteSimpleMoves(cell);
                        break;
                    }
                case purplePiece:
                    {

                        showPurpleComplexMoves(cell);
                        showPurpleSimpleMoves(cell);
                        break;
                    }
                case whiteKing:
                    {

                        showKingComplexMoves(cell);
                        showKingSimpleMoves(cell);
                        break;
                    }
                case purpleKing:
                    {

                        showKingComplexMoves(cell);
                        showKingSimpleMoves(cell);
                        break;
                    }
            }

            if (cell.Color.Equals(Models.Color.WHITE))
            {
                if (validWhiteMoves.Count() != 0)
                {
                    return true;
                }

            }
            else if (cell.Color.Equals(Models.Color.PURPLE))
            {
                if (validWhiteMoves.Count() != 0)
                {
                    return true;
                }

            }

            return false;

        }

        public static void UpdatePlayerData()
        {
            if (playerColor == Color.PURPLE)
            {
                instance.PurplePlayerData = purplePlayer.ToString();
            }
            else
            {
                instance.WhitePlayerData = whitePlayer.ToString();
            }
        }
        public static void clearMoves()
        {
            foreach (var piece in validPurpleMoves)
            {
                GameBoard[piece.Key.X][piece.Key.Y].Image = freeTile;
                GameBoard[piece.Key.X][piece.Key.Y].Type = Models.Type.FREE;
            }

            foreach (var piece in validWhiteMoves)
            {
                GameBoard[piece.Key.X][piece.Key.Y].Image = freeTile;
                GameBoard[piece.Key.X][piece.Key.Y].Type = Models.Type.FREE;
            }

        }

        public static bool isFreeTile(Cell cell)
        {
            if (cell.Image.Equals(freeTile))
                return true;
            return false;
        }

        private static void takePiece(List<KeyValuePair<Cell, Cell>> list, Cell cell)
        {

            if (cell.Color.Equals(Models.Color.PURPLE))
            {
                foreach (var piece in validPurpleMoves)
                {
                    if (piece.Value != null)
                    {
                        GameBoard[piece.Value.X][piece.Value.Y].Image = freeTile;
                        GameBoard[piece.Value.X][piece.Value.Y].Color = Color.NONE;
                        GameBoard[piece.Value.X][piece.Value.Y].Type = Models.Type.FREE;

                        ++purplePlayer.PiecesTaken;
                    }
                }
            }
            else if (cell.Color.Equals(Models.Color.WHITE))
            {
                foreach (var piece in validWhiteMoves)
                {
                    if (piece.Value != null)
                    {
                        GameBoard[piece.Value.X][piece.Value.Y].Image = freeTile;
                        GameBoard[piece.Value.X][piece.Value.Y].Color = Color.NONE;
                        GameBoard[piece.Value.X][piece.Value.Y].Type = Models.Type.FREE;

                        ++whitePlayer.PiecesTaken;
                    }
                }
            }

        }
        public static void movePiece(Cell currentCell, Cell nextCell)
        {

            if (currentCell.Color.Equals(Models.Color.PURPLE))
            {
                takePiece(validPurpleMoves, currentCell);
                clearMoves();
                clearList(validPurpleMoves);

            }
            else if (currentCell.Color.Equals(Models.Color.WHITE))
            {
                takePiece(validWhiteMoves, currentCell);
                clearMoves();
                clearList(validWhiteMoves);
            }

            //se face rege mov
            if (currentCell.Color.Equals(Models.Color.PURPLE) && nextCell.X == 0)
            {
                nextCell.Image = purpleKing;
                nextCell.Color = currentCell.Color;
                nextCell.Type = Models.Type.KING;
            }
            else if (currentCell.Color.Equals(Models.Color.WHITE) && nextCell.X == 7) //se face rege alb
            {
                nextCell.Image = whiteKing;
                nextCell.Color = currentCell.Color;
                nextCell.Type = Models.Type.KING;
            }
            else //mutare normala
            {
                nextCell.Image = currentCell.Image;
                nextCell.Color = currentCell.Color;
                nextCell.Type = currentCell.Type;
            }

            currentCell.Image = freeTile;
            currentCell.Type = Models.Type.FREE;
            currentCell.Color = Color.NONE;

        }

        private static void clearList(List<KeyValuePair<Cell, Cell>> list)
        {
            list.Clear();
        }
        private static bool isOnBoard(int X, int Y)
        {
            return (X < 8 && X >= 0 && Y >= 0 && Y < 8);
        }
        private static void showPurpleSimpleMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            if (isOnBoard(x + NORTH, y + EAST))
            {
                if (GameBoard[x + NORTH][y + EAST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH][y + EAST].Image = validPurpleTile;
                    GameBoard[x + NORTH][y + EAST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH][y + EAST], null));
                }
            }

            if (isOnBoard(x + NORTH, y + WEST))
            {
                if (GameBoard[x + NORTH][y + WEST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH][y + WEST].Image = validPurpleTile;
                    GameBoard[x + NORTH][y + WEST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH][y + WEST], null));
                }
            }
        }

        private static void showPurpleComplexMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            Cell occupiedCell;
            Cell freeCell;

            if (isOnBoard(x + NORTH, y + WEST) && isOnBoard(x + NORTH + NORTH, y + WEST + WEST))
            {
                occupiedCell = GameBoard[x + NORTH][y + WEST];
                freeCell = GameBoard[x + NORTH + NORTH][y + WEST + WEST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.WHITE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH + NORTH][y + WEST + WEST].Image = validPurpleTile;
                    GameBoard[x + NORTH + NORTH][y + WEST + WEST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH + NORTH][y + WEST + WEST], GameBoard[x + NORTH][y + WEST]));
                }
            }

            if (isOnBoard(x + NORTH, y + EAST) && isOnBoard(x + NORTH + NORTH, y + EAST + EAST))
            {
                occupiedCell = GameBoard[x + NORTH][y + EAST];
                freeCell = GameBoard[x + NORTH + NORTH][y + EAST + EAST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.WHITE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH + NORTH][y + EAST + EAST].Image = validPurpleTile;
                    GameBoard[x + NORTH + NORTH][y + EAST + EAST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH + NORTH][y + EAST + EAST], GameBoard[x + NORTH][y + EAST]));
                }
            }
        }

        private static void showWhiteSimpleMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            if (isOnBoard(x + SOUTH, y + EAST))
            {
                if (GameBoard[x + SOUTH][y + EAST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH][y + EAST].Image = validWhiteTile;
                    GameBoard[x + SOUTH][y + EAST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH][y + EAST], null));
                }
            }

            if (isOnBoard(x + SOUTH, y + WEST))
            {
                if (GameBoard[x + SOUTH][y + WEST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH][y + WEST].Image = validWhiteTile;
                    GameBoard[x + SOUTH][y + WEST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH][y + WEST], null));
                }
            }

        }

        private static void showWhiteComplexMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            Cell occupiedCell;
            Cell freeCell;

            if (isOnBoard(x + SOUTH, y + WEST) && isOnBoard(x + SOUTH + SOUTH, y + WEST + WEST))
            {
                occupiedCell = GameBoard[x + SOUTH][y + WEST];
                freeCell = GameBoard[x + SOUTH + SOUTH][y + WEST + WEST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.PURPLE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH + SOUTH][y + WEST + WEST].Image = validWhiteTile;
                    GameBoard[x + SOUTH + SOUTH][y + WEST + WEST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH + SOUTH][y + WEST + WEST], GameBoard[x + SOUTH][y + WEST]));
                }
            }

            if (isOnBoard(x + SOUTH, y + EAST) && isOnBoard(x + SOUTH + SOUTH, y + EAST + EAST))
            {
                occupiedCell = GameBoard[x + SOUTH][y + EAST];
                freeCell = GameBoard[x + SOUTH + SOUTH][y + EAST + EAST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.PURPLE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH + SOUTH][y + EAST + EAST].Image = validWhiteTile;
                    GameBoard[x + SOUTH + SOUTH][y + EAST + EAST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH + SOUTH][y + EAST + EAST], GameBoard[x + SOUTH][y + EAST]));
                }
            }
        }

        private static void showKingSimpleMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            string validTile;

            if (cell.Color.Equals(Models.Color.PURPLE))
            {
                validTile = validPurpleTile;
            }
            else
            {
                validTile = validWhiteTile;
            }

            if (isOnBoard(x + SOUTH, y + EAST))
            {
                if (GameBoard[x + SOUTH][y + EAST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH][y + EAST].Image = validTile;
                    GameBoard[x + SOUTH][y + EAST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH][y + EAST], null));
                }
            }

            if (isOnBoard(x + SOUTH, y + WEST))
            {
                if (GameBoard[x + SOUTH][y + WEST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH][y + WEST].Image = validTile;
                    GameBoard[x + SOUTH][y + WEST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH][y + WEST], null));
                }
            }

            if (isOnBoard(x + NORTH, y + EAST))
            {
                if (GameBoard[x + NORTH][y + EAST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH][y + EAST].Image = validTile;
                    GameBoard[x + NORTH][y + EAST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH][y + EAST], null));
                }
            }

            if (isOnBoard(x + NORTH, y + WEST))
            {
                if (GameBoard[x + NORTH][y + WEST].Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH][y + WEST].Image = validTile;
                    GameBoard[x + NORTH][y + WEST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH][y + WEST], null));
                }
            }

        }

        private static void showKingComplexMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            Cell occupiedCell;
            Cell freeCell;

            string validTile;
            Color enemyColor;

            if (cell.Color.Equals(Models.Color.PURPLE))
            {
                validTile = validWhiteTile;
                enemyColor = Models.Color.PURPLE;

                if (isOnBoard(x + SOUTH, y + WEST) && isOnBoard(x + SOUTH + SOUTH, y + WEST + WEST))
                {
                    occupiedCell = GameBoard[x + SOUTH][y + WEST];
                    freeCell = GameBoard[x + SOUTH + SOUTH][y + WEST + WEST];

                    if (occupiedCell.Type.Equals(Models.Type.PIECE) || occupiedCell.Type.Equals(Models.Type.KING))
                    {
                        if (occupiedCell.Color.Equals(enemyColor) && freeCell.Type.Equals(Models.Type.FREE))
                        {
                            GameBoard[x + SOUTH + SOUTH][y + WEST + WEST].Image = validTile;
                            GameBoard[x + SOUTH + SOUTH][y + WEST + WEST].Type = Models.Type.SELECTED;
                            validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH + SOUTH][y + WEST + WEST], GameBoard[x + SOUTH][y + WEST]));
                        }
                    }
                }

                if (isOnBoard(x + SOUTH, y + EAST) && isOnBoard(x + SOUTH + SOUTH, y + EAST + EAST))
                {
                    occupiedCell = GameBoard[x + SOUTH][y + EAST];
                    freeCell = GameBoard[x + SOUTH + SOUTH][y + EAST + EAST];

                    if (occupiedCell.Type.Equals(Models.Type.PIECE) || occupiedCell.Type.Equals(Models.Type.KING))
                    {
                        if (occupiedCell.Color.Equals(enemyColor) && freeCell.Type.Equals(Models.Type.FREE))
                        {
                            GameBoard[x + SOUTH + SOUTH][y + EAST + EAST].Image = validTile;
                            GameBoard[x + SOUTH + SOUTH][y + EAST + EAST].Type = Models.Type.SELECTED;
                            validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH + SOUTH][y + EAST + EAST], GameBoard[x + SOUTH][y + EAST]));
                        }
                    }
                }

            }
            else
            {
                validTile = validPurpleTile;
                enemyColor = Models.Color.WHITE;

                if (isOnBoard(x + NORTH, y + WEST) && isOnBoard(x + NORTH + NORTH, y + WEST + WEST))
                {
                    occupiedCell = GameBoard[x + NORTH][y + WEST];
                    freeCell = GameBoard[x + NORTH + NORTH][y + WEST + WEST];

                    if (occupiedCell.Type.Equals(Models.Type.PIECE) || occupiedCell.Type.Equals(Models.Type.KING))
                    {
                        if (occupiedCell.Color.Equals(enemyColor) && freeCell.Type.Equals(Models.Type.FREE))
                        {
                            GameBoard[x + NORTH + NORTH][y + WEST + WEST].Image = validTile;
                            GameBoard[x + NORTH + NORTH][y + WEST + WEST].Type = Models.Type.SELECTED;
                            validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH + NORTH][y + WEST + WEST], GameBoard[x + NORTH][y + WEST]));
                        }
                    }
                }

                if (isOnBoard(x + NORTH, y + EAST) && isOnBoard(x + NORTH + NORTH, y + EAST + EAST))
                {
                    occupiedCell = GameBoard[x + NORTH][y + EAST];
                    freeCell = GameBoard[x + NORTH + NORTH][y + EAST + EAST];

                    if (occupiedCell.Type.Equals(Models.Type.PIECE) || occupiedCell.Type.Equals(Models.Type.KING))
                    {
                        if (occupiedCell.Color.Equals(enemyColor) && freeCell.Type.Equals(Models.Type.FREE))
                        {
                            GameBoard[x + NORTH + NORTH][y + EAST + EAST].Image = validTile;
                            GameBoard[x + NORTH + NORTH][y + EAST + EAST].Type = Models.Type.SELECTED;
                            validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH + NORTH][y + EAST + EAST], GameBoard[x + NORTH][y + EAST]));
                        }
                    }
                }
            }


           
        }

        private static void showPurpleMultipleMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            Cell occupiedCell;
            Cell freeCell = null;
            Cell possibleExit = null;

            List<Cell> taken = new List<Cell>();
            int count = 0;

            while (!possibleExit.Image.Equals(freeTile))
            {
                if (isOnBoard(x + NORTH + count, y + WEST + count))
                {
                    possibleExit = GameBoard[x + NORTH + count][y + WEST + count];
                    if (!possibleExit.Image.Equals(freeTile) && possibleExit.Image.Equals(whitePiece))
                    {
                        taken.Add(possibleExit);
                    }
                }
                else
                    break;
            }

            if (possibleExit.Image.Equals(freeTile))
            {
                foreach (var piece in taken)
                {
                    piece.Image = validPurpleTile;
                    piece.Type = Models.Type.SELECTED;
                }

                //validPurpleMultiple.Add(new KeyValuePair<Cell, Cell>(possibleExit, taken));
            }



            if (isOnBoard(x + NORTH, y + WEST) && isOnBoard(x + NORTH + NORTH, y + WEST + WEST))
            {
                occupiedCell = GameBoard[x + NORTH][y + WEST];
                freeCell = GameBoard[x + NORTH + NORTH][y + WEST + WEST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.WHITE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH + NORTH][y + WEST + WEST].Image = validPurpleTile;
                    GameBoard[x + NORTH + NORTH][y + WEST + WEST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH + NORTH][y + WEST + WEST], GameBoard[x + NORTH][y + WEST]));
                }
            }

            if (isOnBoard(x + NORTH, y + EAST) && isOnBoard(x + NORTH + NORTH, y + EAST + EAST))
            {
                occupiedCell = GameBoard[x + NORTH][y + EAST];
                freeCell = GameBoard[x + NORTH + NORTH][y + EAST + EAST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.WHITE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + NORTH + NORTH][y + EAST + EAST].Image = validPurpleTile;
                    GameBoard[x + NORTH + NORTH][y + EAST + EAST].Type = Models.Type.SELECTED;
                    validPurpleMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + NORTH + NORTH][y + EAST + EAST], GameBoard[x + NORTH][y + EAST]));
                }
            }
        }

        private static void showWhiteMultipleMoves(Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            Cell occupiedCell;
            Cell freeCell;

            if (isOnBoard(x + SOUTH, y + WEST) && isOnBoard(x + SOUTH + SOUTH, y + WEST + WEST))
            {
                occupiedCell = GameBoard[x + SOUTH][y + WEST];
                freeCell = GameBoard[x + SOUTH + SOUTH][y + WEST + WEST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.PURPLE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH + SOUTH][y + WEST + WEST].Image = validWhiteTile;
                    GameBoard[x + SOUTH + SOUTH][y + WEST + WEST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH + SOUTH][y + WEST + WEST], GameBoard[x + SOUTH][y + WEST]));
                }
            }

            if (isOnBoard(x + SOUTH, y + EAST) && isOnBoard(x + SOUTH + SOUTH, y + EAST + EAST))
            {
                occupiedCell = GameBoard[x + SOUTH][y + EAST];
                freeCell = GameBoard[x + SOUTH + SOUTH][y + EAST + EAST];

                if (occupiedCell.Type.Equals(Models.Type.PIECE) && occupiedCell.Color.Equals(Models.Color.PURPLE) && freeCell.Type.Equals(Models.Type.FREE))
                {
                    GameBoard[x + SOUTH + SOUTH][y + EAST + EAST].Image = validWhiteTile;
                    GameBoard[x + SOUTH + SOUTH][y + EAST + EAST].Type = Models.Type.SELECTED;
                    validWhiteMoves.Add(new KeyValuePair<Cell, Cell>(GameBoard[x + SOUTH + SOUTH][y + EAST + EAST], GameBoard[x + SOUTH][y + EAST]));
                }
            }
        }

        public static bool IsGameOver()
        {
            if (purpleCounter == 12 || whiteCounter == 12)
                return true;

            return false;
        }

        public static void SaveData()
        {
            List<List<CellData>> data = new List<List<CellData>>();

            int i = 0;

            foreach (var row in GameBoard)
            {
                data.Add(new List<CellData>());

                foreach (var cell in row)
                {
                    data[i].Add(cell.Data);
                }
                ++i;
            }
            SaveSystem.SaveData(data);
        }
        public static void LoadData()
        {
            List<List<CellData>> data = SaveSystem.LoadData();
            var matrix = new ObservableCollection<ObservableCollection<Cell>>();

            int i = 0;

            foreach (var row in data)
            {
                matrix.Add(new ObservableCollection<Cell>());

                foreach (var cell in row)
                {
                    matrix[i].Add(new Cell(cell));
                }
                ++i;
            }

            GameBoard = matrix;
        }

    }
}

