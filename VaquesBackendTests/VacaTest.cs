using Moq;
using VaquesBackend.Models;
using Xunit;

namespace VaquesBackendTest {

    public class VaquesTest 
    {
        [Theory]
        [InlineData(12, 5.5)]
        [InlineData(5.0, 4.0)]
        void TestQueRetornaCorrectamentLaLlet(double pes, double litres) {

            // ARRANGE
            var racaFalsa = new Mock<IRaça>();
            racaFalsa.Setup( r => r.LitresPerKg).Returns(litres);

            Vaca sut = new Vaca("nom", pes, racaFalsa.Object);

            // ACT
            double resultat = sut.Litres();

            // ASSERT
            Assert.Equal(pes * litres, resultat);
        }
    }
}