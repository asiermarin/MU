using Moq;
using MU.Modelos;
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
                    var result = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);

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
                    var resultCase2 = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);

                    var expectedResult3 = new Mu("MIUIUI", "4", listaVacia);
                    var listaResultadosEsperados2 = new List<Mu>
                    {
                        expectedResult3
                    };

                    if (resultCase2.Count == listaResultadosEsperados2.Count && resultCase2.Count == 1)
                    {
                        Assert.AreEqual(resultCase2[0].Cadena, listaResultadosEsperados2[0].Cadena);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                    break;
                case "MUUIUIU":
                    var resultCase3 = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);

                    var expectedResult4 = new Mu("MUIUIU", "4", listaVacia);
                    var listaResultadosEsperados4 = new List<Mu>
                    {
                        expectedResult4
                    };

                    if (resultCase3.Count == listaResultadosEsperados4.Count && resultCase3.Count == 1)
                    {
                        Assert.AreEqual(resultCase3[0].Cadena, listaResultadosEsperados4[0].Cadena);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                    break;
                case "MUUUUUUUI":
                    var resultCase4 = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);

                    var expectedResult5 = new Mu("MUI", "4", listaVacia);
                    var listaResultadosEsperados5 = new List<Mu>
                    {
                        expectedResult5
                    };

                    if (resultCase4.Count == listaResultadosEsperados5.Count && resultCase4.Count == 1)
                    {
                        Assert.AreEqual(resultCase4[0].Cadena, listaResultadosEsperados5[0].Cadena);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                    break;
                case "MIUIUIUUUIUU":
                    var resultCase5 = _mockAdministrador.Object.AplicarReglaCuatroSiEsPosible(muTest);

                    var expectedResult6 = new Mu("MIUIUIUIUU", "4", listaVacia);
                    var expectedResult7 = new Mu("MIUIUIUUUIU", "4", listaVacia);
                    var listaResultadosEsperados6 = new List<Mu>
                    {
                        expectedResult6,
                        expectedResult7
                    };

                    if (resultCase5.Count == listaResultadosEsperados6.Count && resultCase5.Count == 2)
                    {
                        Assert.AreEqual(resultCase5[0].Cadena, listaResultadosEsperados6[0].Cadena);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                    break;
            }
        }
    }
}
