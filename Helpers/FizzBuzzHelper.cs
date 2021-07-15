using FirstMVCApp.Models;

namespace FirstMVCApp.Helpers
{
    public class FizzBuzzHelper
    {
        public FizzBuzz GetResult(FizzBuzz fizzBuzz)
        {
            

            if (fizzBuzz.FizzValue < 1 || fizzBuzz.BuzzValue < 1) return fizzBuzz;

            int startValue = 1;
            int endValue = 100;
                        
            int fizzValue = fizzBuzz.FizzValue;
            int buzzValue = fizzBuzz.BuzzValue;
            int fbValue;

            FizzBuzz fbModel = new();
            fbModel.FizzValue = fizzValue;
            fbModel.BuzzValue = buzzValue;

            if (fizzValue == buzzValue)
            {
                fbValue = fizzValue;
            }
            else if (fizzValue % buzzValue == 0)
            {
                fbValue = fizzValue;
            }
            else if (buzzValue % fizzValue == 0)
            {
                fbValue = buzzValue;
            }
            else
            {
                fbValue = fizzValue * buzzValue;
            }



            for (var i = startValue; i <= endValue; i++)
            {
                if (i % fbValue == 0)
                {
                    fbModel.Result.Add("FizzBuzz");
                }
                else if (i % fizzValue == 0)
                {
                    fbModel.Result.Add("Fizz");
                }
                else if (i % buzzValue == 0)
                {
                    fbModel.Result.Add("Buzz");
                }
                else
                {
                    fbModel.Result.Add(i.ToString());
                }
            }

            return fbModel;
        }
    }
}
