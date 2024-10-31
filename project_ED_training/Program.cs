using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_ED_training.Services;
using project_ED_training.Models;



//main was for pure testing.
class Program
{
    static void Main(string[] args)
    {
        var RepairService = new Repair_Services(context);

    }
}
