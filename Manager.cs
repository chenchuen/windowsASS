using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.NET_Ass2
{
	class Manager : MainClass
	{

		//ArrayList movies = new ArrayList();
		public Manager()
		{
		}

		/*public void Login()
		{
			string username = string.Empty; //read-only
			string password = string.Empty; //read-only


			List<Users> ListOfUsers = new List<Users>();
			ListOfUsers = RetrieveUsersInfo();
			Console.WriteLine("Please enter username:");
			username = Console.ReadLine();

			if (IsUserNameExist(ListOfUsers, username))
			{
				Console.WriteLine("Please enter your password");
				password = Console.ReadLine();

				if(IsPasswordMatch(UserList, password))
				{
					Console.WriteLine("Login successfully for user: " + username);
					if (GetUserRole(UserList, username) == "ADMIN")
					{
						IsRoleAdmin = true;
					}
					else
					{
						IsRoleAdmin = false;
					}
					else
					{
						Console.WriteLine("Invalid Password!");
						Login();
					}
			}
			else
			{
				Console.WriteLine("Invalid UserName!");
				Login();
			}



			return;
		}

		public bool IsUserNameExist(List<Users> UserList, string UserNameInput)
		{
			bool IsUserExist = false;
			foreach (Users usr in UserList)
			{
				if (UserNameInput.ToUpper() == usr.Username.ToUpper())
				{
					IsUserExist = true;
					break;
				}
			}
			return IsUserExist;

		}*/

		public void menu()
		{
			//Login() a = new Login();
			int manager_option;
			Console.WriteLine("Please choose a following:");
			Console.WriteLine("1) Add a film");
			Console.WriteLine("2) Delete a film");
			Console.WriteLine("3) Add Screen");
			Console.WriteLine("3) Add Showing");
			Console.WriteLine("3) Cancel Showing");
			Console.WriteLine("Option:");
			manager_option = Convert.ToInt32(Console.ReadLine());

			switch (manager_option)
			{
				case 1: addFilm(); break;
				case 2: deleteFilm(); break;
				case 3: addScreen(); break;
				case 4: addShowing(); break;
				case 5: cancelShowing(); break;
				default: Console.WriteLine("Try Again!"); break;
			}
		}

		public void addFilm()
		{
			string title, rating, duration, desc;
			Console.WriteLine("1) Title of movie: ");
			title = Console.ReadLine();
			Console.WriteLine("2) Ratings: ");
			rating = Console.ReadLine();
			Console.WriteLine("3) Duration: ");
			duration = Console.ReadLine();
			Console.WriteLine("4) Description: ");

		}
		public void deleteFilm()
		{ 
			Console.WriteLine("deleteFilm");
		}
		public void addScreen()
		{
			Console.WriteLine("addScreen");
		}
		public void addShowing()
		{
			Console.WriteLine("addshowing");
		}
		public void cancelShowing()
		{
			Console.WriteLine("cancelshowing");
		}

		/*public List<Users> RetrieveUsersInfo()
		{
			List<Users> TotalUsers = new List<Users>();
			FileInfo file = new FileInfo(UserDirectory);
		}*/
	}
}
