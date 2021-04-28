using MVVMPairs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class Helper 
    {
        public static Cell CurrentCell { get; set; }
        public static Cell PreviousCell { get; set; }
        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard()
        {
            return new ObservableCollection<ObservableCollection<Cell>>()
            {
                new ObservableCollection<Cell>()
                {
                    new Cell(0, 0, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(0, 1, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(0, 2, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE, Models.Type.NONE),
                    new Cell(0, 3, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(0, 4, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE, Models.Type.NONE),
                    new Cell(0, 5, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(0, 6, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(0, 7, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),

                },
                new ObservableCollection<Cell>()
                {
                    new Cell(1, 0, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE,Models.Type.PIECE),
                    new Cell(1, 1, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(1, 2, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(1, 3, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(1, 4, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(1, 5, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(1, 6, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(1, 7, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                },

                new ObservableCollection<Cell>()
                {
                    new Cell(2, 0, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(2, 1, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(2, 2, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(2, 3, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE,Models.Type.PIECE),
                    new Cell(2, 4, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(2, 5, "/MVVMPairs;component/Resources/whitePiece.png",Models.Color.WHITE, Models.Type.PIECE),
                    new Cell(2, 6, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(2, 7, "/MVVMPairs;component/Resources/whitePiece.png", Models.Color.WHITE,Models.Type.PIECE),

                },
                new ObservableCollection<Cell>()
                {
                    new Cell(3, 0, "/MVVMPairs;component/Resources/purpleBkgr.png",Models.Color.NONE, Models.Type.FREE),
                    new Cell(3, 1, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(3, 2, "/MVVMPairs;component/Resources/purpleBkgr.png",Models.Color.NONE, Models.Type.FREE),
                    new Cell(3, 3, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(3, 4, "/MVVMPairs;component/Resources/purpleBkgr.png", Models.Color.NONE, Models.Type.FREE),
                    new Cell(3, 5, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(3, 6, "/MVVMPairs;component/Resources/purpleBkgr.png",Models.Color.NONE, Models.Type.FREE),
                    new Cell(3, 7, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                },

                 new ObservableCollection<Cell>()
                {
                    new Cell(4, 0, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(4, 1, "/MVVMPairs;component/Resources/purpleBkgr.png",Models.Color.NONE, Models.Type.FREE),
                    new Cell(4, 2, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(4, 3, "/MVVMPairs;component/Resources/purpleBkgr.png",Models.Color.NONE, Models.Type.FREE),
                    new Cell(4, 4, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE, Models.Type.NONE),
                    new Cell(4, 5, "/MVVMPairs;component/Resources/purpleBkgr.png", Models.Color.NONE, Models.Type.FREE),
                    new Cell(4, 6, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(4, 7, "/MVVMPairs;component/Resources/purpleBkgr.png", Models.Color.NONE, Models.Type.FREE),

                },
                new ObservableCollection<Cell>()
                {
                    new Cell(5, 0, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(5, 1, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(5, 2, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(5, 3, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(5, 4, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(5, 5, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(5, 6, "/MVVMPairs;component/Resources/purplePiece.png", Models.Color.PURPLE, Models.Type.PIECE),
                    new Cell(5, 7, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                },

                 new ObservableCollection<Cell>()
                {
                    new Cell(6, 0, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(6, 1, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(6, 2, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(6, 3, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(6, 4, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(6, 5, "/MVVMPairs;component/Resources/purplePiece.png", Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(6, 6, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(6, 7, "/MVVMPairs;component/Resources/purplePiece.png", Models.Color.PURPLE,Models.Type.PIECE),

                },
                new ObservableCollection<Cell>()
                {
                    new Cell(7, 0, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(7, 1, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(7, 2, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(7, 3, "/MVVMPairs;component/Resources/whiteBkgr.png", Models.Color.NONE,Models.Type.NONE),
                    new Cell(7, 4, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(7, 5, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                    new Cell(7, 6, "/MVVMPairs;component/Resources/purplePiece.png",Models.Color.PURPLE,Models.Type.PIECE),
                    new Cell(7, 7, "/MVVMPairs;component/Resources/whiteBkgr.png",Models.Color.NONE, Models.Type.NONE),
                }
            };
        }

     
    }
}
