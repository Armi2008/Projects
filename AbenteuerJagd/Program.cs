
using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static CancellationTokenSource roomCancellation;
    static List<SpawnItems> items = new List<SpawnItems>();

    public static void ShowIntro()
    {
        string[] introText =
        {
            "========================================",
            "",
            "DUNGEON ADVENTURE",
            "",
            "========================================",
            "",
            "Welcome to the Dungeon!",
            "",
            "WASD  - Movement",
            "ESC   - Return / Exit",
            "",
            "Press any key",
            "to start your adventure."
        };

        int startY = Math.Max(0, (Console.WindowHeight - introText.Length) / 2);

        for (int i = 0; i < introText.Length; i++)
        {
            string line = introText[i];
            int startX = Math.Max(0, (Console.WindowWidth - line.Length) / 2);
            int y = startY + i;

            if (y < Console.WindowHeight)
            {
                Console.SetCursorPosition(startX, y);
                Console.Write(line);
            }
        }

        Console.ReadKey(true);
        Console.Clear();
    }

    public static bool Movement(
        Player player, string[,] map, Playground playground)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    player.moveUp(map);
                    break;

                case ConsoleKey.A:
                    player.moveLeft(map);
                    break;

                case ConsoleKey.S:
                    player.moveDown(map);
                    break;

                case ConsoleKey.D:
                    player.moveRight(map);
                    break;

                case ConsoleKey.Escape:
                    ReturnToStartMap(player, playground);
                    break;
            }
            foreach (SpawnItems item in items)
            {
                item.CollectItem(player, map);
            }
            Thread.Sleep(40);
        }

        return true;
    }

    public static List<Mobs> CreateLevels(
        int level, int room, Playground playground)
    {
        List<Mobs> mobs = new List<Mobs>();
        items.Clear();

        if (level == 1)
        {
            if (room == 1)
            {
                for (int i = 0; i < 8; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 6, 5, true, false, playground, 3));

                items.Add(new SpawnItems("❤️", 0, 0, 25, 10, 10, playground));
                items.Add(new SpawnItems("⚔️", 5, 0, 0, 30, 15, playground));
                items.Add(new SpawnItems("🛡️", 0, 5, 0, 60, 10, playground));
            }
            else if (room == 2)
            {
                items.Add(new SpawnItems("❤️", 0, 0, 50, 15, 10, playground));
                items.Add(new SpawnItems("⚔️", 10, 0, 0, 35, 15, playground));
                items.Add(new SpawnItems("🛡️", 0, 10, 0, 45, 15, playground));
            }
            else if (room == 3)
            {
                for (int i = 0; i < 6; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 5, 10, true, false, playground, 3));

                mobs.Add(new Mobs("🧟", 20, 3, 35, 15, true, false, playground, 5));

                items.Add(new SpawnItems("❤️", 0, 0, 50, 10, 20, playground));
                items.Add(new SpawnItems("⚔️", 10, 0, 0, 25, 25, playground));
                items.Add(new SpawnItems("💎", 10, 10, 25, 40, 20, playground));
            }
        }
        else if (level == 2)
        {
            if (room == 1)
            {
                for (int i = 0; i < 6; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 10, 5, true, false, playground, 3));

                mobs.Add(new Mobs("🧟", 8, 2, 20, 12, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 45, 15, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 50, 8, true, false, playground, 5));

                items.Add(new SpawnItems("❤️", 0, 0, 50, 15, 20, playground));
                items.Add(new SpawnItems("⚔️", 15, 0, 0, 35, 10, playground));
                items.Add(new SpawnItems("🛡️", 0, 15, 0, 60, 15, playground));
            }
            else if (room == 2)
            {
                items.Add(new SpawnItems("❤️", 0, 0, 75, 15, 10, playground));
                items.Add(new SpawnItems("⚔️", 15, 0, 0, 40, 15, playground));
                items.Add(new SpawnItems("💎", 10, 10, 50, 30, 15, playground));
            }
            else if (room == 3)
            {
                for (int i = 0; i < 4; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 8, 10, true, false, playground, 3));

                mobs.Add(new Mobs("🧟", 8, 2, 15, 15, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 30, 12, true, false, playground, 5));
                mobs.Add(new Mobs("🗿", 35, 5, 35, 15, true, false, playground, 10));

                items.Add(new SpawnItems("❤️", 0, 0, 50, 10, 25, playground));
                items.Add(new SpawnItems("⚔️", 20, 0, 0, 25, 15, playground));
                items.Add(new SpawnItems("🛡️", 0, 20, 0, 35, 15, playground));
            }
        }
        else if (level == 3)
        {
            if (room == 1)
            {
                mobs.Add(new Mobs("🗿", 20, 3, 20, 8, true, false, playground, 10));
                mobs.Add(new Mobs("🗿", 20, 3, 55, 8, true, false, playground, 10));
                mobs.Add(new Mobs("🧟", 8, 2, 15, 15, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 45, 15, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 30, 12, true, false, playground, 5));

                for (int i = 0; i < 4; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 15, 5, true, false, playground, 3));

                items.Add(new SpawnItems("❤️", 0, 0, 50, 10, 20, playground));
                items.Add(new SpawnItems("⚔️", 25, 0, 0, 30, 20, playground));
                items.Add(new SpawnItems("🛡️", 0, 25, 0, 55, 20, playground));
            }
            else if (room == 2)
            {
                items.Add(new SpawnItems("❤️", 0, 0, 75, 15, 10, playground));
                items.Add(new SpawnItems("💎", 20, 20, 100, 40, 15, playground));
            }
            else if (room == 3)
            {
                for (int i = 0; i < 3; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 10, 10, true, false, playground, 3));

                mobs.Add(new Mobs("🧟", 8, 2, 15, 15, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 30, 12, true, false, playground, 5));
                mobs.Add(new Mobs("🗿", 20, 3, 20, 8, true, false, playground, 10));
                mobs.Add(new Mobs("👹", 60, 8, 35, 15, true, false, playground, 20));

                items.Add(new SpawnItems("❤️", 0, 0, 75, 10, 25, playground));
                items.Add(new SpawnItems("⚔️", 25, 0, 0, 25, 20, playground));
                items.Add(new SpawnItems("🛡️", 0, 30, 0, 30, 25, playground));
            }
        }
        else if (level == 4)
        {
            if (room == 1)
            {
                mobs.Add(new Mobs("👹", 30, 5, 15, 8, true, false, playground, 20));
                mobs.Add(new Mobs("👹", 30, 5, 55, 8, true, false, playground, 20));
                mobs.Add(new Mobs("🗿", 20, 3, 25, 15, true, false, playground, 10));
                mobs.Add(new Mobs("🗿", 20, 3, 50, 15, true, false, playground, 10));
                mobs.Add(new Mobs("🧟", 8, 2, 10, 12, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 40, 18, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 30, 12, true, false, playground, 5));

                for (int i = 0; i < 4; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 15, 5, true, false, playground, 3));

                items.Add(new SpawnItems("❤️", 0, 0, 75, 10, 25, playground));
                items.Add(new SpawnItems("⚔️", 30, 0, 0, 30, 20, playground));
                items.Add(new SpawnItems("🛡️", 0, 30, 0, 55, 20, playground));
            }
            else if (room == 2)
            {
                items.Add(new SpawnItems("❤️", 0, 0, 75, 15, 10, playground));
                items.Add(new SpawnItems("💎", 30, 30, 150, 40, 15, playground));
            }
            else if (room == 3)
            {
                for (int i = 0; i < 3; i++)
                    mobs.Add(new Mobs("💀", 5, 1, 5 + i * 10, 10, true, false, playground, 3));

                mobs.Add(new Mobs("🧟", 8, 2, 15, 15, true, false, playground, 5));
                mobs.Add(new Mobs("🧟", 8, 2, 30, 12, true, false, playground, 5));
                mobs.Add(new Mobs("🗿", 20, 3, 20, 8, true, false, playground, 10));
                mobs.Add(new Mobs("👹", 30, 5, 25, 15, true, false, playground, 20));
                mobs.Add(new Mobs("🐉", 100, 12, 35, 15, true, false, playground, 25));

                items.Add(new SpawnItems("❤️", 0, 0, 75, 10, 25, playground));
                items.Add(new SpawnItems("⚔️", 35, 0, 0, 25, 20, playground));
                items.Add(new SpawnItems("🛡️", 0, 35, 0, 30, 25, playground));
                items.Add(new SpawnItems("💎", 25, 25, 75, 40, 25, playground));
            }
        }

        return mobs;
    }

    public static void StartMobsInRoom(
        int level, int room, string[,] map, Player player, Playground playground)
    {
        List<Mobs> mobs = CreateLevels(level, room, playground);
        roomCancellation = new CancellationTokenSource();

        foreach (Mobs mob in mobs)
        {
            map[mob.Y, mob.X] = mob.Name;
            _ = mob.MoveMobs(map, player, roomCancellation.Token);
        }

        foreach (SpawnItems item in items)
        {
            map[item.Y, item.X] = item.Name;
        }
    }

    public static void EnterSecondRoom(
        int level, int startX, int startY, Player player, Playground playground)
    {
        playground.level = level;
        playground.backToStartX = startX;
        playground.backToStartY = startY;
        playground.startMapIsActive = false;

        Console.Clear();

        playground.secondRoomIsActive = true;
        player.playerX = 30;
        player.playerY = 1;

        if (!playground.secondRoomMobsCreated)
        {
            playground.ShowRoom(playground.secondRoom);

            StartMobsInRoom(
                playground.level, 1, playground.secondRoom, player, playground);

            playground.secondRoomMobsCreated = true;
        }
    }

    public static void EnterRecoveryRoom(Player player, Playground playground)
    {
        playground.secondRoomIsActive = false;

        Console.Clear();

        playground.recoveryRoomIsActive = true;
        player.playerX = 45;
        player.playerY = 1;

        if (!playground.recoveryRoomMobsCreated)
        {
            playground.ShowRoom(playground.recoveryRoom);

            StartMobsInRoom(
                playground.level, 2, playground.recoveryRoom, player, playground);

            playground.recoveryRoomMobsCreated = true;
        }
    }

    public static void EnterThirdRoom(Player player, Playground playground)
    {
        playground.recoveryRoomIsActive = false;

        Console.Clear();

        playground.thirdRoomIsActive = true;
        player.playerX = 30;
        player.playerY = 1;

        if (!playground.thirdRoomMobsCreated)
        {
            playground.ShowRoom(playground.thirdRoom);

            StartMobsInRoom(
                playground.level, 3, playground.thirdRoom, player, playground);

            playground.thirdRoomMobsCreated = true;
        }
    }

    public static void ReturnToStartMap(Player player, Playground playground)
    {
        roomCancellation?.Cancel();

        playground.secondRoomIsActive = false;
        playground.recoveryRoomIsActive = false;
        playground.thirdRoomIsActive = false;
        playground.traderRoomIsActive = false;

        Console.Clear();

        playground.startMapIsActive = true;
        player.playerX = playground.backToStartX;
        player.playerY = playground.backToStartY;

        playground.secondRoomMobsCreated = false;
        playground.recoveryRoomMobsCreated = false;
        playground.thirdRoomMobsCreated = false;
    }

    public static void ReturnToSecondRoom(Player player, Playground playground)
    {
        roomCancellation?.Cancel();

        playground.recoveryRoomIsActive = false;

        Console.Clear();

        playground.secondRoomIsActive = true;
        player.playerX = 1;
        player.playerY = 22;
    }

    public static void ReturnToRecoveryRoom(Player player, Playground playground)
    {
        roomCancellation?.Cancel();

        playground.thirdRoomIsActive = false;

        Console.Clear();

        playground.recoveryRoomIsActive = true;
        player.playerX = 45;
        player.playerY = 1;
    }

    public static void EnterTraderRoom(Player player, Playground playground)
    {
        playground.startMapIsActive = false;
        playground.traderRoomIsActive = true;

        player.playerX = 45;
        player.playerY = 1;

        Console.Clear();

        playground.CreateTraderRoom();

        while (playground.traderRoomIsActive && player.healthPoints > 0)
        {
            playground.ShowRoom(playground.traderRoom);

            if (!Movement(player, playground.startMap, playground))
                return;

            if (player.playerY == 14)
            {
                if (player.playerX == 15)
                {
                    playground.BuyItem(player, 'A');
                    player.playerY = 15;
                }
                else if (player.playerX == 35)
                {
                    playground.BuyItem(player, 'S');
                    player.playerY = 36;
                }
                else if (player.playerX == 55)
                {
                    playground.BuyItem(player, 'L');
                    player.playerY = 56;
                }
                else if (player.playerX == 75)
                {
                    playground.BuyItem(player, 'T');
                    player.playerY = 76;
                }
            }
        }
    }

    public static void Main()
    {
        

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Player player = new Player();
        Playground playground = new Playground(player);

        ShowIntro();

        bool startMapInitialized = false;

        while (player.healthPoints > 0)
        {
            while (playground.startMapIsActive && player.healthPoints > 0)
            {
                if (!startMapInitialized)
                {
                    playground.GenerateMap();
                    startMapInitialized = true;
                }

                playground.ShowMap();

                if (!Movement(player, playground.startMap, playground))
                    return;

                if (player.playerX == 10 && player.playerY == 3)
                {
                    EnterSecondRoom(1, 10, 3, player, playground);
                }
                else if (player.playerX == 40 && player.playerY == 2)
                {
                    playground.backToStartX = 40;
                    playground.backToStartY = 2;

                    EnterTraderRoom(player, playground);
                }
                else if (player.playerX == 70 && player.playerY == 5)
                {
                    EnterSecondRoom(2, 70, 5, player, playground);
                }
                else if (player.playerX == 20 && player.playerY == 17)
                {
                    EnterSecondRoom(3, 20, 17, player, playground);
                }
                else if (player.playerX == 55 && player.playerY == 18)
                {
                    EnterSecondRoom(4, 55, 18, player, playground);
                }

                while (playground.secondRoomIsActive && player.healthPoints > 0)
                {
                    playground.ShowRoom(playground.secondRoom);

                    if (!Movement(player, playground.secondRoom, playground))
                        return;

                    if (player.playerX == 32 && player.playerY == 0)
                        ReturnToStartMap(player, playground);

                    if (player.playerX == 0 && player.playerY == 22)
                        EnterRecoveryRoom(player, playground);

                    while (playground.recoveryRoomIsActive && player.healthPoints > 0)
                    {
                        playground.ShowRoom(playground.recoveryRoom);

                        if (!Movement(player, playground.recoveryRoom, playground))
                            return;

                        if (player.playerX == 45 && player.playerY == 0)
                            ReturnToSecondRoom(player, playground);

                        if (player.playerX == 0 && player.playerY == 17)
                            EnterThirdRoom(player, playground);

                        while (playground.thirdRoomIsActive && player.healthPoints > 0)
                        {
                            playground.ShowRoom(playground.thirdRoom);

                            if (!Movement(player, playground.thirdRoom, playground))
                                return;

                            if (player.playerX == 35 && player.playerY == 0)
                                ReturnToRecoveryRoom(player, playground);

                            if (player.playerX == 0 && player.playerY == 27)
                                ReturnToRecoveryRoom(player, playground);
                        }
                    }
                }
            }
        }
    }
}
