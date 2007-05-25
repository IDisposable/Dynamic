using System;

namespace DynamicComparerSample
{
    public class Person : IComparable<Person>, IComparable, ICallable<Person>
    {
        private static int allowableAgeDifference = 20;
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

        private Person mate;
        public Person Mate
        {
            get { return mate; }
            set
            {
                if (this.mate != value)
                {
                    // handle their divorce automatically
                    if (value != null && value.mate != null && value.mate != this)
                    {
                        value.mate.mate = null;
                        value.mate = null;
                    }

                    // handle our divorce automatically
                    if (this.mate != null)
                    {
                        this.mate.mate = null;
                        this.mate = null;
                    }

                    // let's get them hitched
                    this.mate = value;

                    if (value != null)
                        value.mate = this;
                }
            }
        }

        public Nullable<Gender> MateGender
        {
            get
            {
                Nullable<Gender> mateGender = default(Nullable<Gender>);

                if (mate != null)
                    mateGender = mate.Gender;

                return mateGender;
            }
        }

        public Person()
        {
        }

        public Person(string firstName, string lastName, Gender gender, double age, Person mate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
            this.Mate = mate;
        }

        public Person(string firstName, string lastName, Gender gender, double age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
        }

        public Person Create(string firstName, string lastName, Gender gender, double age)
        {
            return new Person(firstName, lastName, gender, age);
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
            return string.Format("{0,-7} {1,-8} | {2,-6} | {3,2} | {4,-7} {5,-8}"
                , this.firstName
                , this.lastName
                , this.gender
                , this.age
                , this.mate == null ? string.Empty : this.mate.firstName
                , this.mate == null ? string.Empty : this.mate.lastName);
        }

        // don't whine... these are just samples
        public virtual double MinimumAge
        {
            get { return this.age * 0.75; }
        }

        public virtual double MaximumAge
        {
            get { return this.age * 1.25; }
        }

        public virtual bool Compatible(Person other)
        {
            return (Math.Abs(this.age - other.age) / this.age) < 0.25;
        }

        public Person Breed(Person newMate, Gender childGender)
        {
            if (newMate == null)
                return null;

            this.Mate = newMate;

            if (this.gender == mate.gender)
                return null;

            string childFirstName = mate.firstName ?? this.firstName ?? "Junior";
            string childLastName = this.lastName ?? mate.lastName ?? "Smith";
            return new Child(childFirstName, childLastName, childGender, 0, null);
        }

        public void Mutate()
        {
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

            if (this.mate != null && this.mate.gender == this.gender)
            {
                // Honey, you have changed! I want a divorce...
                this.Mate = null;
            }
        }

        public int AgeDifferenceFrom(Person other)
        {
            return AgeDifference(this, other);
        }

        private static int AgeDifference(Person left, Person right)
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

        public int CompareTo(Person other)
        {
            if (this == null)
            {
                return (other == null) ? 0 : -1;
            }

            if (other == null)
                return 1;

            int diff = NullSafeCompareTo(this.lastName, other.lastName);

            if (diff != 0)
                return diff;

            diff = NullSafeCompareTo(this.firstName, other.firstName);

            if (diff != 0)
                return diff;

            diff = this.gender.CompareTo(other.gender);

            if (diff != 0)
                return diff;

            diff = Nullable.Compare(this.MateGender, other.MateGender);

            if (diff != 0)
                return diff;

            return this.age.CompareTo(other.age);
        }

        #region IComparable Members
        int IComparable.CompareTo(object obj)
        {
            return this.CompareTo((Person)obj);
        }
        #endregion

        // This exists ONLY to make it easy to use Reflector to see the right way to call things...
        private static int ShowCalls(Person left, Person right)
        {
            return left.CompareTo(right)
            + ((IComparable)left).CompareTo(right)
            + ((IComparable<Person>)left).CompareTo(right);
        }
    }

    public class Child : Person
    {
        public Child(string firstName, string lastName, Gender gender, double age, Person mate)
            : base(firstName, lastName, gender, age, mate)
        {
        }

        public override double MinimumAge
        {
            get { return (this.Age <= 3) ? 0 : base.MinimumAge; }
        }

        public override double MaximumAge
        {
            get { return (this.Age < 18) ? 18 : base.MaximumAge; } 
        }

        public override bool Compatible(Person other)
        {
            // children must be 18 and not very picky
            return this.Age > 18 && (Math.Abs(this.Age - other.Age) / this.Age) < 0.50;
        }
    }
}