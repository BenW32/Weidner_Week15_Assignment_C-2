using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group2_CompRepair.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group2_CompRepair.Data;

namespace Group2_CompRepair.Controllers.Tests
{
    [TestClass()]
    public class CustomersControllerTests
    {
      /*  [TestMethod()]
        public void CustomersControllerTest()
        {
            Assert.Fail();
        }*/

      //test 5 makes sure the get customer is passing back values and is not null
        [TestMethod()]
        public void GetCustomersTest()
        {
            Group2_ComprepairContext context = null;
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlogin1232112211");
            CustomersController custControll = new CustomersController(manager, context);
            
            Assert.IsNotNull(custControll.GetCustomers());
        }

        /* [TestMethod()]
         public void GetCustomerTest()
         {
             Assert.Fail();
         }

         [TestMethod()]
         public void PutCustomerTest()
         {
             Assert.Fail();
         }

         [TestMethod()]
         public void PostCustomerTest()
         {
             Assert.Fail();
         }

         [TestMethod()]
         public void DeleteCustomerTest()
         {
             Assert.Fail();
         }*/
    }
}