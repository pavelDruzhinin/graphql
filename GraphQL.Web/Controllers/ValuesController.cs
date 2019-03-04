using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQL.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Web.Controllers
{
    public class ValuesController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        
        public ValuesController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }
        
        [HttpPost("graphql")]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
