package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;


public class Facility extends ViaEntity {
    @JsonProperty("name")
    private String name;
    @JsonProperty("campus")
    private Campus campus;

    public Facility() {
    }

    public Facility(int viaId, String password, String name, Campus campus, Account account) {
        super(viaId, password);
        this.name = name;
        this.campus = campus;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "Facility{" +
                "name='" + name + '\'' +
                ", campus=" + campus +
                '}';
    }

    public Campus getCampus() {
        return campus;
    }

    public void setCampus(Campus campus) {
        this.campus = campus;
    }
}
