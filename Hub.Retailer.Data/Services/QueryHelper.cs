using Hub.Retailer.Common.Extensions;
using Hub.Retailer.Common.Models;
using System.Threading.Tasks;

namespace Hub.Retailer.Data.Services
{
    public static class QueryHelper
    {
        public static async Task<bool> IsAddressLinkedToCustomersInSystem(ServiceAddress addr)
        {
            var custNum = string.Empty;
            var shortAddress = addr.Address.ToUpper();
            if (addr.Address.Contains("UNIT"))
                shortAddress = shortAddress.Replace("UNIT", "U");

            var sql = string.Format(@"SELECT rootbuid FROM (SELECT rootbuid, REPLACE(bdaddrl1, '  ',' ') AS bdaddrl1, bdaddrpc, REPLACE(saddrl1, '  ',' ') AS saddrl1, saddrpc FROM vw_accountsummary) 
                                        WHERE (saddrl1 like '{0}%' AND saddrpc = '{1}')  OR (bdaddrl1 like '{0}%' AND bdaddrpc = '{1}')", shortAddress, addr.Postcode);

            await OracleDataAccess.ExecuteReader(sql, x =>
            {
                while (x.Read())
                {
                    custNum = x.GetValue(0).ToString();
                }
            });

            return custNum.IsNotNullOrEmpty();
        }
    }
}
