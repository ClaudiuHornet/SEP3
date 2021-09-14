package dk.via.sep3.group1.applicationlogic.controller;


import dk.via.sep3.group1.applicationlogic.service.DbSeedingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/seeddatabase")
public class DbSeedingController {

    @Autowired
    DbSeedingService dbSeedingService;

    @GetMapping
    public void seedDatabase(){
        System.out.println("controller received seeding request");
        dbSeedingService.seedDatabase();
    }
}
