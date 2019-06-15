/* Disclaimer: The examples and comments from this program are from
   C#7 in a Nutshell and are written for learning purposes only. */
using System;

namespace Advanced_Properties
{
    public class Stock
    {

        decimal currentPrice, sharesOwned;           // The private "banking" field
        public decimal CurrentPrice     // The public property
        {
            // READ-ONLY AND CALCULATED PROPERTIES
            /* A property is read-only if it specifies only a get accessor, and it is
             write-only if it specifies only a set accessor. Write-only properties are
             rarely used.

             A property typically has a dedicated backing field to store the underlying
             data. However, a property can alse be computed from other data. For example: */
            get { return currentPrice * sharesOwned; }
        }
    }
    public class Stock1
    {
        decimal currentPrice, sharesOwned;
        // EXPRESSION-BODIED PROPERTIES (C#6, C#7)
        /*From C#6, you can declare a read-only property, such as the preceding example,
         more tersely as an expression-bodied property. A fat arrow replaces all the 
         braces and the get and return keywords: */
        public decimal Worth => currentPrice * sharesOwned;
    }
    public class Stock2
    {
        decimal currentPrice, sharesOwned;
        /* C#7 extends this further by allowing set accessors to be expression-bodied,
         with a little extra syntax: */
        public decimal Worth
        {
            get => currentPrice * sharesOwned;
            set => sharesOwned = value / currentPrice;
        }
}
    public class Stock3
    {
        // AUTOMATIC PROPERTIES
        /* The most common implementation for a property is a getter
         and/or setter that simply reads and writes to a private field
         of the same type as the property. An automatic property 
         declaration instructs the compiler to provide this implementation.
         We can improve the previous example by declaring CurrentPrice as 
         an automatic property: */
         public decimal CurrentPrice { get; set; }
        /* The compiler automatically generates a private backing field of
         a compiler-generated name that cannot be referred to. The set 
         accessor can be marked private or protected if you want to expose 
         the property as read-only to other types. Automatic properties 
         were introduced in C#3.0. */
    }

    public class Stock4
    {
        /* From C#6, you can add a property initializer to automatic 
          properties, just as with fields: */
        public decimal CurrentPrice { get; set; } = 123;
        /* This gives CurrentPrice an initial value of 123. Properties 
         with an initializer can be read-only: */
        public int Maximum { get; } = 999;
        /* Just as with read-only fields, read-only automatic properties
         can alse be assigned in the type's constructor. This is useful
         in creating immutable (read-only) types. */
    }
    // THE GET AND SET ACCESSIBILITY 
    /* The get and set accessors can have different access levels. The 
     typical use case for this is to have a public property with an
     internal or private access modifier on the setter: */
    public class Foo
    {
        private decimal x;
        public decimal X
        {
            get { return x; }
            private set { x = Math.Round(value, 2); }
            /* Notice that you declare the property itself with the
             more permissive access level (public, in this case), 
             and add the modifier to the accessor you want to be
             less accessible. */
        }
    }
    // CLR PROPERTY IMPLEMENTATION
    /* C# property accessors internally compile methods called get_XXX
     and set_XXX:

     public decimal get_CurrentPrice {...}
     public void set_CurrentPrice (decimal value) {...}
     
    Simple nonvirtual property accessors are inlined by the JIT
    (Just-In-Time) compiler, eliminating any performance difference
    between accessing a property and a field. Inlining is an 
    optimization in which a method call is replaced with the body of
    that method. With WinRT properties, the compiler assumes the put_XXX
    naming convention rather that set_XXX.
     */
}


