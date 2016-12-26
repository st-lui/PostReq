using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using PostReq.Model;

namespace PostReq.Controller
{
	public class UserController
	{
		public static User GetUserInfo(string userName,UnitOfWork uow)
		{
			User user = uow.Users.Get(userName);
			if (user != null)
				return user;
			using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
			{
				using (UserPrincipal foundPrincipal = UserPrincipal.FindByIdentity(domainContext,IdentityType.SamAccountName, userName))
				{
					using (DirectoryEntry de = (DirectoryEntry) foundPrincipal.GetUnderlyingObject())
					{
						using (var deParentContainer = de.Parent)
						{
							user = new User
							{
								UserName = foundPrincipal.SamAccountName,
								Fio = foundPrincipal.DisplayName,
								Post = uow.Posts.Get(deParentContainer.Properties["Name"].Value.ToString())
							};
							return user;
						}
					} 
				}
			}
		}
	}
}
