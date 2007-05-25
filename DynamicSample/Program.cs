using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

using Phydeaux.Utilities;

namespace DynamicComparerSample
{
    class Program
    {
        static readonly string[] firstnames = { null, "Oren", "Matt", "James", "David", "Homer", "Bart", "Maggie", "Marge", "Lisa", "Monty", "Barney", "Frank", "Phillip" };
        static readonly string[] lastnames = { null, "Eini", "Groening", "Brooks", "Cohen", "Simpson", "Burns", "Gumble", "Grimes", "Fry" };

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write("\n\n\n[C]omparer, [M]ethod caller, or E[x]it?");

                ConsoleKey dynamic = new ConsoleKey();
                while (dynamic != ConsoleKey.M
                    && dynamic != ConsoleKey.C
                    && dynamic != ConsoleKey.X)
                    dynamic = Console.ReadKey(true).Key;

                Console.WriteLine(dynamic);

                if (dynamic == ConsoleKey.X)
                {
                    exit = true;
                }
                else
                {
                    Console.Write("[E]xercise, [B]enchmark, [T]ests, [C]onstructor benchmark, or E[x]it?");

                    ConsoleKey option = new ConsoleKey();
                    while (option != ConsoleKey.E
                        && option != ConsoleKey.B
                        && option != ConsoleKey.T
                        && option != ConsoleKey.C
                        && option != ConsoleKey.X)
                        option = Console.ReadKey(true).Key;

                    Console.WriteLine(option);

                    if (option == ConsoleKey.T)
                    {
                        Console.WriteLine("Testing...");

                        // just calling this tests dynamic comparer...
                        List<CountryBDO> list = CountryBDO.GetAllBDOs();
                        foreach (CountryBDO country in list)
                        {
                            Console.WriteLine("\t{0}: {1}", country.ID, country.Name);
                        }
                    }
                    else if (option != ConsoleKey.X)
                    {
                        Console.Write("[P]eople (class), [A]nimal (struct), or E[x]it?");

                        ConsoleKey kind = new ConsoleKey();
                        while (kind != ConsoleKey.P
                            && kind != ConsoleKey.A
                            && kind != ConsoleKey.X)
                            kind = Console.ReadKey(true).Key;

                        Console.WriteLine(kind);

                        switch (kind)
                        {
                            case ConsoleKey.P:
                                {
                                    Person aPerson = new Person();
                                    Do(aPerson, dynamic == ConsoleKey.C, option == ConsoleKey.E, option == ConsoleKey.C, ChooseMate);
                                }
                                break;

                            case ConsoleKey.A:
                                {
                                    Animal anAnimal = new Animal();
                                    Do(anAnimal, dynamic == ConsoleKey.C, option == ConsoleKey.E, option == ConsoleKey.C, null);
                                }
                                break;

                            case ConsoleKey.X:
                                continue; // loop around
                        }
                    }
                }
            }
        }

        private static void ChooseMate(Person person, List<Person> persons, Random rnd)
        {
            // 40% single people
            if (persons.Count == 0 || rnd.Next(100) < 40)
                return;

            int mateIndex = rnd.Next(persons.Count);
            Person mate = persons[mateIndex];
            person.Mate = mate;
        }

        private const int InteractiveEntries = 40;
        private const int BenchmarkEntries = 100000;

        delegate void Adjuster<T>(T instance, List<T> list, Random rnd);

        private static void Do<T>(T progenitor, bool comparerTest, bool interactiveTest, bool activatorBench
            , Adjuster<T> adjuster) where T : ICallable<T>, IComparable
        {
            Random rnd = new Random(12345); // repeatable seed...

            if (comparerTest)
            {
                if (interactiveTest)
                    TestCompare<T>(progenitor, adjuster, rnd);
                else
                    BenchCompare<T>(progenitor, adjuster, rnd);
            }
            else if (activatorBench)
            {
                BenchConstructor<T>(BenchmarkEntries);
            }
            else
            {
                if (interactiveTest)
                    TestCall<T>(progenitor, adjuster, rnd);
                else
                    BenchCall<T>(progenitor, adjuster, rnd);
            }
        }

        // compile-time
        private static List<T> CreateObjects<T>(T progenitor, int numberOfEntries
            , Adjuster<T> adjuster, Random rnd) where T : ICallable<T>
        {
            // Make the collection.
            List<T> list = new List<T>(numberOfEntries);

            // call the default constructor and then Create method...
            for (int i = 0; i < list.Capacity; i++)
            {
                T instance = progenitor.Create(firstnames[rnd.Next(firstnames.Length)]
                    , lastnames[rnd.Next(lastnames.Length)]
                    , (Gender)rnd.Next((int)Gender.MAX)
                    , Math.Floor(rnd.NextDouble() * 100d));

                if (adjuster != null)
                {
                    adjuster(instance, list, rnd);
                }

                list.Add(instance);
            }

            return list;
        }

        // calling the constructor itself
        private static List<T> CreateObjects<T>(int numberOfEntries
            , ConstructorInfo constructor
            , Adjuster<T> adjuster, Random rnd)
        {
            // Make the collection.
            List<T> list = new List<T>(numberOfEntries);

            // call the default constructor and then Create method...
            for (int i = 0; i < list.Capacity; i++)
            {
                T instance = (T)constructor.Invoke(new object[] { firstnames[rnd.Next(firstnames.Length)]
                    , lastnames[rnd.Next(lastnames.Length)]
                    , (Gender)rnd.Next((int)Gender.MAX)
                    , Math.Floor(rnd.NextDouble() * 100d) });

                if (adjuster != null)
                {
                    adjuster(instance, list, rnd);
                }

                list.Add(instance);
            }

            return list;
        }

        // through some strong-typed delegate
        private static List<T> CreateObjects<T>(int numberOfEntries
            , Constructor<T, string, string, Gender, double> create
            , Adjuster<T> adjuster, Random rnd)
        {
            List<T> list = new List<T>(numberOfEntries);

            for (int i = 0; i < list.Capacity; i++)
            {
                T instance = create.Invoke(firstnames[rnd.Next(firstnames.Length)]
                    , lastnames[rnd.Next(lastnames.Length)]
                    , (Gender)rnd.Next((int)Gender.MAX)
                    , Math.Floor(rnd.NextDouble() * 100d));

                if (adjuster != null)
                {
                    adjuster(instance, list, rnd);
                }

                list.Add(instance);
            }

            return list;
        }

        private static List<T> CreateObjects<T>(int numberOfEntries
            , ConstructorParams<T> create
            , Adjuster<T> adjuster, Random rnd)
        {
            List<T> list = new List<T>(numberOfEntries);

            for (int i = 0; i < list.Capacity; i++)
            {
                T instance = create.Invoke(firstnames[rnd.Next(firstnames.Length)]
                    , lastnames[rnd.Next(lastnames.Length)]
                    , (Gender)rnd.Next((int)Gender.MAX)
                    , Math.Floor(rnd.NextDouble() * 100d));

                if (adjuster != null)
                {
                    adjuster(instance, list, rnd);
                }

                list.Add(instance);
            }
            return list;
        }

        private static void BenchConstructor<T>(int numberOfEntries)
        {
            Stopwatch activator = new Stopwatch();
            Stopwatch activatorT = new Stopwatch();
            Stopwatch dynamic = new Stopwatch();

            try
            {
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();

                activator.Start();
                Type tType = typeof(T);
                for (int i = 0; i < numberOfEntries; i++)
                {
                    T t = (T)Activator.CreateInstance(tType);
                }
                activator.Stop();

                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();

                activatorT.Start();
                for (int i = 0; i < numberOfEntries; i++)
                {
                    T t = Activator.CreateInstance<T>();
                }
                activatorT.Stop();

                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();

                ConstructorParams<T> create = Dynamic<T>.Constructor.Params.CreateDelegate(Type.EmptyTypes);

                dynamic.Start();
                for (int i = 0; i < numberOfEntries; i++)
                {
                    T t = create();
                }
                dynamic.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
            finally
            {
                dynamic.Stop();
                activatorT.Stop();
                activator.Stop();
            }

            Console.WriteLine("Activator:\t" + activator.Elapsed
                              + "\nActivator<T>:\t" + activatorT.Elapsed
                              + "\nDynamic:\t" + dynamic.Elapsed);
        }

        private const BindingFlags WhatMembers = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        #region DynamicCall
        #region Test
        private static void TestCall<T>(T progenitor, Adjuster<T> adjuster, Random rnd) where T : ICallable<T>
        {
            List<T> entries = CreateObjects<T>(progenitor, InteractiveEntries, adjuster, rnd);
            Console.Clear();

            try
            {
                // Create the invoker for the type and method.
                Func<T, bool, T> compatible = Dynamic<T>.Instance.Function<bool>.Explicit<T>.CreateDelegate("Compatible");
                Func<T, T, T, Gender> breed = Dynamic<T>.Instance.Function<T>.Explicit<T, Gender>.CreateDelegate("Breed");
                Proc<T> mutate = Dynamic<T>.Instance.Procedure.Explicit.CreateDelegate("Mutate");
                StaticFunc<T, int, T, T> ageDifference = Dynamic<T>.Static.Function<int>.Explicit<T, T>.CreateDelegate("AgeDifference");
                StaticFunc<T, int> getAllowableAgeDifference = Dynamic<T>.Static.Field<int>.Getter.CreateDelegate("allowableAgeDifference");
                StaticProc<T, int> setAllowableAgeDifference = Dynamic<T>.Static.Field<int>.Setter.CreateDelegate("allowableAgeDifference");
                Func<T, double> getAge = Dynamic<T>.Instance.Field<double>.Getter.CreateDelegate("age");
                Proc<T, double> setAge = Dynamic<T>.Instance.Field<double>.Setter.CreateDelegate("age");
                Func<T, double> getMinimumAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("MinimumAge");
                Func<T, double> getMaximumAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("MaximumAge");

                StaticFunc<T, int> getPropAllowableAgeDifference = Dynamic<T>.Static.Property<int>.Explicit.Getter.CreateDelegate("AllowableAgeDifference");
                StaticProc<T, int> setPropAllowableAgeDifference = Dynamic<T>.Static.Property<int>.Explicit.Setter.CreateDelegate("AllowableAgeDifference");
                Func<T, double> getPropAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("Age");
                Proc<T, double> setPropAge = Dynamic<T>.Instance.Property<double>.Explicit.Setter.CreateDelegate("Age");

                bool firstTime = true;
                int allowableAgeDifference = getAllowableAgeDifference();
                int firstIndex = rnd.Next(entries.Count);
                T firstEntry = entries[firstIndex];
                Console.WriteLine(firstEntry.ToString());

                for (int attempt = 0; attempt < entries.Count; attempt++)
                {
                    int secondIndex = rnd.Next(entries.Count);

                    if (secondIndex == firstIndex)
                    {
                        Console.WriteLine("\tskipping self");
                        continue;
                    }

                    T secondEntry = entries[secondIndex];
                    Console.WriteLine("\t" + secondEntry.ToString());

                    int currentAgeDifference = ageDifference(firstEntry, secondEntry);

                    if (allowableAgeDifference < currentAgeDifference)
                    {
                        double firstAge = getAge(firstEntry);
                        double secondAge = getAge(secondEntry);
                        double minAge = getMinimumAge(firstEntry);
                        double maxAge = getMaximumAge(firstEntry);

                        Console.WriteLine("\t\tinsurmountable age difference " + firstAge + " and " + secondAge);
                        Console.WriteLine("\t\tprefer people between " + getMinimumAge(firstEntry) + " and " + getMaximumAge(firstEntry));

                        if (firstTime)
                        {
                            // we'll broaden our horizons by 25%
                            allowableAgeDifference = rnd.Next(allowableAgeDifference, (int)(1.25 * (double)allowableAgeDifference));
                            Console.WriteLine("\t\t\tbroadening our horizons to " + allowableAgeDifference);
                            setAllowableAgeDifference(allowableAgeDifference);
                            firstTime = false;
                        }

                        Console.Write("\t\t\tlet's do the time warp ");

                        if (secondAge < minAge)
                        {
                            secondAge += rnd.Next(currentAgeDifference) / 2;
                            setPropAge(secondEntry, secondAge);
                            Console.WriteLine(", second is now " + getPropAge(secondEntry));
                        }
                        else if (secondAge > maxAge)
                        {
                            firstAge += rnd.Next(currentAgeDifference) / 2;
                            setAge(firstEntry, firstAge);
                            Console.WriteLine(", first is now " + getAge(firstEntry));
                        }

                        currentAgeDifference = ageDifference(firstEntry, secondEntry);

                        if (getPropAllowableAgeDifference() < currentAgeDifference)
                        {
                            Console.WriteLine("\t\t\tyou just won't grow up enough, will you? Still " + firstAge + " and " + secondAge);
                            continue;
                        }
                    }

                    if (compatible(firstEntry, secondEntry))
                    {
                        Console.WriteLine("\t\tIS compatible, breeding...");
                        T child = breed(firstEntry, secondEntry, (Gender)rnd.Next((int)Gender.MAX));
                        if (child == null)
                            Console.WriteLine("\t\tno child");
                        else
                        {
                            Console.WriteLine("\t\tbegat " + child.ToString());
                            // test if the child likes the parent...
                            string likesParent = compatible(child, secondEntry) ? "likes" : "hates";
                            Console.WriteLine("\t\t\t" + likesParent + " parent");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tNOT compatible, mutating...");
                        mutate(secondEntry);
                        Console.WriteLine("\t\tbecame " + secondEntry.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
        }
        #endregion

        #region Benchmark
        // I have to constrain this method because we're enforcing an interface contract on the BenchCallCompileTime
        private static void BenchCall<T>(T progenitor, Adjuster<T> adjuster, Random rnd) where T : ICallable<T>
        {
            Console.WriteLine("Method        \tElapsed          \tConstruction      \tGeneration");
            BenchCallCompileTime<T>(progenitor, adjuster, rnd);
            BenchCallDynamicExplicit<T>(adjuster, rnd);
            BenchCallDynamicParams<T>(adjuster, rnd);
            BenchCallCreateDelegate<T>(adjuster, rnd);
            BenchCallMethodInfo<T>(adjuster, rnd);
        }

        // I have to constrain this method because we're enforcing an interface contract
        private static void BenchCallCompileTime<T>(T progenitor, Adjuster<T> adjuster, Random rnd) where T : ICallable<T>
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Stopwatch watch = new Stopwatch();
            Stopwatch generate = new Stopwatch();
            Stopwatch creating = new Stopwatch();

            try
            {
                generate.Start();
                // no real work... but let's keep a consistent pattern
                generate.Stop();

                creating.Start();
                List<T> entries = CreateObjects(progenitor, BenchmarkEntries, adjuster, rnd);
                creating.Stop();

                watch.Start();

                // should be a static call, but what can you do when it is coupled to a interface?
                bool firstTime = true;
                int allowableAgeDifference = progenitor.GetAllowableAgeDifference();

                for (int firstIndex = 0; firstIndex < entries.Count; firstIndex++)
                {
                    T firstEntry = entries[firstIndex];

                    for (int neighbor = 0; neighbor <= (int)Gender.MAX; neighbor++)
                    {
                        int secondIndex = firstIndex + neighbor + 1;

                        if (secondIndex < entries.Count)
                        {
                            T secondEntry = entries[secondIndex];

                            // this is slightly unfair, but interfaces can't be used on static methods...
                            int currentAgeDifference = firstEntry.AgeDifferenceFrom(secondEntry);

                            if (allowableAgeDifference < currentAgeDifference)
                            {
                                // we have to go through the properties as the fields are (and should be) private...
                                double firstAge = firstEntry.Age;
                                double secondAge = secondEntry.Age;
                                double minAge = firstEntry.MinimumAge;
                                double maxAge = firstEntry.MaximumAge;

                                if (firstTime)
                                {
                                    // we'll broaden our horizons by 25%
                                    allowableAgeDifference = rnd.Next(allowableAgeDifference, (int)(1.25 * allowableAgeDifference));
                                    firstEntry.SetAllowableAgeDifference(allowableAgeDifference);
                                    firstTime = false;
                                }

                                if (secondAge < minAge)
                                {
                                    secondAge += rnd.Next(currentAgeDifference) / 2;
                                    secondEntry.Age = secondAge;
                                    secondAge = secondEntry.Age;
                                }
                                else if (secondAge > maxAge)
                                {
                                    firstAge += rnd.Next(currentAgeDifference) / 2;
                                    firstEntry.Age = firstAge;
                                    firstAge = firstEntry.Age;
                                }

                                currentAgeDifference = firstEntry.AgeDifferenceFrom(secondEntry);

                                if (allowableAgeDifference < currentAgeDifference)
                                {
                                    continue;
                                }
                            }

                            if (firstEntry.Compatible(secondEntry))
                            {
                                T child = firstEntry.Breed(secondEntry, (Gender)neighbor);
                            }
                            else
                            {
                                secondEntry.Mutate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
            finally
            {
                creating.Stop();
                generate.Stop();
                watch.Stop();
            }

            Console.WriteLine("CompileTime\t" + watch.Elapsed + "\t" + creating.Elapsed + "\t" + generate.Elapsed);
        }

        private static void BenchCallDynamicExplicit<T>(Adjuster<T> adjuster, Random rnd)
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Stopwatch watch = new Stopwatch();
            Stopwatch generate = new Stopwatch();
            Stopwatch creating = new Stopwatch();

            try
            {
                // Create the invoker for the methods.
                generate.Start();
                Constructor<T, string, string, Gender, double> create = Dynamic<T>.Constructor.Explicit<string, string, Gender, double>.CreateDelegate(ParameterList.Auto);
                Func<T, bool, T> compatible = Dynamic<T>.Instance.Function<bool>.Explicit<T>.CreateDelegate("Compatible");
                Func<T, T, T, Gender> breed = Dynamic<T>.Instance.Function<T>.Explicit<T, Gender>.CreateDelegate("Breed");
                Proc<T> mutate = Dynamic<T>.Instance.Procedure.Explicit.CreateDelegate("Mutate");
                StaticFunc<T, int, T, T> ageDifference = Dynamic<T>.Static.Function<int>.Explicit<T, T>.CreateDelegate("AgeDifference");
                StaticFunc<T, int> getAllowableAgeDifference = Dynamic<T>.Static.Field<int>.Getter.CreateDelegate("allowableAgeDifference");
                StaticProc<T, int> setAllowableAgeDifference = Dynamic<T>.Static.Field<int>.Setter.CreateDelegate("allowableAgeDifference");
                Func<T, double> getAge = Dynamic<T>.Instance.Field<double>.Getter.CreateDelegate("age");
                Proc<T, double> setAge = Dynamic<T>.Instance.Field<double>.Setter.CreateDelegate("age");
                Func<T, double> getMinimumAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("MinimumAge");
                Func<T, double> getMaximumAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("MaximumAge");
                generate.Stop();

                creating.Start();
                List<T> entries = CreateObjects(BenchmarkEntries, create, adjuster, rnd);
                creating.Stop();

                watch.Start();

                bool firstTime = true;
                int allowableAgeDifference = getAllowableAgeDifference();

                for (int firstIndex = 0; firstIndex < entries.Count; firstIndex++)
                {
                    T firstEntry = entries[firstIndex];

                    for (int neighbor = 0; neighbor <= (int)Gender.MAX; neighbor++)
                    {
                        int secondIndex = firstIndex + neighbor + 1;

                        if (secondIndex < entries.Count)
                        {
                            T secondEntry = entries[secondIndex];

                            int currentAgeDifference = ageDifference(firstEntry, secondEntry);

                            if (allowableAgeDifference < currentAgeDifference)
                            {
                                double firstAge = getAge(firstEntry);
                                double secondAge = getAge(secondEntry);
                                double minAge = getMinimumAge(firstEntry);
                                double maxAge = getMaximumAge(firstEntry);

                                if (firstTime)
                                {
                                    // we'll broaden our horizons by 25%
                                    allowableAgeDifference = rnd.Next(allowableAgeDifference, (int)(1.25 * allowableAgeDifference));
                                    setAllowableAgeDifference(allowableAgeDifference);
                                    firstTime = false;
                                }

                                if (secondAge < minAge)
                                {
                                    secondAge += rnd.Next(currentAgeDifference) / 2;
                                    setAge(secondEntry, secondAge);
                                    secondAge = getAge(secondEntry);
                                }
                                else if (secondAge > maxAge)
                                {
                                    firstAge += rnd.Next(currentAgeDifference) / 2;
                                    setAge(firstEntry, firstAge);
                                    firstAge = getAge(firstEntry);
                                }

                                currentAgeDifference = ageDifference(firstEntry, secondEntry);

                                if (allowableAgeDifference < currentAgeDifference)
                                {
                                    continue;
                                }
                            }

                            if (compatible(firstEntry, secondEntry))
                            {
                                T child = breed(firstEntry, secondEntry, (Gender)neighbor);
                            }
                            else
                            {
                                mutate(secondEntry);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
            finally
            {
                generate.Stop();
                creating.Stop();
                watch.Stop();
            }

            Console.WriteLine("DynamicExplicit\t" + watch.Elapsed + "\t" + creating.Elapsed + "\t" + generate.Elapsed);
        }

        private static void BenchCallDynamicParams<T>(Adjuster<T> adjuster, Random rnd)
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Stopwatch watch = new Stopwatch();
            Stopwatch generate = new Stopwatch();
            Stopwatch creating = new Stopwatch();

            try
            {
                // Create the invoker for the methods.
                generate.Start();
                Type[] parameterList = new Type[] { typeof(string), typeof(string), typeof(Gender), typeof(double) };
                ConstructorInfo constructor = typeof(T).GetConstructor(parameterList);
                ConstructorParams<T> create = Dynamic<T>.Constructor.Params.CreateDelegate(constructor);
                FuncParams<T, bool> compatible = Dynamic<T>.Instance.Function<bool>.Params.CreateDelegate("Compatible");
                FuncParams<T, T> breed = Dynamic<T>.Instance.Function<T>.Params.CreateDelegate("Breed");
                ProcParams<T> mutate = Dynamic<T>.Instance.Procedure.Params.CreateDelegate("Mutate");
                StaticFuncParams<T, int> ageDifference = Dynamic<T>.Static.Function<int>.Params.CreateDelegate("AgeDifference");
                StaticFunc<T, int> getAllowableAgeDifference = Dynamic<T>.Static.Field<int>.Getter.CreateDelegate("allowableAgeDifference");
                StaticProc<T, int> setAllowableAgeDifference = Dynamic<T>.Static.Field<int>.Setter.CreateDelegate("allowableAgeDifference");
                Func<T, double> getAge = Dynamic<T>.Instance.Field<double>.Getter.CreateDelegate("age");
                Proc<T, double> setAge = Dynamic<T>.Instance.Field<double>.Setter.CreateDelegate("age");
                Func<T, double> getMinimumAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("MinimumAge");
                Func<T, double> getMaximumAge = Dynamic<T>.Instance.Property<double>.Explicit.Getter.CreateDelegate("MaximumAge");
                generate.Stop();

                creating.Start();
                List<T> entries = CreateObjects<T>(BenchmarkEntries, create, adjuster, rnd);
                creating.Stop();

                watch.Start();

                bool firstTime = true;
                int allowableAgeDifference = getAllowableAgeDifference();

                for (int firstIndex = 0; firstIndex < entries.Count; firstIndex++)
                {
                    T firstEntry = entries[firstIndex];

                    for (int neighbor = 0; neighbor <= (int)Gender.MAX; neighbor++)
                    {
                        int secondIndex = firstIndex + neighbor + 1;

                        if (secondIndex < entries.Count)
                        {
                            T secondEntry = entries[secondIndex];

                            int currentAgeDifference = ageDifference(firstEntry, secondEntry);

                            if (allowableAgeDifference < currentAgeDifference)
                            {
                                double firstAge = getAge(firstEntry);
                                double secondAge = getAge(secondEntry);
                                double minAge = getMinimumAge(firstEntry);
                                double maxAge = getMaximumAge(firstEntry);

                                if (firstTime)
                                {
                                    // we'll broaden our horizons by 25%
                                    allowableAgeDifference = rnd.Next(allowableAgeDifference, (int)(1.25 * allowableAgeDifference));
                                    setAllowableAgeDifference(allowableAgeDifference);
                                    firstTime = false;
                                }

                                if (secondAge < minAge)
                                {
                                    secondAge += rnd.Next(currentAgeDifference) / 2;
                                    setAge(secondEntry, secondAge);
                                    secondAge = getAge(secondEntry);
                                }
                                else if (secondAge > maxAge)
                                {
                                    firstAge += rnd.Next(currentAgeDifference) / 2;
                                    setAge(firstEntry, firstAge);
                                    firstAge = getAge(firstEntry);
                                }

                                currentAgeDifference = ageDifference(firstEntry, secondEntry);

                                if (allowableAgeDifference < currentAgeDifference)
                                {
                                    continue;
                                }
                            }

                            if (compatible(firstEntry, secondEntry))
                            {
                                T child = breed(firstEntry, secondEntry, (Gender)neighbor);
                            }
                            else
                            {
                                mutate(secondEntry);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
            finally
            {
                generate.Stop();
                creating.Stop();
                watch.Stop();
            }

            Console.WriteLine("DynamicParams\t" + watch.Elapsed + "\t" + creating.Elapsed + "\t" + generate.Elapsed);
        }

        private static void BenchCallCreateDelegate<T>(Adjuster<T> adjuster, Random rnd)
        {
            // can't do lazy-bind to instance methods for structs, this is invalid
            if (typeof(T).IsValueType)
            {
                Console.WriteLine("Cannot use CreateDelegate against a value-type instance methods, skipping.");
                return;
            }

            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Stopwatch watch = new Stopwatch();
            Stopwatch creating = new Stopwatch();
            Stopwatch generate = new Stopwatch();

            try
            {
                // Get the MethodInfo for the methods.
                generate.Start();
                Type[] parameterList = new Type[] { typeof(string), typeof(string), typeof(Gender), typeof(double) };
                ConstructorInfo constructor = typeof(T).GetConstructor(parameterList);

                MethodInfo miCompatible = typeof(T).GetMethod("Compatible");
                Func<T, bool, T> compatible = (Func<T, bool, T>)Delegate.CreateDelegate(typeof(Func<T, bool, T>), default(T), miCompatible, false);

                MethodInfo miBreed = typeof(T).GetMethod("Breed");
                Func<T, T, T, Gender> breed = (Func<T, T, T, Gender>)Delegate.CreateDelegate(typeof(Func<T, T, T, Gender>), default(T), miBreed, false);

                MethodInfo miMutate = typeof(T).GetMethod("Mutate");
                Proc<T> mutate = (Proc<T>)Delegate.CreateDelegate(typeof(Proc<T>), default(T), miMutate, false);

                MethodInfo miAgeDifference = typeof(T).GetMethod("AgeDifference", BindingFlags.Static | BindingFlags.NonPublic);
                StaticFunc<T, int, T, T> ageDifference = (StaticFunc<T, int, T, T>)Delegate.CreateDelegate(typeof(StaticFunc<T, int, T, T>), miAgeDifference);

                FieldInfo fiAllowableAgeDifference = typeof(T).GetField("allowableAgeDifference", BindingFlags.Static | BindingFlags.NonPublic);
                FieldInfo fiAge = typeof(T).GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);

                PropertyInfo piMinimumAge = typeof(T).GetProperty("MinimumAge", BindingFlags.Instance | BindingFlags.Public);
                Func<T, double> getMinimumAge = (Func<T, double>)Delegate.CreateDelegate(typeof(Func<T, double>), piMinimumAge.GetGetMethod());
                PropertyInfo piMaximumAge = typeof(T).GetProperty("MaximumAge", BindingFlags.Instance | BindingFlags.Public);
                Func<T, double> getMaximumAge = (Func<T, double>)Delegate.CreateDelegate(typeof(Func<T, double>), piMaximumAge.GetGetMethod());
                generate.Stop();

                creating.Start();
                List<T> entries = CreateObjects<T>(BenchmarkEntries, constructor, adjuster, rnd);
                creating.Stop();

                watch.Start();

                bool firstTime = true;
                int allowableAgeDifference = (int)fiAllowableAgeDifference.GetValue(null);

                for (int firstIndex = 0; firstIndex < entries.Count; firstIndex++)
                {
                    T firstEntry = entries[firstIndex];

                    for (int neighbor = 0; neighbor <= (int)Gender.MAX; neighbor++)
                    {
                        int secondIndex = firstIndex + neighbor + 1;

                        if (secondIndex < entries.Count)
                        {
                            T secondEntry = entries[secondIndex];

                            int currentAgeDifference = ageDifference(firstEntry, secondEntry);

                            if (allowableAgeDifference < currentAgeDifference)
                            {
                                double firstAge = (double)fiAge.GetValue(firstEntry);
                                double secondAge = (double)fiAge.GetValue(secondEntry);
                                double minAge = getMinimumAge(firstEntry);
                                double maxAge = getMaximumAge(firstEntry);

                                if (firstTime)
                                {
                                    // we'll broaden our horizons by 25%
                                    allowableAgeDifference = rnd.Next(allowableAgeDifference, (int)(1.25 * allowableAgeDifference));
                                    fiAllowableAgeDifference.SetValue(null, allowableAgeDifference);
                                    firstTime = false;
                                }

                                if (secondAge < minAge)
                                {
                                    secondAge += rnd.Next(currentAgeDifference) / 2;
                                    fiAge.SetValue(secondEntry, secondAge);
                                    secondAge = (double)fiAge.GetValue(secondEntry);
                                }
                                else if (secondAge > maxAge)
                                {
                                    firstAge += rnd.Next(currentAgeDifference) / 2;
                                    fiAge.SetValue(firstEntry, firstAge);
                                    firstAge = (double)fiAge.GetValue(firstEntry);
                                }

                                currentAgeDifference = ageDifference(firstEntry, secondEntry);

                                if (allowableAgeDifference < currentAgeDifference)
                                {
                                    continue;
                                }

                                if (compatible(firstEntry, secondEntry))
                                {
                                    T child = breed(firstEntry, secondEntry, (Gender)neighbor);
                                }
                                else
                                {
                                    mutate(secondEntry);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
            finally
            {
                generate.Stop();
                creating.Stop();
                watch.Stop();
            }

            Console.WriteLine("CreateDelegate\t" + watch.Elapsed + "\t" + creating.Elapsed + "\t" + generate.Elapsed);
        }

        private static void BenchCallMethodInfo<T>(Adjuster<T> adjuster, Random rnd)
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Stopwatch watch = new Stopwatch();
            Stopwatch creating = new Stopwatch();
            Stopwatch generate = new Stopwatch();

            try
            {
                // Get the MethodInfo for the methods.
                generate.Start();
                Type[] parameterList = new Type[] { typeof(string), typeof(string), typeof(Gender), typeof(double) };
                ConstructorInfo constructor = typeof(T).GetConstructor(parameterList);
                MethodInfo compatible = typeof(T).GetMethod("Compatible");
                MethodInfo breed = typeof(T).GetMethod("Breed");
                MethodInfo mutate = typeof(T).GetMethod("Mutate");
                MethodInfo ageDifference = typeof(T).GetMethod("AgeDifference", BindingFlags.Static | BindingFlags.NonPublic);
                FieldInfo fiAllowableAgeDifference = typeof(T).GetField("allowableAgeDifference", BindingFlags.Static | BindingFlags.NonPublic);
                FieldInfo fiAge = typeof(T).GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);
                PropertyInfo piMinimumAge = typeof(T).GetProperty("MinimumAge", BindingFlags.Instance | BindingFlags.Public);
                MethodInfo getMinimumAge = piMinimumAge.GetGetMethod();
                PropertyInfo piMaximumAge = typeof(T).GetProperty("MaximumAge", BindingFlags.Instance | BindingFlags.Public);
                MethodInfo getMaximumAge = piMaximumAge.GetGetMethod();
                generate.Stop();

                creating.Start();
                List<T> entries = CreateObjects<T>(BenchmarkEntries, constructor, adjuster, rnd);
                creating.Stop();

                watch.Start();

                bool firstTime = true;
                int allowableAgeDifference = (int)fiAllowableAgeDifference.GetValue(null);

                for (int firstIndex = 0; firstIndex < entries.Count; firstIndex++)
                {
                    T firstEntry = entries[firstIndex];

                    for (int neighbor = 0; neighbor <= (int)Gender.MAX; neighbor++)
                    {
                        int secondIndex = firstIndex + neighbor + 1;

                        if (secondIndex < entries.Count)
                        {
                            T secondEntry = entries[secondIndex];

                            int currentAgeDifference = (int)ageDifference.Invoke(null, new object[] { firstEntry, secondEntry });

                            if (allowableAgeDifference < currentAgeDifference)
                            {
                                double firstAge = (double)fiAge.GetValue(firstEntry);
                                double secondAge = (double)fiAge.GetValue(secondEntry);
                                double minAge = (double)getMinimumAge.Invoke(firstEntry, null);
                                double maxAge = (double)getMaximumAge.Invoke(firstEntry, null);

                                if (firstTime)
                                {
                                    // we'll broaden our horizons by 25%
                                    allowableAgeDifference = rnd.Next(allowableAgeDifference, (int)(1.25 * allowableAgeDifference));
                                    fiAllowableAgeDifference.SetValue(null, allowableAgeDifference);
                                    firstTime = false;
                                }

                                if (secondAge < minAge)
                                {
                                    secondAge += rnd.Next(currentAgeDifference) / 2;
                                    fiAge.SetValue(secondEntry, secondAge);
                                    secondAge = (double)fiAge.GetValue(secondEntry);
                                }
                                else if (secondAge > maxAge)
                                {
                                    firstAge += rnd.Next(currentAgeDifference) / 2;
                                    fiAge.SetValue(firstEntry, firstAge);
                                    firstAge = (double)fiAge.GetValue(firstEntry);
                                }

                                currentAgeDifference = (int)ageDifference.Invoke(null, new object[] { firstEntry, secondEntry });

                                if (allowableAgeDifference < currentAgeDifference)
                                {
                                    continue;
                                }
                            }

                            if ((bool)compatible.Invoke(firstEntry, new object[] { secondEntry }))
                            {
                                T child = (T)breed.Invoke(firstEntry, new object[] { secondEntry, (Gender)neighbor });
                            }
                            else
                            {
                                mutate.Invoke(secondEntry, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
            finally
            {
                generate.Stop();
                creating.Stop();
                watch.Stop();
            }

            Console.WriteLine("MethodInfo\t" + watch.Elapsed + "\t" + creating.Elapsed + "\t" + generate.Elapsed);
        }
        #endregion
        #endregion

        #region DynamicComparer
        #region Test
        private static void TestCompare<T>(T progenitor, Adjuster<T> adjuster, Random rnd) where T : ICallable<T>, IComparable
        {
            List<T> unsorted = CreateObjects<T>(progenitor, InteractiveEntries, adjuster, rnd);

            Console.Clear();
            Console.WriteLine("The following properties are available for sorting:");

            StringBuilder all = new StringBuilder();

            foreach (PropertyInfo pi in typeof(T).GetProperties(WhatMembers | BindingFlags.GetProperty))
            {
                if (!SortProperty.IsComparable(pi.PropertyType))
                    continue;

                Console.WriteLine("{0}", pi.Name);
                all.Append(pi.Name).Append(',');
            }

            if (all.Length > 1)
                all.Length--;   // trim trailing ,

            // Define which properties should be sorted on (must be IComparable).
            Console.Write(@"
You may also enter the word 'all' for all sortable properties in the order listed above
or you me enter the word 'null' to default to the default List.Sort sorter

Please enter an order by clause (case-sensitive): ");
            string orderBy = Console.ReadLine();

            if (orderBy.Equals("all", StringComparison.OrdinalIgnoreCase))
                orderBy = all.ToString();

            try
            {
                // Create the comparer for the type and define the sort fields.
                DynamicComparer<T> comparer = null;

                if (!orderBy.Equals("null", StringComparison.OrdinalIgnoreCase))
                    comparer = new DynamicComparer<T>(orderBy);

                // Print the unsorted list.
                Console.WriteLine("\nUnsorted:");
                foreach (T entry in unsorted)
                    Console.WriteLine(entry.ToString());

                // Sort the list.
                try
                {
                    // Note: you could also call the sort method like: Sort(comparer) but calling it with Sort(comparer.Compare) is faster.
                    if (comparer == null)
                    {
                        unsorted.Sort();
                    }
                    else
                    {
                        unsorted.Sort(comparer.Comparer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n{0}", ex.ToString());
                }

                // Print the sorted list.
                Console.WriteLine("\nSorted:");
                foreach (T entry in unsorted)
                    Console.WriteLine(entry.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.ToString());
            }
        }
        #endregion

        #region Benchmark
        private static void BenchCompare<T>(T progenitor, Adjuster<T> adjuster, Random rnd) where T : ICallable<T>
        {
            List<T> unsorted = CreateObjects<T>(progenitor, BenchmarkEntries, adjuster, rnd);
            BenchCompare(unsorted, typeof(T).GetProperties(WhatMembers | BindingFlags.GetProperty));
            BenchCompare(unsorted, typeof(T).GetFields(WhatMembers | BindingFlags.GetField));
            BenchOneCompare(unsorted, String.Empty);
            BenchOneCompare(unsorted, null);
        }

        private static void BenchCompare<T>(List<T> unsorted, PropertyInfo[] props)
        {
            StringBuilder all = new StringBuilder();

            foreach (PropertyInfo pi in props)
            {
                if (!SortProperty.IsComparable(pi.PropertyType))
                    continue;

                BenchOneCompare(unsorted, pi.Name);
                all.Append(pi.Name).Append(',');
            }

            if (all.Length > 1)
            {
                all.Length--;   // trim trailing ,
                BenchOneCompare(unsorted, all.ToString());
            }
        }

        private static void BenchCompare<T>(List<T> unsorted, FieldInfo[] fields)
        {
            StringBuilder all = new StringBuilder();

            foreach (FieldInfo fi in fields)
            {
                if (!SortProperty.IsComparable(fi.FieldType))
                    continue;

                BenchOneCompare(unsorted, fi.Name);
                all.Append(fi.Name).Append(',');
            }

            if (all.Length > 1)
            {
                all.Length--;   // trim trailing ,
                BenchOneCompare(unsorted, all.ToString());
            }
        }

        private static void BenchOneCompare<T>(List<T> unsorted, string what)
        {
            DynamicComparer<T> comparer;
            if (what == null)
            {
                comparer = null;
                Console.Write("Builtin: ");
            }
            else
            {
                comparer = new DynamicComparer<T>(what);

                if (what.Length == 0)
                    Console.Write("Dynamic object level: ");
                else
                    Console.Write("Dynamic with " + what + ": ");
            }

            List<T> sorted = new List<T>(unsorted.Count);
            foreach (T p in unsorted)
                sorted.Add(p);

            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();

            Stopwatch watch = new Stopwatch();
            if (comparer != null)
            {
                watch.Start();

                try
                {
                    sorted.Sort(comparer.Comparer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\t{0}", ex.ToString());
                }
                finally
                {
                    watch.Stop();
                }
            }
            else
            {
                watch.Start();

                try
                {
                    sorted.Sort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\t{0}", ex.ToString());
                }
                finally
                {
                    watch.Stop();
                }
            }

            Console.WriteLine(watch.Elapsed);
        }
        #endregion
        #endregion
    }
}