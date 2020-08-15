using S2pDAO;
using S2pEntities;
using System;
using System.Collections.Generic;

namespace S2pBusiness
{
	public class TransactionBll
    {
		private readonly IRepository _repo;
		public TransactionBll(IRepository repo)
		{
			_repo = repo;
		}
		public List<ListTransaction> GetByIdentity(string identity)
		{
			try
			{
				return _repo.GetByIdentity(identity);
			}
			catch (Exception e)
			{

				throw;
			}
		}
	}
}
