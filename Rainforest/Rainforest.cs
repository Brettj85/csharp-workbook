using System;

namespace Rainforest
{
    class Program
    {

        static void Main(string[] args)
        {
            Company ourCompany = new Company();
            ourCompany.HarvestFruit("strawberrys");
            ourCompany.HarvestFruit("oranges");
            ourCompany.HarvestFruit("pinapples");
            ourCompany.HarvestFruit("apples");
            ourCompany.HarvestFruit("kiwis");
            ourCompany.HarvestFruit("banannas");
            ourCompany.HarvestFruit("pears");
            ourCompany.HarvestFruit("coconuts");
            ourCompany.HarvestFruit("starfruits");
            ourCompany.BuildWarehouse("Austin");
            ourCompany.BuildWarehouse("New York City");
            ourCompany.BuildWarehouse("Los Angeles");
            ourCompany.BuildContainer("Austin");
            ourCompany.BuildContainer("Austin");
            ourCompany.BuildContainer("Austin");
            ourCompany.BuildContainer("New York City");
            ourCompany.BuildContainer("Los Angeles");
            ourCompany.BuildContainer("Los Angeles");
            ourCompany.ProcessFruit("austin-1")
        }
    }
}
