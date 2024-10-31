using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_ED_training.Models;
using project_ED_training.Repositories;


namespace project_ED_training.Services.Property_Services;

public class Property_Services
{
    private readonly TechnicoDbContext db;


    public PropertyService(TechnicoDbContext db)
    {
        this.db = db;
    }


    //Add a new Property

    public AddProperty(Property property)
    {
        db.Properties.Add(property);
        db.Properties.SaveChanges();

    }

    public bool DeleteProperty(int PropertyID)
    {
        Property? property = db.Properties.Find(PropertyID);
        if (property == null)
        {
            return false;
        }
        db.Properties.Remove(property);
        return true;
    }

    public EditProperty(Property property)
    {
        Property? propertydb = db.Properties.Find(Property.propertyID);
        if (propertydb != null)
        {
            
            propertydb.Address = Address;
            propertydb.YearsOfConstruction = YearsOfConstruction;
            db.Savechanges();
        }
    }

    public List<Properties> IndexProperties()
    {
        return db.Properties.ToList();
    }

    //view a single property based on ID, and throw error if it doesn't find it in the database.
    public ViewProperty(int PropertyID)
    {
        Value = db.Properties.Find(PropertyID);
        if ( Value == null)
        {
            throw new Exception("Property not found.");
        }

        return Value;
    }
}
