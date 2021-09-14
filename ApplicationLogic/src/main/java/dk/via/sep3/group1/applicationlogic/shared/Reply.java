package dk.via.sep3.group1.applicationlogic.shared;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Reply {
    public final String SEEDING_SUCCESS = "SEEDING_SUCCESS";
    public final String ACCOUNT_BY_USERNAME = "ACCOUNT_BY_USERNAME";
    public final String BAD_REQUEST = "BAD_REQUEST";
    public final String SEND_ENTITY = "SEND_ENTITY";
    public final String SEND_MEMBER = "SEND_MEMBER";
    public final String SEND_FACILITY = "SEND_FACILITY";
    public final String SEND_ALL_ACCOUNT_TYPES = "SEND_ALL_ACCOUNT_TYPES";
    public final String SEND_ROLE = "SEND_ROLE";
    public final String SEND_ACCOUNT = "SEND_ACCOUNT";
    public final String ACCOUNT_ADDED = "ACCOUNT_ADDED";
    public final String VERIFY_CREDIT_CARD_TO_ACCOUNT = "VERIFY_CREDIT_CARD_TO_ACCOUNT";
    public final String CHECK_CREDIT_CARD_REPLY = "CHECK_CREDIT_CARD_REPLY";
    public final String DEPOSIT_MONEY_REPLY = "DEPOSIT_MONEY_REPLY";
    public final String SEND_ACCOUNT_BY_ACCOUNT_ID = "SEND_ACCOUNT_BY_ACCOUNT_ID";
    public final String UPDATED_ACCOUNT = "UPDATED_ACCOUNT";
    public final String CREATED_TRANSACTION = "CREATED_TRANSACTION";
    @JsonProperty("type")
    private String type;
    @JsonProperty("payload")
    private String payload;

    public Reply() {
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Reply(String type, String payload) {
        this.type = type;
        this.payload = payload;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }
}
