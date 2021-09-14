package dk.via.sep3.group1.applicationlogic.service;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;

public interface CreditCardService {
    boolean checkCreditCard(int id);
    boolean depositMoney(Account account);
    void addCreditCardToAccount(CreditCard creditCard) throws IllegalAccessException;
}
