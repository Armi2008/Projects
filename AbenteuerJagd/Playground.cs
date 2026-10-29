
using System;

public class Playground
{
    public string[,] startMap = new string[25, 80];
    public bool startMapIsActive = true;

    public string[,] secondRoom = new string[25, 65];
    public bool secondRoomIsActive = false;

    public string[,] thirdRoom = new string[30, 70];
    public bool thirdRoomIsActive = false;

    public string[,] recoveryRoom = new string[20, 90];
    public bool recoveryRoomIsActive = false;

    public string[,] traderRoom = new string[20, 90];
    public bool traderRoomIsActive = false;

    public int backToStartX;
    public int backToStartY;

    public int level = 0;

    string emptyField = "  ";
    string roomField = "🧱";

    private bool secondRoomInitialized = false;
    private bool recoveryRoomInitialized = false;
    private bool thirdRoomInitialized = false;
    private bool traderRoomInitialized = false;

    public bool secondRoomMobsCreated = false;
    public bool recoveryRoomMobsCreated = false;
    public bool thirdRoomMobsCreated = false;

    Player player;

    public Playground(Player player)
    {
        this.player = player;
    }

    public void GenerateMap()
    {
        for (int y = 0; y < startMap.GetLength(0); y++)
        {
            for (int x = 0; x < startMap.GetLength(1); x++)
            {
                if (x == 0 || x == startMap.GetLength(1) - 1 ||
                    y == 0 || y == startMap.GetLength(0) - 1)
                {
                    startMap[y, x] = roomField;
                }
                else
                {
                    startMap[y, x] = emptyField;
                }
            }
        }

        CreateEntrance(5, 3, roomField);
        CreateEntrance(35, 2, roomField);
        CreateEntrance(65, 5, roomField);
        CreateEntrance(15, 17, roomField);
        CreateEntrance(50, 18, roomField);

        ShowInformation(startMap);
    }

    public void StartArea(int startX, int startY, string field)
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (y == 0 || y == 4 || x == 0 || x == 9)
                {
                    startMap[startY + y, startX + x] = field;
                }
            }
        }
    }

    public void CreateEntrance(int startX, int startY, string field)
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (y == 0 || y == 4 || x == 0 || x == 9)
                {
                    startMap[startY + y, startX + x] = field;
                }

                if (y == 0 && x == 4)
                    startMap[startY + y, startX + x] = "🚪";

                if (y == 0 && x == 5)
                    startMap[startY + y, startX + x] = "  ";

                if (y == 0 && x == 6)
                    startMap[startY + y, startX + x] = "🚪";
            }
        }
    }

    public void ShowRoom(string[,] newRoom)
    {
        int roomWidth = newRoom.GetLength(1);
        int roomHeight = newRoom.GetLength(0);

        bool initialized = false;

        if (newRoom == secondRoom)
            initialized = secondRoomInitialized;
        else if (newRoom == recoveryRoom)
            initialized = recoveryRoomInitialized;
        else if (newRoom == thirdRoom)
            initialized = thirdRoomInitialized;
        else if (newRoom == traderRoom)
            initialized = traderRoomInitialized;

        if (!initialized && newRoom != traderRoom)
        {
            int doorMiddle = roomWidth / 2;

            for (int y = 0; y < roomHeight; y++)
            {
                for (int x = 0; x < roomWidth; x++)
                {
                    if (y == 0 && x == doorMiddle - 1 && newRoom != traderRoom)
                        newRoom[y, x] = "🚪";
                    else if (y == 0 && x == doorMiddle)
                        newRoom[y, x] = "  ";
                    else if (y == 0 && x == doorMiddle + 1 && newRoom != traderRoom)
                        newRoom[y, x] = "🚪";
                    else if (x == 0 &&
                             (y == roomHeight - 4 || y == roomHeight - 2) &&
                             newRoom != traderRoom)
                        newRoom[y, x] = "🚪";
                    else if (x == 0 && y == roomHeight - 3 && newRoom != traderRoom)
                        newRoom[y, x] = "  ";
                    else if (x == 0 || x == roomWidth - 1 ||
                             y == 0 || y == roomHeight - 1)
                        newRoom[y, x] = "🧱";
                    else
                        newRoom[y, x] = "  ";
                }
            }

            if (newRoom == secondRoom)
                secondRoomInitialized = true;
            else if (newRoom == recoveryRoom)
                recoveryRoomInitialized = true;
            else if (newRoom == thirdRoom)
                thirdRoomInitialized = true;
            else if (newRoom == traderRoom)
                traderRoomInitialized = true;
        }

        int startX = Math.Max(0, (Console.WindowWidth - roomWidth) / 2);
        int startY = Math.Max(0, (Console.WindowHeight - roomHeight) / 2);

        for (int y = 0; y < roomHeight; y++)
        {
            string output = "";

            for (int x = 0; x < roomWidth; x++)
            {
                if (x == player.playerX && y == player.playerY)
                    output += player.Pl;
                else
                    output += newRoom[y, x];
            }

            if (startY + y < Console.BufferHeight &&
                startX >= 0 && startX + roomWidth <= Console.BufferWidth)
            {
                Console.SetCursorPosition(startX, startY + y);
                Console.Write(output);
            }
        }

        ShowInformation(newRoom);
    }

    public void CreateTraderRoom()
    {
        for (int y = 0; y < traderRoom.GetLength(0); y++)
        {
            for (int x = 0; x < traderRoom.GetLength(1); x++)
            {
                if (x == 0 || x == traderRoom.GetLength(1) - 1 ||
                    y == 0 || y == traderRoom.GetLength(0) - 1)
                {
                    traderRoom[y, x] = "🧱";
                }
                else
                {
                    traderRoom[y, x] = "  ";
                }
            }
        }

        int middle = traderRoom.GetLength(1) / 2;

        traderRoom[0, middle - 1] = "🚪";
        traderRoom[0, middle] = "  ";
        traderRoom[0, middle + 1] = "🚪";

        CreateTraderStand(15, "⚔️");
        CreateTraderStand(35, "🛡️");
        CreateTraderStand(55, "❤️");
        CreateTraderStand(75, "🔱");

        traderRoomInitialized = true;
    }

    public void BuyItem(Player player, char item)
    {
        int cost = 0;

        switch (item)
        {
            case 'A': cost = 50; break;
            case 'S': cost = 75; break;
            case 'L': cost = 100; break;
            case 'T': cost = 150; break;
        }

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"Dein Item: {item}");
            Console.WriteLine("Druecke B zum Kaufen.");
            Console.WriteLine("Druecke C zum Abbrechen.");
            Console.WriteLine($"Dein Gold: {player.Gold}");
            Console.WriteLine($"Kosten: {cost}");

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.C)
            {
                break;
            }

            if (key == ConsoleKey.B)
            {
                if (player.Gold >= cost)
                {
                    player.Gold -= cost;

                    switch (item)
                    {
                        case 'A':
                            player.attack += 10;
                            break;

                        case 'S':
                            player.shield += 10;
                            break;

                        case 'L':
                            player.healthPoints += 10;
                            break;

                        case 'T':
                            // Totem skibidi
                            break;
                    }

                    Console.WriteLine("Gekauft!");
                    Console.ReadKey(true);
                    break;
                }
                else
                {
                    Console.WriteLine("Nicht genug Gold!");
                    Console.ReadKey(true);
                }
            }
        }

        Console.Clear();
    }

    public void CreateTraderStand(int middle, string item)
    {
        int startX = middle - 3;
        int startY = 5;

        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                if (y == 0 || y == 6 || x == 0 || x == 6)
                    traderRoom[startY + y, startX + x] = "🧱";
                else
                    traderRoom[startY + y, startX + x] = "  ";
            }
        }

        traderRoom[startY + 3, middle] = item;
        traderRoom[14, middle - 1] = "🚪";
        traderRoom[14, middle + 1] = "🚪";
    }

    public void ShowMap()
    {
        int mapWidth = startMap.GetLength(1);
        int mapHeight = startMap.GetLength(0);

        int startX = (Console.WindowWidth - mapWidth) / 2;
        int startY = (Console.WindowHeight - mapHeight) / 2;

        for (int y = 0; y < mapHeight; y++)
        {
            string output = "";

            for (int x = 0; x < mapWidth; x++)
            {
                if (x == player.playerX && y == player.playerY)
                    output += player.Pl;
                else
                    output += startMap[y, x];
            }

            Console.SetCursorPosition(startX, startY + y);
            Console.Write(output);
        }

        ShowInformation(startMap);
    }

    public void ShowInformation(string[,] room)
    {
        int mapWidth = room.GetLength(1);
        int mapHeight = room.GetLength(0);

        int startX = (Console.WindowWidth - mapWidth) / 2;
        int startY = (Console.WindowHeight - mapHeight) / 2;

        int infoY = startY + mapHeight + 1;

        string info =
            $"Health: {player.healthPoints} | Attack: {player.attack} | Shield: {player.shield} | Gold: {player.Gold}";

        int infoX = (Console.WindowWidth - info.Length) / 2;

        if (infoY < Console.BufferHeight && infoX >= 0)
        {
            Console.SetCursorPosition(infoX, infoY);
            Console.Write(info);
        }
    }
}
