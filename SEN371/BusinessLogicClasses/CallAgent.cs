﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project_1.BusinessLogicClasses
{
    public class CallAgent : Employee
    {
        string agentId;
        
        public CallAgent(string agentId,string employeeId, string employeeType, string name, string surname, string cell, string email) : base(employeeId, name, surname, employeeType, cell, email)
        {
            this.agentId = agentId;

        }

        public void StoreEmployee(string personId, string streetAddress, string suburb, string city, string country)
        {
            DataAccessLayer.DataHandler database = new DataAccessLayer.DataHandler();
            database.Insert("Employee", new[] { ("personid", personId), ("streetaddress", streetAddress), ("suburb", suburb), ("city", city), ("country", country) });
        }

        public void UpdateEmployee(string employeeId, string name, string surname, string employeeType, string cell, string email)
        {
            DataAccessLayer.DataHandler database = new DataAccessLayer.DataHandler();
            database.Update("Employee", new[] { ("employeeid", employeeId), ("name", name), ("surname", surname), ("employeetype", employeeType), ("cellphonenumber", cell), ("email", email) }, ("EmployeeId = " + employeeId));
        }

        public void DeleteEmployee(string id)
        {
            DataAccessLayer.DataHandler database = new DataAccessLayer.DataHandler();
            database.Delete("PersonAddress", ("EmployeeId = " + id));
        }

        public SqlDataAdapter GetInfo()
        {
            DataAccessLayer.DataHandler database = new DataAccessLayer.DataHandler();
            return database.RetrieveData(this.GetType().Name);
        }


        public SqlDataAdapter GetInfo(string agentId)
        {
            DataAccessLayer.DataHandler database = new DataAccessLayer.DataHandler();
            return database.RetrieveData(this.GetType().Name, ("AgentId = " + agentId));
        }




        public string Status()
        {
            //Will return the status of a specific Call Agent (Working, Idle, Done) based on assigned contracts
            return "placeholder";
        }

        public void LogCallDetails()
        {
            //Will save the call details (client, duration) to an external object or location
        }

        public void StartCall()
        {
            //set call start time
        }
        public void EndCall()
        {
            //set call end time
        }
        public void ViewCallHistory()
        {
            //return this agent call history
        }
        public void ViewCustomerContract()
        {
            //Display client contract information
        }






        //string agentId;
        //string agentName;
        //string agentSurname;
        //string adressId;
        //string contractId;

        //public CallAgent(string agentId, string agentName, string agentSurname, string adressId, string contractId, string employeeID) : base(employeeID, adressId, agentName, agentSurname)
        //{
        //    this.agentId = agentId;
        //    this.agentName = agentName;
        //    this.agentSurname = agentSurname;
        //    this.adressId = adressId;
        //    this.contractId = contractId;
        //}

        //public string AgentId { get => agentId; set => agentId = value; }
        //public string AgentName { get => agentName; set => agentName = value; }
        //public string AgentSurname { get => agentSurname; set => agentSurname = value; }
        //public string AdressId { get => adressId; set => adressId = value; }
        //public string ContractId { get => contractId; set => contractId = value; }

        //public string Status()
        //{
        //    //Will return the status of a specific Call Agent (Working, Idle, Done) based on assigned contracts
        //    return "placeholder";
        //}

        //public void LogCallDetails()
        //{
        //    //Will save the call details (client, duration) to an external object or location
        //}
    }
}
