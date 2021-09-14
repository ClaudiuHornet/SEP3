package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class ViaEntity {
    @JsonProperty("viaId")
    private int viaId;
    @JsonProperty("password")
    private String password;

    public ViaEntity() {
    }

    public ViaEntity(int viaId, String password) {
        this.viaId = viaId;
        this.password = password;
    }

    public int getViaId() {
        return viaId;
    }

    public void setViaId(int viaId) {
        this.viaId = viaId;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "ViaEntity{" +
                "viaId=" + viaId +
                ", password='" + password + '\'' +
                '}';
    }

}
