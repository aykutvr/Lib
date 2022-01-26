namespace WebApplication1.Models
{
    [Lib.DapperORM.Attributes.Table("TestDetail")]
    public class TestDetailDto
    {
        [Lib.DapperORM.Attributes.Key(Identity = true, Increment = 1, Seed = 1)]
        public int Id { get; set; } = 0;
        public TestDto Test { get; set; } = new TestDto();
        public string Description { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
