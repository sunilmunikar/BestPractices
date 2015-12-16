namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSproc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordId = c.Int(nullable: false),
                        CartId = c.String(),
                        AlbumId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.Genre_Insert",
                p => new
                    {
                        Name = p.String(),
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Genres]([Name], [Description])
                      VALUES (@Name, @Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Genres]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Genres] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Genre_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Genres]
                      SET [Name] = @Name, [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Genre_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Genres]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Genre_Delete");
            DropStoredProcedure("dbo.Genre_Update");
            DropStoredProcedure("dbo.Genre_Insert");
            DropForeignKey("dbo.Carts", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Carts", new[] { "AlbumId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Carts");
        }
    }
}
