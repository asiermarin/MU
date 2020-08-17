using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Test
{
    class TestReglas
    {
        private Mock<AdministradorReglas> _mockAdministrador;
        private Mock<Mu> _mockMu;
        private List<Mu> _listaMockTest;

        [SetUp]
        public void SetUp()
        {
            _mockAdministrador = new Mock<AdministradorReglas>();
            _mockMu = new Mock<Mu>();
            _listaMockTest = new List<Mu>();
        }

        [TestCase("MUUIIUUUI")]
        [TestCase("MIUIUUI")]
        [TestCase("MUUIUIU")]
        [TestCase("MUUUUUUUI")]
        [TestCase("MIUIUIUUUIUU")]
        public void TestReglaCuatro(string cadena)
        {
            List<string> listaVacia = new List<string>();
            Mu muTest = new Mu(cadena, "4", listaVacia);

            switch (muTest.Cadena)
            {
                case "MUUIIUUUI":
                    _listaMockTest = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);
                    var result = _listaMockTest;

                    var expectedResult1 = new Mu("MUIIUUUI", "4", listaVacia);
                    var expectedResult2 = new Mu("MUUIIUI", "4", listaVacia);
                    var listaResultadosEsperados = new List<Mu>
                    {
                        expectedResult1,
                        expectedResult2
                    };

                    if (result.Count == listaResultadosEsperados.Count && result.Count == 2)
                    {
                        Assert.AreEqual(result[0].Cadena, listaResultadosEsperados[0].Cadena);
                        Assert.AreEqual(result[1].Cadena, listaResultadosEsperados[1].Cadena);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                    break;
                case "MIUIUUI":
                    _listaMockTest = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);
                    break;
                case "MUUIUIU":
                    _listaMockTest = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);
                    break;
                case "MUUUUUUUI":
                    _listaMockTest = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);
                    break;
                case "MIUIUIUUUIUU":
                    _listaMockTest = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);
                    break;

            }
        }
    }
}
