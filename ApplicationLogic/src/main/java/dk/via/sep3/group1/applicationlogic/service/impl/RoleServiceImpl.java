package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.RoleDAO;
import dk.via.sep3.group1.applicationlogic.service.RoleService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class RoleServiceImpl implements RoleService {

    @Autowired
    RoleDAO roleDAO;

    @Override
    public List<String> getAllAccountTypes() {
        return roleDAO.getAllAccountTypes();
    }
}
