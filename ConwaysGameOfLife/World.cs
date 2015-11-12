using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class World
    {
        public List<Cell> Cells { get; set; }
        public World()
        {
            Cells = new List<Cell>();
        }

        public void AddCell(int x, int y)
        {
            Cells.Add(new Cell { X = x, Y = y });
        }

        public int Count()
        {
            return Cells.Count();
        }

        public Cell GetCell(int x, int y)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.X == x && cell.Y == y)
                {
                    return cell;
                }
            }
            return null;
        }

        public void RemoveCell(int x, int y)
        {
            if (GetCell(x, y) == null)
            {
                throw new ArgumentException();
            }
            else
            {
                Cells.Remove(GetCell(x, y));
            }
        }

        public List<Cell> GetLiveNeighbors(int x, int y)
        {
            List<Cell> result = new List<Cell>();

            //above
            if (GetCell(x, y + 1) != null)
                result.Add(GetCell(x, y + 1));
            //below
            if (GetCell(x, y - 1) != null)
                result.Add(GetCell(x, y - 1));
            //left
            if (GetCell(x - 1, y) != null)
                result.Add(GetCell(x - 1, y));
            //right
            if (GetCell(x + 1, y) != null)
                result.Add(GetCell(x + 1, y));
            //above_right
            if (GetCell(x + 1, y + 1) != null)
                result.Add(GetCell(x + 1, y + 1));
            //above-left
            if (GetCell(x - 1, y + 1) != null)
                result.Add(GetCell(x - 1, y + 1));
            //below-right
            if (GetCell(x + 1, y - 1) != null)
                result.Add(GetCell(x + 1, y - 1));
            //below-left
            if (GetCell(x - 1, y - 1) != null)
                result.Add(GetCell(x - 1, y - 1));

            return result;
        }

        public int NumLiveNeighbors(int x, int y)
        {
            List<Cell> liveNeighborCells = GetLiveNeighbors(x, y);
            return liveNeighborCells.Count;
        }


        public List<Cell> AngelOfDeath()
        {
            List<Cell> lake_of_fire = new List<Cell>();
            foreach (Cell cell in Cells)
            {
                if (NumLiveNeighbors(cell.X, cell.Y) < 2 || NumLiveNeighbors(cell.X, cell.Y) >= 4)
                {
                    lake_of_fire.Add(cell);
                }
            }
            return lake_of_fire;
        }
        public List<Cell> ActOfGod()
        {
            List<Cell> result = new List<Cell>();
            foreach (Cell cell in Cells)
            {
                //above
                if (GetCell(cell.X, cell.Y + 1) == null && NumLiveNeighbors(cell.X, cell.Y + 1) == 3)
                {
                        result.Add(new Cell { X = cell.X, Y = cell.Y + 1 });
                }
                //below
                if (GetCell(cell.X, cell.Y - 1) == null && NumLiveNeighbors(cell.X, cell.Y - 1) == 3)
                {
                    result.Add(new Cell { X = cell.X, Y = cell.Y - 1 });
                }
                //left
                if (GetCell(cell.X - 1, cell.Y) == null && NumLiveNeighbors(cell.X - 1, cell.Y) == 3)
                {
                    result.Add(new Cell { X = cell.X - 1, Y = cell.Y });
                }
                //right
                if (GetCell(cell.X + 1, cell.Y) == null && NumLiveNeighbors(cell.X + 1, cell.Y) == 3)
                {
                    result.Add(new Cell { X = cell.X + 1, Y = cell.Y });
                }
                //above_right
                if (GetCell(cell.X + 1, cell.Y + 1) == null && NumLiveNeighbors(cell.X + 1, cell.Y + 1) == 3)
                {
                    result.Add(new Cell { X = cell.X + 1, Y = cell.Y + 1 });
                }
                //above-left
                if (GetCell(cell.X - 1, cell.Y + 1) == null && NumLiveNeighbors(cell.X - 1, cell.Y + 1) == 3)
                {
                    result.Add(new Cell { X = cell.X - 1, Y = cell.Y + 1 });
                }
                //below-right
                if (GetCell(cell.X + 1, cell.Y - 1) == null && NumLiveNeighbors(cell.X + 1, cell.Y - 1) == 3)
                {
                    result.Add(new Cell { X = cell.X + 1, Y = cell.Y - 1 });
                }
                //below-left
                if (GetCell(cell.X - 1, cell.Y - 1) == null && NumLiveNeighbors(cell.X - 1, cell.Y - 1) == 3)
                {
                    result.Add(new Cell { X = cell.X - 1, Y = cell.Y - 1 });
                }
            }

            return result;
        }

        public void JudgmentOfGod()
        {

            List<Cell> godsGrace = ActOfGod();
            List<Cell> lake_of_fire = AngelOfDeath();
            foreach (Cell chosen_one in godsGrace)
            {
                if (GetCell(chosen_one.X, chosen_one.Y) == null)
                {
                    AddCell(chosen_one.X, chosen_one.Y);
                }
            }
            foreach (Cell sinner in lake_of_fire)
            {
                if (GetCell(sinner.X, sinner.Y) != null)
                {
                    RemoveCell(sinner.X, sinner.Y);
                }
            }
            List<Cell> cell = Cells;
        }

        
   }   

}
