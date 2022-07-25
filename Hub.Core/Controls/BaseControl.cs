using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public abstract class BaseControl
    {
        public abstract Task SetValue(string value);
        public abstract Task<string> GetValue();
    }
}
