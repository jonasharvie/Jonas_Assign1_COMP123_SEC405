using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Jonas_Assign1_COMP123_SEC405
{
    enum Audience {World, Group, Special}
    internal class Program
    {
        
        static void Main(string[] args)
        {

            TikTok tiktok1 = new TikTok("Jonas", 55, "#ILoveThisClass", Audience.World);
            Console.WriteLine(tiktok1);
        }
    }
    class TikTok
    {
        private static int _ID;
        public string Originator { get; }
        public int Length { get; }
        public string HashTag { get;}
        public Audience audience { get; }
        public string Id { get;}

        public TikTok(string originator, int length, string hashTag, Audience audience)
        {
            this.Originator = originator;
            this.Length = length;
            this.HashTag = hashTag;
            this.audience = audience;
            int Id = _ID;
            
            _ID++;
            
        }
        public TikTok(string id, string originator, int length, string hashTag, string audience)
        {

        }
        public override string ToString()
        {      
            return $"ID: {Id}\nOriginator: {Originator}\nHashTag: {HashTag}\nAudience: {audience}\n";
        }

        public static TikTok Parse(string line)
        {
            string[] elements = line.Split('\t');

            int len = int.Parse(elements[2]);

            TikTok tiktokParsed = new TikTok(elements[0], elements[1], len, elements[4], elements[3]);
            

            return tiktokParsed;
        }

    }

}
