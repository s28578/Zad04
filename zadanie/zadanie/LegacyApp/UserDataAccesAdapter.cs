using System;

namespace LegacyApp;

public class UserDataAccesAdapter : IUserDataAcces, IDisposable
{
    public UserDataAccesAdapter()
    {
    }
    public void Dispose()
    {
        //Simulating disposing of resources
    }

    public void AddUser(User user)
    {
        UserDataAccess.AddUser(user);
    }
}