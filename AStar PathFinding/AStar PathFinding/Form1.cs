using System.Diagnostics;

namespace AStar_PathFinding
{
    public partial class Form1 : Form
    {

        Board board;
        bool canSearch = false;

        Queue<List<Cell>> queue = new();
        List<Cell> visited = new();
        bool _mousePressed = false;

        public Form1()
        {
            InitializeComponent();
            board = new Board(pictureBox1);
            board.cells[2, 2].Type = CellTypes.Start;
            board.cells[board.height - 3, board.width - 3].Type = CellTypes.End;
            queue.Enqueue(new List<Cell> { board.cells[2, 2], board.cells[2, 2] });
            visited.Add(board.cells[2, 2]);
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            board.Draw(e.Graphics);
        }

        private void Update(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();

            if (canSearch == false || queue.Count == 0) return;

            List<Cell> current = queue.Dequeue();
            if (current[0].Type == CellTypes.End)
            {
                canSearch = false;
                for (int i = 1; i < current.Count; i++)
                {
                    current[i].Type = CellTypes.Path;
                }

                for (int i = 0; i < board.height; i++)
                {
                    for (int j = 0; j < board.width; j++)
                    {
                        if (board.cells[i, j].Type != CellTypes.Path && board.cells[i, j].Type != CellTypes.Full && board.cells[i, j].Type != CellTypes.Start)
                        {
                            board.cells[i, j].Type = CellTypes.Empty;
                        }
                    }
                }
            }


            List<Cell> n = getNeighbors(current[0].Y, current[0].X);
            for (int i = 0; i < n.Count; i++)
            {
                if (visited.Contains(n[i]))
                {
                    continue;
                }
                if (n[i].Type == CellTypes.Full)
                {
                    continue;
                }

                List<Cell> newInput = [.. current];
                newInput[0] = n[i];
                newInput.Add(n[i]);
                queue.Enqueue(newInput);
                visited.Add(n[i]);
                if (n[i].Type != CellTypes.End && n[i].Type != CellTypes.Start)
                {
                    n[i].Type = CellTypes.Visited;
                }
            }
        }

        private List<Cell> getNeighbors(int row, int col)
        {
            List<Cell> neighbors = new();

            if (row > 0)
            {
                neighbors.Add(board.cells[row - 1, col]);
            }
            if (row + 1 < board.height)
            {
                neighbors.Add(board.cells[row + 1, col]);
            }
            if (col > 0)
            {
                neighbors.Add(board.cells[row, col - 1]);
            }
            if (col + 1 < board.width)
            {
                neighbors.Add(board.cells[row, col + 1]);
            }

            return neighbors;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < board.height; i++)
            {
                for (int j = 0; j < board.width; j++)
                {
                    if (e.X >= j * 25 && e.X <= (j * 25) + 25 && e.Y >= i * 25 && e.Y <= (i * 25) + 25)
                    {
                        board.cells[i, j].Type = CellTypes.Full;
                        return;
                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                queue.Clear();
                visited.Clear();
                canSearch = true;
                board.cells[2, 2].Type = CellTypes.Start;
                board.cells[board.height - 3, board.width - 3].Type = CellTypes.End;
                queue.Enqueue(new List<Cell> { board.cells[2, 2], board.cells[2, 2] });
                visited.Add(board.cells[2, 2]);

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePressed = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mousePressed) 
            {
                for (int i = 0; i < board.height; i++)
                {
                    for (int j = 0; j < board.width; j++)
                    {
                        if (e.X >= j * 25 && e.X <= (j * 25) + 25 && e.Y >= i * 25 && e.Y <= (i * 25) + 25)
                        {
                            board.cells[i, j].Type = CellTypes.Full;
                            return;
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mousePressed = false;
        }
    }
}
