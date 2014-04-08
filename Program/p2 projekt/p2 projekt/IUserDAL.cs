using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt
{
    public interface IUserDAL
    {
        void Create(User user);
        void Delete(User user);
        bool Update(User user);
        bool Read(User user);
    }
}
