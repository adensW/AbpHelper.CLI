﻿using System;
using EasyAbp.AbpHelper.Commands.Ef.Migrations.Add;
using EasyAbp.AbpHelper.Steps.Common;
using EasyAbp.AbpHelper.Workflow;
using EasyAbp.AbpHelper.Workflow.Common;
using Elsa.Activities;
using Elsa.Expressions;
using Elsa.Scripting.JavaScript;
using Elsa.Services;

namespace EasyAbp.AbpHelper.Commands.Ef.Migrations.Remove
{
    public class RemoveCommand : CommandWithOption<RemoveCommandOption>
    {
        private const string AddCommandDescription = @"Removes the last migration. The usage is the same as `dotnet ef migrations remove`, 
except providing the default value for the `--project` and `--startup-project` options.";

        public RemoveCommand(IServiceProvider serviceProvider) : base(serviceProvider, "add", AddCommandDescription)
        {
        }

        protected override IActivityBuilder ConfigureBuild(RemoveCommandOption option, IActivityBuilder activityBuilder)
        {
            string efOptions = option.EfOptions == null ? String.Empty : string.Join(" ", option.EfOptions);
            return base.ConfigureBuild(option, activityBuilder)
                    .Then<SetVariable>(step =>
                    {
                        step.VariableName = "EfOptions";
                        step.ValueExpression = new LiteralExpression(efOptions);

                    })
                    .AddConfigureMigrationProjectsWorkflow(ActivityNames.RemoveMigration)
                    .Then<RunCommandStep>(
                        step => step.Command = new JavaScriptExpression<string>("`dotnet ef migrations remove -p \"${MigrationProjectFile}\" -s \"${StartupProjectFile}\" ${EfOptions || ''}`")
                    ).WithName(ActivityNames.RemoveMigration)
                ;
        }
    }
}