using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using PersistenceServer.Data;
using PersistenceServer.Models;
using PersistenceServer.Repository;
using PersistenceServer.shared;

namespace PersistenceServer.Networking
{
    public class ServerHandler
    {
        private NetworkStream stream;

        public ServerHandler(TcpClient client)
        {
            stream = client.GetStream();
        }

        public async Task HandleRequest()
        {
            Request requestFromClient = new Request();

            try
            {
                string readFromStream = ReadFromStream();
                requestFromClient = ToObject<Request>(readFromStream);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}Bytes from stream could not be read and converted to an Request Object");
                throw new IncompleteInitialization();
            }

            switch (requestFromClient.Type)
            {
                case Request.SEED_DATABASE:
                    RepositoryFactory.GetDbSeedingRepository().SeedDatabase();
                    Reply seedingSuccessReply = new Reply(Reply.SEEDING_SUCCESS, null);
                    string toSend = ToJson(seedingSuccessReply);

                    SendToStream(toSend);
                    break;
                case Request.GET_ACCOUNT_BY_USERNAME:
                    await getAccountByUsername(requestFromClient);
                    break;
                case Request.GET_ENTITY_WITH_ID:
                    await GetEntityWithId(requestFromClient);
                    break;
                case Request.GET_MEMBER_WITH_ID:
                    await GetMemberWithId(requestFromClient);
                    break;
                case Request.GET_FACILITY_WITH_ID:
                    await GetFacilityWithId(requestFromClient);
                    break;
                case Request.GET_ALL_ACCOUNT_TYPES:
                    await GEtAllAccountTypes();
                    break;
                case Request.GET_ROLE_WITH_TYPE:
                    await GetRoleWithType(requestFromClient);
                    break;
                case Request.GET_ACCOUNT_WITH_VIA_ID:
                    await GetAccountWithViaId(requestFromClient);
                    break;
                case Request.ADD_ACCOUNT:
                    await AddAccount(requestFromClient);
                    break;
                case Request.ADD_CREDIT_CARD_TO_ACCOUNT:
                    await AddCreditCardToAccount(requestFromClient);
                    break;
                case Request.CHECK_CREDIT_CARD:
                    string replyForCheckCreditCard = CheckCreditCard(requestFromClient).GetAwaiter().GetResult();
                    SendToStream(replyForCheckCreditCard);
                    break;
                case Request.DEPOSIT_MONEY:
                    string replyForDepositMoney = DepositMoney(requestFromClient).GetAwaiter().GetResult();
                    SendToStream(replyForDepositMoney);
                    break;
                case Request.GET_ACCOUNT_BY_ACCOUNT_ID:
                    await GetAccountByAccountID(requestFromClient);
                    break;
                case Request.UPDATE_ACCOUNT:
                    await updateAccount(requestFromClient);
                    break;
                case Request.CREATE_TRANSACTION:
                    await addTransaction(requestFromClient);
                    break;
                default:
                    Reply badRequestReply = new Reply(Reply.BAD_REQUEST, "Bad Request");
                    String replySerialized = ToJson(badRequestReply);
                    SendToStream(replySerialized);
                    break;
            }

            stream.Close();
        }

        private async Task GetAccountByAccountID(Request request)
        {
            try
            {
                Account account = await RepositoryFactory.GetTransactionRepository()
                    .GetAccountByAccountID(ToObject<int>(request.Payload));
                string payload = ToJson(account);
                Console.WriteLine($"updated account from repository: {payload}");
                Reply reply = new Reply(Reply.SEND_ACCOUNT_BY_ACCOUNT_ID, payload);
                string toSendToClient = ToJson(reply);
                SendToStream(toSendToClient);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                var json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task updateAccount(Request requestFromClient)
        {
            try
            {
                Account updatedAccount = await RepositoryFactory.GetAccountRepository()
                    .UpdateAccount(ToObject<Account>(requestFromClient.Payload));
                string payload = ToJson(updatedAccount);
                Console.WriteLine(payload);
                Reply reply = new Reply(Reply.UPDATED_ACCOUNT, payload);
                string json = ToJson(reply);
                SendToStream(json);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                string json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task addTransaction(Request requestFromClient)
        {
            try
            {
                Transaction transaction = await RepositoryFactory.GetTransactionRepository()
                    .AddTransaction(ToObject<Transaction>(requestFromClient.Payload));
                var payload = ToJson(transaction);
                
                Console.WriteLine($"Transaction added to DB: {payload}");
                Reply reply = new Reply(Reply.CREATED_TRANSACTION, payload);
                string json = ToJson(reply);
                SendToStream(json);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                string json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task AddCreditCardToAccount(Request requestFromClient)
        {
            try
            {
                await RepositoryFactory.GetCreditCardRepository()
                    .AddCreditCardToAccount(ToObject<CreditCard>(requestFromClient.Payload));
                string payload = ToJson("CARD_ADDED");
                Reply reply = new Reply(Reply.VERIFY_CREDIT_CARD_TO_ACCOUNT, payload);
                string toSendToClient = ToJson(reply);
                SendToStream(toSendToClient);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                var json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task getAccountByUsername(Request requestFromClient)
        {
            try
            {
                Account account = await RepositoryFactory.GetAccountRepository()
                    .GetAccountByUsernameAsync(ToObject<string>(requestFromClient.Payload));

                Console.WriteLine($"Account from repo to handler -- password {account.ApplicationPassword}");
                string payloadAccount = ToJson(account);
                Reply replyAc = new Reply(Reply.ACCOUNT_BY_USERNAME, payloadAccount);
                string json = ToJson(replyAc);
                Console.WriteLine(json);
                SendToStream(json);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                var json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task AddAccount(Request requestFromClient)
        {
            try
            {
                await RepositoryFactory.GetAccountRepository()
                    .AddAccountAsync(ToObject<Account>(requestFromClient.Payload));
                Reply reply = new Reply(Reply.ACCOUNT_CREATED, null);

                SendToStream(ToJson(reply));
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                string json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task GetAccountWithViaId(Request requestFromClient)
        {
            try
            {
                Account account = await RepositoryFactory.GetAccountRepository()
                    .GetAccountWithViaId(ToObject<int>(requestFromClient.Payload));

                string payload = ToJson(account);
                Reply reply = new Reply(Reply.SEND_ACCOUNT, payload);

                string json = ToJson(reply);
                SendToStream(json);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                string json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }

        private async Task GetRoleWithType(Request requestFromClient)
        {
            Role role = await RepositoryFactory.GetRoleRepository()
                .GetRoleWithTypeAsync(ToObject<string>(requestFromClient.Payload));

            string roleAsString = ToJson(role);
            Reply roleReply = new Reply(Reply.SEND_ROLE, roleAsString);

            SendToStream(ToJson(roleReply));
        }

        private async Task GEtAllAccountTypes()
        {
            List<string> allAccountTypes =
                await RepositoryFactory.GetRoleRepository().GetAllAccountTypesAsync();

            string allAccountTypesAsString = ToJson(allAccountTypes);
            Reply allAccountTypesReply = new Reply(Reply.SEND_ALL_ACCOUNT_TYPES, allAccountTypesAsString);

            SendToStream(ToJson(allAccountTypesReply));
        }

        private async Task GetFacilityWithId(Request requestFromClient)
        {
            Facility facility = await RepositoryFactory.GetFacilityRepository()
                .GetFacilityWithIdAsync(ToObject<int>(requestFromClient.Payload));

            string facilityAsString = ToJson(facility);
            Reply facilityReply = new Reply(Reply.SEND_FACILITY, facilityAsString);

            SendToStream(ToJson(facilityReply));
        }

        private async Task GetMemberWithId(Request requestFromClient)
        {
            Member member = await RepositoryFactory.GetMemberRepository()
                .GetMemberWithIdAsync(ToObject<int>(requestFromClient.Payload));

            string memberAsString = ToJson(member);
            Reply memberReply = new Reply(Reply.SEND_MEMBER, memberAsString);

            SendToStream(ToJson(memberReply));
        }

        private async Task GetEntityWithId(Request requestFromClient)
        {
            try
            {
                ViaEntity viaEntity = await RepositoryFactory.GetViaEntityRepository()
                    .GetViaEntityWithIdAsync(ToObject<int>(requestFromClient.Payload));

                string payload = ToJson(viaEntity);
                Reply reply = new Reply(Reply.SEND_ENTITY, payload);

                string json = ToJson(reply);
                SendToStream(json);
            }
            catch (Exception e)
            {
                Reply reply = new Reply(Reply.BAD_REQUEST, e.Message);
                string json = ToJson(reply);
                Console.WriteLine($"Reply with exception: {json}");
                SendToStream(json);
            }
        }


        private async Task<string> CheckCreditCard(Request requestFromClient)
        {
            Boolean response = await RepositoryFactory.GetCreditCardRepository()
                .CheckCreditCard(ToObject<int>(requestFromClient.Payload));
            string payload = ToJson(response);
            Reply reply = new Reply(Reply.CHECK_CREDIT_CARD_REPLY, payload);
            Console.WriteLine("Reply built and sent back from check credit card");
            return ToJson(reply);
        }

        private async Task<string> DepositMoney(Request requestFromClient)
        {
            Boolean response = await RepositoryFactory.GetCreditCardRepository()
                .DepositMoney(ToObject<Account>(requestFromClient.Payload));
            string payload = ToJson(response);
            Reply reply = new Reply(Reply.DEPOSIT_MONEY_REPLY, payload);
            Console.WriteLine("Reply built and sent back from deposit money");
            return ToJson(reply);
        }

        private string ReadFromStream()
        {
            byte[] dataFromClient = new byte[2048];
            int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
            return Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
        }

        private void SendToStream(string toSendToClient)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(toSendToClient);
            stream.Write(bytesToSend);
        }

        private T ToObject<T>(String element)
        {
            var deserializeResult = JsonSerializer.Deserialize<T>(element, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return deserializeResult;
        }

        private string ToJson<T>(T objToSerialize)
        {
            string serialized = JsonSerializer.Serialize(objToSerialize, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return serialized;
        }
    }
}