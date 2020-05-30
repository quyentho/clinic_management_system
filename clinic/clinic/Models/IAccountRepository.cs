namespace clinic.Models
{
    public interface IAccountRepository
    {
        void Insert(account newAccount);
        void Delete(int id);
        void Update(account account);
        account GetAccount(string username, string password);
    }
}