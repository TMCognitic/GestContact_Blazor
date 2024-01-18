using GestContact_Blazor.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact_Blazor.Dal.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact? Get(int id);
        Contact Insert(Contact contact);
        bool Update(Contact contact);
        bool Delete(int id);
    }
}
