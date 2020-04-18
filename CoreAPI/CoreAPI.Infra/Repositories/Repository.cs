using CoreAPI.Infra.Data.Contexts;

namespace CoreAPI.Infra.Repositories
{
    public abstract class Repository
    {
        public SQLiteDbContext context;

        public void Commit() => context.SaveChanges();
    }
}
