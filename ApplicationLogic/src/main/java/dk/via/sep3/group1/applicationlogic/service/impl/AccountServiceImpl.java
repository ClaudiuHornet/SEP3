package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.*;
import dk.via.sep3.group1.applicationlogic.model.*;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class AccountServiceImpl implements AccountService {

    @Autowired
    AccountDAO accountDAO;
    @Autowired
    ViaEntityDAO viaEntityDAO;
    @Autowired
    MemberDAO memberDAO;
    @Autowired
    FacilityDAO facilityDAO;
    @Autowired
    RoleDAO roleDAO;

    @Override
    public ViaEntity checkViaAccount(ViaEntity entityToCheck) throws Exception {

        ViaEntity viaEntity = null;
        try {
            viaEntity = viaEntityDAO.getViaEntityWithId(entityToCheck.getViaId());
            if (viaEntity.getPassword().equals(entityToCheck.getPassword())){
                if (!accountDAO.checkAccountWithViaId(entityToCheck.getViaId())){

                    //check if account exists for this via entity
                    //if passwords match get the actual via member or facility

                    Member dbMember = memberDAO.getMemberWithId(entityToCheck.getViaId());
                    if (dbMember != null){
                        return dbMember;
                    } else {
                        Facility facility = facilityDAO.getFacilityWithId(entityToCheck.getViaId());
                        if (facility != null){
                            return facility;
                        } else {
                            throw new Exception("Not found. Please check credentials");
                        }
                    }
                } else {
                    throw new Exception(entityToCheck.getViaId() + " already has an account");
                }
            } else{
                throw new IllegalAccessException("Not found. Please check credentials");
            }
        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }
    }

    @Override
    public void createAccount(Account accountToCreate)  throws Exception{

        System.out.println("*** service ***");
        //check if via id already has an account
        if(!accountDAO.checkAccountWithViaId(accountToCreate.getViaEntity().getViaId())){
            System.out.println("*** setting balance and role and sending account");
            // balance = 0
            accountToCreate.setBalance(0);
            // add correct role id
            Role roleWithId = roleDAO.getRoleWithType(accountToCreate.getAccountType().getRoleType());
            accountToCreate.setAccountType(roleWithId);

            accountDAO.addAccount(accountToCreate);
        } else {
            throw new Exception("Account already exists");
        }
    }
}
