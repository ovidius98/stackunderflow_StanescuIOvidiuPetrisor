using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ZendeskApi_v2.Requests.HelpCenter;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateReply
{
    public class QuestionWriteContext
    {
        public QuestionWriteContext(ICollection<Post> posts)
        {
            Posts = posts;
        }

        public object Posts { get; internal set; }
    }
}
