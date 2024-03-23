namespace Herfitk.API.ChatServices
{
    public class ChatService
    {
        private static readonly Dictionary<string,string>Users= new Dictionary<string,string>();    
        //{key,value} {"Ahmed","sa1233}
        public bool AdduserTolist(string userToadd)
        {
            lock(Users)
            {
                foreach(var user in Users)
                {
                    if (user.Key.ToLower() == userToadd.ToLower())
                    {
                        return false;
                    }
                   
                }
                Users.Add(userToadd, null);
                return true;
            }

        }
        public void Adduserconnectionid(string user,string connectionid)
        {
            lock (Users) 
            {
                if (Users.ContainsKey(user))
                {
                    Users[user] = connectionid;

                }            
            }
        }
        public string GetuserByconnectionid(string connectionid)
        { 
          lock(Users)
            {
                return Users.Where(x=>x.Value == connectionid).Select(x=>x.Key).FirstOrDefault();
            }

        }
        public string GetConnectionidByuser(string user)
        {
            lock (Users)
            {
                return Users.Where(x => x.Key == user).Select(x => x.Value).FirstOrDefault();
            }

        }
        public void RemoveUserFromlist(string user)
        {
            if (Users.ContainsKey(user))
            {
              Users.Remove(user);
            }
        }
        public string[] GetOnlineUser()
        {
            lock (Users)
            {
                return Users.OrderBy(x => x.Key).Select(x => x.Key).ToArray();
            }
        }
    }
}
