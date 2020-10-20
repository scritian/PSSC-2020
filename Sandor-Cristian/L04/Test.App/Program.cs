using Profile.Domain.CreateProfileWorkflow;
using Question.Domain.CreateQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Profile.Domain.CreateProfileWorkflow.CreateProfileResult;
using static Question.Domain.CreateQuestionWorkflow.CreateQuestionResult;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmdProfile = new CreateProfileCmd("Ion", string.Empty, "Ionescu", "ion.inonescu@company.com");
            var cmdQuestion = new CreateQuestionCmd("Ce faci?", "O simpla intrebare.", "LifeStyle");
            var resultProfile = CreateProfile(cmdProfile);
            var resultQuestion = CreateQuestion(cmdQuestion);

            resultProfile.Match(
                    ProcessProfileCreated,
                    ProcessProfileNotCreated,
                    ProcessInvalidProfile
                );

            resultQuestion.Match(
                    ProcessQuestionCreated,
                    ProcessQuestionNotCreated,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        //Profile
        private static ICreateProfileResult ProcessInvalidProfile(ProfileValidationFailed validationErrors)
        {
            Console.WriteLine("Profile validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateProfileResult ProcessProfileNotCreated(ProfileNotCreated profileNotCreatedResult)
        {
            Console.WriteLine($"Profile not created: {profileNotCreatedResult.Reason}");
            return profileNotCreatedResult;
        }

        private static ICreateProfileResult ProcessProfileCreated(ProfileCreated profile)
        {
            Console.WriteLine($"Profile {profile.ProfileId}");
            return profile;
        }

        public static ICreateProfileResult CreateProfile(CreateProfileCmd createProfileCommand)
        {
            if (string.IsNullOrWhiteSpace(createProfileCommand.EmailAddress))
            {
                var errors = new List<string>() { "Invlaid email address" };
                return new ProfileValidationFailed(errors);
            }

            if(new Random().Next(10) > 1)
            {
                return new ProfileNotCreated("Email could not be verified");
            }

            var profileId = Guid.NewGuid();
            var result = new ProfileCreated(profileId, createProfileCommand.EmailAddress);

            //execute logic
            return result;
        }

        //Question
        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateQuestionResult ProcessQuestionNotCreated(QuestionNotCreated questionNotCreatedResult)
        {
            Console.WriteLine($"Question not created: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }

        private static ICreateQuestionResult ProcessQuestionCreated(QuestionCreated question)
        {
            Console.WriteLine($"Question {question.QuestionId}");
            return question;
        }

        public static ICreateQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(createQuestionCommand.Title))
            {
                var errors = new List<string>() { "Invalid title" };
                return new QuestionValidationFailed(errors);
            } else if (string.IsNullOrWhiteSpace(createQuestionCommand.Body))
            {
                var errors = new List<string>() { "Invalid body (invalid description)" };
                return new QuestionValidationFailed(errors);
            } else if (string.IsNullOrWhiteSpace(createQuestionCommand.Tag))
            {
                var errors = new List<string>() { "Invalid tag" };
                return new QuestionValidationFailed(errors);
            }

            if (new Random().Next(10) > 1)
            {
                return new QuestionNotCreated("Question could not be verified");
            }

            var questionId = Guid.NewGuid();
            var resultQuestion = new QuestionCreated(questionId, createQuestionCommand.Title);

            //execute logic
            return resultQuestion;
        }
    }
}
