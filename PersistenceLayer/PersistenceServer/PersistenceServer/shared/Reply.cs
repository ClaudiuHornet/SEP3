namespace PersistenceServer.shared
{
    public class Reply
    {
        public const string BAD_REQUEST = "BAD_REQUEST";
        public const string SEEDING_SUCCESS = "SEEDING_SUCCESS";
        public const string VERIFY_CREDIT_CARD_TO_ACCOUNT = "VERIFY_CREDIT_CARD_TO_ACCOUNT";
        public const string CHECK_CREDIT_CARD_REPLY = "CHECK_CREDIT_CARD_REPLY";
        public const string DEPOSIT_MONEY_REPLY = "DEPOSIT_MONEY_REPLY";
        public const string ACCOUNT_BY_USERNAME = "ACCOUNT_BY_USERNAME";
        public const string SEND_ENTITY = "SEND_ENTITY";
        public const string SEND_MEMBER = "SEND_MEMBER";
        public const string SEND_FACILITY = "SEND_FACILITY";
        public const string SEND_ALL_ACCOUNT_TYPES = "SEND_ALL_ACCOUNT_TYPES";
        public const string SEND_ROLE = "SEND_ROLE";
        public const string SEND_ACCOUNT = "SEND_ACCOUNT";
        public const string ACCOUNT_CREATED = "ACCOUNT_CREATED";
        public const string SEND_ACCOUNT_BY_ACCOUNT_ID = "SEND_ACCOUNT_BY_ACCOUNT_ID";
        public const string UPDATED_ACCOUNT = "UPDATED_ACCOUNT";
        public const string CREATED_TRANSACTION = "CREATED_TRANSACTION";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Reply(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}