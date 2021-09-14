package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.TransactionDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.Transaction;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class TransactionDAOImpl implements TransactionDAO {
    @Autowired
    DataClient dataClient;

    @Override
    public Account getAccountByVIAID(int viaid) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(viaid));
        request.setType(request.GET_ACCOUNT_WITH_VIA_ID);

        Reply reply = dataClient.handleRequest(request);
        return Serialization.deserialize(reply.getPayload(), Account.class);
    }

    @Override
    public Account getAccountByAccountID(int accountID) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(accountID));
        request.setType(request.GET_ACCOUNT_BY_ACCOUNT_ID);

        Reply reply = dataClient.handleRequest(request);
        return Serialization.deserialize(reply.getPayload(), Account.class);
    }

    @Override
    public Account updateAccountsBalance(Account account) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(account));
        request.setType(request.UPDATE_ACCOUNT);

        Reply reply = dataClient.handleRequest(request);
        return Serialization.deserialize(reply.getPayload(), Account.class);
    }

    @Override
    public Transaction addTransaction(Transaction transaction) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(transaction));
        System.out.println(Serialization.serialize(transaction));
        request.setType(request.CREATE_TRANSACTION);

        Reply reply = dataClient.handleRequest(request);
        return Serialization.deserialize(reply.getPayload(), Transaction.class);
    }
}
