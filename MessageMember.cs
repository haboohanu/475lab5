using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475Lab5.Model
{
    /// <summary>
    /// An extension of member that also includes a message for some sort of extra description.
    /// </summary>
    public class MessageMember : Member
    {
        /// <summary>
        /// Creates a new member.
        /// </summary>
        /// <param name="fName">The member's first name.</param>
        /// <param name="lName">The member's last name.</param>
        /// <param name="mail">The member's e-mail.</param>
        /// <param name="message">The extra description</param>
        public MessageMember(string pID, string pName, string quant, string message) : base(pID, pName, quant)
        {
            Message = message;
        }
        /// <summary>
        /// A property that includes the message.
        /// </summary>
        public string Message { get; private set; }
    }
}
