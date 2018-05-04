using GggNetStandard.Pets;
using Xunit;

namespace GggXUnitTestProject
{
    /// <summary>
    /// https://xunit.github.io/
    /// </summary>
    public class PetsUnitTests
    {
        [Fact]
        public void DogTalkToOwnerReturnsWoof()
        {
            string expected = "Woof!";
            string actual = new Dog().TalkToOwner();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CatTalkToOwnerReturnsMeow()
        {
            string expected = "Meow!";
            string actual = new Cat().TalkToOwner();

            Assert.Equal(expected, actual);
        }
    }
}
