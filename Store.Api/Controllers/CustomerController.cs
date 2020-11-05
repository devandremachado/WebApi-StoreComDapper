using System.Collections.Generic;
using Store.Domain.StoreContext.Entites;
using Microsoft.AspNetCore.Mvc;
using System;
using Store.Domain.StoreContext.Commands.CustomerComands.Inputs;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Handlers;
using Store.Shared.Commands;
using Store.Domain.StoreContext.Commands.CustomerComands.Outputs;

namespace Store.Api.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration=60)] // Cache de 1hr (adiciona no header do response)
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult) _handler.Handle(command);
            return result;
        }
    }
}