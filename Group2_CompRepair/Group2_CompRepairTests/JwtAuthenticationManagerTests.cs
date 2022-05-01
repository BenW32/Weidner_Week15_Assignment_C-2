using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group2_CompRepair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group2_CompRepair.Controllers;

namespace Group2_CompRepair.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        //Test 1 Checks if invalid login returns null
        [TestMethod()]
        public void InvalidLoginTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlogin1232112211");
            User user = new User
            {
                username = "username",
                password = "aPassword"
            };
            var ret = manager.Authenticate(user.username,user.password);

            Assert.IsNull(ret);
        }

        //Test 2 Checks that valid login does not return a null value
        [TestMethod()]
        public void ValidLoginTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlogin1232112211");
            User user = new User
            {
                username = "test",
                password = "password"
            };
            var ret = manager.Authenticate(user.username, user.password);

            Assert.IsNotNull(ret);
            

        }

        //Test 3 Makes sure original username and password exist and were not deleted
        [TestMethod()]
        public void UserNamesExistTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlogin1232112211");
            bool var = false;
            if (manager.users.ContainsKey("test") && manager.users["test"].Equals("password"))
            {
                var = true;
            }

            Assert.IsTrue(var);


        }
        //Test 4 Checks that token is correct length of 169
        [TestMethod()]
        public void TokenLengthTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlogin1232112211");
            User user = new User
            {
                username = "test",
                password = "password"
            };
            var ret = manager.Authenticate(user.username, user.password);
            string retString = ret.ToString();
            int retLen = retString.Length;
            Console.WriteLine(retLen.ToString());

            Assert.IsTrue(retLen==169);


        }


    }
}