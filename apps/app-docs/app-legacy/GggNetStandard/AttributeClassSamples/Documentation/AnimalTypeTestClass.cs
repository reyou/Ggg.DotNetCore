using System;

namespace GggNetStandard.AttributeClassSamples.Documentation
{
    class AnimalTypeTestClass
    {
        [AnimalType(Animal.Dog)]
        public void DogMethod()
        {
            Console.WriteLine("DogMethod is running...");
        }

        [AnimalType(Animal.Cat)]
        public void CatMethod()
        {
            Console.WriteLine("CatMethod is running...");
        }

        [AnimalType(Animal.Bird)]
        public void BirdMethod()
        {
            Console.WriteLine("BirdMethod is running...");
        }
    }
}