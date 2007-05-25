using System;
using System.Collections.Generic;
using System.Text;

using Phydeaux.Utilities;

namespace DynamicComparerSample
{
    // tests for bug described by Vlado

    // base class
    public abstract class BDORoot<T>
    {
        private long? _ID;
        public long? ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }

    // derived class
    public class CountryBDO : BDORoot<CountryBDO>
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public static List<CountryBDO> GetAllBDOs()
        {
            List<CountryBDO> list = new List<CountryBDO>();
            CountryBDO c1 = new CountryBDO();
            c1.ID = 100;
            c1.Name = "USA";
            list.Add(c1);
            CountryBDO c2 = new CountryBDO();
            c2.ID = 50;
            c2.Name = "Slovakia";
            list.Add(c2);
            CountryBDO c3 = new CountryBDO();
            c3.ID = 150;
            c3.Name = "Vanuatu";
            list.Add(c3);
            CountryBDO c4 = new CountryBDO();
            c4.ID = 10;
            c4.Name = "Vanuatu"; // fake duplication to check multi-level comparisons
            list.Add(c4);

            //works
            list.Sort(new DynamicComparer<CountryBDO>("Name"));

            // used to throw exception
            list.Sort(new DynamicComparer<CountryBDO>("ID"));

            list.Sort(new DynamicComparer<CountryBDO>("Name, ID"));

            return list;
        }
    }
}
