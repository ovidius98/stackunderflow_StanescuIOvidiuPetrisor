using Access.Primitives.IO;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Dac.Model;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.Domain.Core.Contexts.Question.CreateReply;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionController: ControllerBase  
    {
        private readonly IInterpreterAsync _interpreter;

        public QuestionController(IInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }
            [HttpPost("create")]
            public async Task<AcceptedResult> CreateQuestion()
        {
            return Ok();-
        }
            
        [HttpPost("questionId/reply")]
        public async Task<ActionResult> CreateReply(int questionId)
        {
            //define data /get date

            var questionWriteContext = new QuestionWriteContext(new List<Post>());
            {
                new Post()
                {
                    PostId = 10
                };
            }

            var expr = from replyResult in QuestionDomain.CreateReply(questionId, "123")
                       select replyResult;

            var result = await _interpreter.Interpret(expr, questionWriteContext, new object());

            return result.Match(created => Ok(created),
                   notCreated => BadRequest(notCreated),
                   invalidRequest => ValidationProblem());
        }
    }
}
