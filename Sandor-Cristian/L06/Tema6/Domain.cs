using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;
using Tema6.Inputs;
using Tema6.Outputs;
using static PortExt;

namespace Tema6
{
    public static class BoundedContextDSL
    {

        /// <summary>
        /// CreateReplyCmd -> ICreateReplyResult
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="userId"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static Port<CreateReplyResult.ICreateReplyResult> ValidateReply(int questionId, int userId, string answer)
            => NewPort<CreateReplyCmd, CreateReplyResult.ICreateReplyResult>(new CreateReplyCmd(userId, questionId, answer));

        public static Port<CheckLanguageResult.ICheckLanguageResult> CheckLanguage(string text)
            => NewPort<CheckLanguageCmd, CheckLanguageResult.ICheckLanguageResult>(new CheckLanguageCmd(text));

        public static Port<SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult> SendAckToQuestionOwner(int replyid, int questionid, string answer)
       => NewPort<SendAckToQuestionOwnerCmd, SendAckToQuestionOwnerResult.ISendAckToQuestionOwnerResult>(new SendAckToQuestionOwnerCmd(replyid, questionid, answer));

        public static Port<SendAckToReplyAuthorResult.ISendAskToReplyAuthorResult> SendAckToReplyAuthor(int replyid, int questionid, string answer)
        => NewPort<SendAckToReplyAuthorCmd, SendAckToReplyAuthorResult.ISendAskToReplyAuthorResult>(new SendAckToReplyAuthorCmd(replyid, questionid, answer));

        public static Port<Unit> SendAckToOwner(object safeReply) => NewPort<Unit, Unit>(Unit.Default);

        public static Port<Unit> SendAckToAuthor(object problematicReply) => NewPort<Unit, Unit>(Unit.Default);


    }
}
