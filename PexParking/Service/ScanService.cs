using System;
using System.Threading.Tasks;
using PexParking.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PexParking.Service
{
    public class ScanService
    {
        public async Task<string> ScannerQr()
        {
            try
            {
                var scanner = DependencyService.Get<IQrScan>();
                var result = await scanner.ScanAsync();
                return result.ToString();
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return "ninguno";

            }
        }
    }
}
