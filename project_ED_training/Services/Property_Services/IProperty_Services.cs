namespace project_ED_training.Services.Property_Services
{
    public interface IProperty_Services
    {
        global::System.Boolean DeleteProperty(global::System.Int32 PropertyID);
        List<Properties> IndexProperties();
    }
}