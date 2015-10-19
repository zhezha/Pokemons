using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[] {
                "audino","bagon","baltoy","banette","bidoof","braviary","bronzor",
                "carracosta","charmeleon","cresselia","croagunk","darmanitan","deino",
                "emboar","emolga","exeggcute","gabite","girafarig","gulpin","haxorus",
                "heatmor","heatran","ivysaur","jellicent","jumpluff","kangaskhan",
                "kricketune","landorus","ledyba","loudred","lumineon","lunatone",
                "machamp","magnezone","mamoswine","nosepp","petilil","pidgeotto",
                "pikachu","pinsir","poliwrath","poochyena","porygon2","porygonz",
                "registeel","relicanth","remoraid","rufflet","sableye","scolipede",
                "scrafty","seaking","sealeo","silcoon","simisear","snivy","snorlax",
                "spoink","starly","tirtouga","trapinch","treecko","tyrogue","vigoroth",
                "vulpix","wailord","wartortle","whismur","wingull","yamask","zoo"
            };

            //string[] words = new string[] {
            //    "machamp", "pinsir", "rufflet", "trapinch", "heatmor", "relicanth", "haxorus", "starly", "yamask", "kricketune",
            //    "exeggcute", "emboar", "registeel", "loudred", "darmanitan", "nosepp", "petilil", "landorus", "seaking", "girafarig",
            //    "gabite", "emolga", "audino"
            //};

            Pokemons pokemons = new Pokemons(words);

            var watch = Stopwatch.StartNew();

            pokemons.searchGraph();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Executing time: " + elapsedMs + " ms");

        }
    }
}
