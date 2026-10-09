using System;
using System.Collections.Generic;

namespace Shop.Dal
{
    public class GoodDaoJsonRepository : BaseJsonRepository<GoodDao>
    {
        public GoodDaoJsonRepository(string fileName = "goods.json") : base(fileName) { }
    }
}