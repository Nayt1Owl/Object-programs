using System;
using System.Collections.Generic;

namespace Shop.Dal
{
    public class ClientDaoJsonRepository : BaseJsonRepository<ClientDao>
    {
        public ClientDaoJsonRepository(string fileName = "clients.json") : base(fileName) { }
    }
}