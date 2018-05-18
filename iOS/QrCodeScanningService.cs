using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(PexParking.iOS.QrCodeScanningService))]

namespace PexParking.iOS
{
    public class QrCodeScanningService: Interface.IQrScan
    {
        public QrCodeScanningService()
        {
        }

        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResult = await scanner.Scan();
            return scanResult.Text;
        }
    }
}
