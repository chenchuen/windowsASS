using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.NET_Ass2
{
	class Login : MainClass
	{
		public Login()
		{
			string username = string.Empty; //read-only
			string password = string.Empty; //read-only
			bool Admin = false;


			List<Users> ListOfUsers = new List<Users>();
			ListOfUsers = RetrieveUsersInfo();
			Console.WriteLine("Please enter username:");
			username = Console.ReadLine();

			if (usernameCompare(ListOfUsers, username))
			{
				Console.WriteLine("Please enter your password");
				password = Console.ReadLine();

				if (passwordCompare(ListOfUsers, password))
				{
					Console.WriteLine("Login successfully for user: " + username);
					if (GetUserRole(ListOfUsers, username) == "ADMIN")
					{
						Admin = true;
					}
					else
					{
						Admin = false;
					}
				}
					else
					{
						Console.WriteLine("Invalid Password!");
						return;
					}
				}
				else
				{
					Console.WriteLine("Invalid UserName!");
					return;
					//Login();
				}
			}




			public string GetUserRole(List<Users> User, string username)
		{
			string RoleOfUser = string.Empty;

			foreach (Users usr in User)
			{
				if (usr.Username.ToUpper() == username.ToUpper())
				{
						RoleOfUser = usr.Role.ToUpper();
					break;
				}
			}

				return RoleOfUser;
		}

			public bool usernameCompare(List<Users> UserList, string usernameCollected) //compare username in the list (from file)
		{
			bool usernameStatus = false;
			foreach (Users info in UserList)
			{
				if (usernameCollected.ToUpper() == info.Username.ToUpper()) //convert to uppercase for easier comparison
				{
						usernameStatus = true;
					break;
				}
			}
				return usernameStatus;

		}

			public bool passwordCompare(List<Users> UserList, string passwordCollected) //compare username in the list (from file)
		{
			bool passwordStatus = false;
			foreach (Users info in UserList)
			{
					if (passwordCollected.ToUpper() == info.Password.ToUpper()) //convert to uppercase for easier comparison
				{
						passwordStatus = true;
					break;
				}
			}
				return passwordStatus;

		}
		}	
	}
