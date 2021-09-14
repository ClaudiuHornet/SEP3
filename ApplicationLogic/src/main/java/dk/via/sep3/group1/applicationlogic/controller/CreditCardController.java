package dk.via.sep3.group1.applicationlogic.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.service.CreditCardService;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.http.HttpResponse;

@RestController
@RequestMapping("/creditcard")
public class CreditCardController {

    @Autowired
    CreditCardService creditCardService;
    ObjectMapper objectMapper = new ObjectMapper();

    @PostMapping(path = "/addcreditcard", consumes = "application/json", produces = "application/json")
    public ResponseEntity addCreditCardToAccount(@RequestBody String creditcard) {
        System.out.println(creditcard);
        CreditCard deserialized = null;
        try {
            deserialized = objectMapper.readValue(creditcard, CreditCard.class);
            creditCardService.addCreditCardToAccount(deserialized);
            return new ResponseEntity(HttpStatus.OK);
        } catch (JsonProcessingException | IllegalAccessException e) {
            return new ResponseEntity(e.getMessage(), HttpStatus.NOT_ACCEPTABLE);
        }
    }

    @GetMapping("checkcreditcard/{id}")
    public boolean checkCreditCard(@PathVariable int id)
    {
        boolean response = creditCardService.checkCreditCard(id);
        System.out.println("response got to controller : " + response);
        return response;
    }

    @PatchMapping("depositmoney")
    public boolean depositMoney(@RequestBody String Json)
    {
        Account account = null;
        try {
            account = objectMapper.readValue(Json, Account.class);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return creditCardService.depositMoney(account);
    }

}