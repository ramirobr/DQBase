using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Globalization;

namespace DQBase.Entities
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Convierte un ListItemCollection en una lista generica de ListItem
        /// </summary>
        /// <param name="collection">Coleccion a convertir</param>
        /// <exception cref="System.ArgumentNullException">La colecion no debe ser nula</exception>
        /// <returns></returns>
        public static List<ListItem> ToList(this ListItemCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "collection is null");
            List<ListItem> result = new List<ListItem>();
            foreach (ListItem item in collection)
                result.Add(item);
            return result;
        }

        /// <summary>
        /// Convierte un GridViewRowCollection en una lista generica de GridViewRow
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<GridViewRow> ToList(this GridViewRowCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "collection is null");
            List<GridViewRow> result = new List<GridViewRow>();
            foreach (GridViewRow item in collection)
                result.Add(item);
            return result;
        }

        /// <summary>
        /// Convierte un TableCellCollection en una lista generica de TableCell
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<TableCell> ToList(this TableCellCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "collection is null");
            List<TableCell> result = new List<TableCell>();
            foreach (TableCell item in collection)
                result.Add(item);
            return result;
        }

        /// <summary>
        /// Get the value of the property name
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="entity">Entity of the property</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>The value of the property</returns>
        public static T GetPropertyValue<T>(this object entity, string propertyName)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var type = entity.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo == null)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "The class {0} doesn't have a property named {1}.", type.ToString(), propertyName));
            return (T)propertyInfo.GetValue(entity, null);
        }
    }
}
