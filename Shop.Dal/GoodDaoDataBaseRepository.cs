using Core;

namespace Shop.Dal
{
    public class GoodDaoDataBaseRepository : BaseDataBaseRepository<GoodDao, ShopEntityContext>, IRepository<GoodDao>
    {
        public GoodDaoDataBaseRepository(ShopEntityContext context) : base(context) { }
    }
}