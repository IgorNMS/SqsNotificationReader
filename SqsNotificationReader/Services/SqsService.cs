using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using SqsNotificationReader.Data;
using SqsNotificationReader.Models;

namespace SqsNotificationReader.Services
{
    internal class SqsService
    {
        public void IGetSqsMessage()
        {
            GetSqsMessage();
        }

        private async void GetSqsMessage()
        {
            string accessKey = "";
            string secretKey = "";
            string sqsUrl = "";
            int waitTime = 10;
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var client = new AmazonSQSClient(credentials, RegionEndpoint.SAEast1);
            ReceiveMessageResponse messageResponse = await GetMessage(client, sqsUrl, waitTime);
            ProcessMessage(messageResponse);
        }

        private async Task<ReceiveMessageResponse> GetMessage(IAmazonSQS client, string sqsUrl, int waitTime)
        {
            try {
                ReceiveMessageResponse receivedMessage = await client.ReceiveMessageAsync(new ReceiveMessageRequest { QueueUrl = sqsUrl, WaitTimeSeconds = waitTime });
                return receivedMessage;
            }
            catch(Exception e) { 
                Console.WriteLine(e.Message);
                return null;
            }            
        }

        private void ProcessMessage(ReceiveMessageResponse messageResponse)
        {
            foreach (var message in messageResponse.Messages)
            {
                SqsMessage messageDb = JsonConvert.DeserializeObject<SqsMessage>(message.Body);
                foreach (var records in messageDb.Records)
                {
                    SqsFile sqsFile = new SqsFile
                    {
                        FileName = records.s3.@object.key,
                        FileSize = records.s3.@object.size,
                        LastModified = records.eventTime
                    };
                    WriteMessageDb(sqsFile);
                }
            }
        }

        private void WriteMessageDb(SqsFile sqsMessage)
        {
            using (var context = new FileContext())
            {
                context.SqsFiles.Add(sqsMessage);
                context.SaveChanges();
            }
        }
    }
}
