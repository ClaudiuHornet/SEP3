package dk.via.sep3.group1.applicationlogic;

import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.sql.Timestamp;
import java.util.Calendar;

@SpringBootApplication
public class ApplicationLogicApplication {

    public static void main(String[] args) {
        SpringApplication.run(ApplicationLogicApplication.class, args);
    }

}
