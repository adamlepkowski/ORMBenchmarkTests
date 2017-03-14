using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ORMBenchmarkTests.Model
{
    public class UserType : BaseEntity
    {
        public string Type { get; set; }
    }
}
