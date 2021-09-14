package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.DbSeedingDAO;
import dk.via.sep3.group1.applicationlogic.service.DbSeedingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DbSeedingServiceImpl implements DbSeedingService {

    @Autowired
    DbSeedingDAO dbSeedingDAO;

    @Override
    public void seedDatabase() {
        dbSeedingDAO.seedDatabase();
    }
}
