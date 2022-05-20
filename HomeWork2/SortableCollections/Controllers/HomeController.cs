using Microsoft.AspNetCore.Mvc;
using SortableCollections.Models;
using System.Diagnostics;

namespace SortableCollections.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Contact> contacts;

        private IContactRepository contactRepository;

        public HomeController(ILogger<HomeController> logger,IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
            _logger = logger;           
            
        }
     
        public IActionResult Index(string sortOrder)
        {
            
           ViewData["NameSortParm"] = sortOrder== "name" ? "name_desc" : "name";
           ViewData["IdSortParm"] = sortOrder == "ID" ? "id_desc" : "ID";
           ViewData["CitySortParm"] = sortOrder == "city" ? "city_desc" : "city";
           ViewData["StateSortParm"] = sortOrder == "state" ? "state_desc" : "state";
           ViewData["PhoneSortParm"] = sortOrder == "phone" ? "phone_desc" : "phone";

            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "id":
                        {
                            // id ascending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderBy(s => s.Id).ToList<Contact>();
                            break;
                        }
                    
                    case "name":
                        {
                            // name ascending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderBy(s => s.Name).ToList<Contact>();
                            break;
                        }
                    
                    case "city":
                        {
                            // city ascending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderBy(s => s.City).ToList<Contact>();
                            break;
                        }
                    case "state":
                        {
                            // state ascending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderBy(s => s.State).ToList<Contact>();
                            break;
                        }
                    case "phone":
                        {
                            // phone ascending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderBy(s => s.Phone).ToList<Contact>();
                            break;
                        }

                    case "id_desc":
                        {
                            // id descending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderByDescending(s => s.Id).ToList<Contact>();
                            break;
                        }

                    case "name_desc":
                        {
                            // name descending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderByDescending(s => s.Name).ToList<Contact>();
                            break;
                        }
                    case "city_desc":
                        {
                            // city descending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderByDescending(s => s.City).ToList<Contact>();
                            break;
                        }
                    case "state_desc":
                        {
                            // state descending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderByDescending(s => s.State).ToList<Contact>();
                            break;
                        }
                    case "phone_desc":
                        {
                            // phone descending order
                            contactRepository.Contacts = contactRepository.Contacts.OrderByDescending(s => s.Phone).ToList<Contact>();
                            break;
                        }
                }
            }

            return View(contactRepository.Contacts);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.Add(contact);
                return Index(String.Empty);
            }

            else
            {
                return View();
            }
        }
    }
}