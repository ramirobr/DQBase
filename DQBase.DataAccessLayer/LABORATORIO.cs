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

namespace DQBase.DataAccessLayer
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CORPORACION))]
    [KnownType(typeof(UBICACIONGEOGRAFICA))]
    [KnownType(typeof(MOVIMIENTOSUBPRODUCTO))]
    [KnownType(typeof(USUARIO))]
    [KnownType(typeof(VENTA))]
    public partial class LABORATORIO: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.Guid IDLABORATORIO
        {
            get { return _iDLABORATORIO; }
            set
            {
                if (_iDLABORATORIO != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'IDLABORATORIO' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _iDLABORATORIO = value;
                    OnPropertyChanged("IDLABORATORIO");
                }
            }
        }
        private System.Guid _iDLABORATORIO;
    
        [DataMember]
        public System.Guid IDUBICACION
        {
            get { return _iDUBICACION; }
            set
            {
                if (_iDUBICACION != value)
                {
                    ChangeTracker.RecordOriginalValue("IDUBICACION", _iDUBICACION);
                    if (!IsDeserializing)
                    {
                        if (UBICACIONGEOGRAFICA != null && UBICACIONGEOGRAFICA.IDUBICACION != value)
                        {
                            UBICACIONGEOGRAFICA = null;
                        }
                    }
                    _iDUBICACION = value;
                    OnPropertyChanged("IDUBICACION");
                }
            }
        }
        private System.Guid _iDUBICACION;
    
        [DataMember]
        public Nullable<System.Guid> IDCORPORACION
        {
            get { return _iDCORPORACION; }
            set
            {
                if (_iDCORPORACION != value)
                {
                    ChangeTracker.RecordOriginalValue("IDCORPORACION", _iDCORPORACION);
                    if (!IsDeserializing)
                    {
                        if (CORPORACION != null && CORPORACION.IDCORPORACION != value)
                        {
                            CORPORACION = null;
                        }
                    }
                    _iDCORPORACION = value;
                    OnPropertyChanged("IDCORPORACION");
                }
            }
        }
        private Nullable<System.Guid> _iDCORPORACION;
    
        [DataMember]
        public string NOMBRELABORATORIO
        {
            get { return _nOMBRELABORATORIO; }
            set
            {
                if (_nOMBRELABORATORIO != value)
                {
                    _nOMBRELABORATORIO = value;
                    OnPropertyChanged("NOMBRELABORATORIO");
                }
            }
        }
        private string _nOMBRELABORATORIO;
    
        [DataMember]
        public string ABREVIATURALABORATORIO
        {
            get { return _aBREVIATURALABORATORIO; }
            set
            {
                if (_aBREVIATURALABORATORIO != value)
                {
                    _aBREVIATURALABORATORIO = value;
                    OnPropertyChanged("ABREVIATURALABORATORIO");
                }
            }
        }
        private string _aBREVIATURALABORATORIO;
    
        [DataMember]
        public string DIRECCION
        {
            get { return _dIRECCION; }
            set
            {
                if (_dIRECCION != value)
                {
                    _dIRECCION = value;
                    OnPropertyChanged("DIRECCION");
                }
            }
        }
        private string _dIRECCION;
    
        [DataMember]
        public string DIRECCION2
        {
            get { return _dIRECCION2; }
            set
            {
                if (_dIRECCION2 != value)
                {
                    _dIRECCION2 = value;
                    OnPropertyChanged("DIRECCION2");
                }
            }
        }
        private string _dIRECCION2;
    
        [DataMember]
        public string TELEFONO
        {
            get { return _tELEFONO; }
            set
            {
                if (_tELEFONO != value)
                {
                    _tELEFONO = value;
                    OnPropertyChanged("TELEFONO");
                }
            }
        }
        private string _tELEFONO;
    
        [DataMember]
        public string ORIGEN
        {
            get { return _oRIGEN; }
            set
            {
                if (_oRIGEN != value)
                {
                    _oRIGEN = value;
                    OnPropertyChanged("ORIGEN");
                }
            }
        }
        private string _oRIGEN;
    
        [DataMember]
        public string OBSERVACION
        {
            get { return _oBSERVACION; }
            set
            {
                if (_oBSERVACION != value)
                {
                    _oBSERVACION = value;
                    OnPropertyChanged("OBSERVACION");
                }
            }
        }
        private string _oBSERVACION;
    
        [DataMember]
        public bool ESBORRADOLABORATORIO
        {
            get { return _eSBORRADOLABORATORIO; }
            set
            {
                if (_eSBORRADOLABORATORIO != value)
                {
                    _eSBORRADOLABORATORIO = value;
                    OnPropertyChanged("ESBORRADOLABORATORIO");
                }
            }
        }
        private bool _eSBORRADOLABORATORIO;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public CORPORACION CORPORACION
        {
            get { return _cORPORACION; }
            set
            {
                if (!ReferenceEquals(_cORPORACION, value))
                {
                    var previousValue = _cORPORACION;
                    _cORPORACION = value;
                    FixupCORPORACION(previousValue);
                    OnNavigationPropertyChanged("CORPORACION");
                }
            }
        }
        private CORPORACION _cORPORACION;
    
        [DataMember]
        public UBICACIONGEOGRAFICA UBICACIONGEOGRAFICA
        {
            get { return _uBICACIONGEOGRAFICA; }
            set
            {
                if (!ReferenceEquals(_uBICACIONGEOGRAFICA, value))
                {
                    var previousValue = _uBICACIONGEOGRAFICA;
                    _uBICACIONGEOGRAFICA = value;
                    FixupUBICACIONGEOGRAFICA(previousValue);
                    OnNavigationPropertyChanged("UBICACIONGEOGRAFICA");
                }
            }
        }
        private UBICACIONGEOGRAFICA _uBICACIONGEOGRAFICA;
    
        [DataMember]
        public TrackableCollection<MOVIMIENTOSUBPRODUCTO> MOVIMIENTOSUBPRODUCTO
        {
            get
            {
                if (_mOVIMIENTOSUBPRODUCTO == null)
                {
                    _mOVIMIENTOSUBPRODUCTO = new TrackableCollection<MOVIMIENTOSUBPRODUCTO>();
                    _mOVIMIENTOSUBPRODUCTO.CollectionChanged += FixupMOVIMIENTOSUBPRODUCTO;
                }
                return _mOVIMIENTOSUBPRODUCTO;
            }
            set
            {
                if (!ReferenceEquals(_mOVIMIENTOSUBPRODUCTO, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_mOVIMIENTOSUBPRODUCTO != null)
                    {
                        _mOVIMIENTOSUBPRODUCTO.CollectionChanged -= FixupMOVIMIENTOSUBPRODUCTO;
                    }
                    _mOVIMIENTOSUBPRODUCTO = value;
                    if (_mOVIMIENTOSUBPRODUCTO != null)
                    {
                        _mOVIMIENTOSUBPRODUCTO.CollectionChanged += FixupMOVIMIENTOSUBPRODUCTO;
                    }
                    OnNavigationPropertyChanged("MOVIMIENTOSUBPRODUCTO");
                }
            }
        }
        private TrackableCollection<MOVIMIENTOSUBPRODUCTO> _mOVIMIENTOSUBPRODUCTO;
    
        [DataMember]
        public TrackableCollection<USUARIO> USUARIO
        {
            get
            {
                if (_uSUARIO == null)
                {
                    _uSUARIO = new TrackableCollection<USUARIO>();
                    _uSUARIO.CollectionChanged += FixupUSUARIO;
                }
                return _uSUARIO;
            }
            set
            {
                if (!ReferenceEquals(_uSUARIO, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_uSUARIO != null)
                    {
                        _uSUARIO.CollectionChanged -= FixupUSUARIO;
                    }
                    _uSUARIO = value;
                    if (_uSUARIO != null)
                    {
                        _uSUARIO.CollectionChanged += FixupUSUARIO;
                    }
                    OnNavigationPropertyChanged("USUARIO");
                }
            }
        }
        private TrackableCollection<USUARIO> _uSUARIO;
    
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
            CORPORACION = null;
            UBICACIONGEOGRAFICA = null;
            MOVIMIENTOSUBPRODUCTO.Clear();
            USUARIO.Clear();
            VENTA.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCORPORACION(CORPORACION previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.LABORATORIO.Contains(this))
            {
                previousValue.LABORATORIO.Remove(this);
            }
    
            if (CORPORACION != null)
            {
                if (!CORPORACION.LABORATORIO.Contains(this))
                {
                    CORPORACION.LABORATORIO.Add(this);
                }
    
                IDCORPORACION = CORPORACION.IDCORPORACION;
            }
            else if (!skipKeys)
            {
                IDCORPORACION = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CORPORACION")
                    && (ChangeTracker.OriginalValues["CORPORACION"] == CORPORACION))
                {
                    ChangeTracker.OriginalValues.Remove("CORPORACION");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CORPORACION", previousValue);
                }
                if (CORPORACION != null && !CORPORACION.ChangeTracker.ChangeTrackingEnabled)
                {
                    CORPORACION.StartTracking();
                }
            }
        }
    
        private void FixupUBICACIONGEOGRAFICA(UBICACIONGEOGRAFICA previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.LABORATORIO.Contains(this))
            {
                previousValue.LABORATORIO.Remove(this);
            }
    
            if (UBICACIONGEOGRAFICA != null)
            {
                if (!UBICACIONGEOGRAFICA.LABORATORIO.Contains(this))
                {
                    UBICACIONGEOGRAFICA.LABORATORIO.Add(this);
                }
    
                IDUBICACION = UBICACIONGEOGRAFICA.IDUBICACION;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("UBICACIONGEOGRAFICA")
                    && (ChangeTracker.OriginalValues["UBICACIONGEOGRAFICA"] == UBICACIONGEOGRAFICA))
                {
                    ChangeTracker.OriginalValues.Remove("UBICACIONGEOGRAFICA");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("UBICACIONGEOGRAFICA", previousValue);
                }
                if (UBICACIONGEOGRAFICA != null && !UBICACIONGEOGRAFICA.ChangeTracker.ChangeTrackingEnabled)
                {
                    UBICACIONGEOGRAFICA.StartTracking();
                }
            }
        }
    
        private void FixupMOVIMIENTOSUBPRODUCTO(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (MOVIMIENTOSUBPRODUCTO item in e.NewItems)
                {
                    item.LABORATORIO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("MOVIMIENTOSUBPRODUCTO", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MOVIMIENTOSUBPRODUCTO item in e.OldItems)
                {
                    if (ReferenceEquals(item.LABORATORIO, this))
                    {
                        item.LABORATORIO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("MOVIMIENTOSUBPRODUCTO", item);
                    }
                }
            }
        }
    
        private void FixupUSUARIO(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (USUARIO item in e.NewItems)
                {
                    item.LABORATORIO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("USUARIO", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (USUARIO item in e.OldItems)
                {
                    if (ReferenceEquals(item.LABORATORIO, this))
                    {
                        item.LABORATORIO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("USUARIO", item);
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
                    item.LABORATORIO = this;
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
                    if (ReferenceEquals(item.LABORATORIO, this))
                    {
                        item.LABORATORIO = null;
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
