using AutoMapper;
using Business.Abstract;
using Business.ValidationRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;
        IMapper _mapper;
        public StaffManager(IStaffDal staffDal, IMapper mapper)
        {
            _staffDal = staffDal;
            _mapper = mapper;
        }


        public IResult<StaffModel> Add(StaffModel entity)
        {
            var result=Valid(entity);
            if (result==null)
            {
                var mapped = _mapper.Map<Staff>(entity);
                _staffDal.Add(mapped);
                return new Result<StaffModel>("ekleme başarılı.");
            }
            return new Result<StaffModel>(result,false);

        }

        public IResult<Staff> Delete(int id)
        {
            _staffDal.Delete(id);
            return new Result<Staff>("silme işlemi başarılı.");
        }

        public IResult<List<StaffModel>> GetAll()
        {
            var mapped = _mapper.Map<List<StaffModel>>(_staffDal.GetAll());
            return new Result<List<StaffModel>>(mapped);
        }

        public IResult<StaffModel> GetById(int id)
        {
            var mapped = _mapper.Map<StaffModel>(_staffDal.Get(p => p.Id == id));
            return new Result<StaffModel>(mapped);
        }

        public IResult<StaffModel> Update(Staff entity)
        {
            var mapped = _mapper.Map<StaffModel>(entity);
            var result = Valid(mapped);
            if (result == null)
            {
                _staffDal.Update(entity);
                return new Result<StaffModel>("güncelleme başarılı.");
            }
            return new Result<StaffModel>(result, false);
        }
        public IResult<StaffAddressModel> GetAddressByEmail(string email)
        {
            var mapped = _mapper.Map<StaffAddressModel>(_staffDal.Get(p => p.Email == email));
            return new Result<StaffAddressModel>(mapped);
        }
        public IResult<List<StaffAddressModel>> GetAllAddress()
        {
            var mapped = _mapper.Map<List<StaffAddressModel>>(_staffDal.GetAll());
            return new Result<List<StaffAddressModel>>(mapped);
        }
        public string Valid(StaffModel staffModel)
        {
            StaffModelValidator validator = new StaffModelValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(staffModel);
            if (!result.IsValid)
            {
                return result.Errors[0].ErrorMessage;
            }
            return null;

        }
    }
}
