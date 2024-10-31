using project_ED_training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_ED_training.Models;


namespace project_ED_training.Services.Owner_Services;

public class Owner_services
{
    private readonly TechnicoDbContext db;

    public Owner_services(TechnicoDbContext db)
    {
        this.db = db;
    }




    //CRUD Operations


    //create an Owner and insert in the database
    public Owner CreateOwner(Owner owner)
    {
        db.Owners.Add(owner);
        db.SaveChanges();
        return owner;
    }

    //Read Owners
    public List<Owners> ReadOwners()
    {
        return db.Owners.ToList();
    }

    //Read one Owner based on his VAT Number
    public Owner? ReadOwner(int VATId)
    {
        return db.Owners.Where(c => c.VATId == VATId).FirstOrDefault();
    }

    //update the parts that are eligible to update(E-mail property) of Owner
    public Owner? UpdateOwner(Owner owner)
    {
        Owner? ownerdb = db.Owners.FirstOrDefault(c => c.VATId == owner.VATId);
        if (ownerdb != null)
        {
            ownerdb.Address = owner.Address;
            db.Savechanges();
        }
    }

    //Delete an owner from the database
    public bool DeleteOwner(int VATId)
    {

        Owner? ownerdb = db.Owners.FirstOrDefault(c => c.VATId == VATId);
        if (ownerdb != null)
        {
            db.Owners.Remove(ownerdb);
            db.SaveChanges();
            return true;
        }
        return false;
    }
    //Display service for the current user
    public class DisplayUser
    {

        private readonly Context _context;

        public DisplayUser(Context _context)
        {
            _context = _context;
        }

        public UserDisplayDto GetUserDetails(string VATId)
        {
            var owner = _context.Owners
                .Include(o => o.Properties)
                .Include(o => o.Repairs)
                .SingleOrDefault(o => o.VATId == VATId);
            
            //exception
            if (owner == null)
            {
                throw new Exception("Owner not found.");
            }
            return new GetUserDetails
            {
                OwnerDetails = owner,
                Properties = owner.Properties,
                Repairs = owner.Repairs
            };
        }
    }
}

public class DisplayUsers
{
    public Owner OwnerDetails { get; set; }
    public List<Property> Properties { get; set; }

    public List<Repair> Repairs { get; set; }   
}


