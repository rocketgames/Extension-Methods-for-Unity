using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

/* *****************************************************************************
 * File:    LINQEnumerableExtensions.cs
 * Author:  Philip Pierce - Thursday, September 18, 2014
 * Description:
 *  Extensions for LINQ Enumerable types
 *  
 * History:
 *  Thursday, September 18, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for LINQ Enumerable types
/// </summary>
public static class LINQEnumerableExtensions
{
    #region Generating sequences

    /*
    * 
    * In C# 2, generating arbitrary sequences became much more convenient than it 
    * used to be in C# 1. Instead of implementing two classes, the IEnumerable<T> and 
    * the IEnumerator<T>, you can implement a single method that yields items using 
    * the iterator block syntax (i.e. the yield statements).
    * 
    * However, I still try to avoid creating a method just to generate a simple 
    * sequence, particularly if I use that sequence only in one place in my program. 
    * The Generate operator below accepts a delegate which generates the sequence 
    * element by element. To signal the end of the sequence, the generator returns 
    * null.
    * 
    * Since value types cannot be null, we need one overload for reference types, 
    * and another overload that uses a nullable wrapper to handle value types:
    * 
    * public static IEnumerable<T> Generate<T>(Func<T> generator)    where T : class
    * 
    * public static IEnumerable<T> Generate<T>(Func<Nullable<T>> generator)    where T : struct
    * 
    * To give a usage example, the ReadLinesFromConsole operator I mentioned above 
    * could be implemented as follows:
    * 
    * public static IEnumerable<string> ReadLinesFromConsole()
    * {
    *      return ExtendedEnumerable.Generate(() => Console.ReadLine());
    * }
    * 
    * As another example, this code sample generates an infinite sequence of random 
    * integers:
    * 
    * Random rand = new Random();var randomSeq = ExtendedEnumerable.Generate(() => (int?)rand.Next());
    * 
    *  This Generate operator has two disadvantages. First, it cannot be used to 
    *  generate sequences that contain null values, because null is the terminator 
    *  of the sequence. Second, it is a bit annoying to have to use the cast in the 
    *  value-type overload (see the cast to int? in the random-sequence example). 
    *  These are minor disadvantages, though, and I much prefer using the Generate 
    *  operator over implementing a new method each time I need to generate a simple 
    *  sequence.        
    */

    /// <summary>
    /// Generate a sequence using the <paramref name="generator"/> to pop each item
    /// </summary>
    /// <typeparam name="T">type of object to generate</typeparam>
    /// <param name="generator">delegate to generate the object</param>
    public static IEnumerable<T> Generate<T>(Func<T> generator) where T : class
    {
        if (generator == null) throw new ArgumentNullException("generator");

        T t;
        while ((t = generator()) != null)
        {
            yield return t;
        }
    }

    /// <summary>
    /// Generate a nullable sequence using the <paramref name="generator"/> to pop each item
    /// </summary>
    /// <typeparam name="T">type of object to generate</typeparam>
    /// <param name="generator">delegate to generate the object</param>
    public static IEnumerable<T> Generate<T>(Func<T?> generator) where T : struct
    {
        if (generator == null) throw new ArgumentNullException("generator");

        T? t;
        while ((t = generator()).HasValue)
        {
            yield return t.Value;
        }
    }

    /// <summary>
    /// Creates an IEnumerable from an enumerator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerator"></param>
    public static IEnumerable<T> FromEnumerator<T>(IEnumerator<T> enumerator)
    {
        if (enumerator == null) throw new ArgumentNullException("enumerator");

        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }

    /// <summary>
    /// Returns an IEnumerable from a single item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    public static IEnumerable<T> Single<T>(T value)
    {
        return Enumerable.Repeat(value, 1);
    }

    /// <summary>
    /// Returns an IEnumerable from a single item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="count">number of times to repeat the value in the list</param>
    public static IEnumerable<T> Single<T>(T value, int count)
    {
        return Enumerable.Repeat(value, count);
    }

    // Generating sequences
    #endregion

    #region Do

    /*
         * 
         * Sometimes it is useful to add side-effects in the middle of query, rather 
         * than to the end. For example, we can log which elements have been processed 
         * at a particular stage of the query. The Do operator provides this 
         * functionality:
         * 
         * Enumerable.Range(0,10)
         * .Do((e) => Console.WriteLine("Processing {0}", e))
         * .Select(x => x*2).ToArray();
        */

    /// <summary>
    /// Executes the action in the middle of a query
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    public static IEnumerable<T> Do<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (action == null) throw new ArgumentNullException("action");

        foreach (T elem in source)
        {
            action(elem);
            yield return elem;
        }
    }

    // Do
    #endregion

    #region Combine

    /*
    * The Combine operator exists in various functional languages including F#, 
    * sometimes under the name Zip or ZipWith. It accepts two sequences as inputs, 
    * and combines their elements into a single sequence. So, the first element 
    * in sequence 1 and the first element in sequence 2 will be combined to 
    * produce the first element in the output sequence, and so forth. The function 
    * which combines an element from one sequence with an element from the other 
    * sequence is provided by the user. If one of the sequences is longer, the 
    * remaining elements in the longer sequence will be ignored.
    * 
    * To compute the pairwise sum between elements in seq1 and seq2, use the Combine 
    * operator like this:
    * 
    * IEnumerable<int> sumSeq = seq1.Combine(seq2, (a, b) => a + b);
    * 
    * As another example, to check whether a sequence of integers seq is increasing,
    * use this query:
    * 
    * bool isIncreasing = seq.Combine(seq.Skip(1), (a, b) => a < b).All(x => x);
    */

    /// <summary>
    /// Combines two sequences into one. The first element of sequence 1 and the
    /// first element of sequence 2 combine into a new element for the output
    /// sequence
    /// Ex. sumSeq = seq1.Combine(seq2, (a, b) => a + b);
    /// </summary>
    /// <typeparam name="TIn1"></typeparam>
    /// <typeparam name="TIn2"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <param name="in1"></param>
    /// <param name="in2"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static IEnumerable<TOut> Combine<TIn1, TIn2, TOut>(this IEnumerable<TIn1> in1, IEnumerable<TIn2> in2, Func<TIn1, TIn2, TOut> func)
    {
        if (in1 == null) throw new ArgumentNullException("in1");
        if (in2 == null) throw new ArgumentNullException("in2");
        if (func == null) throw new ArgumentNullException("func");

        using (var e1 = in1.GetEnumerator())
        {
            using (var e2 = in2.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return func(e1.Current, e2.Current);
                }
            }
        }
    }

    // Combine
    #endregion

    #region Shuffle

    /// <summary>
    /// Accepts a sequence and returns the same sequence, randomly rearranged.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(n => Guid.NewGuid());
    }

    // Shuffle
    #endregion

    #region Impliment_LINQ_IDisposible

    // http://solutionizing.net/2009/07/23/using-idisposables-with-linq/

    /// <summary>
    /// Handles disposing of LINQ objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <example>
    /// So how can this simple method solve all our problems? First up: “using” a 
    /// FileStream object created in a LINQ query:
    /// 
    /// var lengths = File.OpenRead(path).UseLINQDisposible().Select(x=> new { path, fs.Length });
    /// </example>
    /// <returns></returns>
    public static IEnumerable<T> UseLINQDisposible<T>(this T obj) where T : IDisposable
    {
        try
        {
            yield return obj;
        }
        finally
        {
            if (null != obj)
                obj.Dispose();
        }
    }

    // Impliment_LINQ_IDisposible
    #endregion

    #region DoWhile

    /// <summary>
    /// Performs a Do While loop on <paramref name="action"/>, using <paramref name="compareFunc"/> to determine the results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action">assignment action</param>
    /// <param name="compareFunc">compare function. when result is False, DoWhileAssignment will exit</param>
    public static IEnumerable<T> DoWhile<T>(this IEnumerable<T> source, Action<T> action, Func<bool> compareFunc)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (action == null) throw new ArgumentNullException("action");

        // loop through each and perform the do while
        foreach (T elem in source)
        {
            do
            {
                // perform action
                action(elem);

            } while (compareFunc()); 

            // return result
            yield return elem;
        }
    }

    // DoWhile
    #endregion

    #region Distinct

    /// <summary>
    /// Provides a Distinct method that takes a key selector lambda as parameter. The .net framework only provides a 
    /// Distinct method that takes an instance of an implementation of IEqualityCompare T where the standard 
    /// parameterless Distinct that uses the default equality comparer doesn't suffice.
    /// </summary>
    /// <remarks>http://extensionmethod.net/csharp/ienumerable-t/distinct</remarks>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="this"></param>
    /// <param name="keySelector"></param>
    /// <returns></returns>
    public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
    {
        return @this.GroupBy(keySelector).Select(grps => grps).Select(e => e.First());
    }

    // Distinct
    #endregion

    #region TakeUntil

    /// <summary>
    /// Continues processing items in a collection until the end condition is true.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="collection">The collection to iterate.</param>
    /// <param name="endCondition">The condition that returns true if iteration should stop.</param>
    /// <returns>Iterator of sub-list.</returns>
    /// <remarks>http://extensionmethod.net/csharp/ienumerable-t/takeuntil</remarks>
    public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> endCondition)
    {
        return collection.TakeWhile(item => !endCondition(item));
    }

    // TakeUntil
    #endregion
}