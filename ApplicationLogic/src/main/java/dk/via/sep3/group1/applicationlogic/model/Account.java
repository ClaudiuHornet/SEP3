package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Account {

    @JsonProperty("accountId")
    private int accountId;
    @JsonProperty("viaEntity")
    private ViaEntity viaEntity;
    @JsonProperty("accountType")
    private Role accountType;
    @JsonProperty("applicationPassword")
    private String applicationPassword;
    @JsonProperty("balance")
    private float balance = 0;

    public Account() {
    }

    public int getAccountId() {
        return accountId;
    }

    public void setAccountId(int accountId) {
        this.accountId = accountId;
    }

    public ViaEntity getViaEntity() {
        return viaEntity;
    }

    public void setViaEntity(ViaEntity viaEntity) {
        this.viaEntity = viaEntity;
    }

    public Role getAccountType() {
        return accountType;
    }

    public void setAccountType(Role accountType) {
        this.accountType = accountType;
    }

    public String getApplicationPassword() {
        return applicationPassword;
    }

    public void setApplicationPassword(String applicationPassword) {
        this.applicationPassword = applicationPassword;
    }

    public float getBalance() {
        return balance;
    }

    public void setBalance(float balance) {
        this.balance = balance;
    }

    @Override
    public String toString() {
        return "Account{" +
                "accountId=" + accountId +
                ", viaEntity=" + viaEntity +
                ", accountType=" + accountType +
                ", applicationPassword='" + applicationPassword + '\'' +
                ", balance=" + balance +
                '}';
    }
}
