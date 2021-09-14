using PersistenceServer.Repository.Impl;

namespace PersistenceServer.Repository
{
    public static class RepositoryFactory
    {
        public static IDbSeedingRepository GetDbSeedingRepository()
        {
            return new DbSeedingRepositoryImpl();
        }

        public static IAccountRepository GetAccountRepository()
        {
            return new AccountRepositoryImpl();
        }

        public static IRoleRepository GetRoleRepository()
        {
            return new RoleRepositoryImpl();
        }

        public static IViaEntityRepository GetViaEntityRepository()
        {
            return new ViaEntityRepositoryImpl();
        }

        public static IMemberRepository GetMemberRepository()
        {
            return new MemberRepositoryImpl();
        }

        public static IFacilityRepository GetFacilityRepository()
        {
            return new FacilityRepositoryImpl();
        }
        public static ICreditCardRepository GetCreditCardRepository()
        {
            return new CreditCardRepositoryImpl();
        }

        public static ITransactionRepository GetTransactionRepository()
        {
            return new TransactionRepositoryImpl();
        }
    }
}