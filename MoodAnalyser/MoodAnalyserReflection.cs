using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyserReflection
    {
        private string message;

       // public static object Assert { get; private set; }

        public MoodAnalyserReflection()
        {
            this.message = "I am in a happy mood";
        }

        public MoodAnalyserReflection(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            if (string.IsNullOrEmpty(message) || message.ToLower().Contains("happy"))
                return "HAPPY";
            else
                return "SAD";
        }

        public static void MoodAnalyser_Reflection()
        {
            try
            {
                // create mood analyser object using factory method
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserReflection", "MoodAnalyserReflection");

                // cast the object to MoodAnalyserReflection class
                MoodAnalyserReflection moodAnalyser = (MoodAnalyserReflection)moodAnalyserObject;

                // analyse the mood
                string mood = moodAnalyser.AnalyseMood();
                Console.WriteLine("Mood: " + mood);
            }
            catch (MoodAnalyserException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string fullName = className + "." + constructorName;
            Type type = Type.GetType(fullName);

            try
            {
                object moodAnalyserObject = Activator.CreateInstance(type);
                return moodAnalyserObject;
            }
            catch (ArgumentNullException)
            {
                throw new MoodAnalyserException("Class name cannot be null or empty", MoodAnalyserException.ExceptionType.NULL_MESSAGE);
            }
            catch (ArgumentException)
            {
                throw new MoodAnalyserException("Class not found", MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND);
            }
            catch (MissingMethodException)
            {
                throw new MoodAnalyserException("Constructor not found", MoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND);
            }
        }
    }

    public class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            METHOD_INVOCATION_ISSUE,
            NO_SUCH_FIELD,
            NULL_MESSAGE,
            EMPTY_MESSAGE
        }

        public ExceptionType type;
        public MoodAnalyserException(string message, ExceptionType type) : base(message)
        {
            this.type = type;
        }
    }
}
