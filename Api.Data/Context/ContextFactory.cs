using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        MyContext IDesignTimeDbContextFactory<MyContext>.CreateDbContext(string[] args)
        {
            var conectionString = "Server=localhost; Port=3306;Database=dbAPI;Uid=root;Pwd=root";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();

            optionBuilder.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));

            return new MyContext(optionBuilder.Options);
        }
    }
}
