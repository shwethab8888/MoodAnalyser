using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        private string message;

       
        public MoodAnalyser()
        {
            this.message = "";
        }

        public MoodAnalyser(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message), "Message cannot be null");

            this.message = message;
        }

        public string AnalyseMood()
        {
            if (message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }

        public static void Mood_Analyser()
        {
            // Test Case 1
            MoodAnalyser moodAnalyser1 = new MoodAnalyser("I am in Sad Mood");
            Console.WriteLine(moodAnalyser1.AnalyseMood()); 

            // Test Case 2
            MoodAnalyser moodAnalyser2 = new MoodAnalyser("I am in Any Mood");
            Console.WriteLine(moodAnalyser2.AnalyseMood()); 

            try
            {
                MoodAnalyser moodAnalyser3 = new MoodAnalyser(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message); 
            }
        
        }
    }
}
