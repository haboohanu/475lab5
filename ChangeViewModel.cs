using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using _475Lab5.Model;
using System;
using _475Lab5.Views;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace _475Lab5.ViewModel
{
    /// <summary>
    /// The VM for modifying or removing users.
    /// </summary>
    public class ChangeViewModel : ViewModelBase
    {
        /// <summary>
        /// The currently entered first name in the change window.
        /// </summary>
        public string enteredPID;
        /// <summary>
        /// The currently entered last name in the change window.
        /// </summary>
        public string enteredPName;
        /// <summary>
        /// The currently entered email in the change window.
        /// </summary>
        public string enteredQuantity;
        public int TEXT_LIMIT = 10;
        /// <summary>
        /// Initializes a new instance of the ChangeViewModel class.
        /// </summary>
        public ChangeViewModel()
        {
            //filled these in
            UpdateCommand = new RelayCommand<IClosable>(UpdateMethod);
            DeleteCommand = new RelayCommand<IClosable>(DeleteMethod);
            Messenger.Default.Register<Member>(this, GetSelected);
        }
        /// <summary>
        /// The command that triggers saving the filled out member data.
        /// </summary>
        public ICommand UpdateCommand { get; private set; }
        /// <summary>
        /// The command that triggers removing the previously selected user.
        /// </summary>
        public ICommand DeleteCommand { get; private set; }
        /// <summary>
        /// Sends a valid member to the main VM to replace at the selected index with, then closes the change window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void UpdateMethod(IClosable window)
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
                    MessageMember m = new MessageMember(mem.ProductID, mem.ProductName, mem.Quantity, "Update");
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
        /// Sends out a message to initiate closing the change window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void DeleteMethod(IClosable window)
        {
            if (window != null)
            {
                Messenger.Default.Send(new NotificationMessage("Delete"));
                EnteredPID = null;
                EnteredPName = null;
                EnteredQuantity = null;
                window.Close();
            }
        }
        /// <summary>
        /// Receives a member from the main VM to auto-fill the change box with the currently selected member.
        /// </summary>
        /// <param name="m">The member data to fill in.</param>
        public void GetSelected(Member m)
        {
            //filled in here
            RaisePropertyChanged("SelectedMember");
        }
        /// <summary>
        /// The currently entered first name in the change window.
        /// </summary>
        public string EnteredPID
        {
            get
            {
                return enteredPID;
            }
            set
            {
                enteredPID = value;
                RaisePropertyChanged("EnteredPID");
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
                enteredPName = value;
                RaisePropertyChanged("EnteredPName");
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
                enteredQuantity = value;
                RaisePropertyChanged("EnteredQuantity");
            }
        }

    }
}

