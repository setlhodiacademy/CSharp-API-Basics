using LearnerReg.Models;
using System.Text.Json;

namespace LearnerReg.Services
{
    public class StorageService
    {
        public static void Save(string learners)
        {
            Directory.CreateDirectory("Data");
            File.WriteAllText("Data/learners.json", learners);
        }

        public static List<Learner> Get()
        {
            var learnersString = File.ReadAllText("Data/learners.json");
            var learners = JsonSerializer.Deserialize<List<Learner>>(learnersString);
            return learners;
        }

        public static Learner Get(string learnerNumber)
        {
            return Get().FirstOrDefault(l => l.LearnerNumber == learnerNumber);
        }


    }
}
