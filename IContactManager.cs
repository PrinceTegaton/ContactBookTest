using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public interface IContactManager
    {
        bool Save(ContactModel model);
        ContactModel GetByID(int id);
        IEnumerable<ContactModel> GetAll();
        bool Delete(int id);
    }
}
