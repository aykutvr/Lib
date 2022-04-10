using Belgrade.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult BelgradeORM()
        //{
        //}

        public IActionResult Shop()
        {
            
            
            this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Dto.UserDto>();
            this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Dto.RoleDto>();
            this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Dto.UsersRolesDto>();
            this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Dto.CategoryDto>();
            this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Dto.ProductDto>();

            this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Insert(data =>
            {
                for (int i = 0; i < 100; i++)
                    data.AddData<Dto.UserDto>(new Dto.UserDto
                    {
                        EmailAddr = $"user{i}@mail.com",
                        Password = "1234"
                    });

                data.AddData<Dto.RoleDto>(new Dto.RoleDto { Name = "Administrator" }, out long adminRoleId);
                data.AddData<Dto.RoleDto>(new Dto.RoleDto { Name = "Moderator" }, out long motedatorRoleId);
                data.AddData<Dto.RoleDto>(new Dto.RoleDto { Name = "Default" }, out long defaultRoleId);

                data.AddData<Dto.CategoryDto>(new Dto.CategoryDto { Name = "Bilgisayar" }, out long bilgisayarId);
                data.AddData<Dto.CategoryDto>(new Dto.CategoryDto { Name = "Elektronik" }, out long elektronikId);
                data.AddData<Dto.CategoryDto>(new Dto.CategoryDto { Name = "Cep Telefonu" }, out long cepTelefonuId);
                data.AddData<Dto.CategoryDto>(new Dto.CategoryDto { Name = "Erkek Giyim" }, out long erkekGiyimId);
                data.AddData<Dto.CategoryDto>(new Dto.CategoryDto { Name = "Kadın Giyim" }, out long kadinGiyimId);
            });



            return Ok();
        }

        public IActionResult Test()
        {
            #region Dapper Tests

            


            //var createOrAlterTable = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Models.TestDto>();
            //var createOrAlterTable2 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).CreateOrAlterTable<Models.TestDetailDto>();
            
            
            var step01 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Insert().AddData<Models.TestDto>(new TestDto { Description = "Description 1", Name = "Step 1" }).GetResult();
            var step02 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Insert(config =>
            {
                config.AddData<Models.TestDto>(new TestDto { Description = "Description 2.1", Name = "Step 2.1" });
                config.AddData<Models.TestDto>(new List<Models.TestDto> 
                { 
                    new TestDto { Name = "Step 2.2.1", Description = "Description 2.2.1" },
                    new TestDto { Name = "Step 2.2.2", Description = "Description 2.2.2" },
                    new TestDto { Name = "Step 2.2.3", Description = "Description 2.2.3" } 
                });
            });
            var step03 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Insert<Models.TestDto>(new TestDto { Description = "Description 3", Name = "Step 3" });
            var step04 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).DataTable("SELECT * FROM Test");
            var step05 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Execute("INSERT INTO Test (Name,Description,CollateType) OUTPUT INSERTED.Id VALUES ('Step 5','Description 5',@cllte)", new { cllte = Lib.DapperORM.SQLCollateTypes.Turkish_100_BIN});
            var step06 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).ExecuteScalar("SELECT COUNT(*) FROM Test");
            var step07 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).ExecuteScalar<int>("SELECT COUNT(*) FROM Test");
            var step08 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Get<Models.TestDto>(step05);
            var step09 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Get<Models.TestDto>("SELECT * FROM Test WHERE Id = @id", new { id = step05 });
            var step10 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).ListAll<Models.TestDto>("SELECT * FROM Test");
            var step11 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).List<Models.TestDto>(builder =>
            {
                builder.SetQuery("SELECT * FROM Test WHERE Id = @id");
                builder.AddParameter(new { id = step05 });
            });
            var step12 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).List<Models.TestDto>("SELECT * FROM Test WHERE Id = @id", builder =>
            {
                builder.AddParameter(new { id = step05 });
            });
            var step13 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Multiple("SELECT * FROM Test SELECT COUNT(*) FROM Test")
                            .Read<Models.TestDto>(out List<Models.TestDto> outList)
                            .ReadFirst<int>(out int count);
            step03.Description = step03.Description + " Updated";
            var step14 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Update<Models.TestDto>(step03);
            var step15 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Delete<Models.TestDto>(step05);
            var step16 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).Delete<Models.TestDto>(step03);
            var step17 = this.LibWidgets().Dapper().Connect(SharedSettings.ConnectionString).DeleteAll<Models.TestDto>();

            #endregion Dapper Tests
            return View();
        }
    }
}