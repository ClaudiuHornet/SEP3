package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.service.LoginService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

@RestController
@RequestMapping(value = "/login")
public class LoginController {

    @Autowired
    LoginService loginService;


    @GetMapping()
    public ResponseEntity validateUser(@RequestParam("username") String username, @RequestParam("password") String password) {
        System.out.println("Controller - Username from client: " + username);
        System.out.println("Controller - Password from client: " + password);

        try {
            Account account = loginService.validateAccount(password, username);
            return new ResponseEntity(account, HttpStatus.OK);
        } catch (Exception e) {
           return new ResponseEntity(e.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
}

