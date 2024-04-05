using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;
        private IUserDataAcces _userDataAcces;

        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _userDataAcces = new UserDataAccesAdapter();
        }
        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService, IUserDataAcces userDataAcces)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
            _userDataAcces = userDataAcces;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (UserValidation.CheckIfNamesNull(firstName, lastName) || !UserValidation.CheckIfEmailCorrect(email) ||
                !UserValidation.CheckIfAdult(dateOfBirth))
            {
                return false;
            }
            
            var client = _clientRepository.GetById(clientId);
            var user = User.CreateUser(client, dateOfBirth, email, firstName, lastName);
            
            _userCreditService.SetUsersCreditLimit(user);
            
            if (!UserValidation.CheckIfEnoughCreditLimit(user, 500))
            {
                return false;
            }
            
            _userDataAcces.AddUser(user);
            
            return true;
        }
    }
}
