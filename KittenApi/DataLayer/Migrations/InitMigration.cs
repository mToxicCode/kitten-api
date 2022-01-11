using FluentMigrator;
using JetBrains.Annotations;

namespace KittenApi.DataLayer.Migrations;

[Migration(0)]
[UsedImplicitly]
public class InitMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table(SqlConstants.RolesTable)
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("name").AsString(255).NotNullable().Unique()
            .WithColumn("description").AsString(1500).Nullable();

        Create.Table(SqlConstants.UsersTable)
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("username").AsString(255).NotNullable().Unique()
            .WithColumn("firstname").AsString(255).NotNullable()
            .WithColumn("secondname").AsString(255).Nullable()
            .WithColumn("middlename").AsString(255).Nullable()
            .WithColumn("dateofbirth").AsDate().NotNullable()
            .WithColumn("description").AsString(1500).Nullable()
            .WithColumn("role").AsInt64().NotNullable().ForeignKey("roles", "id");

        Insert.IntoTable(SqlConstants.RolesTable)
            .Row(new { name = "Default", description = "Default role" })
            .Row(new { name = "Student", description = "Default Student role" })
            .Row(new { name = "Tutor", description = "Default Tutor role" })
            .Row(new { name = "Administrator", description = "Default Administrator role" });
    }
}