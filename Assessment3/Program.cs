// See https://aka.ms/new-console-template for more information
using Assessment3;


//Initialize Empty Movie Collection
MovieCollection MovieCollection = new MovieCollection();
//Initialize Empty Member Collection with 999999 Capacity
MemberCollection MemberCollection = new MemberCollection(99999);
//Initialize System 
ManagementSystem system = new ManagementSystem(MovieCollection, MemberCollection);

//Start the system and menu
system.startUp();

