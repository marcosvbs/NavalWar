Board playerBoard = new();
Player player = new();

playerBoard.ShowCells();
player.FirstTimePlaceMarker(playerBoard);

Console.Clear();

while (true)
{
    Console.WriteLine("Bem vindo ao...");
    Console.WriteLine("  _   _                  _  __        __         \r\n | \\ | | __ ___   ____ _| | \\ \\      / /_ _ _ __ \r\n |  \\| |/ _` \\ \\ / / _` | |  \\ \\ /\\ / / _` | '__|\r\n | |\\  | (_| |\\ V / (_| | |   \\ V  V / (_| | |   \r\n |_| \\_|\\__,_| \\_/ \\__,_|_|    \\_/\\_/ \\__,_|_|");
    Console.WriteLine();

    playerBoard.ShowCells();
    player.MoveMarker(playerBoard);
    Console.Clear();
}

