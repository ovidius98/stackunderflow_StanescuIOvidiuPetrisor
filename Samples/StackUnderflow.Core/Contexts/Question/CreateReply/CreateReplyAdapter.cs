using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateReply
{
    public class CreateReplyAdapter : Adapter<CreateReplyCmd, CreateReplyResult.ICreateRelyResult>
    {
 
    public override Task PostConditions(CreateReplyCmd cmd, CreateReplyResult.ICreateRelyResult result, object state)
        {
            return Task.CompletedTask;
        }

        public override Task<CreateReplyResult.ICreateRelyResult> Work(CreateReplyCmd cmd, object state, object dependencies)
        {
            var questionWriteContext = (QuestionWriteContext)state;

            if (!questionWriteContext.Posts.Any(p=>p.PostId==cmd.QuestionId))
                return new CreateReplyResult.ReplyNotCreated($"Question with id {cmd.QuestionId} does nnot exist");

            var question = questionWriteContext.Posts.First(p => p.PostId == cmd.QuestionId);
            
            var reply = new Post()
            {
                PostText = cmd.Reply 
            };

            question.inversePostnavigation.Add(reply);

            return new CreateReplyResult.ReplyCreated(reply);
        }
    }

}
