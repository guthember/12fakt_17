using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2008sms
{
  struct Uzenet
  {
    public int o; // óra
    public int p; // perc
    public string t; // telefonszám
    public string u; // üzenet
  }

  class Program
  {
    static Uzenet[] uzenetek = new Uzenet[100];
    static int darab = 0;

    static void Elso()
    {
      Console.WriteLine("1. feladat: Adatok beolvasása");
      // beolvasás
      StreamReader file = new StreamReader("sms.txt");

      darab = Convert.ToInt32( file.ReadLine() );

      for (int i = 0; i < darab; i++)
      {
        string sor = file.ReadLine();
        // sor = "9 11 123456789"
        string[] adatok = sor.Split(' ');
        // adatok[0] = "9", adatok[1] = "11",
        // adatok[2] = "123456789"
        sor = file.ReadLine();
        // sor = "Szia, mikor jossz?"
        uzenetek[i].o = Convert.ToInt32(adatok[0]);
        uzenetek[i].p = Convert.ToInt32(adatok[1]);
        uzenetek[i].t = adatok[2];
        uzenetek[i].u = sor;
      }

      file.Close();
    }

    static void Masodik()
    {
      Console.WriteLine("\n2. feladat: Legfrissebb a telefonban");
      if (darab < 11)
      {
        Console.WriteLine(uzenetek[darab - 1].u);
      }
      else
      {
        Console.WriteLine(uzenetek[9].u);
      }
    }

    static void Harmadik()
    {
      Console.WriteLine("\n3. feladat");
      int min = 0; // indexet!!!!!!!
      int max = 0; // indexet!!!!!!!

      for (int i = 1; i < darab; i++)
      {
        // min
        if (uzenetek[i].u.Length < uzenetek[min].u.Length)
        {
          min = i;
        }

        // max
        if (uzenetek[i].u.Length > uzenetek[max].u.Length)
        {
          max = i;
        }
      }

      Console.WriteLine("Legrövidebb üzenet: {0}:{1} {2} {3}",
          uzenetek[min].o, uzenetek[min].p, uzenetek[min].t, uzenetek[min].u
          );

      Console.WriteLine("Leghosszabb üzenet: {0}:{1} {2} {3}",
        uzenetek[max].o, uzenetek[max].p, uzenetek[max].t, uzenetek[max].u
        );
    }

    static void Negyedik()
    {
      Console.WriteLine("\n4. feladat");
      int[] stat = new int[5];

      for (int i = 0; i < darab; i++)
      {
        double mennyi = uzenetek[i].u.Length / (double)20;
        if (mennyi <= 1)
        {
          stat[0]++;
        }
        else if (mennyi <= 2)
        {
          stat[1]++;
        }
        else if (mennyi <= 3)
        {
          stat[2]++;
        }
        else if (mennyi <= 4)
        {
          stat[3]++;
        }
        else
        {
          stat[4]++;
        }
      }
      Console.WriteLine("1-20: {0}",stat[0]);
      Console.WriteLine("21-40: {0}", stat[1]);
      Console.WriteLine("41-60: {0}", stat[2]);
      Console.WriteLine("61-80: {0}", stat[3]);
      Console.WriteLine("81-100: {0}", stat[4]);
    }

    static void Otodik()
    {
      Console.WriteLine("\n5. feladat");
      int hivni = 0;
      int kezdes = uzenetek[0].o;
      int i = 0;

      while (i < darab)
      {
        int db = 0;

        while (i < darab && uzenetek[i].o == kezdes)
        {
          i++;
          db++;
        }

        if (db > 10)
        {
          hivni += (db - 10);
        }

        if (i < darab)
        {
          kezdes = uzenetek[i].o;
        }
      }

      Console.WriteLine("Szolgáltatót felhívni {0} esetben kell.",hivni);

    }

    static void Hatodik()
    {
      Console.WriteLine("\n6. feladat");
      List<int> hivasok = new List<int>();

      for (int i = 0; i < darab; i++)
      {
        if (uzenetek[i].t == "123456789")
        {
          hivasok.Add(uzenetek[i].o * 60 + uzenetek[i].p);
        }
      }

      if (hivasok.Count <= 1)
      {
        Console.WriteLine("Nincs elegendő üzenet!");
      }
      else
      {
        int max = 0;

        for (int i = 1; i < hivasok.Count; i++)
        {
          int eltelt = hivasok[i] - hivasok[i - 1];
          if (max < eltelt)
          {
            max = eltelt;
          }
        }

        int ora = max / 60;
        int perc = max % 60;

        Console.WriteLine("Eltelt leghosszabb idő {0} óra {1} perc.",
          ora, perc);
      }
    }

    static void Hetedik()
    {
      Console.WriteLine("\n7. feladat");
      int ora, perc;
      string tel, uzi;

      Console.Write("Hány óra: ");
      ora = Convert.ToInt32(Console.ReadLine());
      Console.Write("Hány perc: ");
      perc = Convert.ToInt32(Console.ReadLine());
      Console.Write("Telefonszám: ");
      tel = Console.ReadLine();
      Console.Write("Üzenet: ");
      uzi = Console.ReadLine();

      uzenetek[darab].o = ora;
      uzenetek[darab].p = perc;
      uzenetek[darab].t = tel;
      uzenetek[darab].u = uzi;

      darab++;
    }

    static void Nyolcadik()
    {
      Console.WriteLine("\n8. feladat");
      // sorbarendezés növekvő telefonszám
      for (int i = 0; i < darab - 1; i++)
      {
        for (int j = i+1; j < darab; j++)
        {
          if (Convert.ToInt32(uzenetek[i].t) > Convert.ToInt32(uzenetek[j].t))
          {
            Uzenet tmp = uzenetek[i];
            uzenetek[i] = uzenetek[j];
            uzenetek[j] = tmp;
          }
        }
      }
      // sorbarendezés vége

      StreamWriter ki = new StreamWriter("smski.txt");

      int k = 0;
      while ( k < darab )
      {
        string tel = uzenetek[k].t;
        ki.WriteLine(tel);
        while (k < darab && tel == uzenetek[k].t)
        {
          ki.WriteLine("{0}:{1} {2}", uzenetek[k].o, uzenetek[k].p,
            uzenetek[k].u);
          k++;
        }

      }


      ki.Close();
    }

    static void Main(string[] args)
    {
      Elso();
      Masodik();
      Harmadik();
      Negyedik();
      Otodik();
      Hatodik();
      Hetedik();
      Nyolcadik();

      Console.ReadKey();
    }
  }
}
