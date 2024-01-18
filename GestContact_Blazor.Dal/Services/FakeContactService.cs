using GestContact_Blazor.Dal.Entities;
using GestContact_Blazor.Dal.Repositories;

namespace GestContact_Blazor.Dal.Services
{
    public class FakeContactService : IContactRepository
    {
        private readonly IList<Contact> _items;

        public FakeContactService(IList<Contact> items)
        {
            _items = items;
        }

        public IEnumerable<Contact> Get()
        {
            return _items;
        }

        public Contact? Get(int id)
        {
            return _items.SingleOrDefault(c => c.Id == id);
        }

        public Contact Insert(Contact contact)
        {
            contact.Id = _items.Count() > 0 ? _items.Max(c => c.Id) + 1 : 1;
            _items.Add(contact);
            return contact;
        }

        public bool Update(Contact contact)
        {
            Contact? c = _items.SingleOrDefault(c => c.Id == contact.Id);

            if(c is null)
                return false;

            c.Nom = contact.Nom;
            c.Prenom = contact.Prenom;
            c.Anniversaire = contact.Anniversaire;
            return true;
        }

        public bool Delete(int id)
        {
            Contact? c = _items.SingleOrDefault(c => c.Id == id);

            if (c is null)
                return false;

            _items.Remove(c);
            return true;
        }
    }
}
