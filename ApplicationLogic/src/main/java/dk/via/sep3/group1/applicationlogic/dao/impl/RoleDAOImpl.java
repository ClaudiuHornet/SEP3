package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.RoleDAO;
import dk.via.sep3.group1.applicationlogic.model.Role;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class RoleDAOImpl implements RoleDAO {

    @Autowired
    DataClientImpl dataClient;

    @Override
    public List<String> getAllAccountTypes() {
        Request request = new Request();
        request.setPayload(null);
        request.setType(request.GET_ALL_ACCOUNT_TYPES);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.SEND_ALL_ACCOUNT_TYPES)){
            List<String> allAccountTypes = Serialization.deserialize(reply.getPayload(), List.class);
            return allAccountTypes;
        } else
            throw new NullPointerException(reply.BAD_REQUEST);
    }

    @Override
    public Role getRoleWithType(String roleType) {

        Request request = new Request();
        request.setPayload(Serialization.serialize(roleType));
        request.setType(request.GET_ROLE_WITH_TYPE);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.SEND_ROLE)){
            Role role = Serialization.deserialize(reply.getPayload(), Role.class);
            return role;
        } else{
            throw new NullPointerException(reply.BAD_REQUEST);
        }
    }
}
