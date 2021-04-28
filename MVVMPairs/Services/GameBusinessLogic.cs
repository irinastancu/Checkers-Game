using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class GameBusinessLogic
    {
        private static Cell cellToMove;
        Board board;
        private static void displayMoves(Cell cell)
        {
            Board.showValidMoves(cell);
        }
        public static void Move(Cell currentCell, Cell nextCell)
        {
            Board.movePiece(currentCell, nextCell);
            Board.UpdatePlayerData();
            Board.UpdateTurn();

        }

        public static bool isRightTurn(string turn, string last)
        {
            if (turn.Equals(last))
            {
                return false;
            }

            return true;
        }
        public static void ClickAction(Cell clickedCell)
        {
            if (Board.IsGameOver())
            {
                Board.instance.GameStatus = $"Player {clickedCell.Color} has won";
                return;
            }
            if (clickedCell.Type == Models.Type.PIECE || clickedCell.Type == Models.Type.KING)
            {
                //o selecteaza si afiseaza posibilitatile
                Board.clearMoves();
                cellToMove = clickedCell;
                displayMoves(clickedCell);
            }
            else if (clickedCell.Type == Models.Type.SELECTED)
            {
                Move(cellToMove, clickedCell);
                
                //muta piesa selected in cell.
            }

        }

    }
}
