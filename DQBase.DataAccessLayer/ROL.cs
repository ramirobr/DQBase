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
    [KnownType(typeof(ROLMENU))]
    [KnownType(typeof(ROLUSUARIO))]
    public partial class ROL: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.Guid IDROL
        {
            get { return _iDROL; }
            set
            {
                if (_iDROL != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'IDROL' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _iDROL = value;
                    OnPropertyChanged("IDROL");
                }
            }
        }
        private System.Guid _iDROL;
    
        [DataMember]
        public string DESCRIPCIONROL
        {
            get { return _dESCRIPCIONROL; }
            set
            {
                if (_dESCRIPCIONROL != value)
                {
                    _dESCRIPCIONROL = value;
                    OnPropertyChanged("DESCRIPCIONROL");
                }
            }
        }
        private string _dESCRIPCIONROL;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<ROLMENU> ROLMENU
        {
            get
            {
                if (_rOLMENU == null)
                {
                    _rOLMENU = new TrackableCollection<ROLMENU>();
                    _rOLMENU.CollectionChanged += FixupROLMENU;
                }
                return _rOLMENU;
            }
            set
            {
                if (!ReferenceEquals(_rOLMENU, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_rOLMENU != null)
                    {
                        _rOLMENU.CollectionChanged -= FixupROLMENU;
                    }
                    _rOLMENU = value;
                    if (_rOLMENU != null)
                    {
                        _rOLMENU.CollectionChanged += FixupROLMENU;
                    }
                    OnNavigationPropertyChanged("ROLMENU");
                }
            }
        }
        private TrackableCollection<ROLMENU> _rOLMENU;
    
        [DataMember]
        public TrackableCollection<ROLUSUARIO> ROLUSUARIO
        {
            get
            {
                if (_rOLUSUARIO == null)
                {
                    _rOLUSUARIO = new TrackableCollection<ROLUSUARIO>();
                    _rOLUSUARIO.CollectionChanged += FixupROLUSUARIO;
                }
                return _rOLUSUARIO;
            }
            set
            {
                if (!ReferenceEquals(_rOLUSUARIO, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_rOLUSUARIO != null)
                    {
                        _rOLUSUARIO.CollectionChanged -= FixupROLUSUARIO;
                    }
                    _rOLUSUARIO = value;
                    if (_rOLUSUARIO != null)
                    {
                        _rOLUSUARIO.CollectionChanged += FixupROLUSUARIO;
                    }
                    OnNavigationPropertyChanged("ROLUSUARIO");
                }
            }
        }
        private TrackableCollection<ROLUSUARIO> _rOLUSUARIO;

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
            ROLMENU.Clear();
            ROLUSUARIO.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupROLMENU(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ROLMENU item in e.NewItems)
                {
                    item.ROL = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ROLMENU", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ROLMENU item in e.OldItems)
                {
                    if (ReferenceEquals(item.ROL, this))
                    {
                        item.ROL = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ROLMENU", item);
                    }
                }
            }
        }
    
        private void FixupROLUSUARIO(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ROLUSUARIO item in e.NewItems)
                {
                    item.ROL = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ROLUSUARIO", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ROLUSUARIO item in e.OldItems)
                {
                    if (ReferenceEquals(item.ROL, this))
                    {
                        item.ROL = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ROLUSUARIO", item);
                    }
                }
            }
        }

        #endregion
    }
}
