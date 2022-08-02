using Microsoft.Playwright;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class Table
    {
        private readonly ILocator _tableLocator;
        private readonly ILocator _headerLocator;
        private readonly ILocator _bodyLocator;
        private readonly string NO_RECORDS_FOUND = "No records found.";

        public Table(ILocator locator)
        {
            _tableLocator = locator.Locator("table");
            _headerLocator = _tableLocator.Locator("thead tr th");
            _bodyLocator = _tableLocator.Locator("tbody tr");
        }

        public async Task<List<string>> GetAllHeader()
        {
            var allHeader = new List<string>();
            var count = await _headerLocator.CountAsync();
    
            for (var i = 0; i < count; i++)
            {
                var header = await _headerLocator.Nth(i).TextContentAsync();
                allHeader.Add(header);
            }
            return allHeader;
        }

        public async Task<List<string>> GetAllBody()
        {
            var allBody = new List<string>();
            var headerCount = await _headerLocator.CountAsync();
            var bodyCount = await _bodyLocator.CountAsync();
            for (var i = 0; i < bodyCount; i++)
            {
                var builder = new StringBuilder();
                for (var j = 0; j < headerCount; j++)
                {
                    var text = await _bodyLocator.Nth(i).Locator("td").Nth(j).TextContentAsync();

                    if (NO_RECORDS_FOUND.Equals(text))
                        return allBody;

                    builder.Append(text);

                    if (headerCount - j > 1)
                        builder.Append("|");
                }

                allBody.Add(builder.ToString());
            }
            return allBody;
        }

        public Row GetRowByIndex(int index)
        {
            return new Row(_bodyLocator.Nth(index));
        }
    }


}
