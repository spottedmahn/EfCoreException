using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Data.Tests
{
    public class IntegrationTest1
    {
        [Fact]
        public async Task MyDbContext_MultipleAsyncs_GeneratesException()
        {
            //arrange
            using (var db = CreateDb())
            {

                //act
                var task1 = db.MyEntities.Where(r => r.Name == "Blah").ToListAsync();
                var task2 = db.MyEntities.Where(r => r.Name == "Blah2").ToListAsync();

                var tasks = new Task[] { task1, task2 };

                //assert
                //2017/04/26 - 11:10AM EST
                //it is only throwing this exception when the debugger is attached
                //2017/04/26 - 11:15AM EST
                //apparenlty it is only throwing an exception when it is the first test run
                //doesn't fail when it is the second test run
                var ex = await Assert.ThrowsAsync<NullReferenceException>(async () => await Task.WhenAll(tasks));
            }
        }

        //[Fact]
        public async Task MyDbContext_MultipleAsyncs_NoException()
        {
            //arrange
            using (var db = CreateDb())
            {

                //act

                //perform one async task then multiple and no exception is produced
                var blah = await db.MyEntities.ToListAsync();

                var task1 = db.MyEntities.Where(r => r.Name == "Blah").ToListAsync();
                var task2 = db.MyEntities.Where(r => r.Name == "Blah2").ToListAsync();

                var tasks = new Task[] { task1, task2 };

                await Task.WhenAll(tasks);

                //assert
            }
        }

        private static MyDbContext CreateDb()
        {
            //new config
            var configBuilder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = configBuilder.Build();

            //new db options builder
            var dbOptionsBlder = new DbContextOptionsBuilder<MyDbContext>();
            dbOptionsBlder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            //new db context
            var db = new MyDbContext(dbOptionsBlder.Options);
            return db;
        }
    }
}
