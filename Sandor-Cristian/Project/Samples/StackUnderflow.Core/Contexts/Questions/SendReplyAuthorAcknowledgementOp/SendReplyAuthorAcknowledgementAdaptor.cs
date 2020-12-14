using Access.Primitives.IO;
using GrainInterfaces;
using Orleans;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendReplyAuthorAcknowledgementOp
{
    class SendReplyAuthorAcknowledgementAdaptor : Adapter<SendQuestionAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult, QuestionsWriteContext, QuestionsDependencies>
    {
        private readonly IClusterClient clusterClient;

        public SendReplyAuthorAcknowledgementAdaptor(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
        public override Task PostConditions(SendQuestionAuthorAcknowledgementCmd cmd, ISendReplyAuthorAcknowledgementResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendReplyAuthorAcknowledgementResult> Work(SendQuestionAuthorAcknowledgementCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            /*
            var helloGrain = this.clusterClient.GetGrain<IHello>(0);

            var helloResult = await helloGrain.SayHello("My hello greeting");

            return new AcknowledgementSent(1, 2);*/

            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>($"User{cmd.ReplyAuthorId}");
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "email");
            await stream.OnNextAsync($"user{cmd.ReplyAuthorId}@email.com");

            return new AcknowledgementSent(1, 2);
        }
    }
}