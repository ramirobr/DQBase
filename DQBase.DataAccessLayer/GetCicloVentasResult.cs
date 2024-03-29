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
    
    public partial class GetCicloVentasResult : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string Laboratorio
        {
            get { return _laboratorio; }
            set
            {
                if (_laboratorio != value)
                {
                    OnComplexPropertyChanging();
                    _laboratorio = value;
                    OnPropertyChanged("Laboratorio");
                }
            }
        }
        private string _laboratorio;
    
        [DataMember]
        public double CantidadVentaAnterior
        {
            get { return _cantidadVentaAnterior; }
            set
            {
                if (_cantidadVentaAnterior != value)
                {
                    OnComplexPropertyChanging();
                    _cantidadVentaAnterior = value;
                    OnPropertyChanged("CantidadVentaAnterior");
                }
            }
        }
        private double _cantidadVentaAnterior;
    
        [DataMember]
        public double TotalVentaAnterior
        {
            get { return _totalVentaAnterior; }
            set
            {
                if (_totalVentaAnterior != value)
                {
                    OnComplexPropertyChanging();
                    _totalVentaAnterior = value;
                    OnPropertyChanged("TotalVentaAnterior");
                }
            }
        }
        private double _totalVentaAnterior;
    
        [DataMember]
        public double CantidadVentaActual
        {
            get { return _cantidadVentaActual; }
            set
            {
                if (_cantidadVentaActual != value)
                {
                    OnComplexPropertyChanging();
                    _cantidadVentaActual = value;
                    OnPropertyChanged("CantidadVentaActual");
                }
            }
        }
        private double _cantidadVentaActual;
    
        [DataMember]
        public double TotalVentaActual
        {
            get { return _totalVentaActual; }
            set
            {
                if (_totalVentaActual != value)
                {
                    OnComplexPropertyChanging();
                    _totalVentaActual = value;
                    OnPropertyChanged("TotalVentaActual");
                }
            }
        }
        private double _totalVentaActual;

        #endregion
        #region ChangeTracking
    
        private void OnComplexPropertyChanging()
        {
            if (_complexPropertyChanging != null)
            {
                _complexPropertyChanging(this, new EventArgs());
            }
        }
    
        event EventHandler INotifyComplexPropertyChanging.ComplexPropertyChanging { add { _complexPropertyChanging += value; } remove { _complexPropertyChanging -= value; } }
        private event EventHandler _complexPropertyChanging;
    
        private void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
        public static void RecordComplexOriginalValues(String parentPropertyName, GetCicloVentasResult complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Laboratorio", parentPropertyName), complexObject == null ? null : (object)complexObject.Laboratorio);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CantidadVentaAnterior", parentPropertyName), complexObject == null ? null : (object)complexObject.CantidadVentaAnterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TotalVentaAnterior", parentPropertyName), complexObject == null ? null : (object)complexObject.TotalVentaAnterior);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.CantidadVentaActual", parentPropertyName), complexObject == null ? null : (object)complexObject.CantidadVentaActual);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.TotalVentaActual", parentPropertyName), complexObject == null ? null : (object)complexObject.TotalVentaActual);
        }

        #endregion
    }
}
