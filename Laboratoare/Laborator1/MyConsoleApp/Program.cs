using System.Numerics;

class Program
{
    bool Problema1(int n)
    {
        int inverse = 0, temp = n;
        while (temp != 0)
        {
            inverse = inverse * 10 + temp % 10;
            temp /= 10;
        }
        if (n == inverse)
            return true;
        else
            return false;
    }

    bool Problema2(List<int> v)
    {
        bool ok = true;
        for (int i = 0; i < v.Count - 1; i++)
        {
            if (v[i] % 2 == v[i + 1] % 2)
            {
                ok = false;
                break;
            }
        }

        return ok;
            
    }


    static void Main(string[] args)
    {
        // int n = 0;
        // String s = Console.ReadLine();
        // if (s != null)
        //     n = int.Parse(s); //!!!!!!
        // if (new Program().Problema1(n))
        //     Console.WriteLine("Numarul este palindrom");
        // else
        //     Console.WriteLine("Numarul nu este palindrom");

        String s = Console.ReadLine();
        List<int> v = new List<int>();
        String[] temp = s.Split(' ');

        for (int i = 0; i < temp.Length; i++)
            v.Add(int.Parse(temp[i]));
        
        Program Solution = new Program();
        if (Solution.Problema2(v))
            Console.WriteLine("DA");
        else
            Console.WriteLine("NU");

    }
}