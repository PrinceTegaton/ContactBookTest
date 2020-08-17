using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    // implement IContactManager interface and wire up all methods

    public class ContactManager : IContactManager
    {
        string db = AppDomain.CurrentDomain.BaseDirectory + "\\ContactDB.json";

        public ContactManager()
        {
            // create db on init if not exist
            if (!File.Exists(db))
                File.Create(db);
        }

        private List<ContactModel> ReadDB()
        {
            if (!File.Exists(db))
                throw new FileNotFoundException($"Database not found at '{db}'");

            string content = File.ReadAllText(db);
            var data = JsonConvert.DeserializeObject<List<ContactModel>>(content);
            return data;
        }

        private bool WriteDB(IEnumerable<ContactModel> obj)
        {
            File.WriteAllText(db, JsonConvert.SerializeObject(obj));
            return true;
        }

        public bool Save(ContactModel model)
        {
            if (model == null)
                throw new ArgumentNullException("ContactModel cannot be null");

            var data = ReadDB();

            if (data == null)
                data = new List<ContactModel>();

            // generate ID
            model.ID = data.Count + 1;

            data.Add(model);
            return WriteDB(data);
        }

        public bool Delete(int id)
        {
            var data = ReadDB();

            if (!data.Any()) return false;

            // method 1
            data.RemoveAll(a => a.ID == id);

            // method 2
            //var contactToDel = data.FirstOrDefault(a => a.ID == id);
            //if (contactToDel != null)
            //    data.Remove(contactToDel);

            return WriteDB(data);
        }

        public IEnumerable<ContactModel> GetAll()
        {
            var data = ReadDB();
            return data;
        }

        public ContactModel GetByID(int id)
        {
            var data = ReadDB();

            if (!data.Any()) return null;

            // method 1
            //var contact = data.First(a => a.ID == id);
            //return contact;

            // method 2
            return data.FirstOrDefault(a => a.ID == id);
        }
    }
}
