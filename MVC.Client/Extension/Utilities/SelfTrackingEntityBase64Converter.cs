

using System;
using System.IO;
using System.Runtime.Serialization;

namespace MVC.Client.Extensions.Utilities
{
    /// <summary>
    /// This class serializes and deserializes an entity to a base 64 string.
    /// </summary>
    /// <typeparam name="T">Type of the entity to be serialized or deserialized.</typeparam>
    public class SelfTrackingEntityBase64Converter<T>
    {
        #region Members

        /// <summary>
        /// Deserializes the entity from a base 64 string.
        /// </summary>
        /// <param name="value">The base 64 string containing the serialized entity.</param>
        /// <returns>The resulting entity after deserialization.</returns>
        public T ToEntity(string value)
        {
            var bytes = Convert.FromBase64String(value);
            MemoryStream memStream = new MemoryStream(bytes);
            DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
            T result = (T)deserializer.ReadObject(memStream);
            return result;
        }

        /// <summary>
        /// Serialized the entity to a base 64 string.
        /// </summary>
        /// <param name="entity">The entity to be serialized.</param>
        /// <returns>The base 64 string containing the serialized entity.</returns>
        public string ToBase64(T entity)
        {

            MemoryStream memStream = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(memStream, entity);
            string result = Convert.ToBase64String(memStream.ToArray());
            return result;
        }

        #endregion
    }
}