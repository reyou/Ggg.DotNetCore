using System;

namespace GggNetStandard.AttributeClassSamples.Documentation
{
    // An enumeration of animals. Start at 1 (0 = uninitialized).

    // A custom attribute to allow a target to have a pet.
    public class AnimalTypeAttribute : Attribute
    {
        // Keep a variable internally ...
        protected Animal thePet;

        // .. and show a copy to the outside world.
        public Animal Pet
        {
            get => thePet;
            set => thePet = value;
        }

        // The constructor is called when the attribute is set.
        public AnimalTypeAttribute(Animal pet)
        {
            thePet = pet;
            Console.WriteLine("AnimalTypeAttribute constructor is running. pet: {0}", pet);
        }



    }

    // A test class where each method has its own pet.
}
