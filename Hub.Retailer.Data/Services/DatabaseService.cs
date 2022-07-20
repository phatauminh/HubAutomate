using Hub.Retailer.Data.Entities;

namespace Hub.Retailer.Data.Services
{
    public static class DatabaseService
    {
        public static ModelContext GetModelContext()
        {
            return new ModelContext();
        }
    }
}
