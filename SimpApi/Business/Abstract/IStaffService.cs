using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStaffService
    {
        IResult<StaffModel> GetById(int id);
        IResult<List<StaffModel>> GetAll();
        IResult<StaffAddressModel> GetAddressByEmail(string email);
        IResult<List<StaffAddressModel>> GetAllAddress();
        IResult<StaffModel> Add(StaffModel entity);
        IResult<Staff> Delete(int id);
        IResult<StaffModel> Update(Staff entity);
    }
}
