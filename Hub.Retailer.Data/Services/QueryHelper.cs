using Hub.Retailer.Common.Extensions;
using Hub.Retailer.Common.Helpers;
using Hub.Retailer.Common.Models;
using Hub.Retailer.Data.Entities;
using System.Collections.Generic;
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

        public static List<NMIEntity> Generate_List_NMI(string state, int numberOfNMI)
        {
            var scriptPath = @".\Scripts\GenerateNMI.sql";

            var nmi = MiscHelper.Get_Valid_NMI_By_State(state, numberOfNMI);

            var param = $"'{nmi}' '{numberOfNMI}'";
            string output = OracleDataAccess.ExecuteWithOutput(scriptPath, param);

            var listNMIAndCheckSum = output.Substring(output.IndexOf($"{nmi} ")).Split("\r\n\r\n")[0].Replace("\r\n", " ").Split(' ');
            var listNMIEntity = new List<NMIEntity>();

            for (int i = 0; i < listNMIAndCheckSum.Length; i++)
            {
                listNMIEntity.Add(new NMIEntity
                {
                    NMI = listNMIAndCheckSum[i],
                    Checksum = listNMIAndCheckSum[++i]
                }); ;
            }

            return listNMIEntity;
        }
    }
}
