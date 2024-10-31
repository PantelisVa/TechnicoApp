using project_ED_training.Models;

namespace project_ED_training.Services.Owner_Services
{
    public interface IOwner_services
    {
        Owner CreateOwner(Owner owner);
        global::System.Boolean DeleteOwner(global::System.Int32 VATId);
        Owner ReadOwner(global::System.Int32 VATId);
        List<Owners> ReadOwners();
        Owner UpdateOwner(Owner owner);
    }
}