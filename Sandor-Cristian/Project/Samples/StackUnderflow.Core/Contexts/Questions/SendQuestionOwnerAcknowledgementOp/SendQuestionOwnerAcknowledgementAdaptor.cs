using Access.Primitives.IO;
using GrainInterfaces;
using Orleans;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp;
using System;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp
{
    class SendQuestionOwnerAcknowledgementAdaptor : Adapter<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult, QuestionsWriteContext, QuestionsDependencies>
    {
        private readonly IClusterClient clusterClient;

        public SendQuestionOwnerAcknowledgementAdaptor(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        public override Task PostConditions(SendQuestionOwnerAcknowledgementCmd cmd, ISendQuestionOwnerAcknowledgementResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendQuestionOwnerAcknowledgementResult> Work(SendQuestionOwnerAcknowledgementCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>($"User{cmd.QuestionOwnerId}");
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "email");
            await stream.OnNextAsync($"user{cmd.QuestionOwnerId}@email.com");

            return new AcknowledgementSent(1, 2);
        }
    }
}
