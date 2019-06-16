using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBox.Serialization
{
    public interface ISerializer
    {
        string ToJson<T>(T value);
        T FromJson<T>(string value);
        string ToXml<T>(T value);
        T FromXml<T>(string value);
        byte[] ToBinary<T>(T value);
        T FromBinary<T>(byte[] value);
        Stream ToBinaryStream<T>(T value);
        T FromBinaryStream<T>(Stream value);


    }
}
