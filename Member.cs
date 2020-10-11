using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475Lab5.Model
{
    /// <summary>
    /// A class that represents a member of a gym.
    /// </summary>
    public class Member : ObservableObject
    {
        /// <summary>
        /// The member's first name.
        /// </summary>
        //private string firstName;
        private string productID;
        private string productName;
        private string quantity;
        /// <summary>
        /// The member's last name.
        /// </summary>
        //private string lastName;
        //private string email;
        int TEXT_LIMIT = 10;
        public Member() { }
        /// <summary>
        /// Creates a new member.
        /// </summary>
        /// <param name="fName">The member's first name.</param>
        /// <param name="lName">The member's last name.</param>
        /// <param name="mail">The member's e-mail.</param>
        //public Member(string pID, string pName, int quant)
        //{
        //    productID = pID;
        //    productName = pName;
        //    quantity = quant;
        //}
        public string ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                long i = 0;
                bool canConvert = long.TryParse(value, out i);
                if(canConvert == false)
                {
                    throw new ArgumentException("ProductID should be numbers only");
                }
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                productID = value;
            }
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException("Needs input");
                }
                productName = value;
            }
        }
        public string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                long i = 0;
                bool canConvert = long.TryParse(value, out i);
                if (canConvert == false)
                {
                    throw new ArgumentException("Quantity should be numbers only");
                }
                int num = Int32.Parse(value);
                if (num < 5 || num > 100)
                {
                    throw new ArgumentException("Invalid Quantity");
                }
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                quantity = value;
            }
        }
        public Member(string pid, string pName, string quant)
        {
            productID = pid;
            productName = pName;
            quantity = quant;
        }

        //public string FirstName
        //{
        //    get
        //    {
        //        return firstName;
        //    }
        //    set
        //    {
        //        if (value.Length > TEXT_LIMIT)
        //        {
        //            throw new ArgumentException("Too long");
        //        }
        //        if (value.Length == 0)
        //        {
        //            throw new NullReferenceException();
        //        }
        //        firstName = value;
        //    }
        //}
        /// <summary>
        /// A property that gets or sets the member's last name, and makes sure it's not too long.
        /// </summary>
        /// <returns>The member's last name.</returns>
        //public string LastName
        //{
        //    get
        //    {
        //        return lastName;
        //    }
        //    set
        //    {
        //        if (value.Length > TEXT_LIMIT)
        //        {
        //            throw new ArgumentException("Too long");
        //        }
        //        if (value.Length == 0)
        //        {
        //            throw new NullReferenceException();
        //        }
        //        lastName = value;
        //    }
        //}
        /// <summary>
        /// A property that gets or sets the member's e-mail, and makes sure it's not too long.
        /// </summary>
        /// <returns>The member's e-mail.</returns>
        //public string Email
        //{
        //    get
        //    {
        //        return email;
        //    }
        //    set
        //    {
        //        if (value.Length > TEXT_LIMIT)
        //        {
        //            throw new ArgumentException("Too long");
        //        }
        //        if (value.Length == 0)
        //        {
        //            throw new NullReferenceException();
        //        }
        //        if (value.IndexOf("@") == -1 || value.IndexOf(".") == -1)
        //        {
        //            throw new FormatException();
        //        }
        //        email = value;
        //    }
        //}

        /// <summary>
        /// Text to be displayed in the list box.
        /// </summary>
        /// <returns>A concatenation of the member's first name, last name, and email.</returns>
        public override string ToString()
        {
            string str = "ID: " + ProductID + ", Name: " + ProductName + ", Quantity: " + Quantity;
            return str;
        }

    }
}