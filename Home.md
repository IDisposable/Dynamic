[News Feeds](News-Feeds)
**Dynamic Reflection Library**

The Dynamic Reflection Library is a small set of classes designed to greatly speed the use of .Net reflection to call constructors, member methods, property setters and getters including those with indexing arguments such as the Item (a.k.a. []() operator), and fields. 

The libary uses Lightweight Code Generation (LCG) to synthesize the minimum wrapper code to allow fully type-safe calls to arbitrary methods in any class through type-safe delgates. If appropriate runtime rights are available, these methods can even access private fields, methods and properties.

All members may be bound by name, or MemberInfo with optional automatic type coercision of the delegate's arguments to the called-method's argmuents. It also will do type-signature mapping to allow you to match a desired delegate signature and method name to the best-fit method.

Also included in this library is a DynamicCompare class, that generates a very-high performance IComparer method against any class for one or more fields/properties (with ascending/descending support). This allows you to generate the delegate to pass to Sort at runtime against a user-defined sort criteria and get near native speed.

**News**
* I fix them as you find them, current patches for classes derived from an abstract generic base class in the upcoming 2.5.1.0 release.
* Updated to release 2.5.0.0 which includes better XML documentation for the Dynamic class, code refactoring and elimination of duplicate code. At this point, I'm actually running 6% faster than native (C# compiled code)! 
* The first (CodePlex) production release 2.4.0.0 is now available on the Releases tab.
* Full current source is now available online on the Source Code tab.

**Frequently Asked Questions (FAQ)**

* What's the license?
	* In short it's Creative Commons 2.5 Attribution. The gist of which is that you can use this source any which way you want, but please leave the attribution of ownership in the sources.

* Why would I use this? 
## If you need to do binding of code to fields/proporties/methods in classes dynamically, but want full type-safety and excellent performance. This means that you can, with a 25% or less overhead, bind to methods using the method name (or MemberInfo). This compares using standard Reflection, which is typically 20x slower or worse.
## If you want to muck about in private members/methods of a sealed or poorly designed class that you don't have source for (e.g. to fix problems in a .Net framework class).
## If you don't have the ability to dictate an interface, but can dictate a (type-compatible) method signature.
## If you are allowing users to specify classes, methods or sort criteria at runtime or in configuration files.

* What does it support?
	* Binding to any class or struct (i.e. both reference types and value types) including proper Enum support.
	* Binding to any method
	* Binding to any property of any type,  including support for indexed properties with any number of arguments (up to 10)
	* Binding to any field of any type
	* Binding to public, protected or private (with appropriate reflection rights)
	* Handles implicit type coercision for arguments and return values (i.e. converting an Int16 to an Int32)
	* Does best-case matching against a specified argument list to find methods that are compatible with your expected call signature

* Project documentation
	* Check the DynamicSample console mode application, which show all the various ways you could do this stuff using plain old Reflection, CreateDelegate, explicit-type DynamicMethods and parameter-list based DynamicMethods.
	* Check the DynamicSampleWeb mini web application to see how trivial binding by a list of property names could be done.
	* Coming soon to the Wiki near you. In the meantime, check these blog posts
Dynamic method calls:
[http://musingmarc.blogspot.com/2006/07/power-of-generics-compels-you-power-of.html](http://musingmarc.blogspot.com/2006/07/power-of-generics-compels-you-power-of.html)
[http://musingmarc.blogspot.com/2006/07/updated-files-for-dynamic-method.html](http://musingmarc.blogspot.com/2006/07/updated-files-for-dynamic-method.html)
[http://musingmarc.blogspot.com/2006/07/things-to-remember-when-creating.html](http://musingmarc.blogspot.com/2006/07/things-to-remember-when-creating.html)
[http://musingmarc.blogspot.com/2006/08/how-to-do-late-dynamic-method-creation.html](http://musingmarc.blogspot.com/2006/08/how-to-do-late-dynamic-method-creation.html)

DynamicCompare:
[http://musingmarc.blogspot.com/2006/02/dynamic-sorting-of-objects-using.html](http://musingmarc.blogspot.com/2006/02/dynamic-sorting-of-objects-using.html)
[http://musingmarc.blogspot.com/2006/03/extending-dynamic-sorting-of-objects.html](http://musingmarc.blogspot.com/2006/03/extending-dynamic-sorting-of-objects.html)

Where it all started:
[http://www.codeproject.com/dotnet/dynamiclistsorting.asp](http://www.codeproject.com/dotnet/dynamiclistsorting.asp)
[http://msdn.microsoft.com/msdnmag/issues/05/07/Reflection/](http://msdn.microsoft.com/msdnmag/issues/05/07/Reflection/)

* Current issues
	* None reported