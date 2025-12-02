using System;

namespace TdmsExtension.TdmsExtensionTemplate1.Helpers;

public static class TypeConverterExtension
{
    #region Bytes Convert Operation

    /// <summary>
    /// Конвертер UInt32 в 4 байта
    /// </summary>
    /// <param name="Value">Исходное число (UInt32)</param>
    /// <param name="Dest">Результирующий набор байт</param>
    /// <param name="DestStartIndex">Позиция в массиве Dest начиная с которой добавляются сконвертированные байты. После выполнения операции позиция смещается на 4</param>
    /// <returns>true - успешно</returns>
    public static bool UInt322Bytes(UInt32 Value, ref byte[] Dest, ref int DestStartIndex)
    {
        if (DestStartIndex >= 0 && DestStartIndex + sizeof(UInt32) <= Dest.Length)
        {
            byte[] bt = BitConverter.GetBytes(Value); int x = bt.Length;
            try
            {
                Array.Copy(bt, 0, Dest, DestStartIndex, x); DestStartIndex += x; return true;
            }
            catch { }
        }
        return false;
    }

    #endregion
}
