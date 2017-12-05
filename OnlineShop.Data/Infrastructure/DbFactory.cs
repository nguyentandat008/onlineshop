namespace OnlineShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        OnlineShopDBContext dbContext;

        public OnlineShopDBContext Init()
        {
            return dbContext ?? (dbContext = new OnlineShopDBContext());
        }

        protected override void DisposedCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
