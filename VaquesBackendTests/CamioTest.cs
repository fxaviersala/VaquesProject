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
                        new Vaca("", 9, Mock.Of<IRaça>())
                    },
                    9
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",8, Mock.Of<IRaça>()),
                        new Vaca("",1, Mock.Of<IRaça>())
                    },
                    9
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",2, Mock.Of<IRaça>())
                    },
                    8
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",10, Mock.Of<IRaça>())
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
                        new Vaca("", 11, Mock.Of<IRaça>())
                    },
                    0
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",8, Mock.Of<IRaça>()),
                        new Vaca("",3, Mock.Of<IRaça>())
                    },
                    1
                },
                new object[] {
                    new List<IVaca>() {
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",8, Mock.Of<IRaça>()),
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",2, Mock.Of<IRaça>())
                    },
                    2
                },
                 new object[] {
                    new List<IVaca>() {
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",7, Mock.Of<IRaça>()),
                        new Vaca("",2, Mock.Of<IRaça>()),
                        new Vaca("",1, Mock.Of<IRaça>())
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
