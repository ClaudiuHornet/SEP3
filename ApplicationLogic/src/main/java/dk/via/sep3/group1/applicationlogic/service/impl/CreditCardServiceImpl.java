package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.CreditCardDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.service.CreditCardService;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CreditCardServiceImpl implements CreditCardService {

    @Autowired
    CreditCardDAO creditCardDAO;

    @Override
    public void addCreditCardToAccount(CreditCard creditCard) throws IllegalAccessException {
        if (creditCard.getCreditCardNumber() == null || creditCard.getCreditCardNumber().length() != 16 || creditCard.getCreditCardNumber() == null ||creditCard.getFirstName() == null || creditCard.getLastName() == null ||
                creditCard.getSecurityCode() < 0 || creditCard.getSecurityCode() > 999) {
            throw new IllegalAccessException("Provided credit card information is invalid");
        } else {
            try {
                creditCardDAO.addCreditCardToAccount(creditCard);
            }
            catch (Exception e){
                throw new IllegalAccessException(creditCardDAO.addCreditCardToAccount(creditCard));
            }
        }
    }

    @Override
    public boolean checkCreditCard(int id) {
        return creditCardDAO.checkCreditCard(id);
    }

    @Override
    public boolean depositMoney(Account account) {
        return creditCardDAO.depositMoney(account);
    }
}