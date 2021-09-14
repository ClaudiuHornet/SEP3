package dk.via.sep3.group1.applicationlogic.dao;

import dk.via.sep3.group1.applicationlogic.model.Account;

public interface AccountDAO {
    Account getAccountByUsername(String username);

    boolean checkAccountWithViaId(int viaId);

    Account addAccount(Account accountToCreate);
}
