using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostReq;
using PostReq.Model;
namespace PostReqTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Assert.AreEqual(PostReq.Properties.Resources.requestStateSaved, "сохранена");
			using (UnitOfWork unitOfWork = new UnitOfWork(@"server=.\sqlnas;database=postreq;uid=sa;pwd=123456;Max Pool Size=300"))
			{
				State state = unitOfWork.States.Get(PostReq.Properties.Resources.requestStateSaved);
				Assert.IsNotNull(state);
				Assert.AreEqual(state.Id, 1);
			}
			
		}
	}
}
