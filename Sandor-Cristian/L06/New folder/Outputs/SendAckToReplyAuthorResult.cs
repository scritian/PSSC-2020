using System;
using System.Collections.Generic;

namespace L06.Outputs
{
    public static partial class SendAckToReplyAuthorResult
    {
        public interface ISendAskToReplyAuthorResult { };
        public class ReplyPublished : ISendAskToReplyAuthorResult
        {
            public string ConfirmationMessage { get; private set; }
            public ReplyPublished(string confirmationMessage)
            {
                ConfirmationMessage = confirmationMessage;
            }
        }
        public class InvalidReplyPublished : ISendAskToReplyAuthorResult
        {
            public string ErrorMessage { get; private set; }
            public InvalidReplyPublished(string errormessage)
            {
                ErrorMessage = errormessage;
            }
        }
    }
}