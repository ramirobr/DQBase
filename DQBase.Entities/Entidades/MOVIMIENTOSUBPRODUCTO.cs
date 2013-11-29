//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace DQBase.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(HISTORICOPRECIO))]
    [KnownType(typeof(LABORATORIO))]
    [KnownType(typeof(SUBPRODUCTO))]
    [KnownType(typeof(VENTA))]
    public partial class MOVIMIENTOSUBPRODUCTO: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.Guid CODIGOSUBPRODUCTO
        {
            get { return _cODIGOSUBPRODUCTO; }
            set
            {
                if (_cODIGOSUBPRODUCTO != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CODIGOSUBPRODUCTO' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _cODIGOSUBPRODUCTO = value;
                    OnPropertyChanged("CODIGOSUBPRODUCTO");
                }
            }
        }
        private System.Guid _cODIGOSUBPRODUCTO;
    
        [DataMember]
        public System.Guid IDSUBPRODUCTO
        {
            get { return _iDSUBPRODUCTO; }
            set
            {
                if (_iDSUBPRODUCTO != value)
                {
                    ChangeTracker.RecordOriginalValue("IDSUBPRODUCTO", _iDSUBPRODUCTO);
                    if (!IsDeserializing)
                    {
                        if (SUBPRODUCTO != null && SUBPRODUCTO.IDSUBPRODUCTO != value)
                        {
                            SUBPRODUCTO = null;
                        }
                    }
                    _iDSUBPRODUCTO = value;
                    OnPropertyChanged("IDSUBPRODUCTO");
                }
            }
        }
        private System.Guid _iDSUBPRODUCTO;
    
        [DataMember]
        public System.Guid IDLABORATORIO
        {
            get { return _iDLABORATORIO; }
            set
            {
                if (_iDLABORATORIO != value)
                {
                    ChangeTracker.RecordOriginalValue("IDLABORATORIO", _iDLABORATORIO);
                    if (!IsDeserializing)
                    {
                        if (LABORATORIO != null && LABORATORIO.IDLABORATORIO != value)
                        {
                            LABORATORIO = null;
                        }
                    }
                    _iDLABORATORIO = value;
                    OnPropertyChanged("IDLABORATORIO");
                }
            }
        }
        private System.Guid _iDLABORATORIO;
    
        [DataMember]
        public string CODIGOPRODUCTOLABORATORIO
        {
            get { return _cODIGOPRODUCTOLABORATORIO; }
            set
            {
                if (_cODIGOPRODUCTOLABORATORIO != value)
                {
                    _cODIGOPRODUCTOLABORATORIO = value;
                    OnPropertyChanged("CODIGOPRODUCTOLABORATORIO");
                }
            }
        }
        private string _cODIGOPRODUCTOLABORATORIO;
    
        [DataMember]
        public bool ESNUEVO
        {
            get { return _eSNUEVO; }
            set
            {
                if (_eSNUEVO != value)
                {
                    _eSNUEVO = value;
                    OnPropertyChanged("ESNUEVO");
                }
            }
        }
        private bool _eSNUEVO;
    
        [DataMember]
        public System.DateTime FECHALANZAMIENTO
        {
            get { return _fECHALANZAMIENTO; }
            set
            {
                if (_fECHALANZAMIENTO != value)
                {
                    _fECHALANZAMIENTO = value;
                    OnPropertyChanged("FECHALANZAMIENTO");
                }
            }
        }
        private System.DateTime _fECHALANZAMIENTO;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<HISTORICOPRECIO> HISTORICOPRECIO
        {
            get
            {
                if (_hISTORICOPRECIO == null)
                {
                    _hISTORICOPRECIO = new TrackableCollection<HISTORICOPRECIO>();
                    _hISTORICOPRECIO.CollectionChanged += FixupHISTORICOPRECIO;
                }
                return _hISTORICOPRECIO;
            }
            set
            {
                if (!ReferenceEquals(_hISTORICOPRECIO, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_hISTORICOPRECIO != null)
                    {
                        _hISTORICOPRECIO.CollectionChanged -= FixupHISTORICOPRECIO;
                    }
                    _hISTORICOPRECIO = value;
                    if (_hISTORICOPRECIO != null)
                    {
                        _hISTORICOPRECIO.CollectionChanged += FixupHISTORICOPRECIO;
                    }
                    OnNavigationPropertyChanged("HISTORICOPRECIO");
                }
            }
        }
        private TrackableCollection<HISTORICOPRECIO> _hISTORICOPRECIO;
    
        [DataMember]
        public LABORATORIO LABORATORIO
        {
            get { return _lABORATORIO; }
            set
            {
                if (!ReferenceEquals(_lABORATORIO, value))
                {
                    var previousValue = _lABORATORIO;
                    _lABORATORIO = value;
                    FixupLABORATORIO(previousValue);
                    OnNavigationPropertyChanged("LABORATORIO");
                }
            }
        }
        private LABORATORIO _lABORATORIO;
    
        [DataMember]
        public SUBPRODUCTO SUBPRODUCTO
        {
            get { return _sUBPRODUCTO; }
            set
            {
                if (!ReferenceEquals(_sUBPRODUCTO, value))
                {
                    var previousValue = _sUBPRODUCTO;
                    _sUBPRODUCTO = value;
                    FixupSUBPRODUCTO(previousValue);
                    OnNavigationPropertyChanged("SUBPRODUCTO");
                }
            }
        }
        private SUBPRODUCTO _sUBPRODUCTO;
    
        [DataMember]
        public TrackableCollection<VENTA> VENTA
        {
            get
            {
                if (_vENTA == null)
                {
                    _vENTA = new TrackableCollection<VENTA>();
                    _vENTA.CollectionChanged += FixupVENTA;
                }
                return _vENTA;
            }
            set
            {
                if (!ReferenceEquals(_vENTA, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_vENTA != null)
                    {
                        _vENTA.CollectionChanged -= FixupVENTA;
                    }
                    _vENTA = value;
                    if (_vENTA != null)
                    {
                        _vENTA.CollectionChanged += FixupVENTA;
                    }
                    OnNavigationPropertyChanged("VENTA");
                }
            }
        }
        private TrackableCollection<VENTA> _vENTA;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            HISTORICOPRECIO.Clear();
            LABORATORIO = null;
            SUBPRODUCTO = null;
            VENTA.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupLABORATORIO(LABORATORIO previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MOVIMIENTOSUBPRODUCTO.Contains(this))
            {
                previousValue.MOVIMIENTOSUBPRODUCTO.Remove(this);
            }
    
            if (LABORATORIO != null)
            {
                if (!LABORATORIO.MOVIMIENTOSUBPRODUCTO.Contains(this))
                {
                    LABORATORIO.MOVIMIENTOSUBPRODUCTO.Add(this);
                }
    
                IDLABORATORIO = LABORATORIO.IDLABORATORIO;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("LABORATORIO")
                    && (ChangeTracker.OriginalValues["LABORATORIO"] == LABORATORIO))
                {
                    ChangeTracker.OriginalValues.Remove("LABORATORIO");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("LABORATORIO", previousValue);
                }
                if (LABORATORIO != null && !LABORATORIO.ChangeTracker.ChangeTrackingEnabled)
                {
                    LABORATORIO.StartTracking();
                }
            }
        }
    
        private void FixupSUBPRODUCTO(SUBPRODUCTO previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MOVIMIENTOSUBPRODUCTO.Contains(this))
            {
                previousValue.MOVIMIENTOSUBPRODUCTO.Remove(this);
            }
    
            if (SUBPRODUCTO != null)
            {
                if (!SUBPRODUCTO.MOVIMIENTOSUBPRODUCTO.Contains(this))
                {
                    SUBPRODUCTO.MOVIMIENTOSUBPRODUCTO.Add(this);
                }
    
                IDSUBPRODUCTO = SUBPRODUCTO.IDSUBPRODUCTO;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SUBPRODUCTO")
                    && (ChangeTracker.OriginalValues["SUBPRODUCTO"] == SUBPRODUCTO))
                {
                    ChangeTracker.OriginalValues.Remove("SUBPRODUCTO");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SUBPRODUCTO", previousValue);
                }
                if (SUBPRODUCTO != null && !SUBPRODUCTO.ChangeTracker.ChangeTrackingEnabled)
                {
                    SUBPRODUCTO.StartTracking();
                }
            }
        }
    
        private void FixupHISTORICOPRECIO(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (HISTORICOPRECIO item in e.NewItems)
                {
                    item.MOVIMIENTOSUBPRODUCTO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("HISTORICOPRECIO", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HISTORICOPRECIO item in e.OldItems)
                {
                    if (ReferenceEquals(item.MOVIMIENTOSUBPRODUCTO, this))
                    {
                        item.MOVIMIENTOSUBPRODUCTO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("HISTORICOPRECIO", item);
                    }
                }
            }
        }
    
        private void FixupVENTA(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (VENTA item in e.NewItems)
                {
                    item.MOVIMIENTOSUBPRODUCTO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("VENTA", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (VENTA item in e.OldItems)
                {
                    if (ReferenceEquals(item.MOVIMIENTOSUBPRODUCTO, this))
                    {
                        item.MOVIMIENTOSUBPRODUCTO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("VENTA", item);
                    }
                }
            }
        }

        #endregion
    }
}
