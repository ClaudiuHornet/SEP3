package dk.via.sep3.group1.applicationlogic.dao;


import dk.via.sep3.group1.applicationlogic.model.Role;

import java.util.List;

public interface RoleDAO {
    List<String> getAllAccountTypes();

    Role getRoleWithType(String roleType);
}
