using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entites;
using Store.Domain.StoreContext.Queries;

namespace Store.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository 
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
    }
}