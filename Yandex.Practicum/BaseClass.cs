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
        protected static TextReader _reader;
        protected static TextWriter _writer;

        protected static void InitReaderAndWriter()
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());
        }

        protected static void CloseReaderAndWriter()
        {
            _reader.Close();
            _writer.Close();
        }
    }
}
