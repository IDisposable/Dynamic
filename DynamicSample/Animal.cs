using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicComparerSample
{
    public struct Animal : IComparable<Animal>, IComparable, ICallable<Animal>
    {
        private static int allowableAgeDifference = 10;
        public static int AllowableAgeDifference
        {
            get { return allowableAgeDifference; }
            set { allowableAgeDifference = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private double age;
        public double Age
        {
            get { return age; }
            set { age = value; }
        }

        private Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public Animal(string firstName, string lastName, Gender gender, double age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
        }

        public Animal Create(string firstName, string lastName, Gender gender, double age)
        {
            return new Animal(firstName, lastName, gender, age);
        }

        public int GetAllowableAgeDifference()
        {
            return allowableAgeDifference;
        }

        public void SetAllowableAgeDifference(int value)
        {
            allowableAgeDifference = value;
        }

        public override string ToString()
        {
            return string.Format("{0,-7} {1,-8} | {2,-6} | {3,2}"
                , this.firstName
                , this.lastName
                , this.gender
                , this.age);
        }

        // don't whine... these are just samples
        public double MinimumAge
        {
            get { return this.age * 0.75; }
        }

        public double MaximumAge
        {
            get { return this.age * 1.25; }
        }

        public bool Compatible(Animal other)
        {
            return (Math.Abs(this.age - other.age) / this.age) < 0.25;
        }

        public Animal Breed(Animal mate, Gender childGender)
        {
            string childFirstName = mate.firstName ?? this.firstName ?? "Phydeaux";
            string childLastName = this.lastName ?? mate.lastName ?? "Gao";
            return new Animal(childFirstName, childLastName, childGender, 0);
        }

        public void Mutate()
        {
            // note that since this works against a value-type, the changes are made, but the
            // outer caller passing the Animal will never see them!
            switch (this.gender)
            {
                case Gender.Male:
                    this.gender = Gender.Merm;
                    break;
                case Gender.Female:
                    this.gender = Gender.Ferm;
                    break;
                case Gender.Ferm:
                    // this is reversible...
                    this.gender = Gender.Female;
                    break;
                case Gender.Merm:
                    // can't put it back...
                    return;
                case Gender.Herm:
                    // God made me this way...
                    return;
            }
        }

        public int AgeDifferenceFrom(Animal other)
        {
            return AgeDifference(this, other);
        }

        private static int AgeDifference(Animal left, Animal right)
        {
            return (int)Math.Abs(left.age - right.age);
        }

        private static int NullSafeCompareTo(IComparable left, IComparable right)
        {
            if (left != null)
            {
                if (right != null)
                {
                    return left.CompareTo(right);
                }

                return 1;
            }

            if (right != null)
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo(Animal other)
        {
            int diff = NullSafeCompareTo(this.lastName, other.lastName);

            if (diff != 0)
                return diff;

            diff = NullSafeCompareTo(this.firstName, other.firstName);

            if (diff != 0)
                return diff;

            diff = this.gender.CompareTo(other.gender);

            if (diff != 0)
                return diff;
            return this.age.CompareTo(other.age);
        }

        #region IComparable Members
        int IComparable.CompareTo(object obj)
        {
            return this.CompareTo((Animal)obj);
        }
        #endregion

        // This exists ONLY to make it easy to use Reflector to see the right way to call things...
        private static int ShowCalls(Animal left, Animal right)
        {
            return left.CompareTo(right)
            + ((IComparable)left).CompareTo(right)
            + ((IComparable<Animal>)left).CompareTo(right);
        }
    }
}
