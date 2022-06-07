using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum
{
    public static class Common
    {
        public static int ReadInt(TextReader reader)
        {
            return int.Parse(reader.ReadLine());
        }

        public static List<int> ReadList(TextReader reader)
        {
            return reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
