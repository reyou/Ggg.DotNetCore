using System;
using System.Collections.Generic;
using System.Text;

namespace GggNetStandard.Pets
{
    public class PetProgram
    {
        public static void Main_Pet(string[] args)
        {
            List<IPet> pets = new List<IPet>
            {
                new Dog(),
                new Cat()
            };

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.TalkToOwner());
            }
        }
    }
}
