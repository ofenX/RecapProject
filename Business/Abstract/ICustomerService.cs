using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> Get(int id);
        IResult Add(Customer cuctomer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
