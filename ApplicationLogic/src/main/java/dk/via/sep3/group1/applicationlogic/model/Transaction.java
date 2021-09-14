package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;


import java.sql.Timestamp;
import java.util.Date;

public class Transaction {
    @JsonProperty("id")
    private int id;
    @JsonProperty("receiverAccount")
    private Account receiverAccountId;
    @JsonProperty("senderAccount")
    private Account senderAccountId;
    @JsonProperty("amount")
    private float amount;
    @JsonProperty("comment")
    private String comment;
    @JsonProperty("type")
    private String type;
    @JsonProperty("timestamp")
    private String timestamp;

    public Transaction() {
    }

    public Account getReceiverAccountId() {
        return receiverAccountId;
    }

    public void setReceiverAccountId(Account receiverAccountId) {
        this.receiverAccountId = receiverAccountId;
    }

    public Account getSenderAccountId() {
        return senderAccountId;
    }

    public void setSenderAccountId(Account senderAccountId) {
        this.senderAccountId = senderAccountId;
    }

    public float getAmount() {
        return amount;
    }

    public void setAmount(float amount) {
        this.amount = amount;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(String timestamp) {
        this.timestamp = timestamp;
    }
}
