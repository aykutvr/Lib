namespace WebApplication1.Dto
{
    [Lib.DapperORM.Attributes.Table("UsersRoles")]
    [Lib.DapperORM.Attributes.Schema("Shop")]
    public class UsersRolesDto
    {
        [Lib.DapperORM.Attributes.Key]
        public int Id { get; set; } = 0;
        [Lib.DapperORM.Attributes.Relationship(DeleteRule = Lib.DapperORM.SQLRelationshipActions.Cascade, UpdateRule = Lib.DapperORM.SQLRelationshipActions.Cascade)]
        public UserDto User { get; set; } = new UserDto();
        [Lib.DapperORM.Attributes.Relationship(DeleteRule = Lib.DapperORM.SQLRelationshipActions.Cascade, UpdateRule = Lib.DapperORM.SQLRelationshipActions.Cascade)]
        public RoleDto Role { get; set; } = new RoleDto();
    }
}
