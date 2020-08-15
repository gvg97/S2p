using S2pEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace S2pDAO
{
    public interface IRepository
    {
        public string GetConnectionString();
        public List<ListTransaction> GetByIdentity(string identity);
    }
}
