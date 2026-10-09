using System;
using System.Collections.Generic;

namespace Shop.Dal
{
    public class GoodDaoXmlRepository : BaseXmlRepository<GoodDao>
    {
        public GoodDaoXmlRepository(string fileName = "goods.xml") : base(fileName) { }
    }
}