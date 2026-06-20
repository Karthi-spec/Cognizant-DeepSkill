using System;

interface ICustomerRepository
{
    void FindCustomerById(int id);
}

class CustomerRepository : ICustomerRepository
{
    public void FindCustomerById(int id)
    {
        Console.WriteLine("Customer Found: " + id);
    }
}

class CustomerService
{
    private ICustomerRepository repository;

    public CustomerService(ICustomerRepository repository)
    {
        this.repository = repository;
    }
}