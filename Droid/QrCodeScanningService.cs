using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(PexParking.Droid.QrCodeScanningService))]

namespace PexParking.Droid
{
    public class QrCodeScanningService : Interface.IQrScan
    {
        public async Task<string> ScanAsync()
        {
            
            var options = new MobileBarcodeScanningOptions();
            var scanner = new MobileBarcodeScanner();
            var scanResult = await scanner.Scan(options);
            return scanResult.Text;
        }
    }
}
