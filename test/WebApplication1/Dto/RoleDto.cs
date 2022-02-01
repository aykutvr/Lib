using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    [Lib.DapperORM.Attributes.Table("Roles")]
    [Lib.DapperORM.Attributes.Schema("Shop")]
    public class RoleDto
    {
        [Lib.DapperORM.Attributes.Key(Identity = true, Increment = 1, Seed = 100000)]
        public int Id { get; set; } = 0;
        [MaxLength(50)]
        
        public string Name { get; set; } = string.Empty;

    }
}
