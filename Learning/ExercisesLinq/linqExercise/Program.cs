using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //You can get the trainee details from the GetTraineeDetails() method in TraineeData class
            Console.WriteLine("Enter Menu Number");
            int option = Convert.ToInt32(Console.ReadLine());
            TraineeDetails obj = new TraineeDetails();
            TraineeData ob1 = new TraineeData();
            List<TraineeDetails> b = ob1.GetTraineeDetails();

            //display IDs only   
            // var traineeId = b.Select(objectB => objectB.TraineeId).ToList();

            switch (option)
            {
                case 1:
                    {
                        b.Select(objectB => objectB.TraineeId).ToList().ForEach(x => Console.WriteLine(x));
                        break;
                    }
                case 2:
                    {
                        b.Take(3).Select(x => x.TraineeId).ToList().ForEach(x=> Console.WriteLine(x));
                        break;
                    }
                case 3:
                    {
                        b.Skip(b.Count() - 2).Select(x => x.TraineeId).ToList().ForEach(x=> Console.WriteLine(x));
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"Count of trainees: {b.Count()}");
                        break;
                    }
                case 5:
                    {
                        b.Where(passed => passed.YearPassedOut >= 2019).Select(trainee => trainee.TraineeName).ToList().ForEach(x => Console.WriteLine(x));
                        break;
                    }
                case 6:
                    {
                        b.OrderBy(bNames => bNames.TraineeName).ToList().ForEach(x => Console.WriteLine($"TraineeId: {x.TraineeId}\tTrainee Name: {x.TraineeName}"));
                        break;
                    }
                case 7:
                    {
                        var mark4 = b.Where(score => score.ScoreDetails.All(mark => mark.Mark >= 3)).ToList();
                        // mark4.ForEach(item => Console.WriteLine($"\nTrainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}\n{item.ScoreDetails}"));
                        foreach (var item in mark4)
                        {
                            Console.WriteLine($"\nTrainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}\n");
                            Console.WriteLine($"{"TopicName",-10}\t{"ExerciseName",-20}\t{"Mark",-10}\n{new String('-', 50)}");
                            foreach (var element in item.ScoreDetails)
                            {
                                Console.WriteLine($"{element.TopicName,-10}\t{element.ExerciseName,-20}\t{element.Mark,-10}");
                            }
                        }
                        break;
                    }
                case 8:
                    {
                        var distinctYearPassedOut = b.Select(x => x.YearPassedOut).Distinct();
                        foreach (var item in distinctYearPassedOut)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                case 9:
                    {
                        Console.Write("Enter Trainee ID: ");
                        string inputID = Console.ReadLine()!;
                        var res = b.Find(x => x.TraineeId == inputID);
                        if (res == null)
                        {
                            Console.WriteLine("Invalid Id");
                        }
                        else
                        {
                            var marks = res.ScoreDetails.Sum(x => x.Mark);
                            Console.WriteLine($"Total marks: {marks}");
                        }
                        break;
                    }
                case 10:
                    {
                        var first = b.Take(1);
                        foreach (var item in first)
                        {
                            Console.WriteLine($"Trainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}");
                        }
                        break;
                    }
                case 11:
                    {
                        var last = b.TakeLast(1);
                        foreach (var item in last)
                        {
                            Console.WriteLine($"Trainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}");
                        }
                        break;
                    }
                case 12:
                    {
                        foreach (var item in b)
                        {
                            Console.WriteLine($"Trainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}\t TotalScore: {item.TotalScore}");
                        }
                        break;
                    }
                case 13:
                    {
                        var maxMark = b.Select(x => x.TotalScore).Max();
                        Console.WriteLine($"Maximum Total score: {maxMark}");
                        break;
                    }
                case 14:
                    {
                        var minMark = b.Select(x => x.TotalScore).Min();
                        Console.WriteLine($"Minimum Total score: {minMark}");
                        break;
                    }
                case 15:
                    {
                        var averageMark = b.Select(x => x.TotalScore).Average();
                        Console.WriteLine($"Average Total score: {averageMark}");
                        break;
                    }
                case 16:
                    {
                        var isAnyMoreThan40 = b.Any(x => x.TotalScore > 40);
                        Console.WriteLine(isAnyMoreThan40);
                        break;
                    }
                case 17:
                    {
                        var scoresMoreThan20 = b.All(x => x.TotalScore > 20);
                        Console.WriteLine(scoresMoreThan20);
                        break;
                    }
                case 18:
                    {
                        var sortTrainees = b.OrderByDescending(trainee => trainee.TraineeName)
                        .Select(trainee => new
                        {
                            tId = trainee.TraineeId,
                            tName = trainee.TraineeName,
                            tScores = trainee.ScoreDetails.OrderByDescending(x => x.Mark)
                        });
                        foreach (var item in sortTrainees)
                        {
                            Console.WriteLine($"\nTrainee Id: {item.tId}\tTrainee Name: {item.tName}\n");
                            Console.WriteLine($"{"TopicName",-10}\t{"ExerciseName",-20}\t{"Mark",-10}\n{new String('-', 50)}");
                            foreach (var element in item.tScores)
                            {
                                Console.WriteLine($"{element.TopicName,-10}\t{element.ExerciseName,-20}\t{element.Mark,-10}");
                            }
                        }
                        break;
                    }


            }

        }
    }
}
