namespace clinic.Models
{
    public interface IAccountRepository
    {
        void Insert(account newAccount);
        void Delete(int staffId);
        void Update(account account);
        account GetAccount(string username, string password);
        bool CheckExistsAcount(string phoneNumber);
        account GetAccountByStaffId(int staffId);
    }
}