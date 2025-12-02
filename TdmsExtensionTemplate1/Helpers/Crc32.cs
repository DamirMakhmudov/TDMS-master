using System;
using System.IO;
using System.Linq;
using static TdmsExtension.TdmsExtensionTemplate1.Helpers.TypeConverterExtension;

namespace TdmsExtension.TdmsExtensionTemplate1.Helpers;

public class Crc32
{
    private uint[] table = new uint[256];
    public uint[] Table { get { return table; } }

    public Crc32()
    {
        MakeCrcTable();
    }
    private void MakeCrcTable()
    {
        for (uint n = 0; n < 256; n++)
        {
            uint value = n;
            for (int i = 0; i < 8; i++)
            {
                if ((value & 1) != 0)
                    value = 0xedb88320 ^ (value >> 1);
                else
                    value = value >> 1;
            }
            Table[n] = value;
        }
    }
    public uint UpdateCrc(uint crc, byte[] buffer, int length)
    {
        uint result = crc;
        for (int n = 0; n < length; n++)
        {
            result = Table[(result ^ buffer[n]) & 0xff] ^ (result >> 8);
        }
        return result;
    }

    public uint Calculate(Stream stream)
    {
        long pos = stream.Position;
        const int size = 0x32000;
        byte[] buf = new byte[size];
        int bytes = 0;
        uint result = 0xffffffff;
        do
        {
            bytes = stream.Read(buf, 0, size);
            result = UpdateCrc(result, buf, bytes);
        }
        while (bytes == size);
        stream.Position = pos;
        return ~result;
    }
    public uint Calculate(byte[] Bytes)
    {
        if (Bytes != null && Bytes.Length > 0) return Calculate(new MemoryStream(Bytes)); return 0;
    }
    public uint Calculate(UInt32[] uArray)
    {
        if (uArray != null && uArray.Length > 0)
        {
            uint result = 0xffffffff;
            int x = 0, usiz = sizeof(UInt32), bArrayLength = uArray.Length * usiz;
            byte[] buf = new byte[bArrayLength];
            foreach (uint u in uArray) UInt322Bytes(u, ref buf, ref x);
            result = UpdateCrc(result, buf, bArrayLength);
            return result;
        }
        return 0;
    }
    public uint CalcUInt32(params UInt32[] uValue) { return Calculate(uValue); }
    public uint CalcInt32(params Int32[] iValue)
    {
        if (iValue != null && iValue.Length > 0)
        {
            UInt32[] uValue = (from i in iValue select (uint)i).ToArray();
            return Calculate(uValue);
        }
        return 0;
    }
    public uint CalcObject(object? oValue) =>
        oValue == null
        ? 0
        : Calculate(new MemoryStream((byte[])oValue));

}
