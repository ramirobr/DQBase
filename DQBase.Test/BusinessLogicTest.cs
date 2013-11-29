using DQBase.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DQBase.Entities;
using System.Collections.Generic;

namespace DQBase.Test
{
    
    
    /// <summary>
    ///This is a test class for BusinessLogicTest and is intended
    ///to contain all BusinessLogicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BusinessLogicTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ObtenerCatalogo
        ///</summary>
        [TestMethod()]
        public void ObtenerCatalogoTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            Catalogos nombreTabla; // TODO: Initialize to an appropriate value
            List<CATALOGO> expected = null; // TODO: Initialize to an appropriate value
            List<CATALOGO> actual;
            nombreTabla = Catalogos.FORMAPRODUCTO;
            actual = target.ObtenerCatalogo(nombreTabla);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for CrearCatalogo
        ///</summary>
        [TestMethod()]
        public void CrearCatalogoTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            CATALOGO catalogo = new CATALOGO(); // TODO: Initialize to an appropriate value
            catalogo.IDCATALAGO = Guid.NewGuid();
            catalogo.DESCRIPCIONCATALOGO = "Catalogo Demo";
            catalogo.TABLA = "Demo";
            target.CrearCatalogo(catalogo);
            Assert.AreNotEqual(catalogo,new CATALOGO());
        }

        /// <summary>
        ///A test for BorrarCatalogo
        ///</summary>
        [TestMethod()]
        public void BorrarCatalogoTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            CATALOGO catalogo = null; // TODO: Initialize to an appropriate value
            target.BorrarCatalogo(catalogo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ActualizarCatalogo
        ///</summary>
        [TestMethod()]
        public void ActualizarCatalogoTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            CATALOGO catalogo = null; // TODO: Initialize to an appropriate value
            target.ActualizarCatalogo(catalogo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ObtenerCorporaciones
        ///</summary>
        [TestMethod()]
        public void ObtenerCorporacionesTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<CORPORACION> expected = null; // TODO: Initialize to an appropriate value
            List<CORPORACION> actual;
            actual = target.ObtenerCorporaciones();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for ObtenerLaboratorio
        ///</summary>
        [TestMethod()]
        public void ObtenerLaboratorioTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<LABORATORIO> expected = null; // TODO: Initialize to an appropriate value
            List<LABORATORIO> actual;
            actual = target.ObtenerLaboratorio();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for ObtenerLaboratorio
        ///</summary>
        [TestMethod()]
        public void ObtenerLaboratorioTest1()
        {
            ILaboratorios target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            string corporacion = string.Empty;
            List<LABORATORIO> expected = null; // TODO: Initialize to an appropriate value
            List<LABORATORIO> actual;
            actual = target.ObtenerLaboratorio(corporacion);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for ObtenerRoles
        ///</summary>
        [TestMethod()]
        public void ObtenerRolesTest()
        {
            IUsuarios target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<ROL> expected = null; // TODO: Initialize to an appropriate value
            List<ROL> actual;
            actual = target.ObtenerRoles();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetSubProductsByProduct
        ///</summary>
        [TestMethod()]
        public void GetSubProductsByProductTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            Guid productId = new Guid("370278B0-06FA-4BBF-A004-A71612B1B6D5"); // TODO: Initialize to an appropriate value
            List<SubProductos> expected = null; // TODO: Initialize to an appropriate value
            List<SubProductos> actual;
            actual = target.GetSubProductsByProduct(productId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for ObtenerListaUsuarios
        ///</summary>
        [TestMethod()]
        public void ObtenerListaUsuariosTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<UsuarioDetalle> expected = null; // TODO: Initialize to an appropriate value
            List<UsuarioDetalle> actual;
            actual = target.ObtenerListaUsuarios();
            Assert.AreNotEqual(expected, actual);
        }



        /// <summary>
        ///A test for ObtenerCicloVentas
        ///</summary>
        [TestMethod()]
        public void ObtenerCicloVentasTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            DateTime fechaInicio = new DateTime(2008,03,1); // TODO: Initialize to an appropriate value
            DateTime fechaFin = new DateTime(2008,03,31); // TODO: Initialize to an appropriate value
            List<GetCicloVentasResult> expected = null; // TODO: Initialize to an appropriate value
            List<GetCicloVentasResult> actual;
            actual = target.ObtenerCicloVentas(fechaInicio, fechaFin);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetLaboratorios
        ///</summary>
        [TestMethod()]
        public void GetLaboratoriosTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<ListaLaboratorio> expected = null; // TODO: Initialize to an appropriate value
            List<ListaLaboratorio> actual;
            actual = target.GetLaboratorios();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCiudades
        ///</summary>
        [TestMethod()]
        public void GetCiudadesTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<UBICACIONGEOGRAFICA> expected = null; // TODO: Initialize to an appropriate value
            List<UBICACIONGEOGRAFICA> actual;
            actual = target.GetCiudades();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetPaises
        ///</summary>
        [TestMethod()]
        public void GetPaisesTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<UBICACIONGEOGRAFICA> expected = null; // TODO: Initialize to an appropriate value
            List<UBICACIONGEOGRAFICA> actual;
            actual = target.GetPaises();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRegiones
        ///</summary>
        [TestMethod()]
        public void GetRegionesTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<UBICACIONGEOGRAFICA> expected = null; // TODO: Initialize to an appropriate value
            List<UBICACIONGEOGRAFICA> actual;
            actual = target.GetRegiones();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetUbicacionRegiones
        ///</summary>
        [TestMethod()]
        public void GetUbicacionRegionesTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<Ubicacion> expected = null; // TODO: Initialize to an appropriate value
            List<Ubicacion> actual;
            actual = target.GetUbicacionRegiones();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetUbicacionCiudades
        ///</summary>
        [TestMethod()]
        public void GetUbicacionCiudadesTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<Ubicacion> expected = null; // TODO: Initialize to an appropriate value
            List<Ubicacion> actual;
            actual = target.GetUbicacionCiudades();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetMovimientoProductos
        ///</summary>
        [TestMethod()]
        public void GetMovimientoProductosTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<MovimientoProductos> expected = null; // TODO: Initialize to an appropriate value
            List<MovimientoProductos> actual;
            actual = target.GetMovimientoProductos();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetMenus
        ///</summary>
        [TestMethod()]
        public void GetMenusTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            List<ListaMenu> expected = null; // TODO: Initialize to an appropriate value
            List<ListaMenu> actual;
            actual = target.GetMenus();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetIdUbicacionCorporacion
        ///</summary>
        [TestMethod()]
        public void GetIdUbicacionCorporacionTest()
        {
            BusinessLogic target = new BusinessLogic(); // TODO: Initialize to an appropriate value
            string nombreCorporacion = "LETERAGO CORP"; // TODO: Initialize to an appropriate value
            Guid expected = new Guid(); // TODO: Initialize to an appropriate value
            Guid actual;
            actual = target.GetIdUbicacionCorporacion(nombreCorporacion);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
