using System;
using System.Collections.Generic;

namespace Shop.Dal
{
    public class ClientDaoXmlRepository : BaseXmlRepository<ClientDao>
    {
        public ClientDaoXmlRepository(string fileName = "clients.xml") : base(fileName) { }
    }
}
