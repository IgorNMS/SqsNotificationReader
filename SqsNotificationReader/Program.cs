using SqsNotificationReader.Services;

namespace SqsNotificationReader
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Programa iniciado!!");
            SqsService sqsService = new SqsService();
            sqsService.IGetSqsMessage();
        }
    }
}