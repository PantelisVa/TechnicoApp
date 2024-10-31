using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_ED_training.Models;
using project_ED_training.Repositories;

namespace project_ED_training.Services.Repair_Services;

public class Repair_Services : IRepair_Services
{
    private readonly TechnicoDbContext db;

    public Repair_Services(TechnicoDbContext context)
    {
        _context = context;
    }

    public SearchRepair(int repairID)
    {
        var repair = _context.Repairs.FirstOrDefault(r => r.ID == repairID && r.IsActive);

        if (repair == null)
        {
            throw new Exception("Repair not found or is inactive");
        }

        return repair;
    }

    public UpdateRepair(int repairID)
    {
        var repair = _context.Repairs.FirstOrDefault(r => repair.ID == repairID && r.IsActive);

        if (repair == null)
            throw new Exception("Repair is not found.");

        repair.Address = Address;
        repair.Description = Description;
        repair.Status = Status;
        repair.Cost = Cost;

        _context.Savechanges();

    }

    public bool DeleteRepair(int repairID)
    {
        var repair = _context.Repairs.FirstOrDefault(r => r.repairID == repairID);

        if (repair == null)
        {
            throw new Exception("Repair not found");
            return false;
        }
        else
        {
            _context.Repairs.Remove(repair);
            _context.Savechanges();
            return true;
        }
    }

    public CreateRepair(Repair repair)
    {
        _context.Repairs.Add(repair);
        _context.Savechanges();
        return repair;
    }
}