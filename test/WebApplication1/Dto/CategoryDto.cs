using Lib.DapperORM;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    [Lib.DapperORM.Attributes.Table("ProductCategory")]
    [Lib.DapperORM.Attributes.Schema("Shop")]
    public class CategoryDto : IDapper
    {
        [Lib.DapperORM.Attributes.Key]
        public int Id { get; set; } = 0;
        [Lib.DapperORM.Attributes.Relationship(DeleteRule = Lib.DapperORM.SQLRelationshipActions.SetNull,UpdateRule = Lib.DapperORM.SQLRelationshipActions.Cascade)]
        public UserDto? Creator { get; set; } = null;
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        public void Get()
        {
           
        }
    }
}
