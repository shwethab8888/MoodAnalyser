using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{

    // MoodAnalysisException Enum to differentiate errors
    public enum MoodAnalysisError
    {
        NULL_MOOD_ERROR,
        EMPTY_MOOD_ERROR
    }

    // Custom Exception class
    public class MoodAnalysisException : Exception
    {
        private readonly MoodAnalysisError error;

        public MoodAnalysisException(MoodAnalysisError error, string message) : base(message)
        {
            this.error = error;
        }

        public MoodAnalysisException(MoodAnalysisError error, string message, Exception innerException) : base(message, innerException)
        {
            this.error = error;
        }

        public MoodAnalysisError GetError()
        {
            return error;
        }
    }

    public class InvalidMood
    {
        private string message;

        public InvalidMood()
        {
            this.message = "";
        }

        public InvalidMood(string message)
        {
            if (message == null)
                throw new MoodAnalysisException(MoodAnalysisError.NULL_MOOD_ERROR, "Message cannot be null");
            else if (message.Length == 0)
                throw new MoodAnalysisException(MoodAnalysisError.EMPTY_MOOD_ERROR, "Message cannot be empty");

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

        public static void Invalid_Mood()
        {
            // Test case 1: Given Null Mood Should Throw MoodAnalysisException
            try
            {
                InvalidMood analyser = new InvalidMood(null);
            }
            catch (MoodAnalysisException ex)
            {
                Console.WriteLine(ex.Message + " Error: " + ex.GetError());
            }

            // Test case 2: Given Empty Mood Should Throw MoodAnalysisException
            try
            {
                InvalidMood analyser = new InvalidMood("");
            }
            catch (MoodAnalysisException ex)
            {
                Console.WriteLine(ex.Message + " Error: " + ex.GetError());
            }
        }
    }
}
