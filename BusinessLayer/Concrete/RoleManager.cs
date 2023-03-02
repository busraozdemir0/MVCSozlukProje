using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Role GetByID(int id)
        {
            return _roleDal.Get(x=>x.RoleID==id);
        }

        public List<Role> GetList()
        {
            return _roleDal.List();
        }

        public void RoleAdd(Role role)
        {
            _roleDal.Insert(role);
        }

        public void RoleDelete(Role role)
        {
            _roleDal.Delete(role);
        }

        public void RoleUpdate(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
