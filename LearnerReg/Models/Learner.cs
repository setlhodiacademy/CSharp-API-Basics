namespace LearnerReg.Models
{
    public class Learner
    {
        public int LearnerId { get; set; }
        public string LearnerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Course? Course { get; set; }
    }
}
