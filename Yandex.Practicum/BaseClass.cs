using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum
{
    public class BaseClass
    {
        protected internal static TextReader _reader;
        protected internal static TextWriter _writer;

        internal protected virtual void InitReaderAndWriter()
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());
        }

        internal protected virtual void CloseReaderAndWriter()
        {
            _reader.Close();
            _writer.Close();
        }
    }
}
