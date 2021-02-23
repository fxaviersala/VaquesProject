using Moq;
using System;
using System.Collections.Generic;
using VaquesBackend.Models;
using Xunit;

namespace VaquesBackendTests
{
    public class CamioTest
    {
        [Theory]
        [InlineData(5.0)]
        [InlineData(10.0)]
        [InlineData(0.0)]
        public void TestQueTotVaBeQuanEntraUnaVacaEnUnCamioOnHiCap(double pes)
        {
            double llet = 8.0;
            // ARRANGE
            var vacaFalsa = new Mock<IVaca>();
            vacaFalsa.SetupGet(v => v.Pes).Returns(pes);
            vacaFalsa.Setup(v => v.Litres()).Returns(llet);

            Camio sut = new Camio(10);

            // ACT
            var resultat = sut.EntraVaca(vacaFalsa.Object);

            // ASSERT
            Assert.True(resultat, "La vaca ha de poder entrar");
            Assert.Equal(pes, sut.PesActual);
            Assert.Equal(llet, sut.Litres);
        }

        [Theory]
        [InlineData(10.0001)]
        [InlineData(11.0)]
        [InlineData(50.0)]
        void TestQueTotNOEntraUnaVacaEnUnCamioSiPesaMassa(double pes)
        {
            double llet = 8.0;
            // ARRANGE
            var vacaFalsa = new Mock<IVaca>();
            vacaFalsa.Setup(v => v.Pes).Returns(pes);
            vacaFalsa.Setup(v => v.Litres()).Returns(llet);

            Camio sut = new Camio(10);

            // ACT
            var resultat = sut.EntraVaca(vacaFalsa.Object);

            // ASSERT
            Assert.False(resultat, "La vaca NO ha de poder entrar");
            Assert.Equal(0, sut.PesActual);
            Assert.Equal(0, sut.Litres);
        }

        public static IEnumerable<object[]> VaquesOk =>
            new List<object[]>
            {
                new object[] {
                    new List<IVaca>() {
                        new Vaca("", 9, Mock.Of<IRa�a>())
                    },
                    9
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",8, Mock.Of<IRa�a>()),
                        new Vaca("",1, Mock.Of<IRa�a>())
                    },
                    9
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",2, Mock.Of<IRa�a>())
                    },
                    8
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",10, Mock.Of<IRa�a>())
                    },
                    10
                },

            };

        [Theory]
        [MemberData(nameof(VaquesOk))]
        public void TestQueLesVaquesMentreNoSuperinElPesMaximEntrenAlCamio(List<IVaca> vaques, double expectedPes)
        {
            // ARRANGE
            Camio sut = new Camio(10);

            // ACT
            foreach (var vaca in vaques)
            {
                var resultat = sut.EntraVaca(vaca);
            }

            // ASSERT
            Assert.Equal(expectedPes, sut.PesActual);
            Assert.Equal(vaques.Count, sut.Vaques.Count);
            Assert.Equal(vaques, sut.Vaques);
        }



        public static IEnumerable<object[]> VaquesKo =>
            new List<object[]>
            {
                new object[] {
                    new List<IVaca>() {
                        new Vaca("", 11, Mock.Of<IRa�a>())
                    },
                    0
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",8, Mock.Of<IRa�a>()),
                        new Vaca("",3, Mock.Of<IRa�a>())
                    },
                    1
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",8, Mock.Of<IRa�a>()),
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",2, Mock.Of<IRa�a>())
                    },
                    2
                },
                 new object[] {
                    new List<IVaca>() {
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",7, Mock.Of<IRa�a>()),
                        new Vaca("",2, Mock.Of<IRa�a>()),
                        new Vaca("",1, Mock.Of<IRa�a>())
                    },
                    3
                },

            };

        [Theory]
        [MemberData(nameof(VaquesKo))]
        public void TestQueLesVaquesQuanSuperinElPesMaximNoEntrenAlCamio(List<IVaca> vaques, int expectedvaquesAlCamio)
        {
            // ARRANGE
            Camio sut = new Camio(10);

            // ACT
            foreach (var vaca in vaques)
            {
                var resultat = sut.EntraVaca(vaca);
            }

            // ASSERT
            Assert.Equal(expectedvaquesAlCamio, sut.Vaques.Count);

        }




    }
}
