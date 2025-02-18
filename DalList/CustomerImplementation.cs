﻿using DalApi;
using DO;
using Tools;
using System.Reflection;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name," Enter to function");
        if (DataSource.Customers.Any(c => c.Id == item.Id))
            throw new DalExceptionIdAllreadyExist("customer id already exists");
        DataSource.Customers.Add(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava to function");
        return item.Id;
    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        DataSource.Customers.Remove(Read(id));
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

    }

    public Customer? Read(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        try
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            return DataSource.Customers.Single(c => c.Id == id);
        }
        catch
        {
            throw new DalExceptionIdNotExist("customer not exists");
        }

    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        if (filter == null)
            return new List<Customer>(DataSource.Customers);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
        return DataSource.Customers.Where(c => filter(c)).ToList();

    }

    public void Update(Customer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        Delete(item.Id);
        DataSource.Customers.Add(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        try
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            return DataSource.Customers.First(c => filter(c));
        }
        catch
        {
            throw new DalExceptionIdNotExist("customer not exists");
        }

    }

}
