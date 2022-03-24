using Newtonsoft.Json;

namespace SqsNotificationReader.Models
{
    internal class SqsMessage
    {
        public List<Record>? Records { get; set; }

        public class UserIdentity
        {
            public string? principalId { get; set; }
        }

        public class RequestParameters
        {
            public string? sourceIPAddress { get; set; }
        }

        public class ResponseElements
        {
            [JsonProperty("x-amz-request-id")]
            public string? XAmzRequestId { get; set; }

            [JsonProperty("x-amz-id-2")]
            public string? XAmzId2 { get; set; }
        }

        public class OwnerIdentity
        {
            public string? principalId { get; set; }
        }

        public class Bucket
        {
            public string? name { get; set; }
            public OwnerIdentity? ownerIdentity { get; set; }
            public string? arn { get; set; }
        }

        public class Object
        {
            public string? key { get; set; }
            public long? size { get; set; }
            public string? eTag { get; set; }
            public string? versionId { get; set; }
            public string? sequencer { get; set; }
        }

        public class S3
        {
            public string? s3SchemaVersion { get; set; }
            public string? configurationId { get; set; }
            public Bucket? bucket { get; set; }
            public Object? @object { get; set; }
        }

        public class Record
        {
            public string? eventVersion { get; set; }
            public string? eventSource { get; set; }
            public string? awsRegion { get; set; }
            public DateTime eventTime { get; set; }
            public string? eventName { get; set; }
            public UserIdentity? userIdentity { get; set; }
            public RequestParameters? requestParameters { get; set; }
            public ResponseElements? responseElements { get; set; }
            public S3? s3 { get; set; }
        }
    }
}
