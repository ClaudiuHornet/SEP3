package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.service.LoginService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

@Service
public class LoginServiceImpl implements LoginService {
    @Autowired
    AccountDAO accountDAO;


    @Override
    public Account validateAccount(String passwordHashed, String username) throws IllegalAccessException {
        Account account = accountDAO.getAccountByUsername(username);

        System.out.println("-------> Hashed password from client: " + passwordHashed);
        System.out.println("-------> Account type from DAO: " + account.getAccountType().getRoleType());
        System.out.println("-------> Hashed password from DB: " + account.getApplicationPassword());


        if (account.getApplicationPassword().equals(passwordHashed)) {
            System.out.println("Password match");
            return account;
        }

        throw new IllegalAccessException("Not found. Please check credentials");
    }
}


