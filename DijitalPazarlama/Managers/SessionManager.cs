using DijitalPazarlama.Model;

namespace DijitalPazarlama.Managers
{
    public static class SessionManager
    {
        public static AppUser ActiveUser { get; set; } = new AppUser();

        private static int _currentId;

        public static int CurrentUserId
        {
            get
            {
                return _currentId;
            }
        }

        private static string _fullname;

        public static string Fullname
        {
            get
            {
                return _fullname;
            }
        }

        private static Role _role;

        public static Role CurrentUserRole
        {
            get
            {
                return _role;
            }
        }

        public static void SetInfo()
        {
            _currentId = ActiveUser.Id;
            _fullname = $"{ActiveUser.Name} {ActiveUser.Lastname}";
            _role = ActiveUser.Role;
        }
    }
}
