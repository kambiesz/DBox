using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DBox.Serialization
{
    public class DefaultSerializer : ISerializer
    {
        public virtual T FromBinary<T>(byte[] value)
        {
            using (var ms = new MemoryStream(value))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }

        public virtual T FromBinaryStream<T>(Stream value)
        {
            return Serializer.Deserialize<T>(value);
        }

        public virtual T FromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public virtual T FromXml<T>(string value)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(value))
            {
                return (T)serializer.Deserialize(sr);
            }
        }

        public virtual byte[] ToBinary<T>(T value)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, value);
                return ms.ToArray();
            }
        }

        public virtual Stream ToBinaryStream<T>(T value)
        {
            var stream = new MemoryStream();
            Serializer.Serialize(stream, value);

            return stream;
        }

        public virtual string ToJson<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public virtual string ToXml<T>(T value)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, value);

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
