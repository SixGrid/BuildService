using System;
using System.Collections.Generic;
using System.Text;

namespace BuildServiceCommon.Helpers
{
    public class DatabaseHelper
    {
        public delegate void ReadHandler(SerializationReader reader);
        public delegate void WriteHandler(SerializationWriter writer);

        public static bool Read(string filename, ReadHandler handler, VoidDelegate onFail = null)
        {
            if (!File.Exists(filename)) return false;

            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (SerializationReader reader = new SerializationReader(stream))
                {
                    handler(reader);
                    return true;
                }
            }
            catch (Exception e)
            {
                onFail?.Invoke();

                try
                {
                    GeneralHelper.CreateBackup(filename);
                }
                catch { }

                return false;
            }
        }

        public static bool Write(string filename, WriteHandler handler)
        {
            try
            {
                using (SafeWriteStream stream = new SafeWriteStream(filename))
                using (SerializationWriter writer = new SerializationWriter(stream))
                {
                    try
                    {
                        handler(writer);
                        return true;
                    }
                    catch
                    {
                        stream.Abort();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
