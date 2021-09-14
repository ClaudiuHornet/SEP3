package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.MemberDAO;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class MemberDAOImpl implements MemberDAO {

    @Autowired
    DataClient dataClient;


    @Override
    public Member getMemberWithId(int id) {
        System.out.println("looking for member with id: " + id);
        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_MEMBER_WITH_ID);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.SEND_MEMBER)){
            Member member = Serialization.deserialize(reply.getPayload(), Member.class);
            System.out.println(member);
            return member;
        }
        return null;
    }
}
