using System;
using System.Threading.Tasks;

namespace PexParking.Interface
{
    public interface IQrScan
    {Task<string> ScanAsync();
    }


}
