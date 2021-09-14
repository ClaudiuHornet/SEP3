package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.Role;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.HttpStatusCodeException;
import org.springframework.web.server.ResponseStatusException;

@RestController
@RequestMapping("/account")
public class AccountController {

    @Autowired
    AccountService accountService;

    @GetMapping
    public ResponseEntity checkViaEntity(@RequestParam int id, @RequestParam String password){
        System.out.println("Controller received: " + id+ "      " + password);

        try {
            ViaEntity viaEntity = accountService.checkViaAccount(new ViaEntity(id, password));
            return new ResponseEntity(viaEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity(e.getMessage(), HttpStatus.NOT_FOUND);
        }
    }

    @PostMapping
    public ResponseEntity createAccount(@RequestBody Account account){
        System.out.println("creating account: " + account);
        try {
            accountService.createAccount(account);
            return new ResponseEntity(HttpStatus.OK);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return new ResponseEntity(e.getMessage(), HttpStatus.I_AM_A_TEAPOT);
        }
    }
}
