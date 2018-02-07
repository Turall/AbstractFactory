using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new HP("Hp","6 GB","Zalman"));
            Console.WriteLine(client.Name + " \n"+ client.Ram + "\n " + client.cooler );
        }
    }

    class Client
    {
        public string Name { get; set; }
        public string  Ram { get; set; }
        public string cooler { get; set; }
        public Client(CompFactory compFactory)
        {
           Name = compFactory.GetCPU().CPUName;
           Ram = compFactory.GetRAM().RamName;
            cooler = compFactory.GetCooler().ColName;
        }
       
    }

    abstract class CompFactory
    {
        public abstract CPU GetCPU();
        public abstract RAM GetRAM();
        public abstract Cooler GetCooler();

    }
    abstract class Cooler
    {
        public abstract string ColName { get; set; }
    }

    abstract class CPU
    {
        public abstract string CPUName { get; set; }
    }

    abstract class RAM
    {
        public abstract string RamName { get; set; }
    }

    class AppleCpu:CPU
    {
        public override string CPUName { get ; set ; }
        public AppleCpu(string name)
        {
            CPUName = name;
        }
    }

    class AppleRam : RAM
    {
        public override string RamName { get ; set; }
        public AppleRam(string ram)
        {
            RamName = ram;
        }
    }
    class AppleColler : Cooler
    {
        public override string ColName { get ; set ; }
        public AppleColler(string coller)
        {
            ColName = coller;
        }
    }
    class Apple : CompFactory
    {
        public string RAMname { get; set; }
        public string CPUname { get; set; }
        public string ColName { get; set; }
        public Apple(string cpuName,string ram,string collerName)
        {
            CPUname = cpuName;
            RAMname = ram;
            ColName = collerName;
        }
        public override CPU GetCPU()
        {
            return new AppleCpu(CPUname);
        }

        public override RAM GetRAM()
        {
            return new  AppleRam(RAMname);
        }
        public override Cooler GetCooler()
        {
            return new AppleColler(ColName);
        }
    }

    class HP : CompFactory
    {

        public string RAMname { get; set; }
        public string CPUname { get; set; }
        public string ColName { get; set; }
        public HP(string cpuName, string ram, string collerName)
        {
            CPUname = cpuName;
            RAMname = ram;
            ColName = collerName;
        }
        public override CPU GetCPU()
        {
            return new HPCPU(CPUname);
        }

        public override RAM GetRAM()
        {
            return new HPRAM(RAMname);
        }
        public override Cooler GetCooler()
        {
            return new HPColler(ColName);
        }
    }
    class HPRAM : RAM
    {
        public override string RamName { get ; set ; }
        public HPRAM(string Ram)
        {
            RamName = Ram;
        }
    }
    class HPColler : Cooler
    {
        public override string ColName { get ; set ; }
        public HPColler(string coller)
        {
            ColName = coller;
        }
    }
    class HPCPU : CPU
    {
        public override string CPUName { get; set ; }
        public HPCPU(string cpuname)
        {
            CPUName = cpuname;
        }
    }
}
