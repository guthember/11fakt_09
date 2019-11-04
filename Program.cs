using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szellemek
{
  class Program
  {
    static void Main(string[] args)
    {
      // 5 db ajtó
      // életerő 50
      // feladat: választunk az ajtók közül
      // 1 ajtó mögött szellem van (véletlenszerű)
      // 1 ajtó mögött ellenfél van (véletlenszerű, máshol mint szellem)
      // ha szerencsénk van tovább
      // ha nincs -10 életerő
      // ha legyőzünk egy ellenfelet +2 életerő
      // ha 0 az életerő --> GAME OVER
      // ? hány szobán jutottunk keresztül
      int eletero = 50;
      int szobakSzama = 0;
      int valasztas;
      Random vel = new Random();
      int ajto;
      int ellenfel;
      int ellenEletero;


      while (eletero > 0)
      {
        Console.WriteLine("Válassz az ajtók közül!");
        Console.WriteLine("1 - 2 - 3 - 4 - 5");

        // ember választ

        do
        {
          Console.Write("Válasz: ");
          valasztas = Convert.ToInt32(Console.ReadLine()); 
        //} while ( !(valasztas > 0 && valasztas < 4));
        } while ( valasztas < 1 || valasztas > 5 );

        // gép választ ahol a szellem van
        ajto = vel.Next(1, 6); // szellem
        do
        {
          ellenfel = vel.Next(1, 6); // ellenfél 
        } while (ajto == ellenfel);

        if (valasztas == ajto) // szellemet találtunk
        {
          eletero -= 10;
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Whoooaaaa...");
          Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (valasztas == ellenfel)
        {
          ellenEletero = vel.Next(1, eletero + 20);
          if (eletero > ellenEletero)
          {
            eletero += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Legyőztük az ellenfelet!");
            Console.ForegroundColor = ConsoleColor.Gray;
            szobakSzama++;
          }
          else
          {
            eletero -= 10;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Megsebeztek...");
            Console.ForegroundColor = ConsoleColor.Gray;
          }
        }
        else
        {
          szobakSzama++;
        }

        Console.WriteLine("Életerőnk: "+ eletero.ToString());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-----------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine(szobakSzama + " szobán jutottál át!");
      Console.ReadKey();

    }
  }
}
