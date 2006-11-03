using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Phydeaux.Utilities
{
    #region Delegate definitions
    #region Constructors
    /// <summary>Defines a delegate to a constructor with a params array of weak-typed argument values.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <param name="parameters">The array of argument values (weak-typed)</param>
    public delegate T ConstructorParams<T>(params object[] parameters);

    #region Explicit arguments (up to 9, consider passing an object if you think you need more!)
    /// <summary>Defines a delegate to a constructor that takes no arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    public delegate T Constructor<T>();

    /// <summary>Defines a delegate to a constructor that takes a single strong-typed argument.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    public delegate T Constructor<T, V1>(V1 arg1);

    /// <summary>Defines a delegate to a constructor that takes two strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    public delegate T Constructor<T, V1, V2>(V1 arg1, V2 arg2);

    /// <summary>Defines a delegate to a constructor that takes three strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    public delegate T Constructor<T, V1, V2, V3>(V1 arg1, V2 arg2, V3 arg3);

    /// <summary>Defines a delegate to a constructor that takes four strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    public delegate T Constructor<T, V1, V2, V3, V4>(V1 arg1, V2 arg2, V3 arg3, V4 arg4);

    /// <summary>Defines a delegate to a constructor that takes five strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    public delegate T Constructor<T, V1, V2, V3, V4, V5>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5);

    /// <summary>Defines a delegate to a constructor that takes six strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    public delegate T Constructor<T, V1, V2, V3, V4, V5, V6>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6);

    /// <summary>Defines a delegate to a constructor that takes seven strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    public delegate T Constructor<T, V1, V2, V3, V4, V5, V6, V7>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7);

    /// <summary>Defines a delegate to a constructor that takes eight strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    public delegate T Constructor<T, V1, V2, V3, V4, V5, V6, V7, V8>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8);

    /// <summary>Defines a delegate to a constructor that takes nine strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the constructed object</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    /// <typeparam name="V9">The type of the ninth argument</typeparam>
    /// <param name="arg9">The ninth argument value</param>
    public delegate T Constructor<T, V1, V2, V3, V4, V5, V6, V7, V8, V9>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8, V9 arg9);
    #endregion
    #endregion

    #region Procedures (methods that return nothing)
    #region Instance methods
    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) with a params array of weak-typed
    /// argument values.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <param name="parameters">The array of argument values (weak-typed)</param>
    public delegate void ProcParams<T>(T target, params object[] parameters);

    #region Explicit arguments (up to 9, consider passing an object if you think you need more!)
    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes no arguments</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    public delegate void Proc<T>(T target);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes a single
    /// strong-typed argument.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    public delegate void Proc<T, V1>(T target, V1 arg1);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes two
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    public delegate void Proc<T, V1, V2>(T target, V1 arg1, V2 arg2);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes three
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    public delegate void Proc<T, V1, V2, V3>(T target, V1 arg1, V2 arg2, V3 arg3);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes four
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    public delegate void Proc<T, V1, V2, V3, V4>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes five
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    public delegate void Proc<T, V1, V2, V3, V4, V5>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes six
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    public delegate void Proc<T, V1, V2, V3, V4, V5, V6>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes seven
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    public delegate void Proc<T, V1, V2, V3, V4, V5, V6, V7>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes eight
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    public delegate void Proc<T, V1, V2, V3, V4, V5, V6, V7, V8>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8);

    /// <summary>Defines a delegate to a instance procedure (method that doesn't return anything) that takes nine
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    /// <typeparam name="V9">The type of the ninth argument</typeparam>
    /// <param name="arg9">The ninth argument value</param>
    public delegate void Proc<T, V1, V2, V3, V4, V5, V6, V7, V8, V9>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8, V9 arg9);
    #endregion
    #endregion

    #region Static methods
    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) with a params array of weak-typed
    /// argument values.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <param name="parameters">The array of argument values (weak-typed)</param>
    public delegate void StaticProcParams<T>(params object[] parameters);

    #region Explicit arguments (up to 9, consider passing an object if you think you need more!)
    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes nine
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    public delegate void StaticProc<T>();

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes a single
    /// strong-typed argument.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    public delegate void StaticProc<T, V1>(V1 arg1);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes two
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    public delegate void StaticProc<T, V1, V2>(V1 arg1, V2 arg2);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes three
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    public delegate void StaticProc<T, V1, V2, V3>(V1 arg1, V2 arg2, V3 arg3);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes four
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    public delegate void StaticProc<T, V1, V2, V3, V4>(V1 arg1, V2 arg2, V3 arg3, V4 arg4);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes five
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    public delegate void StaticProc<T, V1, V2, V3, V4, V5>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes six
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    public delegate void StaticProc<T, V1, V2, V3, V4, V5, V6>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes seven
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    public delegate void StaticProc<T, V1, V2, V3, V4, V5, V6, V7>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes eight
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    public delegate void StaticProc<T, V1, V2, V3, V4, V5, V6, V7, V8>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8);

    /// <summary>Defines a delegate to a static procedure (method that doesn't return anything) that takes nine
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    /// <typeparam name="V9">The type of the ninth argument</typeparam>
    /// <param name="arg9">The ninth argument value</param>
    public delegate void StaticProc<T, V1, V2, V3, V4, V5, V6, V7, V8, V9>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8, V9 arg9);
    #endregion
    #endregion
    #endregion

    #region Functions (methods that return a TRet)
    #region Instance methods
    /// <summary>Defines a delegate to a instance function (method that return something) with a params array of weak-typed
    /// argument values.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <param name="parameters">The array of argument values (weak-typed)</param>
    public delegate TRet FuncParams<T, TRet>(T target, params object[] parameters);

    #region Explicit arguments
    /// <summary>Defines a delegate to a instance function (method that returns something) that takes no arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    public delegate TRet Func<T, TRet>(T target);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes a single
    /// strong-typed argument.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    public delegate TRet Func<T, TRet, V1>(T target, V1 arg1);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes two
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    public delegate TRet Func<T, TRet, V1, V2>(T target, V1 arg1, V2 arg2);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes three
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3>(T target, V1 arg1, V2 arg2, V3 arg3);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes four
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3, V4>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes five
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3, V4, V5>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes six
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3, V4, V5, V6>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes seven
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3, V4, V5, V6, V7>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes eight
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8);

    /// <summary>Defines a delegate to a instance function (method that returns something) that takes nine
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the instance method target</typeparam>
    /// <param name="target">The target instance (this)</param>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    /// <typeparam name="V9">The type of the ninth argument</typeparam>
    /// <param name="arg9">The ninth argument value</param>
    public delegate TRet Func<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8, V9>(T target, V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8, V9 arg9);
    #endregion
    #endregion

    #region Static methods
    /// <summary>Defines a delegate to a static function (method that return something) with a params array of weak-typed
    /// argument values.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <param name="parameters">The array of argument values (weak-typed)</param>
    public delegate TRet StaticFuncParams<T, TRet>(params object[] parameters);

    #region Explicit arguments
    /// <summary>Defines a delegate to a static function (method that returns something) that takes no arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    public delegate TRet StaticFunc<T, TRet>();

    /// <summary>Defines a delegate to a static function (method that returns something) that takes a single
    /// strong-typed argument.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1>(V1 arg1);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes two
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2>(V1 arg1, V2 arg2);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes three
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3>(V1 arg1, V2 arg2, V3 arg3);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes four
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3, V4>(V1 arg1, V2 arg2, V3 arg3, V4 arg4);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes five
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3, V4, V5>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes six
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes seven
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6, V7>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes eight
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8);

    /// <summary>Defines a delegate to a static function (method that returns something) that takes nine
    /// strong-typed arguments.</summary>
    /// <typeparam name="T">The type of the static method target</typeparam>
    /// <typeparam name="TRet">The type of the return value</typeparam>
    /// <typeparam name="V1">The type of the first argument</typeparam>
    /// <param name="arg1">The first argument value</param>
    /// <typeparam name="V2">The type of the second argument</typeparam>
    /// <param name="arg2">The second argument value</param>
    /// <typeparam name="V3">The type of the third argument</typeparam>
    /// <param name="arg3">The third argument value</param>
    /// <typeparam name="V4">The type of the fourth argument</typeparam>
    /// <param name="arg4">The fourth argument value</param>
    /// <typeparam name="V5">The type of the fifth argument</typeparam>
    /// <param name="arg5">The fifth argument value</param>
    /// <typeparam name="V6">The type of the sixth argument</typeparam>
    /// <param name="arg6">The sixth argument value</param>
    /// <typeparam name="V7">The type of the seventh argument</typeparam>
    /// <param name="arg7">The seventh argument value</param>
    /// <typeparam name="V8">The type of the eighth argument</typeparam>
    /// <param name="arg8">The eighth argument value</param>
    /// <typeparam name="V9">The type of the ninth argument</typeparam>
    /// <param name="arg9">The ninth argument value</param>
    public delegate TRet StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8, V9>(V1 arg1, V2 arg2, V3 arg3, V4 arg4, V5 arg5, V6 arg6, V7 arg7, V8 arg8, V9 arg9);
    #endregion
    #endregion
    #endregion
    #endregion

    /// <summary>This is a "marker" enum used to trigger the automatic matching of a delegate's argument list to the
    // reflected method's parameter list. It serves no other purpose other than to to disambiguate the possible overloads
    // of the CreateDelegate method.</summary>
    public enum ParameterList
    {
        Auto
    }

    /// <summary>Exception thrown when the arguments passed to a delegate do not match the parameter count of the method being called</summary>
    public class ParameterCountMismatchException : ArgumentException
    {
        private const string ErrorFormat = "Method {0}.{1} takes {2} arguments, passed {3}.";

        /// <summary>Checks the parameter counts and throws a ParameterCountMismatchException if they are not the same.</summary>
        /// <param name="type">The Type the method is being called against</param>
        /// <param name="methodName">The method name being called</param>
        /// <param name="expectedParameterCount">The number of parameters that method expects</param>
        /// <param name="actualArgumentCount">The number of arguments specified at call time (for Params-type delegates) or at
        /// CreateDelegate time (for Explicit-type delegates)</param>
        public static void CheckAndThrow(Type type, string methodName, int expectedParameterCount, int actualArgumentCount)
        {
            if (expectedParameterCount != actualArgumentCount)
                throw new ParameterCountMismatchException(type, methodName, expectedParameterCount, actualArgumentCount);
        }

        /// <summary>Constructs a ParameterCountMismatchException and fills in the error message based on the characteristics 
        /// specified</summary>
        /// <param name="type">The Type the method is being called against</param>
        /// <param name="methodName">The method name being called</param>
        /// <param name="expectedParameterCount">The number of parameters that method expects</param>
        /// <param name="actualArgumentCount">The number of arguments specified at call time (for Params-type delegates) or at
        /// CreateDelegate time (for Explicit-type delegates)</param>
        public ParameterCountMismatchException(Type type, string methodName, int expectedParameterCount, int actualArgumentCount)
            : base(string.Format(ErrorFormat, type, methodName, expectedParameterCount, actualArgumentCount))
        {
        }

        // cache the reflection information on the ParameterCountMismatchException.CheckAndThrow method
        static MethodInfo s_CheckAndThrow;
        
        public static MethodInfo CheckAndThrowMethodInfo
        {
            get
            {
                if (s_CheckAndThrow == null)
                {
                    s_CheckAndThrow = typeof(ParameterCountMismatchException).GetMethod("CheckAndThrow");
                }

                return s_CheckAndThrow;
            }
        }
    }

    /// <summary>Dynamic method wrapper class</summary>
    /// <typeparam name="T">The type implementing the method desired.</typeparam>
    /// <remarks>
    /// You can use any reference or value-type, including built-in primitive types
    /// </remarks>
    public abstract class Dynamic<T>
    {
        /// <summary>Represents all instance constructors</summary>
        public class Constructor
        {
            /// <summary>Represents Late-bound argument list (e.g. params object[])</summary>
            public class Params
                : DynamicBase<ConstructorParams<T>>.Params.Constructor
            {
            }

            #region Explicit arguments
            /// <summary>Represents a constructor that takes known-typed argument list (empty)</summary>
            public class Explicit
                : DynamicBase<Constructor<T>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (one argument)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1>
                : DynamicBase<Constructor<T, V1>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (two arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2>
                : DynamicBase<Constructor<T, V1, V2>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (three arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3>
                : DynamicBase<Constructor<T, V1, V2, V3>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (four arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <typeparam name="V4">The type of the fourth argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3, V4>
                : DynamicBase<Constructor<T, V1, V2, V3, V4>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (five arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <typeparam name="V4">The type of the fourth argument</typeparam>
            /// <typeparam name="V5">The type of the fifth argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3, V4, V5>
                : DynamicBase<Constructor<T, V1, V2, V3, V4, V5>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (six arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <typeparam name="V4">The type of the fourth argument</typeparam>
            /// <typeparam name="V5">The type of the fifth argument</typeparam>
            /// <typeparam name="V6">The type of the sixth argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3, V4, V5, V6>
                : DynamicBase<Constructor<T, V1, V2, V3, V4, V5, V6>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (seven arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <typeparam name="V4">The type of the fourth argument</typeparam>
            /// <typeparam name="V5">The type of the fifth argument</typeparam>
            /// <typeparam name="V6">The type of the sixth argument</typeparam>
            /// <typeparam name="V7">The type of the seventh argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                : DynamicBase<Constructor<T, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (eight arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <typeparam name="V4">The type of the fourth argument</typeparam>
            /// <typeparam name="V5">The type of the fifth argument</typeparam>
            /// <typeparam name="V6">The type of the sixth argument</typeparam>
            /// <typeparam name="V7">The type of the seventh argument</typeparam>
            /// <typeparam name="V8">The type of the eighth argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                : DynamicBase<Constructor<T, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Constructor
            {
            }

            /// <summary>Represents constructor that takes known-typed argument list (nine arguments)</summary>
            /// <typeparam name="V1">The type of the first argument</typeparam>
            /// <typeparam name="V2">The type of the second argument</typeparam>
            /// <typeparam name="V3">The type of the third argument</typeparam>
            /// <typeparam name="V4">The type of the fourth argument</typeparam>
            /// <typeparam name="V5">The type of the fifth argument</typeparam>
            /// <typeparam name="V6">The type of the sixth argument</typeparam>
            /// <typeparam name="V7">The type of the seventh argument</typeparam>
            /// <typeparam name="V8">The type of the eighth argument</typeparam>
            /// <typeparam name="V9">The type of the ninth argument</typeparam>
            /// <remarks>
            /// Argument types must be compatible, but need not exactly match the actual
            /// method. This means that if the method takes an argument of type object,
            /// it is legal to define the dynamic delegate as something more type-specific
            /// </remarks>
            public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8, V9>
                : DynamicBase<Constructor<T, V1, V2, V3, V4, V5, V6, V7, V8, V9>>.Explicit.Constructor
            {
            }
            #endregion
        }

        /// <summary>Represents static methods (no "this" instance passed)</summary>
        public abstract class Static
        {
            /// <summary>Represents the static fields (for Get and/or Set)</summary>
            /// <typeparam name="VF">The type of the field</typeparam>
            public abstract class Field<VF>
            {
                /// <summary>Represents a field-getter.</summary>
                public abstract class Getter
                    : DynamicBase<StaticFunc<T, VF>>.Explicit.Static.Field<VF>.Getter
                {
                }

                /// <summary>Represents a field-setter.</summary>
                public abstract class Setter
                    : DynamicBase<StaticProc<T, VF>>.Explicit.Static.Field<VF>.Setter
                {
                }
            }

            /// <summary>Represents the static properties (for Get and/or Set with/with-out indexers)</summary>
            /// <typeparam name="VP">The type of the property</typeparam>
            public abstract class Property<VP>
            {
                /// <summary>Represents Late-bound argument list (e.g. params object[])</summary>
                public abstract class Params
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFuncParams<T, VP>>.Params.Static.Property.Getter<VP>
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProcParams<T>>.Params.Static.Property.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (no indexer)</summary>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public abstract class Explicit
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (one indexer argument)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (two indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (three indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2, V3>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2, V3>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (four indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2, V3, V4>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2, V3, V4>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (five indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2, V3, V4, V5>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2, V3, V4, V5>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (six indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <typeparam name="V6">The type of the sixth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2, V3, V4, V5, V6>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2, V3, V4, V5, V6>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (seven indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <typeparam name="V6">The type of the sixth indexer argument</typeparam>
                /// <typeparam name="V7">The type of the seventh indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (eight indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <typeparam name="V6">The type of the sixth indexer argument</typeparam>
                /// <typeparam name="V7">The type of the seventh indexer argument</typeparam>
                /// <typeparam name="V8">The type of the eighth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<StaticFunc<T, VP, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Static.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing)</summary>
                    public abstract class Setter
                        : DynamicBase<StaticProc<T, VP, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Static.Property<VP>.Setter
                    {
                    }
                }
            }

            /// <summary>Represents procedures (methods that return nothing)</summary>
            public abstract class Procedure
            {
                /// <summary>Represents Late-bound argument list (e.g. params object[])</summary>
                public class Params
                    : DynamicBase<StaticProcParams<T>>.Params.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (empty)</summary>
                public class Explicit
                    : DynamicBase<StaticProc<T>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (one argument)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1>
                    : DynamicBase<StaticProc<T, V1>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (two arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2>
                    : DynamicBase<StaticProc<T, V1, V2>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (three arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3>
                    : DynamicBase<StaticProc<T, V1, V2, V3>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (four arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4>
                    : DynamicBase<StaticProc<T, V1, V2, V3, V4>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (five arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5>
                    : DynamicBase<StaticProc<T, V1, V2, V3, V4, V5>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (six arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6>
                    : DynamicBase<StaticProc<T, V1, V2, V3, V4, V5, V6>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (seven arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                    : DynamicBase<StaticProc<T, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (eight arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                    : DynamicBase<StaticProc<T, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Static.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (nine arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <typeparam name="V9">The type of the ninth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8, V9>
                    : DynamicBase<StaticProc<T, V1, V2, V3, V4, V5, V6, V7, V8, V9>>.Explicit.Static.Procedure
                {
                }
            }

            /// <summary>Represents functions (methods that return a value)</summary>
            /// <typeparam name="TRet">The type of the return value</typeparam>
            public abstract class Function<TRet>
            {
                /// <summary>Represents Late-bound argument list (e.g. params object[])</summary>
                public class Params
                    : DynamicBase<StaticFuncParams<T, TRet>>.Params.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (empty)</summary>
                public class Explicit
                    : DynamicBase<StaticFunc<T, TRet>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (one argument)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1>
                    : DynamicBase<StaticFunc<T, TRet, V1>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (two arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (three arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (four arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3, V4>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (five arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3, V4, V5>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (six arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (seven arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (eight arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Static.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (nine arguments)</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <typeparam name="V9">The type of the ninth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8, V9>
                    : DynamicBase<StaticFunc<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8, V9>>.Explicit.Static.Function<TRet>
                {
                }
            }
        }

        /// <summary>Represents instance methods (those that get a "this" argument)</summary>
        public abstract class Instance
        {
            /// <summary>Represents the instance fields (for Get and/or Set</summary>
            /// <typeparam name="VF">The type of the field</typeparam>
            public abstract class Field<VF>
            {
                /// <summary>Represents a field-getter</summary>
                public abstract class Getter
                    : DynamicBase<Func<T, VF>>.Explicit.Instance.Field<VF>.Getter
                {
                }

                /// <summary>Represents a field-setter</summary>
                public abstract class Setter
                    : DynamicBase<Proc<T, VF>>.Explicit.Instance.Field<VF>.Setter
                {
                }
            }

            /// <summary>Represents the static properties (for Get and/or Set with/with-out indexers</summary>
            /// <typeparam name="VP">The type of the property</typeparam>
            public abstract class Property<VP>
            {
                /// <summary>Represents Late-bound argument list (e.g. params object[])</summary>
                public abstract class Params
                {
                    /// <summary>Represents property-get (methods that return a value)</summary>
                    public abstract class Getter
                        : DynamicBase<FuncParams<T, VP>>.Params.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<ProcParams<T>>.Params.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (no indexer)</summary>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public abstract class Explicit
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (one indexer argument)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (two indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (three indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2, V3>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2, V3>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (four indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2, V3, V4>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2, V3, V4>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (five indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2, V3, V4, V5>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2, V3, V4, V5>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (six indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <typeparam name="V6">The type of the sixth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2, V3, V4, V5, V6>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2, V3, V4, V5, V6>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (seven indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <typeparam name="V6">The type of the sixth indexer argument</typeparam>
                /// <typeparam name="V7">The type of the seventh indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }

                /// <summary>Represents methods that take known-typed argument list (eight indexer arguments)</summary>
                /// <typeparam name="V1">The type of the first indexer argument</typeparam>
                /// <typeparam name="V2">The type of the second indexer argument</typeparam>
                /// <typeparam name="V3">The type of the third indexer argument</typeparam>
                /// <typeparam name="V4">The type of the fourth indexer argument</typeparam>
                /// <typeparam name="V5">The type of the fifth indexer argument</typeparam>
                /// <typeparam name="V6">The type of the sixth indexer argument</typeparam>
                /// <typeparam name="V7">The type of the seventh indexer argument</typeparam>
                /// <typeparam name="V8">The type of the eighth indexer argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                {
                    /// <summary>Represents property-get (methods that return a value</summary>
                    public abstract class Getter
                        : DynamicBase<Func<T, VP, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Instance.Property<VP>.Getter
                    {
                    }

                    /// <summary>Represents property-set (methods that return nothing</summary>
                    public abstract class Setter
                        : DynamicBase<Proc<T, VP, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Instance.Property<VP>.Setter
                    {
                    }
                }
            }

            /// <summary>Represents procedures (methods that return nothing</summary>
            public abstract class Procedure
            {
                /// <summary>Represents Late-bound argument list (e.g. params object[]</summary>
                public class Params
                    : DynamicBase<ProcParams<T>>.Params.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (empty</summary>
                public class Explicit
                    : DynamicBase<Proc<T>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (one argument</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1>
                    : DynamicBase<Proc<T, V1>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (two arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2>
                    : DynamicBase<Proc<T, V1, V2>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (three arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3>
                    : DynamicBase<Proc<T, V1, V2, V3>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (four arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4>
                    : DynamicBase<Proc<T, V1, V2, V3, V4>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (five arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5>
                    : DynamicBase<Proc<T, V1, V2, V3, V4, V5>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (six arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6>
                    : DynamicBase<Proc<T, V1, V2, V3, V4, V5, V6>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (seven arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                    : DynamicBase<Proc<T, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (eight arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                    : DynamicBase<Proc<T, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Instance.Procedure
                {
                }

                /// <summary>Represents methods that take known-typed argument list (nine arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <typeparam name="V9">The type of the ninth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8, V9>
                    : DynamicBase<Proc<T, V1, V2, V3, V4, V5, V6, V7, V8, V9>>.Explicit.Instance.Procedure
                {
                }
            }

            /// <summary>Represents functions (methods that return a value</summary>
            /// <typeparam name="TRet">The type of the return value</typeparam>
            public abstract class Function<TRet>
            {
                /// <summary>Represents Late-bound argument list (e.g. params object[]</summary>
                public class Params
                    : DynamicBase<FuncParams<T, TRet>>.Params.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods with no argument</summary>
                public class Explicit
                    : DynamicBase<Func<T, TRet>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (one argument</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1>
                    : DynamicBase<Func<T, TRet, V1>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (two arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2>
                    : DynamicBase<Func<T, TRet, V1, V2>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (three arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3>
                    : DynamicBase<Func<T, TRet, V1, V2, V3>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (four arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4>
                    : DynamicBase<Func<T, TRet, V1, V2, V3, V4>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (five arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5>
                    : DynamicBase<Func<T, TRet, V1, V2, V3, V4, V5>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (six arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6>
                    : DynamicBase<Func<T, TRet, V1, V2, V3, V4, V5, V6>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (seven arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7>
                    : DynamicBase<Func<T, TRet, V1, V2, V3, V4, V5, V6, V7>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (eight arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8>
                    : DynamicBase<Func<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8>>.Explicit.Instance.Function<TRet>
                {
                }

                /// <summary>Represents methods that take known-typed argument list (nine arguments</summary>
                /// <typeparam name="V1">The type of the first argument</typeparam>
                /// <typeparam name="V2">The type of the second argument</typeparam>
                /// <typeparam name="V3">The type of the third argument</typeparam>
                /// <typeparam name="V4">The type of the fourth argument</typeparam>
                /// <typeparam name="V5">The type of the fifth argument</typeparam>
                /// <typeparam name="V6">The type of the sixth argument</typeparam>
                /// <typeparam name="V7">The type of the seventh argument</typeparam>
                /// <typeparam name="V8">The type of the eighth argument</typeparam>
                /// <typeparam name="V9">The type of the ninth argument</typeparam>
                /// <remarks>
                /// Argument types must be compatible, but need not exactly match the actual
                /// method. This means that if the method takes an argument of type object,
                /// it is legal to define the dynamic delegate as something more type-specific
                /// </remarks>
                public class Explicit<V1, V2, V3, V4, V5, V6, V7, V8, V9>
                    : DynamicBase<Func<T, TRet, V1, V2, V3, V4, V5, V6, V7, V8, V9>>.Explicit.Instance.Function<TRet>
                {
                }
            }
        }

        /// <summary>Über Base class for all Dynamic classes, this class holds all the code generation and is 
        /// specialized and JITted against the delegate signature</summary>
        /// <typeparam name="D">The delegate type that we call-through</typeparam>
        public abstract class DynamicBase<D> where D : class
        {
            #region Internal constants
            private const BindingFlags DefaultFlags = BindingFlags.Public | BindingFlags.NonPublic;
            protected const BindingFlags StaticFlags = DefaultFlags | BindingFlags.Static;
            protected const BindingFlags InstanceFlags = DefaultFlags | BindingFlags.Instance;
            #endregion

            // emit the sequence to load the "this"
            private static void EmitLoadThis(DynamicEmit de, MemberInfo memberInfo)
            {
                de.LoadArgument(typeof(T).IsValueType, 0);  // get the "this" pointer we were passed

                // if we can't directly (assume/assign), then do an explicit cast.
                if (memberInfo.DeclaringType != null && !memberInfo.DeclaringType.IsAssignableFrom(typeof(T)))
                {
                    de.CastTo(typeof(T), memberInfo.DeclaringType);
                }
            }

            // emit sequence to get a field
            private static void EmitGetField(DynamicEmit de, FieldInfo fieldInfo, Type memberType)
            {
                de.LoadField(fieldInfo);
                de.CastTo(fieldInfo.FieldType, memberType);
            }

            // emit sequence to set a field
            private static void EmitSetField(DynamicEmit de, int argumentOffset, FieldInfo fieldInfo, Type knownArgumentType)
            {
                // emit code to convert the weak-typed boxed argument we were given to the
                // correctly-typed value, which we can then pass to the real method...
                de.LoadArgument(argumentOffset);

                if (knownArgumentType == null)
                {
                    de.LoadLiteral(0);
                    de.LoadElementReference();
                    de.CastTo(fieldInfo.FieldType);
                }
                else
                {
                    de.CastTo(knownArgumentType, fieldInfo.FieldType);
                }

                de.StoreField(fieldInfo);
            }

            public abstract class Params
            {
                #region Builders
                // helpers
                // emit an argument count check
                protected static void EmitArgumentCountCheck(DynamicEmit de, int argumentOffset, int parameterLength, string methodName)
                {
                    // check to see if the call has the required amount of arguments in the object[] array.
                    de.LoadType<T>();
                    de.LoadLiteral(methodName);
                    de.LoadLiteral(parameterLength);    // expected parameter length
                    de.LoadArgument(argumentOffset);
                    de.LoadArrayLength();
                    de.Convert<int>();                  // actual parameters supplied length
                    de.Call(ParameterCountMismatchException.CheckAndThrowMethodInfo);
                }

                // emit code to convert the weak-typed boxed arguments we were given to the
                // correctly-typed local values, which we can then pass to the real method...
                private static LocalBuilder[] EmitCoerceArguments(DynamicEmit de, int argumentOffset, ParameterInfo[] parameterInfos)
                {
                    LocalBuilder[] locals = new LocalBuilder[parameterInfos.Length];
                    for (int i = 0; i < locals.Length; i++)
                    {
                        Type parameterType = parameterInfos[i].ParameterType;
                        de.LoadArgument(argumentOffset);
                        de.LoadLiteral(i);
                        de.LoadElementReference();
                        de.CastTo(parameterType);
                        locals[i] = de.DeclareLocal(parameterType);
                        de.StoreLocal(locals[i].LocalIndex);
                    }
                    return locals;
                }

                // emit both a check of the argument count and coercion of the arguments to matching types
                private static LocalBuilder[] EmitArgumentCheckAndCoerce(DynamicEmit de, int argumentOffset, ParameterInfo[] parameterInfos, MemberInfo member)
                {
                    EmitArgumentCountCheck(de, argumentOffset, parameterInfos.Length, member.Name);
                    return EmitCoerceArguments(de, argumentOffset, parameterInfos);
                }

                // For constructors
                protected static D Build(ConstructorInfo constructorInfo)
                {
                    if (constructorInfo == null)
                        throw new ArgumentNullException("constructorInfo");

                    Type[] argumentTypes = new Type[] { typeof(object[]) };

                    DynamicMethod dm = new DynamicMethod(constructorInfo.Name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard
                                                        , typeof(T), argumentTypes, typeof(T), true);
                    dm.InitLocals = true;
                    DynamicEmit de = new DynamicEmit(dm);

                    ParameterInfo[] parameterInfos = constructorInfo.GetParameters();
                    LocalBuilder[] locals = EmitArgumentCheckAndCoerce(de, 0, parameterInfos, constructorInfo);

                    // now build up the call stack...
                    for (int i = 0; i < locals.Length; i++)
                    {
                        de.LoadLocal(locals[i].LocalIndex); // get all of the now-correctly-typed arguments
                    }

                    de.Call(constructorInfo);

                    de.Return();
                    return dm.CreateDelegate(typeof(D)) as D;
                }

                // For fields
                protected static D Build(Type memberType, FieldInfo fieldInfo, bool wantGet)
                {
                    if (memberType == null)
                        throw new ArgumentNullException("memberType");

                    if (fieldInfo == null)
                        throw new ArgumentNullException("fieldInfo");

                    if (memberType != typeof(void) && !memberType.IsAssignableFrom(fieldInfo.FieldType))
                        throw new NotSupportedException(string.Format("{0} cannot be assigned from actual  type {1} of field {2}.{3}"
                                                        , memberType, fieldInfo.FieldType, typeof(T), fieldInfo.Name));

                    int argumentOffset = fieldInfo.IsStatic ? 0 : 1;
                    Type[] argumentTypes = fieldInfo.IsStatic ? new Type[] { typeof(object[]) } : new Type[] { typeof(T), typeof(object[]) };

                    DynamicMethod dm = new DynamicMethod(fieldInfo.Name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard
                                                        , memberType, argumentTypes, typeof(T), true);
                    dm.InitLocals = !wantGet;
                    DynamicEmit de = new DynamicEmit(dm);

                    int parameterLength = wantGet ? 0 : 1;

                    EmitArgumentCountCheck(de, argumentOffset, parameterLength, fieldInfo.Name);

                    // now build up the call stack...
                    if (!fieldInfo.IsStatic)
                    {
                        EmitLoadThis(de, fieldInfo);
                    }

                    if (wantGet)
                        EmitGetField(de, fieldInfo, memberType);
                    else
                        EmitSetField(de, argumentOffset, fieldInfo, null);

                    de.Return();
                    return dm.CreateDelegate(typeof(D)) as D;
                }

                // For methods
                protected static D Build(Type returnType, MethodInfo methodInfo)
                {
                    if (returnType == null)
                        throw new ArgumentNullException("returnType");

                    if (methodInfo == null)
                        throw new ArgumentNullException("methodInfo");

                    if (returnType != typeof(void) && !returnType.IsAssignableFrom(methodInfo.ReturnType))
                        throw new NotSupportedException(string.Format("{0} cannot be assigned from actual return type {1} of method {2}.{3}"
                                                        , returnType, methodInfo.ReturnType, typeof(T), methodInfo.Name));

                    int argumentOffset = methodInfo.IsStatic ? 0 : 1;
                    Type[] argumentTypes = methodInfo.IsStatic ? new Type[] { typeof(object[]) } : new Type[] { typeof(T), typeof(object[]) };

                    DynamicMethod dm = new DynamicMethod(methodInfo.Name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard
                                                        , returnType, argumentTypes, typeof(T), true);
                    dm.InitLocals = true;
                    DynamicEmit de = new DynamicEmit(dm);

                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    LocalBuilder[] locals = EmitArgumentCheckAndCoerce(de, argumentOffset, parameterInfos, methodInfo);

                    // now build up the call stack...
                    if (!methodInfo.IsStatic)
                    {
                        EmitLoadThis(de, methodInfo);
                    }

                    for (int i = 0; i < locals.Length; i++)
                    {
                        de.LoadLocal(locals[i].LocalIndex); // get all of the now-correctly-typed arguments
                    }

                    de.Call(methodInfo);
                    de.CastTo(methodInfo.ReturnType, returnType);

                    de.Return();
                    return dm.CreateDelegate(typeof(D)) as D;
                }
                #endregion

                public abstract class Constructor
                {
                    public static D CreateDelegate(ConstructorInfo constructorInfo)
                    {
                        return Build(constructorInfo);
                    }

                    public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                    {
                        ConstructorInfo constructorInfo = (ConstructorInfo)ConstructorInfo.GetMethodFromHandle(methodHandle);
                        return CreateDelegate(constructorInfo);
                    }

                    public static D CreateDelegate()
                    {
                        return CreateDelegate(typeof(T).GetConstructor(InstanceFlags, null, Type.EmptyTypes, null));
                    }

                    public static D CreateDelegate(Type[] parameterTypes)
                    {
                        return CreateDelegate(typeof(T).GetConstructor(InstanceFlags, null, parameterTypes, null));
                    }
                }

                public abstract class Static
                {
                    public abstract class Field
                    {
                        public abstract class Getter<TRet>
                        {
                            // okay, for a static field Get, the delegate looks like this
                            // StaticFunc<T, TRet> so ignore the generic types entirely
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(TRet), fieldInfo, true);
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, StaticFlags | BindingFlags.GetField));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for a static field Set, the delegate looks like this
                            // StaticProc<T, params object[]>
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(void), fieldInfo, false);
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, StaticFlags | BindingFlags.SetField));
                            }
                        }
                    }

                    public abstract class Property
                    {
                        public abstract class Getter<TRet>
                        {
                            // okay, for a static property Get, the delegate looks like this
                            // StaticFuncParams<T, TRet, params object[]> so ignore the generic types entirely
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(TRet), propertyInfo.GetGetMethod(true));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.GetProperty));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.GetProperty
                                                                            , null, typeof(TRet), parameterTypes, null));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for a static property Set, the delegate looks like this
                            // StaticProcParams<T, params object[]>
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(void), propertyInfo.GetSetMethod(true));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.SetProperty));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.SetProperty
                                                                            , null, typeof(void), parameterTypes, null));
                            }
                        }
                    }

                    public abstract class Procedure
                    {
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(void), methodInfo);
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags, null, parameterTypes, null));
                        }
                    }

                    public abstract class Function<TRet>
                    {
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(TRet), methodInfo);
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags, null, parameterTypes, null));
                        }
                    }
                }

                public abstract class Instance
                {
                    public abstract class Field<VF>
                    {
                        public abstract class Getter
                        {
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(VF), fieldInfo, true);
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, InstanceFlags | BindingFlags.GetField));
                            }
                        }

                        public abstract class Setter
                        {
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(void), fieldInfo, false);
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, InstanceFlags | BindingFlags.SetField));
                            }
                        }
                    }

                    public abstract class Property<VP>
                    {
                        public abstract class Getter
                        {
                            // okay, for an instance property Get, the delegate looks like this
                            // FuncParams<T, TRet, params object[]> so ignore the generic types entirely
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(VP), propertyInfo.GetGetMethod(true));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.GetProperty));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.GetProperty
                                                                            , null, typeof(VP), parameterTypes, null));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for an instance property Set, the delegate looks like this
                            // ProcParams<T, params object[]>
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(void), propertyInfo.GetSetMethod(true));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.SetProperty));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.SetProperty
                                                                            , null, typeof(void), parameterTypes, null));
                            }
                        }
                    }

                    public abstract class Procedure
                    {
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(void), methodInfo);
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags, null, parameterTypes, null));
                        }
                    }

                    public abstract class Function<TRet>
                    {
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(TRet), methodInfo);
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags, null, parameterTypes, null));
                        }
                    }
                }
            }

            public abstract class Explicit
            {
                #region Builders
                // For constructors
                protected static D Build(ConstructorInfo constructorInfo, Type[] knownArgumentTypes)
                {
                    if (constructorInfo == null)
                        throw new ArgumentNullException("constructorInfo");

                    if (knownArgumentTypes == null)
                        throw new ArgumentNullException("argumentTypes");

                    ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

                    if (parameterInfos.Length != knownArgumentTypes.Length)
                        throw new ParameterCountMismatchException(typeof(T), constructorInfo.Name, parameterInfos.Length, knownArgumentTypes.Length);

                    DynamicMethod dm = new DynamicMethod(constructorInfo.Name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard
                                                        , typeof(T), knownArgumentTypes, typeof(T), true);
                    dm.InitLocals = false; // we have no locals
                    DynamicEmit de = new DynamicEmit(dm);

                    for (int i = 0; i < parameterInfos.Length; i++)
                    {
                        de.LoadArgument(i);
                        de.CastTo(knownArgumentTypes[i], parameterInfos[i].ParameterType);
                    }

                    de.Call(constructorInfo);

                    de.Return();
                    return dm.CreateDelegate(typeof(D)) as D;
                }

                // For fields
                protected static D Build(Type memberType, FieldInfo fieldInfo, bool wantGet, Type[] knownArgumentTypes)
                {
                    if (memberType == null)
                        throw new ArgumentNullException("memberType");

                    if (fieldInfo == null)
                        throw new ArgumentNullException("fieldInfo");

                    if (knownArgumentTypes == null)
                        throw new ArgumentNullException("knownArgumentTypes");

                    if (memberType != typeof(void) && !memberType.IsAssignableFrom(fieldInfo.FieldType))
                        throw new NotSupportedException(string.Format("{0} cannot be assigned from actual type {1} of field {2}.{3}"
                                                        , memberType, fieldInfo.FieldType, typeof(T), fieldInfo.Name));

                    int argumentOffset = fieldInfo.IsStatic ? 0 : 1;
                    int argumentCount = (knownArgumentTypes.Length - argumentOffset);

                    int parameterLength = wantGet ? 0 : 1;

                    if (argumentCount != parameterLength)
                        throw new ParameterCountMismatchException(typeof(T), fieldInfo.Name, parameterLength, argumentCount);

                    DynamicMethod dm = new DynamicMethod(fieldInfo.Name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard
                                                        , memberType, knownArgumentTypes, typeof(T), true);
                    dm.InitLocals = false;
                    DynamicEmit de = new DynamicEmit(dm);

                    // now build up the call stack...
                    if (!fieldInfo.IsStatic)
                    {
                        EmitLoadThis(de, fieldInfo);
                    }

                    if (wantGet)
                        EmitGetField(de, fieldInfo, memberType);
                    else
                        EmitSetField(de, argumentOffset, fieldInfo, knownArgumentTypes[argumentOffset]);

                    de.Return();
                    return dm.CreateDelegate(typeof(D)) as D;
                }

                // For methods
                protected static D Build(Type returnType, MethodInfo methodInfo, Type[] knownArgumentTypes)
                {
                    if (returnType == null)
                        throw new ArgumentNullException("returnType");

                    if (methodInfo == null)
                        throw new ArgumentNullException("methodInfo");

                    if (knownArgumentTypes == null)
                        throw new ArgumentNullException("argumentTypes");

                    if (returnType != typeof(void) && !returnType.IsAssignableFrom(methodInfo.ReturnType))
                        throw new NotSupportedException(string.Format("{0} cannot be assigned from actual return type {1} of method {2}.{3}"
                                                        , returnType, methodInfo.ReturnType, typeof(T), methodInfo.Name));

                    int argumentOffset = methodInfo.IsStatic ? 0 : 1;
                    int argumentCount = (knownArgumentTypes.Length - argumentOffset);

                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();

                    if (argumentCount != parameterInfos.Length)
                        throw new ParameterCountMismatchException(typeof(T), methodInfo.Name, parameterInfos.Length, argumentCount);

                    DynamicMethod dm = new DynamicMethod(methodInfo.Name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard
                                                        , returnType, knownArgumentTypes, typeof(T), true);
                    dm.InitLocals = false; // we have no locals
                    DynamicEmit de = new DynamicEmit(dm);

                    // now build up call stack...
                    if (!methodInfo.IsStatic)
                    {
                        EmitLoadThis(de, methodInfo);
                    }

                    for (int i = 0; i < parameterInfos.Length; i++)
                    {
                        de.LoadArgument(i + argumentOffset);
                        de.CastTo(knownArgumentTypes[i + argumentOffset], parameterInfos[i].ParameterType);
                    }

                    de.Call(methodInfo);
                    de.CastTo(methodInfo.ReturnType, returnType);

                    de.Return();
                    return dm.CreateDelegate(typeof(D)) as D;
                }

                private static Type[] KnownArgumentTypes(int discardFirstCount)
                {
                    return KnownArgumentTypes(0, discardFirstCount);
                }

                private static Type[] KnownArgumentTypes(int discardFirst, int discardCount)
                {
                    Type[] delegateTypes = typeof(D).GetGenericArguments();

                    // if we're a no-operation, just return...
                    if (discardCount == 0)
                        return delegateTypes;

                    Type[] knownArgumentTypes = new Type[delegateTypes.Length - discardCount];

                    // If there are some following the slice-out segment, grab them
                    if (discardFirst + discardCount <= delegateTypes.Length)
                        Array.Copy(delegateTypes, discardFirst + discardCount, knownArgumentTypes, discardFirst, knownArgumentTypes.Length - discardFirst);

                    // If there are some before the slice-out segment, grab them
                    if (discardFirst > 0)
                        Array.Copy(delegateTypes, 0, knownArgumentTypes, 0, discardFirst);

                    return knownArgumentTypes;
                }
                #endregion

                public abstract class Constructor
                {
                    // okay, a constructor looks like a static function returning T, the delegate looks like this
                    // Constructor<T, V1 arg1, V2 arg2, ...) so ignore the first one...
                    public static D CreateDelegate(ConstructorInfo constructorInfo)
                    {
                        return Build(constructorInfo, KnownArgumentTypes(1));
                    }

                    public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                    {
                        ConstructorInfo constructorInfo = (ConstructorInfo)ConstructorInfo.GetMethodFromHandle(methodHandle);
                        return CreateDelegate(constructorInfo);
                    }

                    public static D CreateDelegate()
                    {
                        return CreateDelegate(typeof(T).GetConstructor(InstanceFlags, null, Type.EmptyTypes, null));
                    }

                    public static D CreateDelegate(ParameterList flag)
                    {
                        // we must also strip the T to match the actual method...
                        return CreateDelegate(KnownArgumentTypes(1));
                    }

                    public static D CreateDelegate(Type[] parameterTypes)
                    {
                        return CreateDelegate(typeof(T).GetConstructor(InstanceFlags, null, parameterTypes, null));
                    }
                }

                public abstract class Static
                {
                    public abstract class Field<VF>
                    {
                        public abstract class Getter
                        {
                            // okay, for a static field Get, the delegate looks like this
                            // StaticFunc<T, TRet> so ignore the generic types entirely
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(VF), fieldInfo, true, Type.EmptyTypes);
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, StaticFlags | BindingFlags.GetField));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for a static field Set, the delegate looks like this
                            // StaticProc<T, VF arg1> so pass just the field type VF...
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(void), fieldInfo, false, new Type[] { typeof(VF) });
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, StaticFlags | BindingFlags.SetField));
                            }
                        }
                    }

                    public abstract class Property<VP>
                    {
                        public abstract class Getter
                        {
                            // okay, for a static property Get, the delegate looks like this
                            // StaticFunc<T, VP, V1, ...> so ignore the T and VP
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(VP), propertyInfo.GetGetMethod(true), KnownArgumentTypes(2));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.GetProperty));
                            }

                            public static D CreateDelegate(string propertyName, ParameterList flag)
                            {
                                // we must also strip the "this" pointer to match the actual property...
                                return CreateDelegate(propertyName, KnownArgumentTypes(2));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.GetProperty
                                                                            , null, typeof(VP), parameterTypes, null));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for a static property Set, the delegate looks like this
                            // StaticProc<T, VP arg1, V1 arg2 ...> so ignore the T
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(void), propertyInfo.GetSetMethod(true), KnownArgumentTypes(1));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.SetProperty));
                            }

                            public static D CreateDelegate(string propertyName, ParameterList flag)
                            {
                                // we must strip the "this" pointer to match the actual method...
                                return CreateDelegate(propertyName, KnownArgumentTypes(1));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, StaticFlags | BindingFlags.SetProperty
                                                                            , null, typeof(void), parameterTypes, null));
                            }
                        }
                    }

                    public abstract class Procedure
                    {
                        // okay, for a static procedure, the delegate looks like this
                        // StaticProc<T, V1 arg1, V2 arg2, ...) so ignore the first one...
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(void), methodInfo, KnownArgumentTypes(1));
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags));
                        }

                        public static D CreateDelegate(string methodName, ParameterList flag)
                        {
                            // since this is a static method, we do NOT have an additional "this" to strip to match the actual method...
                            return CreateDelegate(methodName, KnownArgumentTypes(1));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags, null, parameterTypes, null));
                        }
                    }

                    public abstract class Function<TRet>
                    {
                        // okay, for a static function, the delegate looks like this
                        // StaticFunc<T, TRet, V1 arg1, V2 arg2, ...) so ignore the first two...
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(TRet), methodInfo, KnownArgumentTypes(2));
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags));
                        }

                        public static D CreateDelegate(string methodName, ParameterList flag)
                        {
                            // since this is a static method, we do NOT have an additional "this" to strip to match the actual method...
                            return CreateDelegate(methodName, KnownArgumentTypes(2));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, StaticFlags, null, parameterTypes, null));
                        }
                    }
                }

                public abstract class Instance
                {
                    public abstract class Field<VF>
                    {
                        public abstract class Getter
                        {
                            // okay, for an instance field Get, the delegate looks like this
                            // Func<T, VF> so ignore the generic types entirely
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(VF), fieldInfo, true, new Type[] { typeof(T) });
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, InstanceFlags | BindingFlags.GetField));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for an instance field Set, the delegate looks like this
                            // Proc<T, VF arg1> so pass just the known type...
                            public static D CreateDelegate(FieldInfo fieldInfo)
                            {
                                return Build(typeof(void), fieldInfo, false, new Type[] { typeof(T), typeof(VF) });
                            }

                            public static D CreateDelegate(RuntimeFieldHandle fieldHandle)
                            {
                                FieldInfo fieldInfo = (FieldInfo)FieldInfo.GetFieldFromHandle(fieldHandle);
                                return CreateDelegate(fieldInfo);
                            }

                            public static D CreateDelegate(string fieldName)
                            {
                                return CreateDelegate(typeof(T).GetField(fieldName, InstanceFlags | BindingFlags.SetField));
                            }
                        }
                    }

                    public abstract class Property<VP>
                    {
                        public abstract class Getter
                        {
                            // okay, for an instance property Get, the delegate looks like this
                            // Func<T, TRet, V1, ...> so ignore the TRet
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(VP), propertyInfo.GetGetMethod(true), KnownArgumentTypes(1, 1));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.GetProperty));
                            }

                            public static D CreateDelegate(string propertyName, ParameterList flag)
                            {
                                // we must also strip the "this" pointer to match the actual property...
                                return CreateDelegate(propertyName, KnownArgumentTypes(2));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.GetProperty
                                                                            , null, typeof(VP), parameterTypes, null));
                            }
                        }

                        public abstract class Setter
                        {
                            // okay, for an instance property Set, the delegate looks like this
                            // Proc<T, V1 arg1, V2 arg2 ...> so we want everything
                            public static D CreateDelegate(PropertyInfo propertyInfo)
                            {
                                if (propertyInfo == null)
                                    throw new ArgumentNullException("propertyInfo");

                                return Build(typeof(void), propertyInfo.GetSetMethod(true), KnownArgumentTypes(0));
                            }

                            public static D CreateDelegate(string propertyName)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.SetProperty));
                            }

                            public static D CreateDelegate(string propertyName, ParameterList flag)
                            {
                                // we must strip the "this" pointer to match the actual method...
                                return CreateDelegate(propertyName, KnownArgumentTypes(1));
                            }

                            public static D CreateDelegate(string propertyName, Type[] parameterTypes)
                            {
                                return CreateDelegate(typeof(T).GetProperty(propertyName, InstanceFlags | BindingFlags.SetProperty
                                                                            , null, typeof(void), parameterTypes, null));
                            }
                        }
                    }

                    public abstract class Procedure
                    {
                        // okay, for an instance procedure, the delegate looks like this
                        // Proc<T, V1 arg1, V2 arg2, ...) so we want everything...
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(void), methodInfo, KnownArgumentTypes(0));
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags));
                        }

                        public static D CreateDelegate(string methodName, ParameterList flag)
                        {
                            // we must strip the "this" pointer to match the actual method...
                            return CreateDelegate(methodName, KnownArgumentTypes(1));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags, null, parameterTypes, null));
                        }
                    }

                    public abstract class Function<TRet>
                    {
                        // okay, for an instance function, the delegate looks like this
                        // Func<T, TRet, V1 arg1, V2 arg2, ...) so we want everything except the TRet...
                        public static D CreateDelegate(MethodInfo methodInfo)
                        {
                            return Build(typeof(TRet), methodInfo, KnownArgumentTypes(1, 1));
                        }

                        public static D CreateDelegate(RuntimeMethodHandle methodHandle)
                        {
                            MethodInfo methodInfo = (MethodInfo)MethodInfo.GetMethodFromHandle(methodHandle);
                            return CreateDelegate(methodInfo);
                        }

                        public static D CreateDelegate(string methodName)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags));
                        }

                        public static D CreateDelegate(string methodName, ParameterList flag)
                        {
                            // we must also strip the "this" pointer to match the actual method...
                            return CreateDelegate(methodName, KnownArgumentTypes(2));
                        }

                        public static D CreateDelegate(string methodName, Type[] parameterTypes)
                        {
                            return CreateDelegate(typeof(T).GetMethod(methodName, InstanceFlags, null, parameterTypes, null));
                        }
                    }
                }
            }
        }
    }
}