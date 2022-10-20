class Program
{
    static readonly char[] cells = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the TicTacToe game!\nWhat is your name?");
        string name = Console.ReadLine();
        Console.Clear();
        PrintGame();
        Console.WriteLine($"{name}, you go first.");
        for (int i = 0; i < 4; i++)
        {
            UserChoice();
            ComputerChoice();
        }
        UserChoice();
        Console.WriteLine("It's a draw.");
    }
    static void PrintGame()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {cells[1]}  |  {cells[2]}  |  {cells[3]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {cells[4]}  |  {cells[5]}  |  {cells[6]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {cells[7]}  |  {cells[8]}  |  {cells[9]}");
        Console.WriteLine("     |     |      ");
    }
    static void VictoryCheck()
    {
        if (cells[1] + cells[2] + cells[3] == 264 // X = 88
         || cells[4] + cells[5] + cells[6] == 264
         || cells[7] + cells[8] + cells[9] == 264
         || cells[1] + cells[4] + cells[7] == 264
         || cells[2] + cells[5] + cells[8] == 264
         || cells[3] + cells[6] + cells[9] == 264
         || cells[1] + cells[5] + cells[9] == 264
         || cells[3] + cells[5] + cells[7] == 264)
        {
         Console.WriteLine("You are the winner!");
         Environment.Exit(0);
        }
        else if (cells[1] + cells[2] + cells[3] == 237 // O = 79
             || cells[4] + cells[5] + cells[6] == 237
             || cells[7] + cells[8] + cells[9] == 237
             || cells[1] + cells[4] + cells[7] == 237
             || cells[2] + cells[5] + cells[8] == 237
             || cells[3] + cells[6] + cells[9] == 237
             || cells[1] + cells[5] + cells[9] == 237
             || cells[3] + cells[5] + cells[7] == 237)
        {
         Console.WriteLine("You have lost.");
         Environment.Exit(0);
        }
    }
    static void UserChoice()
    {
        Console.WriteLine("Please choose a number.");
        bool exit = false;
        while (exit == false)
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int choice1); //verifying that a number is typed 
            while (!isNumber)
            {
                Console.WriteLine("Please enter a number from 1 to 9.");
                isNumber = int.TryParse(Console.ReadLine(), out choice1);
            }
            if (choice1 > 9 || choice1 < 1)  //verifying that the number is in range 
            {
                Console.WriteLine("Please enter a number from 1 to 9.");
                continue;
            }
            else if (cells[choice1] == 'O' || cells[choice1] == 'X') //verifying that the cell is vacant
            {
                Console.WriteLine("Cell is occupied. Please type a different number.");
                continue;
            }
            else
            {
                cells[choice1] = 'X';
                exit = true;
            }
        }
        Console.Clear();
        PrintGame();
        VictoryCheck();
    }
    static void ComputerChoice()
    {
        Random random = new();
        int choice2 = random.Next(1, 9);
        while (cells[choice2] == 'O' || cells[choice2] == 'X')  //verifying that the cell is vacant
        {
            choice2 = random.Next(1, 9);
        }
        cells[choice2] = 'O';
        Console.Clear();
        PrintGame();
        VictoryCheck();
    }
}