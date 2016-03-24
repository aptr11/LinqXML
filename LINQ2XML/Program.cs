﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LINQ2XML
{
    class Program
    {
        //public static Person[] persons = new Person[5];
        public static List<Person> persons = new List<Person>();

        static void Main()
        {
            
            AddFivePersons();
            AddFivePersons();
            ReadData();
            //SaveData();
        }
        /// <summary>
        /// Add five test entries to persons
        /// </summary>
        public static void AddFivePersons()
        {
            persons.Add(new Person("Alex", "0745896321", "alex@patruta.xyz"));
            persons.Add(new Person("Diana", "0789456325", "diana@patruta.xyz"));
            persons.Add(new Person("Marinel", "0765892759", "niculaie@patruta.xyz"));
            persons.Add(new Person("Daniel", "0773895621", "daniel@patruta.xyz"));
            persons.Add(new Person("Sorin", "0721458791", "sorin@patruta.xyz"));
        }
        public static void SaveData()
        {
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("XML Created using System.Xml.Linq namespace"),
                new XElement("Agenda",

                    from person in persons
                    select
                        new XElement("Entry", new XAttribute("ID", person.ID),
                        new XElement("Name", person.Name),
                        new XElement("Telephone", person.Telephone),
                        new XElement("Email", person.Email)
                        )));
            xmlDocument.Save("data.xml");
        }

        public static void ReadData()
        {
            //IEnumerable < string > names = from entry in XDocument.Load(@"data.xml")
            //                                                      .Descendants("Entry")
            //                         select entry.Element("Name").Value;
            //IEnumerable < string > tel = from entry in XDocument.Load(@"data.xml")
            //                                                 .Descendants("Entry")
            //                             select entry.Element("Telephone").Value;
            //IEnumerable < string > emails = from entry in XDocument.Load(@"data.xml")
            //                                              .Descendants("Entry")
            //                          select entry.Element("Email").Value;

            XDocument xml = XDocument.Load("data.xml");
            System.Console.WriteLine(xml.Element("Agenda").ToString());
        }
        
        /// <summary>
        /// Updates an XML document tree with a certain Person type object.
        /// </summary>
        /// <param name="xDoc">Type: "XDocument". Loaded document, the one which will be updated, but NOT overwritten</param>
        /// <param name="person">Type: "Person". The entry to be written in the new, updated XML file</param>
        public static void Update(XDocument xDoc, Person person)
        {
            try
            {
                xDoc.Element("Agenda").Add
                    (
                    new XElement("Entry", new XAttribute("ID", person.ID.ToString())),    
                        new XElement("Name", person.Name),
                        new XElement("Telephone", person.Telephone),
                        new XElement("Email", person.Email)
                    );
                xDoc.Save(@"updated.xml");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Failed to update. Got exception: {0}", ex.ToString());
            }
        }
    }
}
