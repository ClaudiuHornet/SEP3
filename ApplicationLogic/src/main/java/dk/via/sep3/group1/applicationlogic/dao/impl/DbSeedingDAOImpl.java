package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.DbSeedingDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class DbSeedingDAOImpl implements DbSeedingDAO {

    @Autowired
    DataClientImpl dataClient;

    @Override
    public void seedDatabase() {
        Request request = new Request();
        request.setPayload(null);
        request.setType(request.SEED_DATABASE);
        Reply reply = dataClient.handleRequest(request);
        if (reply.getType().equals(reply.SEEDING_SUCCESS)){
            System.out.println("seeding was successful");
        } else {
            System.out.println("seeding was not successful");
        }
    }
}
