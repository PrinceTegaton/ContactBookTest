using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    class Program
    {
        // utilize IContactManager here

        static IContactManager _contactManager;

        static void Main(string[] args)
        {
        _start:

            try
            {
                _contactManager = new ContactManager();
                string input = string.Empty;

                Console.WriteLine("WELCOME TO CONTACT BOOK");
                Console.WriteLine("Enter a command..");

                input = Console.ReadLine().ToLower();
                if (input == "add")
                {
                    // add new contact here

                    // accept all parameters to fit model here using Console.ReadLine() for each property one by one

                    var contact = new ContactModel();

                    Console.WriteLine("Enter Name:");
                    contact.Name = Console.ReadLine();

                    Console.WriteLine("Enter Phone Number:");
                    contact.PhoneNumber = Console.ReadLine();

                    Console.WriteLine("Enter Email Address:");
                    contact.EmailAddress = Console.ReadLine();

                    // save contact
                    bool result = _contactManager.Save(contact);

                    if (result == true)
                        Console.WriteLine("Contact has been saved OK");
                    else
                        Console.WriteLine("Unable to save contact details");
                }
                else if (input.StartsWith("get")) // e.g: get 1 (retrieves contact with ID=1)
                {
                    // get contact by ID here
                    string str = input.Split(' ')[1]; // retrieve ID of contact from command

                    // get contact info and print in the below format
                    // ID: 1
                    // Name: James Khan
                    // Phone: 09099999999
                    // Email: james.khan@gmail.com

                    int id = Convert.ToInt32(str);
                    var contact = _contactManager.GetByID(id);

                    if (contact == null)
                    {
                        Console.WriteLine($"Contact with ID '{id}' does not exist");
                    }
                    else
                    {
                        Console.WriteLine("ID: {0}", contact.ID);
                        Console.WriteLine("Name: {0}", contact.Name);
                        Console.WriteLine("Phone: {0}", contact.PhoneNumber);
                        Console.WriteLine("Email: {0}", contact.EmailAddress);

                        // or
                        //Console.WriteLine($"ID: {contact.ID}");
                        //Console.WriteLine($"Name: {contact.Name}");
                        //Console.WriteLine($"Phone: {contact.PhoneNumber}");
                        //Console.WriteLine($"Email: {contact.EmailAddress}");
                    }

                }
                else if (input == "all")
                {
                    // get all contact and print them in the below format
                    // ID: 1, Name: James Khan, Phone: 09099999999, Email: james.khan@gmail.com

                    // print here
                    var contacts = _contactManager.GetAll();

                    if (contacts == null || !contacts.Any())
                        Console.WriteLine("Contact book is empty");
                    else
                    {
                        foreach (var i in contacts)
                        {
                            Console.WriteLine("ID: {0}, Name: {1}, Phone: {2}, Email: {3}", i.ID, i.Name, i.PhoneNumber, i.EmailAddress);
                        }
                    }
                }
                else if (input.StartsWith("delete")) // e.g: get 1 (delete contact with ID=1)
                {
                    // get contact by ID here
                    string str = input.Split(' ')[1]; // retrieve ID of contact to delete
                    int id = Convert.ToInt32(str);

                    // delete here
                    bool result = _contactManager.Delete(id);

                    if (result == true)
                        Console.WriteLine("Contact has been deleted");
                    else
                        Console.WriteLine("Unable to delete contact details");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
            goto _start;
        }
    }
}
