using Homework3.Db;
using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// adding data
using (var context = new Homework3.Db.ContactsContext())
{
    Contact contact = new Contact()
    {
        ContactName = "Jack",
        ContactEmail = "Jack@gmail.com",
        ContactAge = 33,
        ContactNotes = "Jack",
        ContactPhoneNumber = "145623",
        ContactCreatedDate = DateTime.Now,
        ContactPhoneType = "Mobile"

    };
    context.Contacts.Add(contact);
    context.SaveChanges();
}

// update data
using (var context = new Homework3.Db.ContactsContext())
{
    var contact = context.Contacts.FirstOrDefault();
    contact.ContactName = "Jill";
    context.SaveChanges();
}

// delete data
using (var context = new Homework3.Db.ContactsContext())
{
    var contact = context.Contacts.Where(a => a.ContactId == 1).FirstOrDefault();
    context.Contacts.Remove(contact);
    context.SaveChanges(true);
}
    