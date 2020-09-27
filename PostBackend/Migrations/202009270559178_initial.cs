namespace PostBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        CommentTitle = c.String(),
                        CommentAddedBy = c.String(),
                        CommentAddedDate = c.DateTime(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        DislikeCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        PostAddedBy = c.String(),
                        PostAddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
