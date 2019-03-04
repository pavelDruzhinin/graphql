using System;
using System.Threading.Tasks;
using GraphQL.Http;
using GraphQL.Types;

namespace GraphQL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        private static async Task Run()
        {
            var schema = new Schema { Query = new BaseQuery() };
            var result = await new DocumentExecuter().ExecuteAsync( _ =>
            {
                _.Schema = schema;
                _.Query = @"
                query {
                  base {
                    id
                    name
                  }
                }
              ";
            }).ConfigureAwait(false);

            var json = new DocumentWriter(indent: true).Write(result);

            System.Console.WriteLine(json);
        }
    }

    public class BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class BaseDtoType : ObjectGraphType<BaseDto>
    {
        public BaseDtoType()
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
        }
    }

    public class BaseQuery : ObjectGraphType
    {
        public BaseQuery()
        {
            Field<BaseDtoType>(
                "base",
                resolve: context => new BaseDto { Id = 1, Name = "1234" });
        }
    }
}
