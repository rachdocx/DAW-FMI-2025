using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class StudentsController : Controller
    {
        public string Index()
        {
            return "Afisarea tuturor studentilor";
        }
        public string Create()
        {
            return "Creare student nou";
        }
        public string Show(int? id)
        {
            if (id is null)
            {
                return "nu exista id-ul ";
            }
            return "Afisare student cu id-ul " + id;
        }
        public string Edit(int? id)
        {
            if (id is null)
            {
                return "nu exista id-ul ";
            }
            return "Editare student cu id-ul " + id;
        }

        public string Delete(int? id)
        {
            if (id is null)
            {
                return "nu exista id-ul ";
            }
            return "Stergere student cu id-ul " + id;
        }

    }
}
