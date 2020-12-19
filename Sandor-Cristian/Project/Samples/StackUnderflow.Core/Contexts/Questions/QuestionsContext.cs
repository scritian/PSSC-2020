using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionsOp;
using StackUnderflow.Domain.Schema.Questions.CheckLanguageOp;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionsOp.CreateQuestionsResult;
using static StackUnderflow.Domain.Schema.Questions.CheckLanguageOp.CheckLanguageResult;
using static StackUnderflow.Domain.Schema.Questions.CreateAnswerOp.CreateReplyResult;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;
using static StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionsContext
    {
        public static Port<ICreateQuestionsResult> CreateQuestion(CreateQuestionsCmd createQuestionsCmd) =>
            NewPort<CreateQuestionsCmd, ICreateQuestionsResult>(createQuestionsCmd);
        public static Port<ICreateReplyResult> CreateReply(CreateReplyCmd createReplyCmd) =>
           NewPort<CreateReplyCmd, ICreateReplyResult>(createReplyCmd);

        public static Port<ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd) =>
            NewPort<CheckLanguageCmd, ICheckLanguageResult>(checkLanguageCmd);

        public static Port<ISendQuestionOwnerAcknowledgementResult> SendQuestionOwnerAcknowledgement(SendQuestionOwnerAcknowledgementCmd cmd) =>
            NewPort<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult>(cmd);

        public static Port<ISendReplyAuthorAcknowledgementResult> SendQuestionAuthorAcknowledgement(SendQuestionAuthorAcknowledgementCmd cmd) =>
           NewPort<SendQuestionAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult>(cmd);
    }
}
