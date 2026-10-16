using Core;

namespace Shop.Dal
{
    public class ShopDaoDataBaseRepository : BaseDataBaseRepository<ShopDao, ShopEntityContext>, IRepository<ShopDao>
    {
        public ShopDaoDataBaseRepository(ShopEntityContext context) : base(context) { }
    }
}