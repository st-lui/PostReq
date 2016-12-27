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
			try
			{
				using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
				{
					using (
						UserPrincipal foundPrincipal = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName))
					{
						using (DirectoryEntry de = (DirectoryEntry) foundPrincipal.GetUnderlyingObject())
						{
								user = new User
								{
									UserName = foundPrincipal.SamAccountName,
									Fio = foundPrincipal.DisplayName,
									Post = uow.Posts.Get(de.Properties["Company"].Value.ToString())
								};
								return user;
							
						}
					}
				}
			}
			catch (Exception e)
			{
				user = new User
				{
					UserName = userName
				};
				return user;
			}
		}
	}
}
