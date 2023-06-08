using ContactManagerApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApp
{
    [Route("")]
    public class ContactController : Controller
    {
        ContactDataContext db = new ContactDataContext();
        IConfiguration config;
        CSVHandler csvhandler = new CSVHandler();


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
            string path = Path.Combine("D:\\MiscData", "aoghau", newFileName);
            Directory.CreateDirectory(Path.Combine("D:\\MiscData", "aoghau"));
            await using (FileStream fs = new(path, FileMode.CreateNew))
            {
                await file.OpenReadStream().CopyToAsync(fs);
            };
            using (StreamReader sr = new StreamReader(path))
            {
                string text = await sr.ReadToEndAsync();
                var people = csvhandler.GetContactsFromCSV(text);
                for(int i = 0; i < people.Count(); i++) 
                {
                    if (!(people[i] == null))
                        db.Contacts.Add(people[i]);
                }                
                db.SaveChanges();
            };

            List<string[]> contacts = new List<string[]>();
            for (int i = 0; i < db.Contacts.Count(); i++)
            {
                string[] items = new string[6];
                items[0] = db.Contacts.ToList()[i].Id.ToString();
                items[1] = db.Contacts.ToList()[i].Name;
                items[2] = db.Contacts.ToList()[i].DateOfBirth.ToString();
                items[3] = db.Contacts.ToList()[i].Married.ToString();
                items[4] = db.Contacts.ToList()[i].Phone;
                items[5] = db.Contacts.ToList()[i].Salary.ToString();
                contacts.Add(items);
            }

            ViewBag.People = contacts;
            return View();
        }
    }
}
