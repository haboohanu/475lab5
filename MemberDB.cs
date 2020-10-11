using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _475Lab5.Model
{
    /// <summary>
    /// A class that uses a text file to store information about the gym members longterm.
    /// </summary>
    class MemberDB : ObservableObject
    {
        /// <summary>
        /// The list of members to be saved.
        /// </summary>
        private ObservableCollection<Member> members;
        /// <summary>
        /// Where the database is stored.
        /// </summary>
        private const string filepath = "../members.txt";
        /// <summary>
        /// Creates a new member database.
        /// </summary>
        /// <param name="m">The list to saved from or written to.</param>
        public MemberDB(ObservableCollection<Member> m)
        {
            members = m;
        }
        /// <summary>
        /// Reads the saved text file database into the program's list of members.
        /// </summary>
        /// <returns>The list containing the text file data read in.</returns>
        public ObservableCollection<Member> GetMemberships()
        {
            try
            {
                StreamReader input = new StreamReader(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read));
                //members.Add(new Member { FirstName = "Jimmy", LastName = "Tran", Email = "haboohanu@gmail.com" });
                //members.Add(new Member { FirstName = "Arty", LastName = "Day", Email = "aa@gmail.com" });
                //members.Add(new Member { FirstName = "Bob", LastName = "Gee", Email = "bb@gmail.com" });
                //int counter = 0;
                string line;
                while((line = input.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    //System.Console.WriteLine("{0}", words[0]);
                    //System.Console.WriteLine("{0}", words[1]);
                    //System.Console.WriteLine("{0}", words[2]);
                    //counter++;
                    members.Add(new Member { ProductID = words[0], ProductName = words[1], Quantity = words[2] });
                }
                //System.Console.WriteLine("There were {0} lines.", counter);
                input.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Input...(MemberDBget)");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Missing Input...(MemberDBget)");
            }
            return members;
        }
        /// <summary>
        /// Saves the program's list of members into the text file database.
        /// </summary>
        public void SaveMemberships()
        {
            try
            {
                StreamWriter output = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write));
                foreach(Member member in members)
                {
                    output.WriteLine(member.ProductID + " " + member.ProductName + " " + member.Quantity);
                }
                output.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Input...(MemberDBsave)");
            }
        }
    }
}
