using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Question.CreateReply;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;


namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public static class QuestionDomain
    {
        public static Port<CreateReplyResult.ICreateRelyResult> CreateReply(int questionId, string reply)
        => NewPort<CreateReplyCmd, CreateReplyResult.ICreateRelyResult>(new CreateReplyCmd(questionId, reply));

    }
}
