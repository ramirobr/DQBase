﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using DQBase.Entities;

namespace DQBase.DataAccessLayer
{
    public partial class DQBaseContext : ObjectContext
    {
        public const string ConnectionString = "name=DQBaseContext";
        public const string ContainerName = "DQBaseContext";
    
        #region Constructors
    
        public DQBaseContext()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public DQBaseContext(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public DQBaseContext(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<CATALOGO> CATALOGO
        {
            get { return _cATALOGO  ?? (_cATALOGO = CreateObjectSet<CATALOGO>("CATALOGO")); }
        }
        private ObjectSet<CATALOGO> _cATALOGO;
    
        public ObjectSet<CONSULTA> CONSULTA
        {
            get { return _cONSULTA  ?? (_cONSULTA = CreateObjectSet<CONSULTA>("CONSULTA")); }
        }
        private ObjectSet<CONSULTA> _cONSULTA;
    
        public ObjectSet<CORPORACION> CORPORACION
        {
            get { return _cORPORACION  ?? (_cORPORACION = CreateObjectSet<CORPORACION>("CORPORACION")); }
        }
        private ObjectSet<CORPORACION> _cORPORACION;
    
        public ObjectSet<GRUPOTERAPEUTICO> GRUPOTERAPEUTICO
        {
            get { return _gRUPOTERAPEUTICO  ?? (_gRUPOTERAPEUTICO = CreateObjectSet<GRUPOTERAPEUTICO>("GRUPOTERAPEUTICO")); }
        }
        private ObjectSet<GRUPOTERAPEUTICO> _gRUPOTERAPEUTICO;
    
        public ObjectSet<HISTORIALUSUARIO> HISTORIALUSUARIO
        {
            get { return _hISTORIALUSUARIO  ?? (_hISTORIALUSUARIO = CreateObjectSet<HISTORIALUSUARIO>("HISTORIALUSUARIO")); }
        }
        private ObjectSet<HISTORIALUSUARIO> _hISTORIALUSUARIO;
    
        public ObjectSet<HISTORICOPRECIO> HISTORICOPRECIO
        {
            get { return _hISTORICOPRECIO  ?? (_hISTORICOPRECIO = CreateObjectSet<HISTORICOPRECIO>("HISTORICOPRECIO")); }
        }
        private ObjectSet<HISTORICOPRECIO> _hISTORICOPRECIO;
    
        public ObjectSet<LABORATORIO> LABORATORIO
        {
            get { return _lABORATORIO  ?? (_lABORATORIO = CreateObjectSet<LABORATORIO>("LABORATORIO")); }
        }
        private ObjectSet<LABORATORIO> _lABORATORIO;
    
        public ObjectSet<MENU> MENU
        {
            get { return _mENU  ?? (_mENU = CreateObjectSet<MENU>("MENU")); }
        }
        private ObjectSet<MENU> _mENU;
    
        public ObjectSet<MOVIMIENTOSUBPRODUCTO> MOVIMIENTOSUBPRODUCTO
        {
            get { return _mOVIMIENTOSUBPRODUCTO  ?? (_mOVIMIENTOSUBPRODUCTO = CreateObjectSet<MOVIMIENTOSUBPRODUCTO>("MOVIMIENTOSUBPRODUCTO")); }
        }
        private ObjectSet<MOVIMIENTOSUBPRODUCTO> _mOVIMIENTOSUBPRODUCTO;
    
        public ObjectSet<PRODUCTO> PRODUCTO
        {
            get { return _pRODUCTO  ?? (_pRODUCTO = CreateObjectSet<PRODUCTO>("PRODUCTO")); }
        }
        private ObjectSet<PRODUCTO> _pRODUCTO;
    
        public ObjectSet<ROL> ROL
        {
            get { return _rOL  ?? (_rOL = CreateObjectSet<ROL>("ROL")); }
        }
        private ObjectSet<ROL> _rOL;
    
        public ObjectSet<ROLMENU> ROLMENU
        {
            get { return _rOLMENU  ?? (_rOLMENU = CreateObjectSet<ROLMENU>("ROLMENU")); }
        }
        private ObjectSet<ROLMENU> _rOLMENU;
    
        public ObjectSet<ROLUSUARIO> ROLUSUARIO
        {
            get { return _rOLUSUARIO  ?? (_rOLUSUARIO = CreateObjectSet<ROLUSUARIO>("ROLUSUARIO")); }
        }
        private ObjectSet<ROLUSUARIO> _rOLUSUARIO;
    
        public ObjectSet<SUBPRODUCTO> SUBPRODUCTO
        {
            get { return _sUBPRODUCTO  ?? (_sUBPRODUCTO = CreateObjectSet<SUBPRODUCTO>("SUBPRODUCTO")); }
        }
        private ObjectSet<SUBPRODUCTO> _sUBPRODUCTO;
    
        public ObjectSet<UBICACIONGEOGRAFICA> UBICACIONGEOGRAFICA
        {
            get { return _uBICACIONGEOGRAFICA  ?? (_uBICACIONGEOGRAFICA = CreateObjectSet<UBICACIONGEOGRAFICA>("UBICACIONGEOGRAFICA")); }
        }
        private ObjectSet<UBICACIONGEOGRAFICA> _uBICACIONGEOGRAFICA;
    
        public ObjectSet<USUARIO> USUARIO
        {
            get { return _uSUARIO  ?? (_uSUARIO = CreateObjectSet<USUARIO>("USUARIO")); }
        }
        private ObjectSet<USUARIO> _uSUARIO;
    
        public ObjectSet<VENTA> VENTA
        {
            get { return _vENTA  ?? (_vENTA = CreateObjectSet<VENTA>("VENTA")); }
        }
        private ObjectSet<VENTA> _vENTA;
    
        public ObjectSet<Ciclo> Ciclo
        {
            get { return _ciclo  ?? (_ciclo = CreateObjectSet<Ciclo>("Ciclo")); }
        }
        private ObjectSet<Ciclo> _ciclo;

        #endregion
        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="fechaInicioActual">No Metadata Documentation available.</param>
        /// <param name="fechaFinActual">No Metadata Documentation available.</param>
        /// <param name="fechaInicioAnterior">No Metadata Documentation available.</param>
        /// <param name="fechaFinAnterior">No Metadata Documentation available.</param>
        public virtual ObjectResult<GetCicloVentasResult> GetCicloVentas(Nullable<System.DateTime> fechaInicioActual, Nullable<System.DateTime> fechaFinActual, Nullable<System.DateTime> fechaInicioAnterior, Nullable<System.DateTime> fechaFinAnterior)
        {
    
            ObjectParameter fechaInicioActualParameter;
    
            if (fechaInicioActual.HasValue)
            {
                fechaInicioActualParameter = new ObjectParameter("fechaInicioActual", fechaInicioActual);
            }
            else
            {
                fechaInicioActualParameter = new ObjectParameter("fechaInicioActual", typeof(System.DateTime));
            }
    
            ObjectParameter fechaFinActualParameter;
    
            if (fechaFinActual.HasValue)
            {
                fechaFinActualParameter = new ObjectParameter("fechaFinActual", fechaFinActual);
            }
            else
            {
                fechaFinActualParameter = new ObjectParameter("fechaFinActual", typeof(System.DateTime));
            }
    
            ObjectParameter fechaInicioAnteriorParameter;
    
            if (fechaInicioAnterior.HasValue)
            {
                fechaInicioAnteriorParameter = new ObjectParameter("fechaInicioAnterior", fechaInicioAnterior);
            }
            else
            {
                fechaInicioAnteriorParameter = new ObjectParameter("fechaInicioAnterior", typeof(System.DateTime));
            }
    
            ObjectParameter fechaFinAnteriorParameter;
    
            if (fechaFinAnterior.HasValue)
            {
                fechaFinAnteriorParameter = new ObjectParameter("fechaFinAnterior", fechaFinAnterior);
            }
            else
            {
                fechaFinAnteriorParameter = new ObjectParameter("fechaFinAnterior", typeof(System.DateTime));
            }
            return base.ExecuteFunction<GetCicloVentasResult>("GetCicloVentas", fechaInicioActualParameter, fechaFinActualParameter, fechaInicioAnteriorParameter, fechaFinAnteriorParameter);
        }

        #endregion
    }
}