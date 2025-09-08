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
                        b.Take(3).Select(x => x.TraineeId).ToList().ForEach(x => Console.WriteLine(x));
                        break;
                    }
                case 3:
                    {
                        b.Skip(b.Count() - 2).Select(x => x.TraineeId).ToList().ForEach(x => Console.WriteLine(x));
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
                        b.Where(score => score.ScoreDetails.All(mark => mark.Mark >= 4)).ToList().ForEach(item =>
                        {
                            Console.WriteLine($"\nTrainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}\n");
                            Console.WriteLine($"{"TopicName",-10}\t{"ExerciseName",-20}\t{"Mark",-10}\n{new String('-', 50)}");
                            item.ScoreDetails.ToList().ForEach(element => Console.WriteLine($"{element.TopicName,-10}\t{element.ExerciseName,-20}\t{element.Mark,-10}"));
                        });
                        break;
                    }
                case 8:
                    {
                        b.Select(x => x.YearPassedOut).Distinct().ToList().ForEach(item => Console.WriteLine(item));
                        break;
                    }
                case 9:
                    {
                        Console.Write("Enter Trainee ID: ");
                        var res = b.Find(x => x.TraineeId == Console.ReadLine()!);
                        if (res != null)
                            Console.WriteLine($"Total marks: {res.ScoreDetails.Sum(x => x.Mark)}");
                        else
                            Console.WriteLine("Invalid Id");

                        break;
                    }
                case 10:
                    {
                        b.Take(1).ToList().ForEach(item => Console.WriteLine($"Trainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}"));
                        break;
                    }
                case 11:
                    {
                        b.TakeLast(1).ToList().ForEach(item => Console.WriteLine($"Trainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}"));
                        break;
                    }
                case 12:
                    {
                        b.ForEach(item => Console.WriteLine($"Trainee Id: {item.TraineeId}\tTrainee Name: {item.TraineeName}\t TotalScore: {item.TotalScore}"));
                        break;
                    }
                case 13:
                    {
                        Console.WriteLine($"Maximum Total score: {b.Select(x => x.TotalScore).Max()}");
                        break;
                    }
                case 14:
                    {
                        Console.WriteLine($"Minimum Total score: {b.Select(x => x.TotalScore).Min()}");
                        break;
                    }
                case 15:
                    {
                        Console.WriteLine($"Average Total score: {b.Select(x => x.TotalScore).Average()}");
                        break;
                    }
                case 16:
                    {
                        Console.WriteLine(b.Any(x => x.TotalScore > 40));
                        break;
                    }
                case 17:
                    {
                        Console.WriteLine(b.All(x => x.TotalScore > 20));
                        break;
                    }
                case 18:
                    {
                        b.OrderByDescending(trainee => trainee.TraineeName)
                        .Select(trainee => new
                        {
                            tId = trainee.TraineeId,
                            tName = trainee.TraineeName,
                            tScores = trainee.ScoreDetails.OrderByDescending(x => x.Mark)
                        }).ToList().ForEach(item =>
                        {
                            Console.WriteLine($"\nTrainee Id: {item.tId}\tTrainee Name: {item.tName}\n");
                            Console.WriteLine($"{"TopicName",-10}\t{"ExerciseName",-20}\t{"Mark",-10}\n{new String('-', 50)}");
                            item.tScores.ToList().ForEach(element => Console.WriteLine($"{element.TopicName,-10}\t{element.ExerciseName,-20}\t{element.Mark,-10}"));
                        });
                        
                        break;
                    }


            }

        }
    }
}
