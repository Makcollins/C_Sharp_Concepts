using System;

namespace Test;

public class ListManager
{
    public static List<Contact> GetContacts()
    {
        return new List<Contact>()
        {
            new Contact(){Name= "Ronny", Phone = "08547948696"},
            new Contact(){Name = "Stephanie", Phone = "378578243"},
            new Contact(){Name = "Douglas", Phone = "839842989"}
        };
    }
}
