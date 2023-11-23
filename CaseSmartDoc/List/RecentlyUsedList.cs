using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CaseSmartDoc.List
{
    public class RecentlyUsedList
    {
        //Deklarer datatypene for klassen
        protected List<string> items;
        protected int listLength;

        //Getter for listen
        public List<string> Items
        { get { return items; } }

        // Konstruktør med input parameter for satt listelengde.
        public RecentlyUsedList(int listLength)
        {
            // Sjekker om ønsket størrelse er større enn null.
            if (0 >= listLength)
            {
                // Sender feilmelding om ugyldig listelengde.
                throw new ArgumentOutOfRangeException("The length of the list needs to be larger than 0.");
            }

            // Setter makslengde på listen,
            this.listLength = listLength;
            // Lager en ny liste for strenger.
            items = new List<string>();
        }

        //Metode for å legge til ressurs i listen
        public void AddItemToList(string item)
        {
            // Sjekker om ressursen er null eller en tom streng.
            if(item == null || item == "")
            {
                // Sender feilmelding om at strengen ikke er gyldig.
                throw new ArgumentException("The item needs to have a value.");
            }

            // Fjerner duplikater som allerede ligger i listen.
            if(items.Contains(item))
            {
                items.Remove(item);
            }

            // Setter den nye strengen først i listen
            items.Insert(0, item);

            // Sjekker hvor mange nylige brukte ressurser som ligger i listen
            int spaceUsed = items.Count;

            // Fjerner den eldste ressursen i listen hvis listen er full.
            if(spaceUsed > listLength)
            {
                //Fjerner det bakerste elementet i listen
                items.RemoveAt(spaceUsed - 1);
            }
             
        }
    }
}
