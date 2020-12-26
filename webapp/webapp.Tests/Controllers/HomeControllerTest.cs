using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using criminal.reporting.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapp;
using webapp.Controllers;

namespace webapp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
