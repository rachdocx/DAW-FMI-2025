using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class ExamplesController : Controller
    {
        public string concatenare(string a, string b)
        {
            return a + b;
        }
        public string produs(int a, int? b)
        {
            if (b == null)
            {
                return "Introduceti ambele valori";
            }
            return (a * b).ToString();
        }
        public string operatie(int? a, int? b, string? op)
        {
            string mesaj = "Introduceti: ";
            if (a == null)
            {
                mesaj += "prima valoare, ";
            }
            if (b == null)
            {
                mesaj += "a doua valoare, ";
            }
            if (op == null)
            {
                mesaj += "operatia";
            }
            if (mesaj != "Introduceti: ")
            {
                return mesaj;
            }

            
            if (op == "adunare")
            {
                return (a + b).ToString();
            }
            else if (op == "scadere")
            {
                return (a - b).ToString();
            }
            else if (op == "inmultire")
            {
                return (a * b).ToString();
            }
            else if (op == "impartire")
            {
                if (b == 0)
                {
                    return "Impartirea la 0 nu este definita";
                }
                return (a / b).ToString();
            }
            else 
            {
                return "Operatie necunoscuta";
            }
        }
        
    }
}
