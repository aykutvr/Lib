using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    [Lib.DapperORM.Attributes.Table("User")]
    [Lib.DapperORM.Attributes.Schema("Shop")]
    public class UserDto
    {
        [Lib.DapperORM.Attributes.Key(Identity = true,Increment = 1, Seed = 100000)]
        public int Id { get; set; } = 0;
        [MaxLength(50)]
        [Lib.DapperORM.Attributes.MaskedWith("email()")]
        public string EmailAddr { get; set; } = string.Empty;
        [MaxLength(50)]
        [Lib.DapperORM.Attributes.SpecifiedDbType(System.Data.SqlDbType.NVarChar)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [DefaultValue(0)]
        public int Count { get; set; } = 0;
        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;
        [DefaultValue("1900-01-01")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
