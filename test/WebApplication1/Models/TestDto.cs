using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Lib.DapperORM.Attributes.Table("Test")]
    public class TestDto
    {
        [Key]
        
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Nullable<int> NullableValue { get; set; } = null;
        public int? NullableSecond { get; set; } = null;
        public Lib.DapperORM.SQLCollateTypes CollateType { get; set; } = Lib.DapperORM.SQLCollateTypes.Default;
    }
}
