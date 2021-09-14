package dk.via.sep3.group1.applicationlogic.shared;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.io.Serializable;

public class Request {
    public final String SEED_DATABASE = "SEED_DATABASE";
    public final String GET_ACCOUNT_BY_USERNAME = "GET_ACCOUNT_BY_USERNAME";
    public final String GET_ENTITY_WITH_ID = "GET_ENTITY_WITH_ID";
    public final String GET_MEMBER_WITH_ID = "GET_MEMBER_WITH_ID";
    public final String GET_FACILITY_WITH_ID = "GET_FACILITY_WITH_ID";
    public final String GET_ALL_ACCOUNT_TYPES = "GET_ALL_ACCOUNT_TYPES";
    public final String GET_ROLE_WITH_TYPE = "GET_ROLE_WITH_TYPE";
    public final String GET_ACCOUNT_WITH_VIA_ID = "GET_ACCOUNT_WITH_VIA_ID";
    public final String ADD_ACCOUNT = "ADD_ACCOUNT";
    public final String ADD_CREDIT_CARD_TO_ACCOUNT = "ADD_CREDIT_CARD_TO_ACCOUNT";
    public final String CHECK_CREDIT_CARD = "CHECK_CREDIT_CARD";
    public final String DEPOSIT_MONEY = "DEPOSIT_MONEY";
    public final String GET_ACCOUNT_BY_ACCOUNT_ID = "GET_ACCOUNT_BY_ACCOUNT_ID";
    public final String UPDATE_ACCOUNT = "UPDATE_ACCOUNT";
    public final String CREATE_TRANSACTION = "CREATE_TRANSACTION";
    @JsonProperty("type")
    private String type;
    @JsonProperty("payload")
    private String payload;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Request(String type, String payload) {
        this.type = type;
        this.payload = payload;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }

    @Override
    public String toString() {
        return "Request{" +
                "type='" + type + '\'' +
                ", payload='" + payload + '\'' +
                '}';
    }

    public Request() {
    }
}
