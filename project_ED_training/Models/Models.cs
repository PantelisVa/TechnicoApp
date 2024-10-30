using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_ED_training.Models;

///<summary> - Simple ERD representation of entities of the project
//Owner
//  VATId, Name, Surname, Address, PhoneNumber, Username(E-mail), Password, TypeOfUser
//Property
//  PropertyID, [Address]. YearOfConstruction, TypeOfProperty, VATID
//Repair
//  RepairDateTime, TypeOfRepair, Description, [Address], Status, Cost, <Owner>
///
/// </summary>
public class Owner
{
    public long VATId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }= string.Empty;
    public string Address { get; set; } = string.Empty;

    public string Password { get; set;} = string.Empty;

    virtual public List<TypeOfUser> TypeOfUser { get; set; } = new List<TypeOfUser>();

    virtual public List<Repair> Repairs { get; set; } = new List<Repair>();
    virtual public List<Property> Properties { get; set; } = new List<Property>();

}

public class Property
{
    public long PropertyID { get; set; }
    public string Address { get; set; } = string.Empty;

    public int YearsOfConstruction { get; set; }

    virtual public Owner? Owner { get; set; }

    virtual public List<TypeOfProperty> TypeOfProperty { get; set; } = new List<TypeOfProperty>();

    virtual public List<Repair> Repairs { get; set; } = new List<Repair>();

}

public class Repair
{
    public long RepairID { get; set; }

    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime RepairDate { get; set; }

    public Status Status { get; set; } = Status.WORKINPROGRESS;

    public decimal Cost { get; set; }

    virtual public Owner? Owner { get; set; }

    virtual public List<TypeOfRepair> TypeOfRepair { get; set; } = new List<TypeOfRepair>();
}

public enum Status
{
    WORKINPROGRESS, COMPLETED, CANCELLED
}