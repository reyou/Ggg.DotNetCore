namespace GggNetStandard.AttributeClassSamples.ApplyingAttributes
{
    class Test
    {
        public static void Run()
        {
            // This generates a compile-time warning.
            int i = Example.Add(2, 2);
        }
    }
}