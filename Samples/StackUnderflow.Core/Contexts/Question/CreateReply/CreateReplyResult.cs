using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateReply
{
    [AsChoice] 
    public static partial class CreateReplyResult
    {
        public interface ICreateRelyResult {}

        public class ReplyCreated : ICreateRelyResult
        {
            public Post Post { get; }

            public ReplyCreated(Post post)
            {
                Post = post;

            }
            public class ReplyNotCreated : ICreateRelyResult
            {
                public string Reason { get; }

                public ReplyNotCreated(string reason)
                {
                    Reason = reason;
                }
            }

            public class InvalidRequest : ICreateRelyResult
            {
                public CreateReplyCmd Cmd { get; }

                public InvalidRequest(CreateReplyCmd cmd)
                {
                    Cmd = cmd;
                }
            }
        }

    }
}
