using Core;

namespace Shop.Dal
{
    public class ClientDaoDataBaseRepository : BaseDataBaseRepository<ClientDao, ShopEntityContext>, IRepository<ClientDao>
    {
        public ClientDaoDataBaseRepository(ShopEntityContext context) : base(context) { }
    }
}