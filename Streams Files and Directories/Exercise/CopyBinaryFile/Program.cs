using System;
using System.IO;

namespace CopyBinaryFile
{
    public class Program
    {
        public static void Main()
        {
            using (FileStream writer = new FileStream("output.png", FileMode.OpenOrCreate))
            {
                using (FileStream reader = new FileStream("copyMe.png", FileMode.Open))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];
                        var read = reader.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            break;
                        }
                        else if(read<buffer.Length)
                        {
                            writer.Write(buffer,0,read);
                            break;
                        }
                        else
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                    
                }
            }            
        }
    }
}
