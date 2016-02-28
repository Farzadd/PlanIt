namespace PlanIt_ServerService.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PlanIt_ServerService.Models.PlanIt_ServerContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PlanIt_ServerService.Models.PlanIt_ServerContext context)
        {
            //  This method will be called after migrating to the latest version.
        }
    }
}
