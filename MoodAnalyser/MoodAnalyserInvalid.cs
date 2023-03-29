using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyserInvalid
    {
        private string message;

        // Default constructor
        public MoodAnalyserInvalid()
        {
            this.message = "";
        }

        // Parameterized constructor
        public MoodAnalyserInvalid(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message), "Message cannot be null");

            this.message = message;
        }

        public string AnalyseMood()
        {
            try
            {
                if (string.IsNullOrEmpty(message) || message.ToLower().Contains("happy"))
                    return "HAPPY";
                else
                    return "SAD";
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return "HAPPY";
            }
        }

        public static void MoodAnalyser_Invalid()
        {
            // Test case 1: Given Null Mood Should Return Happy
            try
            {
                MoodAnalyserInvalid analyser = new MoodAnalyserInvalid(null);
                Console.WriteLine(analyser.AnalyseMood());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
