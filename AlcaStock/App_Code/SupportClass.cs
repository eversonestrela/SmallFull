using System;

/// <summary>
/// Contains conversion support elements such as classes, interfaces and static methods.
/// </summary>
public class SupportClass
{
    /// <summary>
    /// This class has static methods to manage collections.
    /// </summary>
    public class CollectionsSupport
    {
        /// <summary>
        /// Copies the IList to other IList.
        /// </summary>
        /// <param name="SourceList">IList source.</param>
        /// <param name="TargetList">IList target.</param>
        public static void Copy(System.Collections.IList SourceList, System.Collections.IList TargetList)
        {
            for (int i = 0; i < SourceList.Count; i++)
                TargetList[i] = SourceList[i];
        }

        /// <summary>
        /// Replaces the elements of the specified list with the specified element.
        /// </summary>
        /// <param name="List">The list to be filled with the specified element.</param>
        /// <param name="Element">The element with which to fill the specified list.</param>
        public static void Fill(System.Collections.IList List, System.Object Element)
        {
            for (int i = 0; i < List.Count; i++)
                List[i] = Element;
        }

        /// <summary>
        /// This class implements System.Collections.IComparer and is used for Comparing two String objects by evaluating 
        /// the numeric values of the corresponding Char objects in each string.
        /// </summary>
        class CompareCharValues : System.Collections.IComparer
        {
            public int Compare(System.Object x, System.Object y)
            {
                return System.String.CompareOrdinal((System.String)x, (System.String)y);
            }
        }

        /// <summary>
        /// Obtain the maximum element of the given collection with the specified comparator.
        /// </summary>
        /// <param name="Collection">Collection from which the maximum value will be obtained.</param>
        /// <param name="Comparator">The comparator with which to determine the maximum element.</param>
        /// <returns></returns>
        public static System.Object Max(System.Collections.ICollection Collection, System.Collections.IComparer Comparator)
        {
            System.Collections.ArrayList tempArrayList;

            if (((System.Collections.ArrayList)Collection).IsReadOnly)
                throw new System.NotSupportedException();

            if ((Comparator == null) || (Comparator is System.Collections.Comparer))
            {
                try
                {
                    tempArrayList = new System.Collections.ArrayList(Collection);
                    tempArrayList.Sort();
                }
                catch (System.InvalidOperationException e)
                {
                    throw new System.InvalidCastException(e.Message);
                }
                return (System.Object)tempArrayList[Collection.Count - 1];
            }
            else
            {
                try
                {
                    tempArrayList = new System.Collections.ArrayList(Collection);
                    tempArrayList.Sort(Comparator);
                }
                catch (System.InvalidOperationException e)
                {
                    throw new System.InvalidCastException(e.Message);
                }
                return (System.Object)tempArrayList[Collection.Count - 1];
            }
        }

        /// <summary>
        /// Obtain the minimum element of the given collection with the specified comparator.
        /// </summary>
        /// <param name="Collection">Collection from which the minimum value will be obtained.</param>
        /// <param name="Comparator">The comparator with which to determine the minimum element.</param>
        /// <returns></returns>
        public static System.Object Min(System.Collections.ICollection Collection, System.Collections.IComparer Comparator)
        {
            System.Collections.ArrayList tempArrayList;

            if (((System.Collections.ArrayList)Collection).IsReadOnly)
                throw new System.NotSupportedException();

            if ((Comparator == null) || (Comparator is System.Collections.Comparer))
            {
                try
                {
                    tempArrayList = new System.Collections.ArrayList(Collection);
                    tempArrayList.Sort();
                }
                catch (System.InvalidOperationException e)
                {
                    throw new System.InvalidCastException(e.Message);
                }
                return (System.Object)tempArrayList[0];
            }
            else
            {
                try
                {
                    tempArrayList = new System.Collections.ArrayList(Collection);
                    tempArrayList.Sort(Comparator);
                }
                catch (System.InvalidOperationException e)
                {
                    throw new System.InvalidCastException(e.Message);
                }
                return (System.Object)tempArrayList[0];
            }
        }

        /// <summary>
        /// Sorts an IList collections
        /// </summary>
        /// <param name="list">The System.Collections.IList instance that will be sorted</param>
        /// <param name="Comparator">The Comparator criteria, null to use natural comparator.</param>
        public static void Sort(System.Collections.IList list, System.Collections.IComparer Comparator)
        {
            if (((System.Collections.ArrayList)list).IsReadOnly)
                throw new System.NotSupportedException();

            if ((Comparator == null) || (Comparator is System.Collections.Comparer))
            {
                try
                {
                    ((System.Collections.ArrayList)list).Sort();
                }
                catch (System.InvalidOperationException e)
                {
                    throw new System.InvalidCastException(e.Message);
                }
            }
            else
            {
                try
                {
                    ((System.Collections.ArrayList)list).Sort(Comparator);
                }
                catch (System.InvalidOperationException e)
                {
                    throw new System.InvalidCastException(e.Message);
                }
            }
        }

        /// <summary>
        /// Shuffles the list randomly.
        /// </summary>
        /// <param name="List">The list to be shuffled.</param>
        public static void Shuffle(System.Collections.IList List)
        {
            System.Random RandomList = new System.Random(unchecked((int)System.DateTime.Now.Ticks));
            Shuffle(List, RandomList);
        }

        /// <summary>
        /// Shuffles the list randomly.
        /// </summary>
        /// <param name="List">The list to be shuffled.</param>
        /// <param name="RandomList">The random to use to shuffle the list.</param>
        public static void Shuffle(System.Collections.IList List, System.Random RandomList)
        {
            System.Object source = null;
            int target = 0;

            for (int i = 0; i < List.Count; i++)
            {
                target = RandomList.Next(List.Count);
                source = (System.Object)List[i];
                List[i] = List[target];
                List[target] = source;
            }
        }
    }
}