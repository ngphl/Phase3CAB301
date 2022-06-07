//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }




    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection
    public void Add(IMember member)
    {
        // To be implemented by students in Phase 1
        if (!IsFull())
        {

            if (count > 0)
            {
                if (Search(member) == true)
                {
                    Console.WriteLine("{0} has been used by other member", member.ToString());
                }
                else
                {
                    int pos = count - 1; //initially the value of pos is the index of the last element in the array
                    while ((pos >= 0) && members[pos].CompareTo((Member)member) > 0)
                    {
                        members[pos + 1] = members[pos];
                        pos--;
                    }
                    members[pos + 1] = (Member)member;
                    count++;
                    Console.WriteLine("{0} added to member", member.ToString()); ;
                }
            }
            else if (IsEmpty())
            {
                members[0] = (Member)member;
                count++;
                Console.WriteLine("{0} added to member", member.ToString()); ;
            }
        }
        else
        {
            Console.WriteLine($"Membership fully occupied");
        }

        //For testing
        //foreach (Member item in members)
        //{
        //    if (item != null)
        //    {
        //        Console.WriteLine("[{0}]", string.Join(", ", item.ToString())); ;
        //    }
        //}

    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
    public void Delete(IMember aMember)
    {
        // To be implemented by students in Phase 1
        int lower = 0;
        int upper = count - 1;
        int index = count;
        while (lower <= upper)
        {
            int search = (lower + upper) / 2;
            if (members[search] != null)
            {
                if (members[search].CompareTo((Member)aMember) == 0)
                {
                    index = search;
                    break;
                }
                else if (members[search].CompareTo((Member)aMember) < 0)
                {
                    lower = search + 1;
                }
                else
                {
                    upper = search - 1;

                }
            }
        }
        if (index < count)
        {
            for (int j = index; j < count; j++)
                if ((j + 1) >= count)
                {
                    members[j] = null;
                    break;
                }
                else if ((j + 1) < count)
                {
                    members[j] = members[j + 1];

                }
            count--;
        }
        else
        {
            Console.WriteLine("{0} is not a member", aMember.ToString());
        }
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
        // To be implemented by students in Phase 1
        int lower = 0;
        int upper = count - 1;
        while (lower <= upper)
        {
            int index = (lower + upper) / 2;
            if (members[index] != null)
            {
                if (members[index].CompareTo((Member)member) == 0)
                {
                    return true;
                }
                else if (members[index].CompareTo((Member)member) < 0)
                {
                    lower = index + 1;
                }
                else
                {
                    upper = index - 1;

                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        string d = " ";
        for (int i = 0; i < count; i++)
            s =  s + members[i].ToString() + "\n";
        return s;
    }

    // Find a given member in this member collection
    // Pre-condition: nil
    // Post-condition: return the reference of the member object in the member collection, if this member is in the member collection; return null otherwise; member collection remains unchanged
    public IMember Find(IMember member)
    {
        int lower = 0;
        int upper = count - 1;
        while (lower <= upper)
        {
            int index = (lower + upper) / 2;
            if (members[index] != null)
            {
                if (members[index].CompareTo((Member)member) == 0)
                {
                    return members[index];
                }
                else if (members[index].CompareTo((Member)member) < 0)
                {
                    lower = index + 1;
                }
                else
                {
                    upper = index - 1;
                }
            }
            else
            {
                return null;
            }
        }
        return null;
    }
}