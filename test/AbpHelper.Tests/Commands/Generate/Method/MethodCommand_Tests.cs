using EasyAbp.AbpHelper.Core.Commands.Generate.Crud;
using EasyAbp.AbpHelper.Core.Commands.Generate.Methods;
using EasyAbp.AbpHelper.Core.Commands.Generate.Service;
using System;
using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyApp.AbpHelper.Tests.Commands.Generate.Crud;
public class MethodCommand_Tests: CommandTestsBase
{
  
    [Fact]
    public async Task Should_Method_Correct()
    {   
        var _crudCommand=GetRequiredService<MethodsCommand>();
        await _crudCommand.RunCommand(new MethodsCommandOption
        {
            ServiceName = "BookmarkPublic",
            MethodNames=new string[]{ "GetAllRelatedBookmarks" },
            Directory= @"C:\Users\wangdingchen\Repos\Adens\Woo\Ego\modules\navigator",
            ProjectName="Navigator",
            Subname ="Public"
        });
    }
}
