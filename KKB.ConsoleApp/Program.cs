using KKB.BLL.Model;
using System;
using System.IO.Ports;
using System.Text;

namespace KKB.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Menu.FirstMenu();
            Console.ReadKey();
        }
    }

    //организм
    public abstract class Organizm
    {
        public string Name { get; set; }
        public double MoveSpeed { get; set; }

        public abstract void Move();
        public abstract void Breeze();

        public virtual string Eat()
        {
            return "Фотосинтезем";
        }
    }

    public class Dog : Organizm
    {
        public new string Name { get; set; }
        public override void Move()
        {
            
        }
        public override void Breeze()
        {
            
        }
        public override string Eat()
        {
            base.Name = "";
            this.Name = "";
           
            //1 
            return "ртом";
            //2
            //return base.Eat()+" ртом";
        }
    }

    public sealed class Kolee : Dog
    {

    }

    public class ChauChau: Kolee
    {

    }


    public class Ameba : Organizm
    {
        public override void Move()
        {

        }
        public override void Breeze()
        {

        }
    }

    public static class StringBulderExtension
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == value) return i;
            }
            return -1;
        }
    }
}
