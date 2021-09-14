package dk.via.sep3.group1.applicationlogic.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.Transaction;
import dk.via.sep3.group1.applicationlogic.service.TransactionService;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/transaction")
public class TransactionController {
    @Autowired
    TransactionService transactionService;


    @PostMapping(path = "/maketransaction", consumes = "application/json", produces = "application/json")
    public ResponseEntity makeTransaction(@RequestBody String transaction) {
        Transaction deserializedTransaction;
        System.out.println("Controller received: " + transaction);
        try {
            deserializedTransaction = Serialization.deserialize(transaction, Transaction.class);
            Transaction transaction1 = transactionService.makeTransaction(deserializedTransaction);
            return new ResponseEntity(transaction1, HttpStatus.OK);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return new ResponseEntity(e.getMessage(), HttpStatus.NOT_ACCEPTABLE);
        }

    }


}
