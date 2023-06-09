namespace DevFreela.Application.Queries.GetUser
{
    public class UserDetailsOutputModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public UserDetailsOutputModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
