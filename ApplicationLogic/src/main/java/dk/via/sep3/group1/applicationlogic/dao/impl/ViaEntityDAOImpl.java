package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.ViaEntityDAO;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.serializer.support.SerializationFailedException;
import org.springframework.stereotype.Repository;

@Repository
public class ViaEntityDAOImpl implements ViaEntityDAO {

    @Autowired
    DataClient dataClient;

    @Override
    public ViaEntity getViaEntityWithId(int id){
        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_ENTITY_WITH_ID);

        Reply reply = dataClient.handleRequest(request);
        return Serialization.deserialize(reply.getPayload(), ViaEntity.class);
    }
}
