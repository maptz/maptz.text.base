using System.Collections.Generic;
namespace Maptz.Text.CamelCasing
{
    public interface ICamelString
    {
        IEnumerable<ICamelComponent> CamelComponents { get; }
    }
}