using System.Collections.Generic;
using GraphQL.Data;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using GraphQL.Data;
using System.Linq;

namespace GraphQL.Web.Models
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389
    }

    public class BlogStatsSchema : Schema
    {
        public BlogStatsSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BlogsQuery>();
        }
    }

    public class BlogsQuery : ObjectGraphType
    {
        public BlogsQuery(BlogContext db)
        {
            Field<BaseDtoType>(
                "base",
                resolve: context =>
                    new BaseDto()
                    {
                        Id = 1,
                        Name = "Test"
                    });
            // Field<PlayerType>(
            //     "player",
            //     arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //     resolve: context =>  playerRepository.Get(context.GetArgument<int>("id")));

            // Field<PlayerType>(
            //     "randomPlayer",
            //     resolve: context => playerRepository.GetRandom());

            // Field<ListGraphType<BlogPostType>>(
            //     "blogposts",
            //     resolve: context => new List<BlogPost>{ new BlogPost(1,"Title 1", "Body 1") { Categories = new List<BlogsCategories>()}});
        }
    }

    public class BlogPostType : ObjectGraphType<BlogPost>
    {
        public BlogPostType()
        {
            Field(x => x.Id, true);
            Field(x => x.Title, true);
            Field(x => x.Body, true);
            Field(x => x.CreatedUtcDateTime);
            Field(x => x.Categories, true);
            //Field<ListGraphType<SkaterStatisticType>>(x => x.Categories, true, resolve: x => new List<BlogsCategories>());

            ;
        }
    }

    public class BaseDtoType : ObjectGraphType<BaseDto>
    {
        public BaseDtoType()
        {
            Field(x => x.Id).Description("Id base");
            Field(x => x.Name, true).Description("Base name");
        }
    }

    public class BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}