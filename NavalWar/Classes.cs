class Board
{
    int rows = 10;
    int columns = 10;
    string[,] cells;

    public Board()
    {
        cells = GenerateCells();
    }

    string[,] GenerateCells()
    {
        string[,] cells = new string[rows, columns];

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columns; columnIndex++)
            {
                cells[rowIndex, columnIndex] = "   ";
            }
        }
        return cells;
    }

    public void ShowCells()
    {
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columns; columnIndex++)
            {
                if (columnIndex + 1 == columns)
                {
                    Console.Write($"|{cells[rowIndex, columnIndex]}|");
                }
                else
                {
                    Console.Write($"|{cells[rowIndex, columnIndex]}");
                } 
            }
            Console.WriteLine();
        }
    }

    public void UpdateCellContent(int cellRow, int cellColumn, string newValue)
    {
        cells[cellRow, cellColumn] = newValue;
    }

    public void ClearCellContent(int cellRow, int cellColumn)
    {
        string clearSymbol = "   ";

        cells[cellRow, cellColumn] = clearSymbol;
    }

    public int GetBoardWidth()
    {
        return rows;
    }

    public int GetBoardHeight()
    {
        return columns;
    }
}

class Player
{
    Marker marker = new();

    ConsoleKey getInputFromKeyBoard()
    {
        ConsoleKeyInfo keyInfo;
        keyInfo = Console.ReadKey(true);

        return keyInfo.Key;
    }

    public void FirstTimePlaceMarker(Board playerBoard)
    {
        int initialRow = 0;
        int initialColumn = 0;

        marker.ChangeMarkerLocation(initialRow, initialColumn);

        playerBoard.UpdateCellContent(initialRow, initialColumn, marker.GetMarkerSymbol());
    }

    public void MoveMarker(Board playerBoard)
    {
        int currentMarkerRow = marker.GetMarkerCurrentRow();
        int currentMarkerColumn = marker.GetMarkerCurrentColumn();

        switch (getInputFromKeyBoard())
        {
            case (ConsoleKey.UpArrow):

                if (currentMarkerRow - 1 >= 0)
                {
                    playerBoard.ClearCellContent(currentMarkerRow, currentMarkerColumn);
                    marker.ChangeMarkerLocation(currentMarkerRow - 1, currentMarkerColumn);
                }

                break;
            case (ConsoleKey.DownArrow):

                if (currentMarkerRow + 1 < playerBoard.GetBoardHeight())
                {
                    playerBoard.ClearCellContent(currentMarkerRow, currentMarkerColumn);
                    marker.ChangeMarkerLocation(currentMarkerRow + 1, currentMarkerColumn);
                }
                   
                break;
            case (ConsoleKey.RightArrow):

                if (currentMarkerColumn + 1 < playerBoard.GetBoardWidth())
                {
                    playerBoard.ClearCellContent(currentMarkerRow, currentMarkerColumn);
                    marker.ChangeMarkerLocation(currentMarkerRow, currentMarkerColumn + 1);
                }     

                break;
            case (ConsoleKey.LeftArrow):

                if (currentMarkerColumn - 1 >= 0)
                {
                    playerBoard.ClearCellContent(currentMarkerRow, currentMarkerColumn);
                    marker.ChangeMarkerLocation(currentMarkerRow, currentMarkerColumn - 1);
                }
                    
                break;

        }

        playerBoard.UpdateCellContent(marker.GetMarkerCurrentRow(), marker.GetMarkerCurrentColumn(), marker.GetMarkerSymbol());

    }

    

}

class Marker
{
    string symbol = "[ ]";
    int currentRow;
    int currentColumn;

    public void ChangeMarkerLocation(int newRow, int newColumn)
    {
        currentRow = newRow;
        currentColumn = newColumn;
    }

    public string GetMarkerSymbol()
    {
        return symbol;
    }

    public int GetMarkerCurrentRow()
    {
        return currentRow;
    }

    public int GetMarkerCurrentColumn()
    {
        return currentColumn;
    }
}