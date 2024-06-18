Random random = new Random();
DiceRoll diceRoll = new DiceRoll(random);
PlayDiceGame playDiceGame = new PlayDiceGame(diceRoll);

Console.WriteLine(playDiceGame.PlayGame());


public class DiceRoll
{
    private const int diceSizes = 6;
    private readonly Random _random;

    public DiceRoll(Random random)
    {
        _random = random;
    }

    public int ThrowDiceRoll()
    {
        return _random.Next(1, diceSizes+1);
    }

    public string DiceDescription()
    {
        return $"This dice have {diceSizes}, good luck to get the chose one ;)";
    }
}


//TODO: try to make this more easier, we can't have the enter of the value (Console.ReadLine) here, try to make another class when all the logic can make sense and well be all in the same spot 
public static class UserNumber
{
    public static int GettingNumber()
    {
        string? _userInput;
        
        Console.WriteLine("Please enter a number between 1 and 6:");
        _userInput = Console.ReadLine();
        
        int.TryParse(_userInput, out int userNumber);
     
        return userNumber;
    }
}



public class PlayDiceGame
{
    private readonly DiceRoll _diceRoll;
    public PlayDiceGame(DiceRoll diceRoll)
    {
        _diceRoll = diceRoll;
    }

    public string PlayGame()
    {
        int _userNumber,_diceNumber,counter=0,trysLeft=2;
        
        Console.WriteLine(_diceRoll.DiceDescription());
        
        do
        {
            _userNumber = UserNumber.GettingNumber();
            _diceNumber = _diceRoll.ThrowDiceRoll();
        
            if (_userNumber == _diceNumber)
            {
                return $"Winner Winner Chicken Dinner!";
            }
            //else
            Console.WriteLine($"That's not the correct number, you have {trysLeft} trys left");

            trysLeft--;
            counter++;
        } while (counter<3);

        return $"Sorry buddy YOU LOSE.....";
    }
}