//using System;
//using System.IO;
//using System.Collections;
//using NDatabase.Api;
//using NDatabase;

//public class Sport
//{
//    public Sport(string name)
//    {
//        Name = name;
//    }

//    public string Name { get; set; }

//    public override string ToString()
//    {
//        return Name;
//    }
//}

//public class Player
//{
//    public Player(string name, DateTime time, Sport sport)
//    {
//        Name = name;
//        Time = DateTime.Now;
//        gameName = sport;

//    }

//    public string Name { get; set; }
//    public DateTime Time { get; set; }
//    public Sport gameName { get; set; }

//    public override string ToString()
//    {
//        return Name + "\n" + Time + "\n" + gameName + "\n";
//    }
//}

//public class n1
//{
//    public void persistobj()
//    {

//        var sport = new Sport("volley-ball");

//        using (var odb = OdbFactory.Open("test.db"))
//            odb.Store(sport);

//        var player1 = new Player("julia", DateTime.Now, new Sport("volleyball"));
//        var player2 = new Player("magdalena", DateTime.Now, new Sport("volleyball"));
//        var player3 = new Player("jacek", DateTime.Now, new Sport("volleyball"));
//        var player4 = new Player("michal", DateTime.Now, new Sport("volleyball"));

//        using (var odb = OdbFactory.Open("test.db"))
//        {
//            odb.Store(player1);
//            odb.Store(player2);
//            odb.Store(player3);
//            odb.Store(player4);
//        }
//        //var sport = new Sport("volley-ball");

//        //using (var odb = OdbFactory.Open("test.db"))
//        //{
//        //    odb.Store(sport);
//        //}
//    }

//    public void retrieveobj()
//    {
//        using (var odb1 = OdbFactory.Open("test.db"))
//        {
//            var sports = odb1.QueryAndExecute<Sport>();
//            //var sport = odb1.Query<Sport>();
//            foreach(var sport in sports)
//            {
//                Console.WriteLine(sport.Name);
//                Console.WriteLine(sport.ToString());
//            }
//            Console.WriteLine(sports);
//        }
//        using (var odb1 = OdbFactory.Open("test.db"))
//        {
//            var player = odb1.QueryAndExecute<Player>();
//            //var sport = odb1.Query<Sport>();
//            foreach(var item in player)
//            {
//                Console.WriteLine(item.Name);
//                Console.WriteLine(item.Time);
//                Console.WriteLine(item.gameName);
//                Console.WriteLine(item.ToString());
//            }
//        }
//    }

//    public static void Main()
//    {
//        n1 n = new n1();
//        bool exitflag = false;
//        while (!exitflag)
//        {
//            Console.WriteLine();
//            Console.WriteLine("n1 - NDatabase Code Sample 1 - p4 - NDatabase pdf");
//            Console.WriteLine("1  - persist an object and store data in db");
//            Console.WriteLine("2  - retrieve object from db");
//            Console.WriteLine("3  - quit");
//            Console.Write("> ");
//            int i1 = int.Parse(Console.ReadLine());
//            switch (i1)
//            {
//                case 1:
//                    n.persistobj();
//                    break;
//                case 2:
//                    n.retrieveobj();
//                    break;
//                case 3:
//                    exitflag = true;
//                    break;
//            }
//        }
//    }
//}