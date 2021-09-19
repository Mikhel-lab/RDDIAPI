using RDDIntegration.Repository.Database;
//using RDDIntegration.Repository.Repositories.Implementations;
//using RDDIntegration.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDDIntegration.Repository.Repositories.UnitofWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext context;
		public UnitOfWork(AppDbContext context)
		{
			this.context = context;
			//SetUpMandate = new SetUpMandateRepository(context);
		}
		//public ISetUpMandate SetUpMandate { get; set; }

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public int Complete()
		{
			return context.SaveChanges();
		}
	}
}
