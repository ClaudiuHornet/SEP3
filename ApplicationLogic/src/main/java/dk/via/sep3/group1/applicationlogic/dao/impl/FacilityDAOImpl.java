package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.FacilityDAO;
import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class FacilityDAOImpl implements FacilityDAO {

    @Autowired
    DataClient dataClient;

    @Override
    public Facility getFacilityWithId(int id) {
        System.out.println("looking for facility with id: " + id);
        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_FACILITY_WITH_ID);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.SEND_FACILITY)){
            Facility facility = Serialization.deserialize(reply.getPayload(), Facility.class);
            System.out.println(facility);
            return facility;
        }
        return null;
    }
}
