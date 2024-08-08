using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_PathFinding
{
    public class Board
    {
        public Cell[,] cells;
        public int width = 0;
        public int height = 0;

        public Board(PictureBox pic) 
        {
            width = pic.Width/ 25;
            height = pic.Height/25;
            cells = new Cell[pic.Height/25, pic.Width/25];
            for (int i = 0; i < pic.Height/25; i++)
            {
                for (int j = 0; j <pic.Width/25; j++)
                {
                    cells[i,j] = new Cell(j,i);
                }
            }
        }
        public void Draw(Graphics gr)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j].Draw(gr);
                }
            }
        }
    }
}
