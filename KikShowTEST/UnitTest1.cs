using KikShowAPI.DAL;
using KikShowAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace KikShowTEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var data = await new UserPost().SelectUserPostsAsync();
            Assert.IsNotNull(data);
        }
    }
}
