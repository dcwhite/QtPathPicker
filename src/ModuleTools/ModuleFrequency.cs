using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace ModuleTools
{
    [TestFixture]
    public class ModuleFrequency
    {
        public IEnumerable<string> NetworkFilesIn(string path)
        {
            return Directory.EnumerateFiles(path, "*.srn", SearchOption.AllDirectories);
        }

        [Test]
        public void ListNetworkFiles()
        {
            NetworkFilesIn(@"E:\scirun\trunk_ref\SCIRun\src\nets")
                .Print();
        }

        public IEnumerable<string> ModuleLinesFromNetworkFile(string file)
        {
            return File.ReadAllLines(file)
                .Where(line => line.Contains("<module "));
        }

        public string GrabModuleNameFromLine(string line)
        {
            var nameAttr = "name=\"";
            int start = line.IndexOf(nameAttr);
            int end = line.IndexOf("\"", start + nameAttr.Length);
            return line.Substring(start + nameAttr.Length, end - (start + nameAttr.Length));
        }

        [Test]
        public void ListModuleLinesInNetworkFile()
        {
            var file = @"E:\scirun\trunk_ref\SCIRun\src\nets\FwdInvToolbox\activation-based-fem\activation-based-fem.srn";
            var lines = ModuleLinesFromNetworkFile(file);
            //lines.Print();

            lines.Select(GrabModuleNameFromLine).Print();
        }

        public IDictionary<string, int> GetModuleFrequencyFor(IEnumerable<string> files)
        {
            var modules = files.SelectMany(ModuleLinesFromNetworkFile).Select(GrabModuleNameFromLine);

            var dict = new SortedDictionary<string,int>();
            modules.ForEach(s => { if (!dict.ContainsKey(s)) dict.Add(s, 0); dict[s]++; });
            return dict;
        }

        [Test]
        public void BuildDictionaryOfModuleFrequency()
        {
            var file = @"E:\scirun\trunk_ref\SCIRun\src\nets\FwdInvToolbox\activation-based-fem\activation-based-fem.srn";

            var dict = GetModuleFrequencyFor(new[] { file });

            dict.Print();
        }

        [Test]
        public void PrintLargeScaleModuleFrequency()
        {
            var dict = GetModuleFrequencyFor(NetworkFilesIn(@"E:\scirun\trunk_ref\SCIRun\src\nets"));

            dict.Print();
        }

        [Test]
        public void Top10ModulesByUsage()
        {
            var dict = GetModuleFrequencyFor(NetworkFilesIn(@"E:\scirun\trunk_ref\SCIRun\src\nets"));

            dict.OrderByDescending(p => p.Value).Take(10).Print();
        }

        [Test]
        public void ModulesUsedOnlyOnce()
        {
            var dict = GetModuleFrequencyFor(NetworkFilesIn(@"E:\scirun\trunk_ref\SCIRun\src\nets"));

            dict.Where(p => p.Value == 1).Select(p => p.Key).Print();
        }

        [Test]
        public void ModulesPerNetworkFile()
        {
            var modsPerFile = NetworkFilesIn(@"E:\scirun\trunk_ref\SCIRun\src\nets").ToDictionary(f => f, f => ModuleLinesFromNetworkFile(f).Count());

            Console.WriteLine("Average modules per network file: {0}", Enumerable.Average(modsPerFile.Values));

            modsPerFile.OrderByDescending(p => p.Value).Print();
        }
    }


    public static class Ext
    {
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> f)
        {
            foreach (T t in ts)
            {
                f(t);
            }
        }

        public static void Print<T>(this IEnumerable<T> ts) where T : class
        {
            ts.ForEach(Console.WriteLine);
        }

        public static void Print<TK, TV>(this IEnumerable<KeyValuePair<TK, TV>> pairs)
        {
            pairs.ForEach(p => Console.WriteLine("{0}, {1}", p.Key, p.Value));
        }
    }
}
