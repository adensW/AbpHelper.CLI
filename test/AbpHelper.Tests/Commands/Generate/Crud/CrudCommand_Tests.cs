using EasyAbp.AbpHelper.Core.Commands.Generate.Crud;
using System;
using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyApp.AbpHelper.Tests.Commands.Generate.Crud;
public class CrudCommand_Tests: CommandTestsBase
{
  
    [Fact]
    public async Task Should_Crud_Correct()
    {   
        var _crudCommand=GetRequiredService<CrudCommand>();
        await _crudCommand.RunCommand(new CrudCommandOption
        {
            Entity="Bookmark",
            Directory= @"C:\Users\wangdingchen\Repos\Adens\Woo\Ego\modules\navigator",
            SeparateDto= true,
            SkipDbMigrations= true,
            ProjectName="Navigator",
            Subname="Admin"
        });
    }
}
