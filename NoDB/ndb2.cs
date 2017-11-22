//----------------------------------------------------------------------------------------
// NDB2.cs - 1st Clone Example Taken from NDB1.cs - example NDatabase database
//----------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections;
using NDatabase.Api;
using NDatabase;

//----------------------------------------------------------------------------------------
// Rec - class for storage of records
//----------------------------------------------------------------------------------------
public class Rec
{
    public Rec(string str)
    {
        Str = str;
    }

    public string Str { get; set; }

    public override string ToString()
    {
        return Str;
    }
}

//----------------------------------------------------------------------------------------
// Dat - class to implement storage of records
//----------------------------------------------------------------------------------------
public class Dat
{
    public Dat(int key, string str)
    {
        Key = key;
        Str = str;
    }

    public int Key { get; set; }
    public string Str { get; set; }

    public override string ToString()
    {
        return Key + "\n" + Str + "\n";
    }
}

//----------------------------------------------------------------------------------------
// n2 - main class of NDB2
//----------------------------------------------------------------------------------------
public class n2
{
    //----------------------------------------------------------------------------------------
    // persistobj - create database initially
    //----------------------------------------------------------------------------------------
    public void persistobj()
    {
        using (var odb = OdbFactory.Open("test.db"))
        {
        }
    }

    //----------------------------------------------------------------------------------------
    // storeobj - to store one record in database
    //----------------------------------------------------------------------------------------
    public void storeobj(int k, string s)
    {
        var Dat1 = new Dat(k, s);

        using (var odb = OdbFactory.Open("test.db"))
        {
            odb.Store(Dat1);
        }
    }

    //----------------------------------------------------------------------------------------
    // removeobj - to remove one record in database
    //----------------------------------------------------------------------------------------
    public void removeobj(int k, string s)
    {
        var Dat1 = new Dat(k, s);

        using (var odb = OdbFactory.Open("test.db"))
        {
            var Dat = odb.QueryAndExecute<Dat>();
            foreach (var item in Dat)
            {
                if ((item.Key == k) && (item.Str == s))
                {
                    odb.Delete(item);
                }
            }
        }
    }

    //----------------------------------------------------------------------------------------
    // retrieveobj - to retrieve one record from the database
    //----------------------------------------------------------------------------------------
    public void retrieveobj(int k)
    {
        using (var odb1 = OdbFactory.Open("test.db"))
        {
            var Dat = odb1.QueryAndExecute<Dat>();

            foreach (var item in Dat)
            {
                if (item.Key == k)
                {
                    Console.WriteLine(item.Key + "," + item.Str);
                }
            }
        }
    }

    //----------------------------------------------------------------------------------------
    // listallobj - to retrieve all records from the database
    //----------------------------------------------------------------------------------------
    public void listallobj()
    {
        using (var odb1 = OdbFactory.Open("test.db"))
        {
            var Dat = odb1.QueryAndExecute<Dat>();

            foreach (var item in Dat)
            {
                Console.WriteLine(item.Key + "," + item.Str);
            }
        }
    }

    //----------------------------------------------------------------------------------------
    // reinit - to delete all records from the database
    //----------------------------------------------------------------------------------------
    public void reinit()
    {
        OdbFactory.Delete("test.db");
    }

    //----------------------------------------------------------------------------------------
    // Main - main line of program NDB2
    //----------------------------------------------------------------------------------------
    public static void Main()
    {
        n2 n = new n2();
        try
        {
            bool exitflag = false;
            int k = 0;
            string s = "";
            while (!exitflag)
            {
                Console.WriteLine();
                Console.WriteLine("n1 - NDatabase Code Sample 1 - p4 - NDatabase pdf");
                Console.WriteLine("1  - create db");
                Console.WriteLine("2  - store record in db");
                Console.WriteLine("3  - retrieve record from db");
                Console.WriteLine("4  - remove record from db");
                Console.WriteLine("5  - list all objects");
                Console.WriteLine("6  - delete all records");
                Console.WriteLine("7  - quit");
                Console.Write("> ");
                int i1 = int.Parse(Console.ReadLine());
                switch (i1)
                {
                    case 1:
                        n.persistobj();
                        break;
                    case 2:
                        Console.Write("Enter key: ");
                        k = int.Parse(Console.ReadLine());
                        Console.Write("Enter data: ");
                        s = Console.ReadLine();
                        n.storeobj(k, s);
                        break;
                    case 3:
                        Console.Write("Enter key: ");
                        k = int.Parse(Console.ReadLine());
                        n.retrieveobj(k);
                        break;
                    case 4:
                        Console.Write("Enter key: ");
                        k = int.Parse(Console.ReadLine());
                        Console.Write("Enter data: ");
                        s = Console.ReadLine();
                        n.removeobj(k, s);
                        break;
                    case 5:
                        n.listallobj();
                        break;
                    case 6:
                        n.reinit();
                        break;
                    case 7:
                        exitflag = true;
                        break;
                }
            }
        }
        catch
        {
        }
    }
}