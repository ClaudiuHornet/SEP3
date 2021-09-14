package dk.via.sep3.group1.applicationlogic.service;

import dk.via.sep3.group1.applicationlogic.model.Account;

public interface LoginService {

    Account validateAccount(String passwordHashed, String username) throws IllegalAccessException;
}
