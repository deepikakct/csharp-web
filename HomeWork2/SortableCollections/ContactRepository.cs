namespace SortableCollections.Models
{
 
    public interface IContactRepository
    {
        IEnumerable<Contact> Contacts { get; set; }
        public void Add(Contact contact);
    }

    public class ContactRepository : IContactRepository
    {
        List<Contact> contacts = new List<Contact>();

        public ContactRepository()
        {
            contacts.Add(new Contact { Id = 1, Name = "dave", City = "Seattle", State = "WA", Phone = "123" });
            contacts.Add(new Contact { Id = 2, Name = "mike", City = "Spokane", State = "WA", Phone = "234" });
            contacts.Add(new Contact { Id = 3, Name = "lisa", City = "San Jose", State = "CA", Phone = "345" });
            contacts.Add(new Contact { Id = 4, Name = "cathy", City = "Dallas", State = "TX", Phone = "456" });
        }
        public IEnumerable<Contact> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = (List<Contact>)value;
            }
        }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
