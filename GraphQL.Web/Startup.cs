using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL.Data;
using GraphQL.Types;
using GraphQL.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraphQL.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("BlogContext")));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<BlogStatsSchema>();
            services.AddSingleton<BlogsQuery>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new BlogStatsSchema(new FuncDependencyResolver(sp.GetService)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
