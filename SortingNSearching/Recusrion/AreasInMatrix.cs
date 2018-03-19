using System;
using System.Collections.Generic;

class AreasInMatrix
{
    private string[] Matrix;
    private int rows;
    private int cols;
    private List<ConnectedArea> areas;
    private bool[][] BoolMatrix;
    public void Run()
    {

        ReadInput();
        areas = new List<ConnectedArea>();
        BoolMatrix = new bool[rows][];

        FillBoolMatrix();

        GetAreas();
        PrintOutput();
    }

    private void GetAreas()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (Matrix[row][col] != '*' && BoolMatrix[row][col])
                {
                    var area = new ConnectedArea(row, col);
                    Traverse(area, row, col);
                    areas.Add(area);
                }
            }
        }

        areas.Sort((a, b) => SortMethod(a, b));
    }

    private int SortMethod(ConnectedArea a, ConnectedArea b)
    {
        if (a.Size < b.Size) return 1;
        if (a.Size > b.Size) return -1;

        if (a.LocationY < b.LocationY) return -1;
        if (a.LocationY > b.LocationY) return 1;

        if (a.LocationX < b.LocationX) return -1;
        if (a.LocationX > b.LocationX) return 1;

        return 0;
    }

    private void Traverse(ConnectedArea area, 
        int currentRow, int currentCol)
    {
        char currentCell = Matrix[currentRow][currentCol];

        BoolMatrix[currentRow][currentCol] = false;

        if (currentCell == '*')
        {
            return;
        }

        area.Size++;
        if(currentRow - 1 >= 0 && BoolMatrix[currentRow - 1][currentCol])
        {
            Traverse(area, currentRow - 1, currentCol);
        }
        if(currentRow + 1 < rows && BoolMatrix[currentRow + 1][currentCol])
        {
            Traverse(area, currentRow + 1, currentCol);
        }
        if(currentCol + 1 < cols && BoolMatrix[currentRow][currentCol + 1])
        {
            Traverse(area, currentRow, currentCol + 1);
        }
        if (currentCol - 1 >= 0 && BoolMatrix[currentRow][currentCol - 1])
        {
            Traverse(area, currentRow, currentCol - 1);
        }

    }

    private void ReadInput()
    {
        rows = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());

        var matrix = new string[rows];

        for (int row = 0; row < rows; row++)
        {
            string rowArr = Console.ReadLine();
            matrix[row] = rowArr;
        }

        Matrix = matrix;
    }

    private void FillBoolMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            BoolMatrix[i] = new bool[cols]; 
            for (int i1 = 0; i1 < cols; i1++)
            {
                BoolMatrix[i][i1] = true;
            }
        }
    }

    private void PrintOutput()
    {
        Console.WriteLine($"Total areas found: {areas.Count}");
        for (int i = 0; i < areas.Count; i++)
        {
            var area = areas[i];
            Console.WriteLine(
                $"Area #{i + 1} at ({area.LocationY}, {area.LocationX}), " +
                $"size: {area.Size}");
        }
    }

    private class ConnectedArea
    {
        public int Size;
        public int LocationX;
        public int LocationY;

        public ConnectedArea(int locationY,int locationX)
        {
            Size = 0;
            LocationX = locationX;
            LocationY = locationY;
        }
    }
}

