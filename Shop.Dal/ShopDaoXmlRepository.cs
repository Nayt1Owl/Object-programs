using System;
using System.Collections.Generic;

namespace Shop.Dal
{
    public class ShopDaoXmlRepository : BaseXmlRepository<ShopDao>
    {
        public ShopDaoXmlRepository(string fileName = "shops.xml") : base(fileName) { }
    }
}