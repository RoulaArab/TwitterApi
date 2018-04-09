namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        TweetID = c.Int(nullable: false, identity: true),
                        Created_at = c.String(),
                        Text = c.String(),
                        favourite_count = c.Int(),
                        lang = c.String(),
                        place = c.String(),
                        retweet_count = c.Int(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TweetID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Created_date = c.String(),
                        description = c.String(),
                        favourites_count = c.Int(),
                        followers_count = c.Int(),
                        friends_count = c.Int(),
                        lang = c.String(),
                        location = c.String(),
                        Name = c.String(),
                        screen_name = c.String(),
                        status_count = c.Int(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tweets", "UserID", "dbo.Users");
            DropIndex("dbo.Tweets", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tweets");
        }
    }
}
