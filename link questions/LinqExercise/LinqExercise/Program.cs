using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //You can get the trainee details from the GetTraineeDetails() method in TraineeData class
            Console.WriteLine("Enter Menu Number");
            int option = Convert.ToInt32(Console.ReadLine());
            TraineeDetails obj = new TraineeDetails();
            TraineeData ob1 = new TraineeData();
            List<TraineeDetails> b = ob1.GetTraineeDetails();

            var traineeId = b.Select(objectB => objectB.TraineeId).ToList();
            

            switch (option)
            {
                case 1:
                    {
                        foreach (var item in traineeId)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                case 2:
                    {

                        break;
                    }

            }
           
        }
    }
}
