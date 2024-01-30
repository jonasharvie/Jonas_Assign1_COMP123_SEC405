using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
 * COMP 123 Programming 2
 * Section 405
 * Winter 2024
 * Group 4
 * Assignment 1
 * Due Feb 5
 * Team Members:
 * Jonas Harvie
 * Farhan Rahman
 * Maharaj Nath
 */

namespace Jonas_Assign1_COMP123_SEC405
{
    enum Audience {world, group, special}
    internal class Program
    {
        
        static void Main(string[] args)
        {

            TikTok tiktok1 = new TikTok("Jonas", 55, "#ILoveThisClass", Audience.world);
            Console.WriteLine(tiktok1);
            TikTok tiktok2 = new TikTok("Jonas", 55, "#ILoveThisClass", Audience.world);
            Console.WriteLine(tiktok2);

            Console.WriteLine("do you want to import an external file to test the TikTokManager? [y/n]");
            if (Console.ReadLine() == "y")
            {
                TikTokManager.TokTokManager();
                TikTokManager.Show();
            }
            else
            {
                TikTokManager.Initialize();
                TikTokManager.Show();
                TikTokManager.Show("covid");
                TikTokManager.Show(20);
                TikTokManager.Show(Audience.world);
            }
            

            

        }
    }
    class TikTok
    {
        private static int _ID;
        public string Originator { get; }
        public int Length { get; }
        public string HashTag { get;}
        public Audience audience { get; }
        public int Id { get;}

        public TikTok(string originator, int length, string hashTag, Audience audience)
        {
            this.Originator = originator;
            this.Length = length;
            this.HashTag = hashTag;
            this.audience = audience;
            this.Id = _ID;
            
            _ID++;
            
        }
        private TikTok(string id, string originator, int length, string hashTag, string audience1)
        {
            this.Id = int.Parse(id);
            this.Originator= originator;
            this.Length = length;
            this.HashTag = hashTag;
            this.audience = (Audience)Enum.Parse(typeof(Audience), audience1);

        }
        public override string ToString()
        {      
            return $"ID: {Id} Originator: {Originator} Length: {Length} HashTag: {HashTag} Audience: {audience}\n";
        }

        public static TikTok Parse(string line)
        {
            string[] elements = line.Split('\t');

            int len = int.Parse(elements[2]);

            TikTok tiktokParsed = new TikTok(elements[0], elements[1], len, elements[4], elements[3]);
            

            return tiktokParsed;
        }

    }

    static class TikTokManager
    {
        private static List<TikTok> TIKTOKS;
        public static string FILENAME;

        public static void TokTokManager()
        {
            //a
            TIKTOKS = new List<TikTok>();

            //b
            FILENAME = "C:\\01_desktop\\02centennialcollege\\02_Winter_2024\\COMP123 Programming 2\\Assignment1_due_Feb_5\\tik toks.txt";
            Console.WriteLine("Enter the file path with the file name: ");
            FILENAME = Console.ReadLine();

            TextReader reader = new StreamReader(FILENAME); //Declare and initialise a t
            string line = reader.ReadLine(); //read the first line
            while (line != null) //read the first line
            {
                TIKTOKS.Add(TikTok.Parse(line));
                line = reader.ReadLine();
            }
            reader.Close();
        }
        static void TokTokManager(string lines)
        {
            //a
            TIKTOKS = new List<TikTok>();

            StringReader reader = new StringReader(lines); //Declare and initialise a t
            string line = reader.ReadLine(); //read the first line
            while (line != null) //read the first line
            {
                TIKTOKS.Add(TikTok.Parse(line));
                line = reader.ReadLine();
            }
            reader.Close();
        }

        public static void Initialize()
        {
            
            string testTikToks;
            testTikToks = "500000\tJonas3\t20\tgroup\tcovid\r\n500001\tsameer\t19\tgroup\tcovid\r\n500002\tjoan\t24\tgroup\tsummer heat\r\n500003\tajay\t15\tworld\tbars\r\n500004\tcarl\t21\tworld\tpark";
            TokTokManager(testTikToks);
        }

        public static void Show()
        {
            Console.WriteLine("show");
            foreach (TikTok x in TIKTOKS)
            {
                Console.WriteLine(x);
            }
        }
        public static void Show(string tag)
        {
            Console.WriteLine("show only tiktoks with specified tag");
            foreach (var tiktok in TIKTOKS)
            {
                if (tag == tiktok.HashTag)
                {
                    Console.WriteLine($"{tiktok}");
                }
            }
        }
        public static void Show(int length)
        {
            Console.WriteLine($"show only tiktoks with length greater then {length} seconds");
            foreach (var tiktok in TIKTOKS)
            {
                if (length > tiktok.Length)
                {
                    Console.WriteLine($"{tiktok}");
                }
            }
        }
        public static void Show(Audience audience)
        {
            Console.WriteLine("show only tiktoks with specified audience");
            foreach (var tiktok in TIKTOKS)
            {
                if (audience == tiktok.audience)
                {
                    Console.WriteLine($"{tiktok}");
                }
            }
        }
    }

}
