using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class Program
{
    static void Main()
    {
        using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out))
        using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.GetClientHandleAsString()))
        {
            Thread writerThread = new Thread(() => WriteToPipe(pipeServer));
            Thread readerThread = new Thread(() => ReadFromPipe(pipeClient));

            writerThread.Start();
            readerThread.Start();

            writerThread.Join();
            readerThread.Join();
        }
    }

    static void WriteToPipe(PipeStream pipe)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(pipe))
            {
                writer.AutoFlush = true;
                for (int i = 1; i <= 5; i++)
                {
                    writer.WriteLine($"Message {i}");
                    Thread.Sleep(500);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Write error: " + ex.Message);
        }
    }

    static void ReadFromPipe(PipeStream pipe)
    {
        try
        {
            using (StreamReader reader = new StreamReader(pipe))
            {
                string message = reader.ReadLine();
                Console.WriteLine("Received message: " + message);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Reader error: " + ex.Message);
        }
    }
}
