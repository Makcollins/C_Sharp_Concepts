using LearnLibrary;

Console.WriteLine("Enter firstname: ");
string firstname = Console.ReadLine();

Console.WriteLine("Enter last name: ");
string lastname = Console.ReadLine();

string fullname = PersonProcessor.JoinName(firstname, lastname);

Console.WriteLine($"Full name is : {fullname}" );