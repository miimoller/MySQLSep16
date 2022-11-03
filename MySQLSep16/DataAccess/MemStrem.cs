using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal static class MemStrem
    {
        public static void Clear(this MemoryStream source)
        {
            byte[] buffer = source.GetBuffer();
            Array.Clear(buffer, 0, buffer.Length);
            source.Position = 0;
            source.SetLength(0);
        }
    }
}
