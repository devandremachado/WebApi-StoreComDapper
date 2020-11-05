using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entites;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return null;
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return null;
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            return null;
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return null;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}