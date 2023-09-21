using Quest;

Random ran = new Random();

// Create a few challenges for our Adventurer's quest
// The "Challenge" Constructor takes three arguments
//   the text of the challenge
//   a correct answer
//   a number of awesome points to gain or lose depending on the success of the challenge
Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
Challenge theAnswer = new Challenge(
    "What's the answer to life, the universe and everything?", 42, 25);
Challenge whatSecond = new Challenge(
    "What is the current second?", DateTime.Now.Second, 50);

int randomNumber = new Random().Next() % 10;
Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

Challenge favoriteBeatle = new Challenge(
    @"Who's your favorite Beatle?
1) John
2) Paul
3) George
4) Ringo
",
    4, 20
);

Challenge canYouRead = new("What is this number? -> 4", 4, 5);

Challenge squareRoot = new("What is the square root of 25?", 5, 25);

// "Awesomeness" is like our Adventurer's current "score"
// A higher Awesomeness is better

// Here we set some reasonable min and max values.
//  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
//  If an Adventurer has an Awesomeness less than the min, they are terrible
int minAwesomeness = 0;
int maxAwesomeness = 100;

// A list of challenges for the Adventurer to complete
// Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
List<Challenge> challenges = new List<Challenge>()
{
    twoPlusTwo,
    theAnswer,
    whatSecond,
    guessRandom,
    favoriteBeatle,
    canYouRead,
    squareRoot
};

// create list of strings
var colors = new List<string> {
    "red",
    "white",
    "blue"
};

// create a Robe object
Robe advRobe = new Robe()
{
    Colors = colors,
    Length = 60
};

//create a Hat object
Hat advHat = new()
{
    ShininessLevel = 5
};

// create an instance of a Prize
Prize advPrize = new("1GP");

// prompt user for a name
Console.WriteLine("What is your adventurer's name?");
string advName = Console.ReadLine();

// check for replay
string choice = null;

// Make a new "Adventurer" object using the "Adventurer" class
Adventurer theAdventurer = new Adventurer(advName, advRobe, advHat);

while (choice != "no") {
choice = null;

// Print description of adventurer
Console.WriteLine(theAdventurer.GetDescription());

// create an empty list of challenges (outside while loop)
List<Challenge> randomChallenges = new();
// Pick 5 random Challenges
// get whole list of challenges
// pick a challenge and store it in empty list (while loop) -> if the challenge found is already found continue
while (randomChallenges.Count < 5)
{
    int r = ran.Next(0, challenges.Count);

    Challenge foundChallenge = challenges[r];

    // challenges.Remove(foundChallenge);
    // randomChallenges.Add(foundChallenge);

    if(!randomChallenges.Contains(foundChallenge))
    {
        randomChallenges.Add(foundChallenge);
    }
}
// pick another challenge that hasn't been chosen
// store it in the same place
// return list of randomly selected challenges

Console.WriteLine($"Your awesomeness is at {theAdventurer.Awesomeness}");
Console.WriteLine($"Successes: {theAdventurer.Successes}");
// Loop through all the challenges and subject the Adventurer to them
foreach (Challenge challenge in randomChallenges)
{
    challenge.RunChallenge(theAdventurer);
    Console.WriteLine($"Your awesomeness is at {theAdventurer.Awesomeness}");
    Console.WriteLine($"Successes: {theAdventurer.Successes}");
}

// This code examines how Awesome the Adventurer is after completing the challenges
// And praises or humiliates them accordingly
if (theAdventurer.Awesomeness >= maxAwesomeness)
{
    Console.WriteLine("YOU DID IT! You are truly awesome!");
}
else if (theAdventurer.Awesomeness <= minAwesomeness)
{
    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
}
else
{
    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
}
advPrize.ShowPrize(theAdventurer);
while (choice != "yes" && choice != "no")
    {
        Console.WriteLine("Would you like to play again? (yes/no)");
        choice = Console.ReadLine();
        if (choice == "no")
        {
            Console.WriteLine("Thank you for playing!");
        }
        else if (choice != "yes") 
        {
            Console.WriteLine("Please only type yes or no");
        }
    }
}
