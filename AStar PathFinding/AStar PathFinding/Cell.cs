using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_PathFinding
{
    public class Cell
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public CellTypes Type { get; set; } = CellTypes.Empty;
        public Cell(int x,int y) 
        {
            X= x; Y=y;
        }

        public void Draw(Graphics g)
        {
            if (Type == CellTypes.Start)
            {
                g.FillRectangle(Brushes.LightGreen, X*25, Y*25, 25, 25);
            }
            else if (Type == CellTypes.End)
            {
                g.FillRectangle(Brushes.Orange, X * 25, Y * 25, 25, 25);
            }
            else if (Type == CellTypes.Empty)
            {
                g.DrawRectangle(Pens.Black, X* 25, Y* 25, 25, 25);
            }
            else if (Type == CellTypes.Full)
            {
                g.FillRectangle(Brushes.Black, X * 25, Y * 25, 25, 25);
            }
            else if (Type == CellTypes.Visited)
            {
                g.FillRectangle(Brushes.Blue, X * 25, Y * 25, 25, 25);
            }
            else if (Type == CellTypes.Path)
            {
                g.FillRectangle(Brushes.Red, X * 25, Y * 25, 25, 25);
            }
        }
    }
}
