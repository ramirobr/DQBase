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
    [KnownType(typeof(SUBPRODUCTO))]
    public partial class GRUPOTERAPEUTICO: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.Guid IDGRUPO
        {
            get { return _iDGRUPO; }
            set
            {
                if (_iDGRUPO != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'IDGRUPO' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _iDGRUPO = value;
                    OnPropertyChanged("IDGRUPO");
                }
            }
        }
        private System.Guid _iDGRUPO;
    
        [DataMember]
        public Nullable<System.Guid> IDSUBGRUPO
        {
            get { return _iDSUBGRUPO; }
            set
            {
                if (_iDSUBGRUPO != value)
                {
                    _iDSUBGRUPO = value;
                    OnPropertyChanged("IDSUBGRUPO");
                }
            }
        }
        private Nullable<System.Guid> _iDSUBGRUPO;
    
        [DataMember]
        public string ABREVIATURAGRUPOTER
        {
            get { return _aBREVIATURAGRUPOTER; }
            set
            {
                if (_aBREVIATURAGRUPOTER != value)
                {
                    _aBREVIATURAGRUPOTER = value;
                    OnPropertyChanged("ABREVIATURAGRUPOTER");
                }
            }
        }
        private string _aBREVIATURAGRUPOTER;
    
        [DataMember]
        public string NOMBREGRUPOTER
        {
            get { return _nOMBREGRUPOTER; }
            set
            {
                if (_nOMBREGRUPOTER != value)
                {
                    _nOMBREGRUPOTER = value;
                    OnPropertyChanged("NOMBREGRUPOTER");
                }
            }
        }
        private string _nOMBREGRUPOTER;
    
        [DataMember]
        public string DESCRIPCIONGRUPOTER
        {
            get { return _dESCRIPCIONGRUPOTER; }
            set
            {
                if (_dESCRIPCIONGRUPOTER != value)
                {
                    _dESCRIPCIONGRUPOTER = value;
                    OnPropertyChanged("DESCRIPCIONGRUPOTER");
                }
            }
        }
        private string _dESCRIPCIONGRUPOTER;
    
        [DataMember]
        public bool ESBORRADOGRUPOTER
        {
            get { return _eSBORRADOGRUPOTER; }
            set
            {
                if (_eSBORRADOGRUPOTER != value)
                {
                    _eSBORRADOGRUPOTER = value;
                    OnPropertyChanged("ESBORRADOGRUPOTER");
                }
            }
        }
        private bool _eSBORRADOGRUPOTER;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<SUBPRODUCTO> SUBPRODUCTO
        {
            get
            {
                if (_sUBPRODUCTO == null)
                {
                    _sUBPRODUCTO = new TrackableCollection<SUBPRODUCTO>();
                    _sUBPRODUCTO.CollectionChanged += FixupSUBPRODUCTO;
                }
                return _sUBPRODUCTO;
            }
            set
            {
                if (!ReferenceEquals(_sUBPRODUCTO, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_sUBPRODUCTO != null)
                    {
                        _sUBPRODUCTO.CollectionChanged -= FixupSUBPRODUCTO;
                    }
                    _sUBPRODUCTO = value;
                    if (_sUBPRODUCTO != null)
                    {
                        _sUBPRODUCTO.CollectionChanged += FixupSUBPRODUCTO;
                    }
                    OnNavigationPropertyChanged("SUBPRODUCTO");
                }
            }
        }
        private TrackableCollection<SUBPRODUCTO> _sUBPRODUCTO;

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
            SUBPRODUCTO.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupSUBPRODUCTO(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (SUBPRODUCTO item in e.NewItems)
                {
                    item.GRUPOTERAPEUTICO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("SUBPRODUCTO", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SUBPRODUCTO item in e.OldItems)
                {
                    if (ReferenceEquals(item.GRUPOTERAPEUTICO, this))
                    {
                        item.GRUPOTERAPEUTICO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("SUBPRODUCTO", item);
                    }
                }
            }
        }

        #endregion
    }
}
