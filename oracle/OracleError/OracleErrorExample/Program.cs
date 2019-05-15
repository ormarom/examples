using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OracleErrorExample.Domain;
using OracleErrorExample.DTO;
using OracleErrorExample.Infra;

namespace OracleErrorExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                services.GetService<LabDbContext>().Database.Migrate();
                var commandsDao = new Commands(services.GetService<LabDbContext>());
                commandsDao.CreatProject(1000);
                commandsDao.CreatProject(1001);
                commandsDao.CreatProject(1002);
                var projects = new Query(services.GetService<LabDbContext>()).Get().Result;
            }
            return;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public class Commands
    {
        private readonly LabDbContext _context;

        public Commands(LabDbContext context)
        {
            _context = context;
        }

        //just creating some entities 
        public void CreatProject(int id) {
            var projectToAdd = new ProjectProperties(id, Guid.NewGuid().ToString(), "Test", "Test");
            projectToAdd.SetId(id);
            projectToAdd.UpdateLimits(0, 0, 0, 0, "", "", "", null, "", "");
            _context.ProjectProperties.Add(projectToAdd);
            _context.SaveChanges();
        }
    }

    public class Query
    {
        private readonly LabDbContext _context;

        public Query(LabDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectPropertiesDTO>> Get()
        {
            //we crash in the select. note that this works in MsSql...
            return await _context.ProjectProperties.Select(Mapper()).ToListAsync();
        }

        public Expression<Func<ProjectProperties, ProjectPropertiesDTO>> Mapper()
        {
            return domain => new ProjectPropertiesDTO
            {
                AutPoolID = domain.PrjpAutHostPoolId.HasValue ? domain.PrjpAutHostPoolId.ToString() : "",
                ConcurrentRuns = domain.PrjpConcurrentRuns,
                DiagnosticsServerId = domain.PrjpDiagnosticsServerId.HasValue ? domain.PrjpDiagnosticsServerId.ToString() : "",
                Domain = domain.PrjpDomain,
                HostPoolID = domain.PrjpHostPoolId.HasValue ? domain.PrjpHostPoolId.ToString() : "",
                HostsLimit = domain.PrjpMachineLimit,
                ID = domain.Id,
                Name = domain.PrjpProjectName,
                ProjectID = domain.PrjpProjectId.HasValue ? domain.PrjpProjectId.ToString() : "",
                RecurrentReservation = domain.PrjpRecResEnabled,
                State = domain.PrjpState,
                ToolsOptions = domain.PrjpToolsOptions,
                TotalConsumption = domain.PrjpTotalVudsUsed,
                UniqueID = domain.PrjpProjectUid,
                VUDSLimit = domain.PrjpVudsLimit,
                VugenWorkingMode = domain.PrjpVugenWorkingMode,
                VusersLimit = domain.PrjpVuserLimit,
                TestExtendDuration = domain.PrjpFuncProlongDuration.HasValue ? domain.PrjpFuncProlongDuration.ToString() : "",
                MaxNumberOfProlongs = domain.PrjpMaxNumOfProlongs.HasValue ? domain.PrjpMaxNumOfProlongs.ToString() : ""
            };
        }

    }
}
