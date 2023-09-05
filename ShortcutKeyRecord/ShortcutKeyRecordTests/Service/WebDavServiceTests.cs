using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortcutKeyRecord.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutKeyRecord.Service.Tests
{
    [TestClass()]
    public class WebDavServiceTests
    {
        [TestMethod()]
        public void ListTest()
        {
            WebDavService service = new WebDavService();
            string result = service.List();
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void UploadTest()
        {
            WebDavService service = new WebDavService();
            service.Upload();
        }

        [TestMethod()]
        public void DownloadTest()
        {
            WebDavService service = new WebDavService();
            service.Download();
        }
    }
}