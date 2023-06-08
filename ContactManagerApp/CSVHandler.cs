using ContactManagerApp.Data;

namespace ContactManagerApp
{
    public class CSVHandler
    {
        public CSVHandler() { }

        public Contact[] GetContactsFromCSV(string csv)
        {
            string[] csvs = csv.Split("\n");
            Contact[] contacts = new Contact[csvs.Length - 1];

            for (int i = 1; i < csvs.Length; i++)
            {   
                if(csvs[i].Equals(""))
                {                    
                    break;
                }
                string[] items = csvs[i].Split(",");                
                string name = items[0];
                DateTime date = Convert.ToDateTime(items[1]);
                bool married = Convert.ToBoolean(items[2]);
                string phone = items[3];
                decimal salary = Convert.ToDecimal(items[4]);
                Contact contact = new Contact(name, date, married, phone, salary);
                contacts[i - 1] = contact;
            }

            return contacts;
        }
    }
}
