using LearnerReg.Models;
using LearnerReg.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LearnerReg.Controllers
{
    [Route("api/learner")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        [HttpGet]
        public List<Learner> GetLearners()
        {
            return GetListOfLearners();       
        }

        [HttpGet("{learnerNumber}")]
        public Learner GetLearner(string learnerNumber)
        {
            var learners = GetListOfLearners();
            return learners.FirstOrDefault(l => l.LearnerNumber == learnerNumber);
        }

        [HttpPost]
        public List<Learner> CreateLearner([FromBody] Learner learner)
        {
            var learners = GetListOfLearners();
            learner.LearnerId = learners.Count + 1;
            learners.Add(learner);

            var learnerJson = JsonSerializer.Serialize(learners);
            StorageService.Save(learnerJson);
            return learners;
        }

        private static List<Learner> GetListOfLearners()
        {
            return new List<Learner>
            {
                new Learner
                {
                    LearnerId = 1,
                    LearnerNumber = "LS001",
                    FirstName = "Letlhogonolo",
                    LastName = "Setlhodi",
                    Course = new Course
                    {
                        CourseId = 1,
                        CourseCode = "IP001",
                        CourseName = "Introduction to Programming"
                    }
                },

                new Learner
                {
                    LearnerId = 1,
                    LearnerNumber = "IT001",
                    FirstName = "Itumeleng",
                    LastName = "Setlhodi",
                    Course = new Course
                    {
                        CourseId = 1,
                        CourseCode = "IP001",
                        CourseName = "Introduction to Programming"
                    }
                }
            };

        }
    }
}
