using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.NET_Ass2
{

	class MainClass
	{
		public const string MasterDirectory = "../Database/";
		static string UserDirectory = string.Empty;
		static string MovieListDirectory = string.Empty;

		static void Main(string[] args)
		{
			CreateDirectory();
			int option;
			Console.WriteLine("===================================");
			Console.WriteLine("\t\t\tWelcome to JCL Cinemas!\t\t\t");
			Console.WriteLine("===================================");
			Console.WriteLine("Login as:");
			Console.WriteLine("1) Customer");
			Console.WriteLine("2) Manager");
			Console.WriteLine("3) Clerk");
			Console.WriteLine("Option:");
			option = Convert.ToInt32(Console.ReadLine());


			switch (option)
			{
				case 1:
					Console.WriteLine("Coming Soon!");
					break;

				case 2:
					//Login log = new Login();
					Login();
					/*Manager man = new Manager();
					man.menu();*/

					break;

				case 3:
					Console.WriteLine("Coming Soon!");
					break;

				default:
					Console.WriteLine("Try again!");
					break;
			}
		}

		//Creating File Directories

		public static void CreateDirectory()
		{
			Console.WriteLine("hello");
			if (!Directory.Exists(MasterDirectory)) //create directory 
			{
				Directory.CreateDirectory(MasterDirectory); //create directory
			}

			String MovieFile = "ListOfMovies.txt";
			String UserInfo = "UsersInfo.txt";

			String MasterMovieList = Path.Combine(MasterDirectory, MovieFile); //combine path and name of files
			String MasterUserInfo = Path.Combine(MasterDirectory, UserInfo); //combine path and name of files 

			if (!File.Exists(MasterMovieList)) //if no files exist, create new file
			{
				Console.WriteLine("hello");
				File.CreateText(MasterMovieList).Close();
			}

			if (!File.Exists(MasterUserInfo))//if no files exist, create new file
			{
				Console.WriteLine("hello");
				File.CreateText(MasterUserInfo).Close();
			}

			UserDirectory = MasterUserInfo; // get path of the userFile
			MovieListDirectory = MasterMovieList; // get path of the MovieList
		}

		public static List<Users> RetrieveUsersInfo()
		{
			List<Users> TotalUsers = new List<Users>();

			FileInfo file = new FileInfo(UserDirectory);

			if (file.Length > 0)
			{
				string[] lines = System.IO.File.ReadAllLines(UserDirectory);
				if (lines.Count() > 0)
				{
					foreach (string ln in lines)
					{
						//Retreive data from txt file and put inside a list separated by ;
						Users user = new Users();
						string[] Userdata = ln.Split(';');
						user.Name = Userdata[0];
						user.Username = Userdata[1];
						user.Role = Userdata[2];
						user.Password = Userdata[3];
						user.EmailAddress = Userdata[4];
						TotalUsers.Add(user);
					}
				}
			}
			return TotalUsers;
		}

		public static void Login()
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
			return;
		}




		public static string GetUserRole(List<Users> User, string username)
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

		public static bool usernameCompare(List<Users> UserList, string usernameCollected) //compare username in the list (from file)
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

		public static bool passwordCompare(List<Users> UserList, string passwordCollected) //compare username in the list (from file)
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
