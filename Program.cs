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

        static void Main(string[] args)
        {
            string input = string.Empty;

            input = Console.ReadLine().ToLower();
            if (input == "add")
            {
                // add new contact here

                // accept all parameters to fit model here using Console.ReadLine() for each property one by one
                // save contact
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
            }
            else if (input == "getall")
            {
                // get all contact and print them in the below format
                // ID: 1, Name: James Khan, Phone: 09099999999, Email: james.khan@gmail.com

                // print here
            }
            else if (input.StartsWith("delete")) // e.g: get 1 (delete contact with ID=1)
            {
                // get contact by ID here
                string str = input.Split(' ')[1]; // retrieve ID of contact to delete


                // delete here
            }
        }
    }
}
