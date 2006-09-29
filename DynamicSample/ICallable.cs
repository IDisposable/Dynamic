using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicComparerSample
{
    // this only exists to allow us to statically code against Animal or Person generically... not needed for the
    // dynamic stuff AT ALL.
    interface ICallable<T> 
    {
        bool Compatible(T other);
        T Breed(T mate, Gender childGender);
        void Mutate();

        double Age
        {
            get; set;
        }

        // these are supposed to be static, but cannot be in an interface...
        //int AgeDifference(T first, T other);
        int AgeDifferenceFrom(T other);

        // T(string firstName, string lastName, Gender gender, double age);
        T Create(string firstName, string lastName, Gender gender, double age);

        //static double AllowableAgeDifference
        //{
        //    get; set;
        //}
        int GetAllowableAgeDifference();
        void SetAllowableAgeDifference(int value);
    }
}
