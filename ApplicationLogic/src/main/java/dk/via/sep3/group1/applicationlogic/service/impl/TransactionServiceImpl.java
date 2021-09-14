package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.TransactionDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.Transaction;
import dk.via.sep3.group1.applicationlogic.service.TransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.TimeZone;

@Service
public class TransactionServiceImpl implements TransactionService {
    @Autowired
    TransactionDAO transactionDAO;

    @Override
    public Transaction makeTransaction(Transaction transaction) throws Exception {
        Account receiverAccount = transactionDAO.getAccountByVIAID(transaction.getReceiverAccountId().getViaEntity().getViaId());

        Account senderAccount = transactionDAO.getAccountByAccountID(transaction.getSenderAccountId().getAccountId());

        // check if balance is OK here
        if (transaction.getType().equals("Transfer")) {
            if (senderAccount.getBalance() >= transaction.getAmount()) {
                // Take money from sender's account
                float senderAccountBalanceUpdated = senderAccount.getBalance() - transaction.getAmount();

                senderAccount.setBalance(senderAccountBalanceUpdated);
                // update sender's account

                Account account = transactionDAO.updateAccountsBalance(senderAccount);

                // Add money to receiver's account
                // update sender's account
                float receiverAccountBalanceUpdated = receiverAccount.getBalance() + transaction.getAmount();
                receiverAccount.setBalance(receiverAccountBalanceUpdated);
                Account updateAccountsBalance = transactionDAO.updateAccountsBalance(receiverAccount);

                // register transaction
                Transaction transactionToSave = new Transaction();
                transactionToSave.setSenderAccountId(senderAccount);
                transactionToSave.setReceiverAccountId(receiverAccount);
                transactionToSave.setType(transaction.getType());
                transactionToSave.setAmount(transaction.getAmount());
                transactionToSave.setComment(transaction.getComment());
                transactionToSave.setTimestamp(getCurrentTimeAsString());

                Transaction addedTransaction = transactionDAO.addTransaction(transactionToSave);

                return addedTransaction;
            } else {
                throw new Exception("Insufficient funds");
            }
        }
        return null;
    }

    private String  getCurrentTimeAsString(){
        Calendar calendar = Calendar.getInstance();
        calendar.set(Calendar.MILLISECOND, 0);
        SimpleDateFormat sdf;
        sdf = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
        sdf.setTimeZone(TimeZone.getTimeZone("CET"));
        return sdf.format(calendar.getTime());
    }
}
