namespace PersistenceServer.shared
{
    public class Request
    {
        public const string SEED_DATABASE = "SEED_DATABASE";
        public const string GET_ACCOUNT_BY_USERNAME = "GET_ACCOUNT_BY_USERNAME";
        public const string GET_ENTITY_WITH_ID = "GET_ENTITY_WITH_ID";
        public const string GET_MEMBER_WITH_ID = "GET_MEMBER_WITH_ID";
        public const string GET_FACILITY_WITH_ID = "GET_FACILITY_WITH_ID";
        public const string GET_ALL_ACCOUNT_TYPES = "GET_ALL_ACCOUNT_TYPES";
        public const string GET_ROLE_WITH_TYPE = "GET_ROLE_WITH_TYPE";
        public const string GET_ACCOUNT_WITH_VIA_ID = "GET_ACCOUNT_WITH_VIA_ID";
        public const string ADD_ACCOUNT = "ADD_ACCOUNT";
        public const string ADD_CREDIT_CARD_TO_ACCOUNT = "ADD_CREDIT_CARD_TO_ACCOUNT";
        public const string CHECK_CREDIT_CARD = "CHECK_CREDIT_CARD";
        public const string DEPOSIT_MONEY = "DEPOSIT_MONEY";
        public const string GET_ACCOUNT_BY_ACCOUNT_ID = "GET_ACCOUNT_BY_ACCOUNT_ID";
        public const string UPDATE_ACCOUNT = "UPDATE_ACCOUNT";
        public const string CREATE_TRANSACTION = "CREATE_TRANSACTION";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Request(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }

        public Request()
        {
        }
    }
}