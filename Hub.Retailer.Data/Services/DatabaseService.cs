using Hub.Retailer.Data.Entities;

namespace Hub.Retailer.Data.Services
{
    public static class DatabaseService
    {

        //Use for EF core (In progress)
        public static ModelContext GetModelContext()
        {
            return new ModelContext();
        }

    }
}
