package dk.via.sep3.group1.applicationlogic.service;


import dk.via.sep3.group1.applicationlogic.model.Transaction;

public interface TransactionService {
    Transaction makeTransaction(Transaction transaction) throws Exception;
}
