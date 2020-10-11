using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using _475Lab5.Model;
using _475Lab5.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;


namespace _475Lab5.ViewModel
{
    /// <summary>
    /// The VM for adding users to the list.
    /// </summary>
    public class AddViewModel : ViewModelBase
    {
        /// <summary>
        /// The currently entered first name in the add window.
        /// </summary>
        public string enteredPID;
        /// <summary>
        /// The currently entered last name in the add window.
        /// </summary>
        public string enteredPName;
        /// <summary>
        /// The currently entered email in the add window.
        /// </summary>
        public string enteredQuantity;
        int TEXT_LIMIT = 10;
        /// <summary>
        /// Initializes a new instance of the AddViewModel class.
        /// </summary>
        public AddViewModel()
        {
            SaveCommand = new RelayCommand<IClosable>(SaveMethod);
            CancelCommand = new RelayCommand<IClosable>(CancelMethod);
        }
        /// <summary>
        /// The command that triggers saving the filled out member data.
        /// </summary>
        public ICommand SaveCommand { get; private set; }
        /// <summary>
        /// The command that triggers closing the add window.
        /// </summary>
        public ICommand CancelCommand { get; private set; }
        /// <summary>
        /// Sends a valid member to the Main VM to add to the list, then closes the window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void SaveMethod(IClosable window)
        {
            try
            {
                if (window != null)
                {
                    Member mem = new Member(EnteredPID, EnteredPName, EnteredQuantity);
                    
                    if (EnteredPName == null || EnteredPID == null)
                    {
                        throw new NullReferenceException();

                    }
                    long i = 0;
                    bool canConvertPID = long.TryParse(EnteredPID, out i);
                    if (canConvertPID == false)
                    {
                        //MessageBox.Show("ProductID should be numbers only", "Entry Error");
                        throw new FormatException("ProductID should be numbers only");
                    }
                    if (EnteredPID.Length > TEXT_LIMIT)
                    {
                        throw new InvalidDataException("Too long");
                    }
                    long j = 0;
                    bool canConvertQuant = long.TryParse(EnteredQuantity, out j);
                    if (canConvertQuant == false)
                    {
                        //MessageBox.Show("Quantity should should be numbers only", "Entry Error");
                        throw new FormatException("Quantity should be numbers only");
                    }
                    else
                    {
                        int num = Int32.Parse(EnteredQuantity);
                        if (num < 5 || num > 100)
                        {
                            //MessageBox.Show("Invalid Quantity", "Entry Error");
                            throw new ArgumentException("Invalid Quantity");
                        }
                    }
                    MessageMember m = new MessageMember(mem.ProductID, mem.ProductName, mem.Quantity, "Add");
                    Messenger.Default.Send<MessageMember>(m);
                    EnteredPID = null;
                    EnteredPName = null;
                    EnteredQuantity = null;
                    window.Close();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid Quantity.", "Entry Error");
                Console.WriteLine("Invalid input.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fields cannot be empty.", "Entry Error");
                Console.WriteLine("Fields cannot be empty.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Product ID or Quantity should be numbers only.", "Entry Error");
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Input too long", "Entry Error");
            }
        }
        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void CancelMethod(IClosable window)
        {
            if (window != null)
            {
                EnteredPID = null;
                EnteredPName = null;
                EnteredQuantity = null;
                window.Close();
            }
        }
        /// <summary>
        /// The currently entered first name in the add window.
        /// </summary>
        public string EnteredPID
        {
            get
            {
                return enteredPID;
            }
            set
            {
                //enteredPID = value;
                //RaisePropertyChanged("EnteredPID");
                //long i = 0;
                //bool canConvert = long.TryParse(value, out i);
                //if (value.Length == 0)
                //{
                //    MessageBox.Show("Fields cannot be empty.", "Entry Error");
                //    //throw new NullReferenceException();
                //}
                //else if (canConvert == false)
                //{
                //    MessageBox.Show("ProductID should be numbers only", "Entry Error");
                //    //throw new ArgumentException("ProductID should be numbers only");
                //}
                enteredPID = value;
            }
        }
        public string EnteredPName
        {
            get
            {
                return enteredPName;
            }
            set
            {
                ////enteredPName = value;
                //RaisePropertyChanged("EnteredPName");
                //if (value.Length > TEXT_LIMIT)
                //{
                //    MessageBox.Show("Fields must be under 10 characters", "Entry Error");
                //    //throw new ArgumentException("Too long");
                //}
                //else if (value.Length == 0)
                //{
                //    MessageBox.Show("Fields cannot be empty", "Entry Error");
                //    throw new NullReferenceException("Needs input");
                //}
                enteredPName = value;
            }
        }
        public string EnteredQuantity
        {
            get
            {
                return enteredQuantity;
            }
            set
            {
                ////enteredQuantity = value;
                //RaisePropertyChanged("EnteredQuantity");
                //long i = 0;
                //bool canConvert = long.TryParse(value, out i);
                //if (canConvert == false)
                //{
                //    MessageBox.Show("Quantity should should be numbers only", "Entry Error");
                //    //throw new ArgumentException("Quantity should be numbers only");
                //}
                //else
                //{
                //    int num = Int32.Parse(value);
                //    if (num < 5 || num > 100)
                //    {
                //        MessageBox.Show("Invalid Quantity", "Entry Error");
                //        //throw new ArgumentException("Invalid Quantity");
                //    }
                //}
                //if (value.Length > TEXT_LIMIT)
                //{
                //    MessageBox.Show("Fields must be less than 10 characters", "Entry Error");
                //    //throw new ArgumentException("Too long");
                //}
                //if (value.Length == 0)
                //{
                //    MessageBox.Show("Fields cannot be empty", "Entry Error");
                //    throw new NullReferenceException();
                //}
                enteredQuantity = value;
            }
        }
        /// <summary>

    }
}