using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Models
{
    [Serializable]
    public class CellData
    {
        public CellData(int x, int y, string img, Color color, Type type)
        {
            this.x = x;
            this.y = y;
            this.image = img;
            this.color = color;
            this.type = type;
        }

        public int x;

        public int y;

        public string image;

        public Color color;

        public Type type;



    }
}
