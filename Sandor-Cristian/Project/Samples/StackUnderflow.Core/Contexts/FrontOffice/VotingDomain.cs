using Access.Primitives.IO;
using StackUnderflow.Domain.Schema.Voting.VoteUpOp;
using System;
using System.Collections.Generic;
using System.Text;
using static StackUnderflow.Domain.Schema.Voting.VoteResult;
using static PortExt;
using StackUnderflow.Domain.Schema.Voting.VoteDownOp;
using StackUnderflow.Domain.Schema.Voting.CancelVoteOp;
using StackUnderflow.Domain.Schema.Questions.MarkAsReadOp;
using static StackUnderflow.Domain.Schema.Questions.MarkAsReadOp.MarkAsViewedResult;

namespace StackUnderflow.Domain.Core.Contexts.FrontOffice
{
    public static class VotingDomain
    {
        public static Port<IVoteResult> VoteUp(int tenantId, Guid userId, int questionId) =>
            NewPort<VoteUpCmdInternal, IVoteResult>(new VoteUpCmdInternal(tenantId, userId, questionId));

        public static Port<IVoteResult> VoteDown(int tenantId, Guid userId, int questionId) =>
            NewPort<VoteDownCmdInternal, IVoteResult>(new VoteDownCmdInternal(tenantId, userId, questionId));

        public static Port<IVoteResult> CancelVote(int tenantId, Guid userId, int questionId) =>
            NewPort<CancelVoteCmdInternal, IVoteResult>(new CancelVoteCmdInternal(tenantId, userId, questionId));

        public static Port<IMarkAsViewedResult> MarkAsViewed(int tenantId, Guid userId, int questionId) =>
            NewPort<MarkAsViewedCmd, IMarkAsViewedResult>(new MarkAsViewedCmd(tenantId, userId, questionId));

    }
}
