using System;
using System.Collections.Generic;

namespace Shop.Dal
{
    public class ShopDaoJsonRepository : BaseJsonRepository<ShopDao>
    {
        public ShopDaoJsonRepository(string fileName = "shops.json") : base(fileName) { }
    }
}