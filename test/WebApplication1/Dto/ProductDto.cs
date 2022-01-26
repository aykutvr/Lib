using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    [Lib.DapperORM.Attributes.Table("Product")]
    [Lib.DapperORM.Attributes.Schema("Shop")]
    public class ProductDto
    {
        [Lib.DapperORM.Attributes.Key(Identity = true, Increment = 1, Seed = 100000)]
        public int Id { get; set; } = 0;
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        [Lib.DapperORM.Attributes.Relationship(DeleteRule = Lib.DapperORM.SQLRelationshipActions.SetNull, UpdateRule = Lib.DapperORM.SQLRelationshipActions.Cascade)]
        public CategoryDto? Category { get; set; } = null;
    }
}
